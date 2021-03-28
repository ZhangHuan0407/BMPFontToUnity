using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BMPFontToUnity
{
    public class BMPFontInfo
    {
        /* const */

        /* field */
        public static readonly Regex FaceRegex = new Regex("(?<=face=\")\\w+(?=\")");
        public string Face { get; set; }

        public static readonly Regex SizeRegex = new Regex("(?<=size=)[0-9]+");
        private int m_Size;
        public int Size { get => m_Size; }

        public static readonly Regex BoldRegex = new Regex("(?<=bold=)[01]");
        private bool m_Bold;
        public bool Bold { get => m_Bold; }

        public static readonly Regex ItalicRegex = new Regex("(?<=italic=)[01]");
        private bool m_Italic;
        public bool Italic { get => m_Italic; }

        public static readonly Regex CharSetRegex = new Regex("(?<=charset=\")\\w*(?=\")");
        public string CharSet { get; set; }

        public static readonly Regex UnicodeRegex = new Regex("(?<=unicode=)[01]");
        private bool m_Unicode;
        public bool Unicode { get => m_Unicode; }

        private int m_StretchH;
        public int StretchH { get => m_StretchH; }

        public static readonly Regex SmoothRegex = new Regex("(?<=smooth=)[01]");
        private bool m_Smooth;
        public bool Smooth { get => m_Smooth; }

        private bool m_AA;
        public bool AA { get => m_AA; }

        private VectorInt4 m_Padding;
        public VectorInt4 Padding { get => m_Padding; }

        private VectorInt2 m_Spacing;
        public VectorInt2 Spacing { get => m_Spacing; }

        /// <summary>
        /// 存在错误，无法使用
        /// </summary>
        public bool HaveError { get; private set; }

        /* inter */

        /* ctor */
        public BMPFontInfo()
        {
            HaveError = true;
        }

        internal void SetStringValue(string line)
        {
            HaveError = true;
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentException($"“{nameof(line)}”不能为 null 或空白。", nameof(line));

            Match faceMatch = FaceRegex.Match(line);
            if (faceMatch.Success)
                Face = faceMatch.Value;
            else
            {
                MessageBox.Show("Info Face Error");
                return;
            }

            Match sizeMatch = SizeRegex.Match(line);
            if (!sizeMatch.Success
                || !int.TryParse(sizeMatch.Value, out m_Size))
            {
                MessageBox.Show("Info Size Error");
                return;
            }

            Match boldMatch = BoldRegex.Match(line);
            if (!boldMatch.Success
                || !int.TryParse(boldMatch.Value, out int boldValue))
            {
                MessageBox.Show("Info Bold Error");
                return;
            }
            else
                m_Bold = boldValue > 0;

            Match italicMatch = ItalicRegex.Match(line);
            if (!italicMatch.Success
                || !int.TryParse(italicMatch.Value, out int italicValue))
            {
                MessageBox.Show("Info Italic Error");
                return;
            }
            else
                m_Italic = italicValue > 0;

            Match charSetMatch = FaceRegex.Match(line);
            if (charSetMatch.Success)
                CharSet = charSetMatch.Value;
            else
            {
                MessageBox.Show("Info CharSet Error");
                return;
            }

            Match unicodeMatch = UnicodeRegex.Match(line);
            if (!unicodeMatch.Success
                || !int.TryParse(unicodeMatch.Value, out int unicodeValue))
            {
                MessageBox.Show("Info Unicode Error");
                return;
            }
            else
                m_Unicode = unicodeValue > 0;

            // stretchH

            Match smoothMatch = SmoothRegex.Match(line);
            if (!smoothMatch.Success
                || !int.TryParse(smoothMatch.Value, out int smoothValue))
            {
                MessageBox.Show("Info Smooth Error");
                return;
            }
            else
                m_Smooth = smoothValue > 0;

            // aa 

            // padding

            // spacing

            HaveError = false;
        }

        /* func */

    }
}