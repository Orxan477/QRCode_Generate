﻿namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnGenerate = new Button();
            label1 = new Label();
            pic = new PictureBox();
            txtQRCode = new TextBox();
            reng = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(494, 588);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(75, 23);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 18);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 1;
            label1.Text = "QR Code";
            label1.Click += label1_Click;
            // 
            // pic
            // 
            pic.BackColor = Color.White;
            pic.Location = new Point(21, 36);
            pic.Name = "pic";
            pic.Size = new Size(531, 461);
            pic.SizeMode = PictureBoxSizeMode.CenterImage;
            pic.TabIndex = 2;
            pic.TabStop = false;
            // 
            // txtQRCode
            // 
            txtQRCode.BackColor = Color.White;
            txtQRCode.Location = new Point(21, 503);
            txtQRCode.Multiline = true;
            txtQRCode.Name = "txtQRCode";
            txtQRCode.Size = new Size(531, 79);
            txtQRCode.TabIndex = 3;
            // 
            // reng
            // 
            reng.Location = new Point(21, 588);
            reng.Name = "reng";
            reng.Size = new Size(100, 23);
            reng.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 623);
            Controls.Add(reng);
            Controls.Add(txtQRCode);
            Controls.Add(pic);
            Controls.Add(label1);
            Controls.Add(btnGenerate);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QRCode Generate";
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGenerate;
        private Label label1;
        private PictureBox pic;
        private TextBox txtQRCode;
        private TextBox reng;
    }
}