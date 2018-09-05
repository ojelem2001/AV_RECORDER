namespace AV_RECORDER
{
    partial class AudioVideoForm
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
            this.statusBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbOutputDir = new System.Windows.Forms.TextBox();
            this.lbOutFile = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.chkMic = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(12, 96);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(417, 260);
            this.statusBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Полученный файл:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Директория для сохранения:";
            // 
            // lbOutputDir
            // 
            this.lbOutputDir.Location = new System.Drawing.Point(180, 12);
            this.lbOutputDir.Name = "lbOutputDir";
            this.lbOutputDir.Size = new System.Drawing.Size(249, 20);
            this.lbOutputDir.TabIndex = 12;
            this.lbOutputDir.Text = "D:\\Audio\\";
            // 
            // lbOutFile
            // 
            this.lbOutFile.Enabled = false;
            this.lbOutFile.Location = new System.Drawing.Point(180, 40);
            this.lbOutFile.Name = "lbOutFile";
            this.lbOutFile.Size = new System.Drawing.Size(249, 20);
            this.lbOutFile.TabIndex = 11;
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.ForestGreen;
            this.button_start.Location = new System.Drawing.Point(435, 9);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(106, 53);
            this.button_start.TabIndex = 10;
            this.button_start.Text = "Rec";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // chkMic
            // 
            this.chkMic.AutoSize = true;
            this.chkMic.Checked = true;
            this.chkMic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMic.Location = new System.Drawing.Point(15, 73);
            this.chkMic.Name = "chkMic";
            this.chkMic.Size = new System.Drawing.Size(142, 17);
            this.chkMic.TabIndex = 15;
            this.chkMic.Text = "+ Запись с микрофона";
            this.chkMic.UseVisualStyleBackColor = true;
            // 
            // AudioVideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 369);
            this.Controls.Add(this.chkMic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbOutputDir);
            this.Controls.Add(this.lbOutFile);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.statusBox);
            this.Name = "AudioVideoForm";
            this.Text = "Звукозаписывающая программа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lbOutputDir;
        private System.Windows.Forms.TextBox lbOutFile;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.CheckBox chkMic;
    }
}

