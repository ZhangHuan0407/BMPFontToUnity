using System;
using System.Collections.Generic;

namespace BMPFontToUnity
{
    public class BMPFontChar
    {
        /* const */

        /* field */
        private int m_ID;
        public int ID { get => m_ID; }

        private VectorInt2 m_Position;
        public VectorInt2 Position { get => m_Position; }

        private VectorInt2 m_Size;
        public VectorInt2 Size { get => m_Size; }

        private VectorInt2 m_Offset;
        public VectorInt2 Offset { get => m_Offset; }

        private VectorInt2 m_Advance;
        public VectorInt2 Advance { get => m_Advance; }

        private int m_PageIndex;
        public int PageIndex { get => m_PageIndex; }

        private bool m_Chnl;
        public bool Chnl { get => m_Chnl; }

        public string Letter { get; set; }

        /// <summary>
        /// 存在错误，无法使用
        /// </summary>
        public bool HaveError { get; private set; }

        /* inter */

        /* ctor */
        public BMPFontChar()
        {
            HaveError = true;
        }

        /* func */
        public override int GetHashCode() => ID;

        internal void SetStringValue(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentException($"“{nameof(line)}”不能为 null 或空白。", nameof(line));

            HaveError = false;


        }

        internal void LoadSprite(BMPFont bMPFont)
        {
            throw new NotImplementedException();
        }
    }
}