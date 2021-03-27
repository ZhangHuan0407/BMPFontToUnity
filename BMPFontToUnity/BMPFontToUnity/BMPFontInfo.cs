using System;
using System.Collections.Generic;

namespace BMPFontToUnity
{
    public class BMPFontInfo
    {
        /* const */

        /* field */
        public string Face { get; set; }

        private int m_Size;
        public int Size { get => m_Size; }

        private bool m_Bold;
        public bool Bold { get => m_Bold; }

        private bool m_Italic;
        public bool Italic { get; set; }

        public string CharSet { get; set; }

        private bool m_Unicode;
        public bool Unicode { get; set; }

        private int m_StretchH;
        public int StretchH { get => m_StretchH; }

        private bool m_Smooth;
        public bool Smooth { get; set; }

        private bool m_AA;
        public bool AA { get; set; }

        private VectorInt4 m_Padding;
        public VectorInt4 Padding { get => m_Padding; }

        private VectorInt4 m_Spacing;
        public VectorInt4 Spacing { get; set; }

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