using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BMPFontToUnity
{
    public class BMPFont : IDisposable
    {
        /* const */
        public static readonly Regex CharsCountRegex = new Regex("(?<=count=)[0-9]{1,}");

        /* field */
        public BMPFontInfo Info { get; private set; }
        public BMPFontCommon Common { get; private set; }
        public List<BMPFontPage> Pages { get; }
        public Dictionary<char, BMPFontChar> Chars { get; }
        public bool HaveSetValue { get; private set; }
        public bool HaveError { get; private set; }

        /* inter */

        /* ctor */
        public BMPFont()
        {
            Info = new BMPFontInfo();
            Common = new BMPFontCommon();
            Pages = new List<BMPFontPage>();
            Chars = new Dictionary<char, BMPFontChar>();
            HaveSetValue = false;
            HaveError = false;
        }

        /* func */
        public void LoadFontFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("路径不能为空白");
                return;
            }
            else if (!File.Exists(filePath))
            {
                MessageBox.Show($"没有找到文件。\n{filePath}");
                return;
            }

            LoadFontFromText(File.ReadAllLines(filePath));
        }
        public void LoadFontFromText(string[] lines)
        {
            if (lines is null)
                throw new ArgumentNullException(nameof(lines));
            if (HaveSetValue)
                throw new ArgumentException("Use new instance!");
            else
                HaveSetValue = true;

            HaveError = true;
            int charCounts = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                int spaceIndex = line.IndexOf(" ");
                if (spaceIndex == -1)
                    continue;
                string label = line.Substring(0, spaceIndex);
                switch (label)
                {
                    case "char":
                        BMPFontChar oneChar = new BMPFontChar();
                        oneChar.SetStringValue(line);
                        char @char = (char)oneChar.ID;
                        if (Chars.ContainsKey(@char))
                            MessageBox.Show($"有相同的 ID 值。\nID={oneChar.ID}, Char={@char}");
                        else
                            Chars.Add(@char, oneChar);
                        break;
                    case "info":
                        Info.SetStringValue(line);
                        break;
                    case "common":
                        Common.SetStringValue(line);
                        break;
                    case "page":
                        BMPFontPage page = new BMPFontPage();
                        page.SetStringValue(line);
                        Pages.Add(page);
                        break;
                    case "chars":
                        Match match = CharsCountRegex.Match(line);
                        if (!match.Success
                            || !int.TryParse(match.Value, out charCounts))
                            MessageBox.Show($"这一行可能有问题。{line}");
                        break;
                    default:
                        // 意外的字段
                        break;
                }
            }

            if (charCounts != Chars.Count)
                MessageBox.Show($"字符的数量与声明的数量不一致。");
            HaveError = false;
            HaveError = Info.HaveError || Common.HaveError;
            foreach (BMPFontPage bMPFontPage in Pages)
                HaveError |= bMPFontPage.HaveError;
            foreach (BMPFontChar bMPFontChar in Chars.Values)
                HaveError |= bMPFontChar.HaveError;
            if (HaveError)
            {
                MessageBox.Show("读取字体配置时出现错误，停止读入");
                return;
            }

            Pages.Sort();
            foreach (BMPFontPage page in Pages)
                page.LoadImage();
            foreach (BMPFontChar bmpFontChar in Chars.Values)
                bmpFontChar.LoadSprite(this);
            HaveError = false;
            HaveError = Info.HaveError || Common.HaveError;
            foreach (BMPFontPage bMPFontPage in Pages)
                HaveError |= bMPFontPage.HaveError;
            foreach (BMPFontChar bMPFontChar in Chars.Values)
                HaveError |= bMPFontChar.HaveError;
            if (HaveError)
            {
                MessageBox.Show("加载字体配置时出现错误，停止读入");
                return;
            }
        }

        /* IDisposable */
        public void Dispose()
        {
            if (Info != null)
                Info = null;
            if (Common != null)
                Common = null;
            foreach (BMPFontPage bMPFontPage in Pages)
            {
                bMPFontPage.PageImage?.Dispose();
                bMPFontPage.PageImage = null;
            }
            foreach (BMPFontChar bMPFontChar in Chars.Values)
                bMPFontChar.Colors = null;
        }
    }
}
