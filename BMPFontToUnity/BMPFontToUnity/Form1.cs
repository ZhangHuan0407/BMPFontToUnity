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
    public partial class Form1 : Form
    {
        /* field */
        BMPFont BMPFont;

        /* ctor */
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BMPFont = new BMPFont();
            BMPFont.LoadFontFromFile("FL_fnt01.fnt");
            //string json = JsonConvert.SerializeObject(font, Formatting.Indented);
            //File.WriteAllText("font.json", json);
            StringBuilder warning = new StringBuilder();
            if (BMPFontRenderer.RendererLine(BMPFont, textBox1.Text, in warning) is Bitmap bitmap)
            {
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = bitmap;
            }
            else
                MessageBox.Show(warning.ToString());
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
    }
}
