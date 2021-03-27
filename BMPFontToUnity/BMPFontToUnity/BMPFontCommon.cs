using System;
using System.Collections.Generic;

namespace BMPFontToUnity
{
    public class BMPFontCommon
    {
        /* const */

        /* field */
        private int m_LineHelght;
        public int LineHelght { get => m_LineHelght; }

        private int m_Base;
        public int Base { get => m_Base; }

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
