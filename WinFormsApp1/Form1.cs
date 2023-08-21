﻿using Microsoft.VisualBasic.ApplicationServices;
using QRCoder;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Bitmap logo;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //globalda olan

            //QRCodeGenerator qr = new QRCodeGenerator();
            //QRCodeData data = qr.CreateQrCode(txtQRCode.Text, QRCodeGenerator.ECCLevel.Q);
            //QRCode code = new QRCode(data);
            //System.Drawing.Bitmap qrImage = code.GetGraphic(5);

            //if (reng.Text == "")
            //{
            //    reng.Text = "#000";
            //}

            //System.Drawing.Color customColor = System.Drawing.ColorTranslator.FromHtml(reng.Text);

            //for (int y = 0; y < qrImage.Height; y++)
            //{
            //    for (int x = 0; x < qrImage.Width; x++)
            //    {
            //        System.Drawing.Color pixelColor = qrImage.GetPixel(x, y);
            //        if (pixelColor.ToArgb() == System.Drawing.Color.Black.ToArgb())
            //        {
            //            qrImage.SetPixel(x, y, customColor); // Siyah pikselleri özel renkle değiştir
            //        }
            //    }
            //}

            //pic.Image = qrImage;



            // yuxardan asagi

            //QRCodeGenerator qr = new QRCodeGenerator();
            //QRCodeData data = qr.CreateQrCode(txtQRCode.Text, QRCodeGenerator.ECCLevel.Q);
            //QRCode code = new QRCode(data);
            //System.Drawing.Bitmap qrImage = code.GetGraphic(5);

            //System.Drawing.Color startColor = System.Drawing.ColorTranslator.FromHtml("#3f4293"); // Başlangıç rengi
            //System.Drawing.Color endColor = System.Drawing.ColorTranslator.FromHtml("#3d3d3b"); // Bitiş rengi

            //for (int y = 0; y < qrImage.Height; y++)
            //{
            //    for (int x = 0; x < qrImage.Width; x++)
            //    {
            //        System.Drawing.Color pixelColor = qrImage.GetPixel(x, y);
            //        if (pixelColor.ToArgb() == System.Drawing.Color.Black.ToArgb())
            //        {
            //            int gradientValue = (int)((double)y / qrImage.Height * 255 * 3); // Alpha değeri 255'ten fazla olmamalı
            //            gradientValue = Math.Min(255, gradientValue); // Alpha değerini 255'e sınırla
            //            Color gradientColor = Color.FromArgb(gradientValue, startColor);
            //            qrImage.SetPixel(x, y, gradientColor); // Siyah pikselleri gradient renk ile değiştir
            //        }
            //    }
            //}

            //pic.Image = qrImage;

            // logo ile

            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(txtQRCode.Text, QRCodeGenerator.ECCLevel.Q);
            //QRCodeData data = qr.CreateQrCode(Uri.EscapeDataString(txtQRCode.Text), QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            Bitmap qrImage = code.GetGraphic(4);
            if (reng.Text == "")
            {
                reng.Text = "#000";
            }
            Color startColor = ColorTranslator.FromHtml(reng.Text); // Başlangıç rengi
                                                                    //Color startColor = ColorTranslator.FromHtml("#3f4293"); // Başlangıç rengi
            if (label3.Text != "")
            {
                logo = new Bitmap(@"C:\Users\Orxan477\Desktop\QRCode_Generate\" + label3.Text); // Logo dosyasının yolunu belirtin
                int logoSize = qrImage.Width / 2; // Logo boyutunu ayarlayabilirsiniz
                logo = new Bitmap(logo, new Size(logoSize, logoSize));

            }

            for (int y = 0; y < qrImage.Height; y++)
            {
                for (int x = 0; x < qrImage.Width; x++)
                {
                    Color pixelColor = qrImage.GetPixel(x, y);
                    if (Gradient.Checked == true)
                    {
                        if (pixelColor.ToArgb() == Color.Black.ToArgb())
                        {
                            int gradientValue = (int)((double)y / qrImage.Height * 255 * 3); // Alpha değeri 255'ten fazla olmamalı
                            gradientValue = Math.Min(255, gradientValue); // Alpha değerini 255'e sınırla
                            Color gradientColor = Color.FromArgb(gradientValue, startColor);


                            qrImage.SetPixel(x, y, gradientColor);
                        }
                    }
                    else
                    {
                        if (pixelColor.ToArgb() == System.Drawing.Color.Black.ToArgb())
                        {
                            qrImage.SetPixel(x, y, startColor); // Siyah pikselleri özel renkle değiştir
                        }
                    }
                }
            }
            if (label3.Text != "")
            {
                int xPos = (qrImage.Width - logo.Width) / 2;
                int yPos = (qrImage.Height - logo.Height) / 2;
                using (Graphics g = Graphics.FromImage(qrImage))
                {
                    g.DrawImage(logo, new Point(xPos, yPos));
                }
            }

            pic.Image = qrImage;
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files|*.jpg;*.png;*.gif;*.bmp;*.jpeg|All Files|*.*";

            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                string imagePath = opnfd.FileName;
                Bitmap image = new Bitmap(imagePath);
                image_check.Text = "Yükləndi";
                label3.Text = opnfd.SafeFileName;
            }
        }
    }
}
