using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BMPFontToUnity
{
    public class BMPFontChar
    {
        /* const */

        /* field */
        public static readonly Regex CharIDRegex = new Regex("(?<=id=)[0-9]+");
        private int m_ID;
        public int ID { get => m_ID; }

        public static readonly Regex PositionRegex = new Regex("(?<=x=)[0-9]+ y=[0-9]+");
        private VectorInt2 m_Position;
        public VectorInt2 Position { get => m_Position; }

        public static readonly Regex SizeRegex = new Regex("(?<=width=)[0-9]+ height=[0-9]+");
        private VectorInt2 m_Size;
        public VectorInt2 Size { get => m_Size; }

        public static readonly Regex OffsetRegex = new Regex("(?<=xoffset=)[0-9]+ yoffset=[0-9]+");
        private VectorInt2 m_Offset;
        public VectorInt2 Offset { get => m_Offset; }

        private VectorInt2 m_Advance;
        public VectorInt2 Advance { get => m_Advance; }

        public static readonly Regex PageIndexRegex = new Regex("(?<=page=)[0-9]+");
        private int m_PageIndex;
        public int PageIndex { get => m_PageIndex; }

        private bool m_Chnl;
        public bool Chnl { get => m_Chnl; }

        public string Letter { get; set; }

        internal Color[,] Colors;

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
            HaveError = true;
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentException($"“{nameof(line)}”不能为 null 或空白。", nameof(line));

            Match charIDMatch = CharIDRegex.Match(line);
            if (!charIDMatch.Success
                || !int.TryParse(charIDMatch.Value, out m_ID))
            {
                MessageBox.Show("Page ID Error");
                return;
            }



            HaveError = false;
        }

        internal void LoadSprite(BMPFont bMPFont)
        {
            HaveError = true;
            throw new NotImplementedException();

            HaveError = false;
        }
    }
}