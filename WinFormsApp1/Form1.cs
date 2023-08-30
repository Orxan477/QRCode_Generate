using QRCoder;
using SkiaSharp;
using System.Drawing;

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
            pic.Image = Qr(4);
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
            var qrImage = Qr(4);
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    qrImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // QR kodunu PNG olarak belleğe kaydet
                    ms.Seek(0, SeekOrigin.Begin);

                    using (StreamReader reader = new StreamReader(ms))
                    {
                        string pngData = Convert.ToBase64String(ms.ToArray()); // Bellekten Base64 verisi olarak al
                        string svgCode = $@"
<svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""{qrImage.Width}"" height=""{qrImage.Height}"">
    <image xlink:href=""data:image/png;base64,{pngData}"" width=""{qrImage.Width}"" height=""{qrImage.Height}"" />
</svg>";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // SVG kodunu dosyaya kaydet
                            string svgFilePath = saveFileDialog.FileName + ".svg";
                            File.WriteAllText(svgFilePath, svgCode);
                        }

                    }
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            image_check.Text = "";
            label4.Text = "Logo silindi";
        }


        private Bitmap Qr(int px)
        {
            string qrData = txtQRCode.Text; // QR kodunun içeriği
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrImage = qrCode.GetGraphic(px); // 4 piksel büyüklüğünde QR kodu oluştur
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
            return qrImage;
        }
    }
}
