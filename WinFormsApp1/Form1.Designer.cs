namespace WinFormsApp1
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
            txtQRCode = new TextBox();
            reng = new TextBox();
            pic = new PictureBox();
            label2 = new Label();
            Gradient = new CheckBox();
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            image_check = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(850, 588);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(75, 38);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Düzəltmək";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 1;
            label1.Text = "QR Code";
            label1.Click += label1_Click;
            // 
            // txtQRCode
            // 
            txtQRCode.BackColor = Color.White;
            txtQRCode.Location = new Point(12, 547);
            txtQRCode.Multiline = true;
            txtQRCode.Name = "txtQRCode";
            txtQRCode.Size = new Size(503, 79);
            txtQRCode.TabIndex = 3;
            // 
            // reng
            // 
            reng.Location = new Point(521, 565);
            reng.Name = "reng";
            reng.Size = new Size(100, 23);
            reng.TabIndex = 4;
            // 
            // pic
            // 
            pic.BackColor = Color.White;
            pic.Location = new Point(12, 27);
            pic.Name = "pic";
            pic.Size = new Size(913, 514);
            pic.SizeMode = PictureBoxSizeMode.CenterImage;
            pic.TabIndex = 2;
            pic.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(521, 547);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 5;
            label2.Text = "Rəng kodu";
            // 
            // Gradient
            // 
            Gradient.AutoSize = true;
            Gradient.Location = new Point(632, 543);
            Gradient.Name = "Gradient";
            Gradient.Size = new Size(71, 19);
            Gradient.TabIndex = 6;
            Gradient.Text = "Gradient";
            Gradient.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // button1
            // 
            button1.Location = new Point(521, 594);
            button1.Name = "button1";
            button1.Size = new Size(75, 26);
            button1.TabIndex = 8;
            button1.Text = "Logo yüklə";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // image_check
            // 
            image_check.AutoSize = true;
            image_check.ForeColor = Color.FromArgb(0, 192, 0);
            image_check.Location = new Point(602, 588);
            image_check.Name = "image_check";
            image_check.Size = new Size(0, 15);
            image_check.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Enabled = false;
            label3.Location = new Point(764, 508);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 10;
            label3.Visible = false;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            ClientSize = new Size(937, 634);
            Controls.Add(label3);
            Controls.Add(image_check);
            Controls.Add(button1);
            Controls.Add(Gradient);
            Controls.Add(label2);
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
        private TextBox txtQRCode;
        private TextBox reng;
        private PictureBox pic;
        private Label label2;
        private CheckBox Gradient;
        private OpenFileDialog openFileDialog1;
        private Button button1;
        private Label image_check;
        private Label label3;
    }
}