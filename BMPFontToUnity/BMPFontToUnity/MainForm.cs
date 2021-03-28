using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BMPFontToUnity
{
    public partial class MainForm : Form
    {
        /* field */
        BMPFont BMPFont;

        /* ctor */
        public MainForm()
        {
            InitializeComponent();
        }


        private void CountdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!BMPFont.HaveSetValue || BMPFont.HaveError)
                return;

            CountdownForm countdownForm = new CountdownForm()
            {
                BMPFont = BMPFont,
            };
            countdownForm.ShowDialog();
            countdownForm.Close();
            countdownForm.Dispose();
        }

        private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            BMPFont?.Dispose();
            BMPFont = new BMPFont();
            BMPFont.LoadFontFromFile(openFileDialog.FileName);
            bmpFontDataText.Text = JsonConvert.SerializeObject(BMPFont, Formatting.Indented);
        }

        private void RendererTextButton_Click(object sender, EventArgs e)
        {
            if (!BMPFont.HaveSetValue || BMPFont.HaveError)
            {
                MessageBox.Show("没有可用字体");
                return;
            }

            StringBuilder warning = new StringBuilder();
            if (BMPFontRenderer.RendererLines(BMPFont, uerInputText.Lines, in warning) is Bitmap bitmap)
            {
                pictureBox.Image?.Dispose();
                pictureBox.Image = bitmap;
            }
            if (warning.Length > 0)
                MessageBox.Show(warning.ToString());
        }

        private void BmpFontDataText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
