using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BMPFontToUnity
{
    public class BMPFontInfo
    {
        /* const */

        /* field */
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

        public string CharSet { get; set; }

        private bool m_Unicode;
        public bool Unicode { get => m_Unicode; }

        private int m_StretchH;
        public int StretchH { get => m_StretchH; }

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
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentException($"“{nameof(line)}”不能为 null 或空白。", nameof(line));

            HaveError = false;



        }

        /* func */

    }
}