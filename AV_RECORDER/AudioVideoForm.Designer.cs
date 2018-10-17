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
            this.lbTimeCounter = new System.Windows.Forms.Label();
            this.chkRemoveWav = new System.Windows.Forms.CheckBox();
            this.lbOutputFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(12, 194);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(417, 239);
            this.statusBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Полученный файл:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
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
            this.lbOutFile.Location = new System.Drawing.Point(180, 67);
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
            this.chkMic.Location = new System.Drawing.Point(15, 122);
            this.chkMic.Name = "chkMic";
            this.chkMic.Size = new System.Drawing.Size(142, 17);
            this.chkMic.TabIndex = 15;
            this.chkMic.Text = "+ Запись с микрофона";
            this.chkMic.UseVisualStyleBackColor = true;
            this.chkMic.CheckedChanged += new System.EventHandler(this.chkMic_CheckedChanged);
            // 
            // lbTimeCounter
            // 
            this.lbTimeCounter.AutoSize = true;
            this.lbTimeCounter.Location = new System.Drawing.Point(177, 102);
            this.lbTimeCounter.Name = "lbTimeCounter";
            this.lbTimeCounter.Size = new System.Drawing.Size(0, 13);
            this.lbTimeCounter.TabIndex = 16;
            // 
            // chkRemoveWav
            // 
            this.chkRemoveWav.AutoSize = true;
            this.chkRemoveWav.Checked = true;
            this.chkRemoveWav.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoveWav.Location = new System.Drawing.Point(15, 143);
            this.chkRemoveWav.Name = "chkRemoveWav";
            this.chkRemoveWav.Size = new System.Drawing.Size(173, 17);
            this.chkRemoveWav.TabIndex = 17;
            this.chkRemoveWav.Text = "+ Удалить wav после записи";
            this.chkRemoveWav.UseVisualStyleBackColor = true;
            this.chkRemoveWav.CheckedChanged += new System.EventHandler(this.chkRemoveWav_CheckedChanged);
            // 
            // lbOutputFileName
            // 
            this.lbOutputFileName.Location = new System.Drawing.Point(180, 38);
            this.lbOutputFileName.Name = "lbOutputFileName";
            this.lbOutputFileName.Size = new System.Drawing.Size(249, 20);
            this.lbOutputFileName.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Метка файла:";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(353, 165);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 20;
            this.btnClearAll.Text = "ClearAll";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // AudioVideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 450);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbOutputFileName);
            this.Controls.Add(this.chkRemoveWav);
            this.Controls.Add(this.lbTimeCounter);
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
        private System.Windows.Forms.Label lbTimeCounter;
        private System.Windows.Forms.CheckBox chkRemoveWav;
        private System.Windows.Forms.TextBox lbOutputFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClearAll;
    }
}

