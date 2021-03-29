using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;

namespace BMPFontToUnity
{
    public class BMPFontRenderer
    {
        /* const */
        public const int MaxCharPreLine = 20;

        /* func */
        public static Bitmap RendererLine(BMPFont bMPFont, string str, in StringBuilder warning, Bitmap bitmap = null, int vernierY = 0)
        {
            if (warning is null)
                throw new ArgumentNullException(nameof(warning));
            if (!bMPFont.HaveSetValue || bMPFont.HaveError)
            {
                warning.AppendLine("使用的字体存在问题，不可渲染");
                return null;
            }
            else if (str is null)
            {
                warning.AppendLine("字符串为空，不可渲染");
                return null;
            }
            else if (str.Contains("\n"))
            {
                warning.AppendLine("存在换行符，不可渲染");
                return null;
            }

            // 计算渲染参数，并制定渲染操作
            int vernierX = 0;
            int lastCharExtraWidth = 0;
            Queue<Action<Bitmap>> drawCall = new Queue<Action<Bitmap>>();
            foreach (char @char in str)
            {
                BMPFontChar targetChar = null;
                if (!bMPFont.Chars.TryGetValue(@char, out targetChar)
                    && !bMPFont.Chars.TryGetValue(' ', out targetChar))
                {
                    warning.AppendLine($"Not Found Char : {@char}");
                    continue;
                }

                drawCall.Enqueue(targetChar.CreateDrawCall(vernierX, vernierY));
                vernierX += targetChar.XAdvance;
                lastCharExtraWidth = targetChar.Size.X - targetChar.XAdvance + targetChar.Offset.X;
            }
            if (lastCharExtraWidth > 0)
                vernierX += lastCharExtraWidth;

            // 执行渲染
            bitmap = bitmap ?? new Bitmap(
                vernierX, 
                bMPFont.Common.LineHelght + bMPFont.ExtraLineHeight);
            while (drawCall.Count > 0)
                drawCall.Dequeue()(bitmap);
            return bitmap;
        }
        public static Bitmap RendererLines(BMPFont bMPFont, string[] lines, in StringBuilder warning)
        {
            if (warning is null)
                throw new ArgumentNullException(nameof(warning));
            if (!bMPFont.HaveSetValue || bMPFont.HaveError)
            {
                warning.AppendLine("使用的字体存在问题，不可渲染");
                return null;
            }

            List<string> buffer = new List<string>();
            foreach (string rawLine in lines)
            {
                string lineBuffer = rawLine;
                while (lineBuffer.Length > MaxCharPreLine)
                {
                    buffer.Add(lineBuffer.Substring(0, MaxCharPreLine));
                    lineBuffer = lineBuffer.Substring(MaxCharPreLine);
                }
                buffer.Add(lineBuffer);
            }
            int maxCharCount = Enumerable.Max(buffer, (string str) => str.Length);
            Bitmap bitmap = new Bitmap(
                (maxCharCount + 1) * bMPFont.CharMaxWidth,
                buffer.Count * bMPFont.Common.LineHelght + bMPFont.ExtraLineHeight);

            for (int lineIndex = 0; lineIndex < buffer.Count; lineIndex++)
            {
                RendererLine(
                    bMPFont, buffer[lineIndex], warning, 
                    bitmap, lineIndex * bMPFont.Common.LineHelght);
            }
            return bitmap;
        }
        public static Color ColorPlusColor(Color back, Color font)
        {
            if (font.A == 0)
                return back;

            float backAlpha = back.A / 255f;
            float backRed = back.R / 255f;
            float backGreen = back.G / 255f;
            float backBlue = back.B / 255f;

            float fontAlpha = font.A / 255f;
            float fontRed = font.R / 255f;
            float fontGreen = font.G / 255f;
            float fontBlue = font.B / 255f;

            float resultAlpha = backAlpha + fontAlpha - backAlpha * fontAlpha;
            float resultRed = (fontRed * fontAlpha * (1 - backAlpha) + backRed * backAlpha) /  resultAlpha;
            float resultGreen = (fontGreen * fontAlpha * (1 - backAlpha) + backGreen * backAlpha) / resultAlpha;
            float resultBlue = (fontBlue * fontAlpha * (1 - backAlpha) + backBlue * backAlpha) / resultAlpha;
            return Color.FromArgb(
                (byte)(resultAlpha * 255f), 
                (byte)(resultRed * 255f), 
                (byte)(resultGreen * 255f),
                (byte)(resultBlue * 255f));
        }
    }
}