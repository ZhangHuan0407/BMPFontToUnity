
namespace BMPFontToUnity
{
    partial class CountdownForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TimeSpanText = new System.Windows.Forms.TextBox();
            this.SetTimeSpanButton = new System.Windows.Forms.Button();
            this.TimerPicktureBox = new System.Windows.Forms.PictureBox();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TimerPicktureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TimeSpanText
            // 
            this.TimeSpanText.Location = new System.Drawing.Point(12, 12);
            this.TimeSpanText.Name = "TimeSpanText";
            this.TimeSpanText.Size = new System.Drawing.Size(196, 30);
            this.TimeSpanText.TabIndex = 0;
            this.TimeSpanText.Text = "24:00:00";
            // 
            // SetTimeSpanButton
            // 
            this.SetTimeSpanButton.Location = new System.Drawing.Point(239, 6);
            this.SetTimeSpanButton.Name = "SetTimeSpanButton";
            this.SetTimeSpanButton.Size = new System.Drawing.Size(103, 39);
            this.SetTimeSpanButton.TabIndex = 1;
            this.SetTimeSpanButton.Text = "设置时间";
            this.SetTimeSpanButton.UseVisualStyleBackColor = true;
            this.SetTimeSpanButton.Click += new System.EventHandler(this.SetTimeSpanButton_Click);
            // 
            // TimerPicktureBox
            // 
            this.TimerPicktureBox.Location = new System.Drawing.Point(12, 68);
            this.TimerPicktureBox.Name = "TimerPicktureBox";
            this.TimerPicktureBox.Size = new System.Drawing.Size(257, 101);
            this.TimerPicktureBox.TabIndex = 2;
            this.TimerPicktureBox.TabStop = false;
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 1000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // CountdownForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 247);
            this.Controls.Add(this.TimerPicktureBox);
            this.Controls.Add(this.SetTimeSpanButton);
            this.Controls.Add(this.TimeSpanText);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CountdownForm";
            this.Text = "ClockForm";
            this.Load += new System.EventHandler(this.ClockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TimerPicktureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TimeSpanText;
        private System.Windows.Forms.Button SetTimeSpanButton;
        private System.Windows.Forms.PictureBox TimerPicktureBox;
        private System.Windows.Forms.Timer RefreshTimer;
    }
}