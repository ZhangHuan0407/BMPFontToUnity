using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPFontToUnity
{
    public partial class CountdownForm : Form
    {
        /* field */
        public TimeSpan TimeSpan;
        public BMPFont BMPFont;

        /* ctor */
        public CountdownForm()
        {
            InitializeComponent();
        }

        private void ClockForm_Load(object sender, EventArgs e)
        {
            if (BMPFont.HaveError || !BMPFont.HaveSetValue)
                Close();
        }

        private void SetTimeSpanButton_Click(object sender, EventArgs e)
        {
            if (!TimeSpan.TryParse(TimeSpanText.Text, out TimeSpan))
                RefreshTimer.Enabled = false;

            TimerPicktureBox.Size = new Size(BMPFont.CharMaxWidth * 9, BMPFont.Common.LineHelght);
            RefreshTimer.Enabled = true;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan -= new TimeSpan(0, 0, 1);
            if (TimeSpan.TotalSeconds < 1)
                RefreshTimer.Enabled = false;
            if (BMPFont.RedererLine($"{TimeSpan.Hours}:{TimeSpan.Minutes}:{TimeSpan.Seconds}") is Bitmap bitmap)
            {
                TimerPicktureBox.Image?.Dispose();
                TimerPicktureBox.Image = bitmap;
            }
        }
    }
}
