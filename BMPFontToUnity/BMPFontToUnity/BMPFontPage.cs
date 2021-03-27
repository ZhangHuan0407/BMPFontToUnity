using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BMPFontToUnity
{
    public class BMPFontPage : IComparable<BMPFontPage>
    {
        /* const */
        public static readonly Regex PageIDRegex = new Regex("(?<=id=)[0-9]{1,}");
        public static readonly Regex FilePathRegex = new Regex("(?<=file=\").\\w+(?=\")");

        /* field */
        private int m_ID;
        public int ID { get => m_ID; }

        public string FilePath { get; set; }

        /// <summary>
        /// 存在错误，无法使用
        /// </summary>
        public bool HaveError { get; private set; }

        /* inter */

        /* ctor */
        public BMPFontPage()
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
            Match pageIDMatch = PageIDRegex.Match(line);
            if (!pageIDMatch.Success
                || !int.TryParse(pageIDMatch.Value, out m_ID))
            {
                HaveError = true;
                MessageBox.Show("Page ID Error");
                return;
            }

            Match filePathMatch = FilePathRegex.Match(line);
            if (filePathMatch.Success)
                FilePath = filePathMatch.Value;
            else
            {
                HaveError = true;
                MessageBox.Show("Page File Error");
                return;
            }
        }

        /* IComparable */
        public int CompareTo(BMPFontPage other)
        {
            if (other is null)
                return 1;
            else
                return other.ID.CompareTo(ID);
        }

        internal void LoadImage()
        {
            if (File.Exists(FilePath))
            {
                MessageBox.Show("没有找到图片文件");
                return;
            }
        }
    }
}
