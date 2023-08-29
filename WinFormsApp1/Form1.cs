using QRCoder;
using SixLabors.ImageSharp.Formats.Jpeg;
using SkiaSharp;
using Svg.Skia;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Image = SixLabors.ImageSharp.Image;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Bitmap logo;
        private Bitmap qrImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(txtQRCode.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            qrImage = code.GetGraphic(4);

            if (reng.Text == "")
            {
                reng.Text = "#000";
            }

            System.Drawing.Color startColor = ColorTranslator.FromHtml(reng.Text);

            if (!string.IsNullOrEmpty(label3.Text))
            {
                logo = new Bitmap(label3.Text);
                int logoSize = qrImage.Width / 2;
                logo = new Bitmap(logo, new System.Drawing.Size(logoSize, logoSize));
            }

            for (int y = 0; y < qrImage.Height; y++)
            {
                for (int x = 0; x < qrImage.Width; x++)
                {
                    System.Drawing.Color pixelColor = qrImage.GetPixel(x, y);
                    if (Gradient.Checked)
                    {
                        if (pixelColor.ToArgb() == System.Drawing.Color.Black.ToArgb())
                        {
                            int gradientValue = (int)((double)y / qrImage.Height * 255 * 3);
                            gradientValue = Math.Min(255, gradientValue);
                            System.Drawing.Color gradientColor = System.Drawing.Color.FromArgb(gradientValue, startColor);
                            qrImage.SetPixel(x, y, gradientColor);
                        }
                    }
                    else
                    {
                        if (pixelColor.ToArgb() == System.Drawing.Color.Black.ToArgb())
                        {
                            qrImage.SetPixel(x, y, startColor);
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(label3.Text))
            {
                int xPos = (qrImage.Width - logo.Width) / 2;
                int yPos = (qrImage.Height - logo.Height) / 2;
                using (Graphics g = Graphics.FromImage(qrImage))
                {
                    g.DrawImage(logo, new System.Drawing.Point(xPos, yPos));
                }
            }
            pic.Image = qrImage;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files|*.jpg;*.png;*.gif;*.bmp;*.jpeg|All Files|*.*";

            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                string imagePath = opnfd.FileName;
                Bitmap image = new Bitmap(imagePath);
                image_check.Text = "Yüklendi";
                label3.Text = opnfd.FileName;
                label4.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Dosyaları (*.png)|*.png|Tüm Dosyalar (*.*)|*.*";
                saveFileDialog.FileName = "QRCode.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap qrBitmap = new Bitmap(pic.Image); // QR kod görüntüsünü al
                    qrBitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            image_check.Text = "";
            label4.Text = "Logo silindi";
        }
    }
}
