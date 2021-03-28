
namespace BMPFontToUnity
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uerInputText = new System.Windows.Forms.TextBox();
            this.rendererTextButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.bmpFontDataText = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1243, 28);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem});
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.fontToolStripMenuItem.Text = "字体";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.loadFileToolStripMenuItem.Text = "读自文件";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.LoadFileToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countdownToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.testToolStripMenuItem.Text = "测试";
            // 
            // countdownToolStripMenuItem
            // 
            this.countdownToolStripMenuItem.Name = "countdownToolStripMenuItem";
            this.countdownToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.countdownToolStripMenuItem.Text = "倒计时";
            this.countdownToolStripMenuItem.Click += new System.EventHandler(this.CountdownToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "读取字体文件";
            this.openFileDialog.Filter = "字体配置文件|*.fnt";
            // 
            // uerInputText
            // 
            this.uerInputText.Location = new System.Drawing.Point(341, 41);
            this.uerInputText.Multiline = true;
            this.uerInputText.Name = "uerInputText";
            this.uerInputText.Size = new System.Drawing.Size(365, 361);
            this.uerInputText.TabIndex = 4;
            // 
            // rendererTextButton
            // 
            this.rendererTextButton.Location = new System.Drawing.Point(341, 433);
            this.rendererTextButton.Name = "rendererTextButton";
            this.rendererTextButton.Size = new System.Drawing.Size(128, 36);
            this.rendererTextButton.TabIndex = 5;
            this.rendererTextButton.Text = "渲染!";
            this.rendererTextButton.UseVisualStyleBackColor = true;
            this.rendererTextButton.Click += new System.EventHandler(this.RendererTextButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(723, 41);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(503, 428);
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            // 
            // bmpFontDataText
            // 
            this.bmpFontDataText.Location = new System.Drawing.Point(12, 41);
            this.bmpFontDataText.Multiline = true;
            this.bmpFontDataText.Name = "bmpFontDataText";
            this.bmpFontDataText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bmpFontDataText.Size = new System.Drawing.Size(310, 428);
            this.bmpFontDataText.TabIndex = 7;
            this.bmpFontDataText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BmpFontDataText_KeyPress);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 488);
            this.Controls.Add(this.bmpFontDataText);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.rendererTextButton);
            this.Controls.Add(this.uerInputText);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox uerInputText;
        private System.Windows.Forms.Button rendererTextButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox bmpFontDataText;
    }
}

