using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BMPFontToUnity
{
    public class BMPFontCommon
    {
        /* const */

        /* field */
        public static readonly Regex LineHelghtRegex = new Regex("(?<=lineHeight=)[0-9]+");
        private int m_LineHelght;
        public int LineHelght { get => m_LineHelght; }

        public static readonly Regex BaseRegex = new Regex("(?<=base=)[0-9]+");
        private int m_Base;
        public int Base { get => m_Base; }

        public static readonly Regex ScaleRegex = new Regex("(?<=scaleW=)[0-9]+ scaleH=[0-9]+");
        private VectorInt2 m_Scale;
        public VectorInt2 Scale { get => m_Scale; }

        //...

        /// <summary>
        /// 存在错误，无法使用
        /// </summary>
        public bool HaveError { get; private set; }

        /* inter */

        /* ctor */
        public BMPFontCommon()
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
