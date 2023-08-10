using QRCoder;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(txtQRCode.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            System.Drawing.Bitmap qrImage = code.GetGraphic(5);

            if(reng.Text=="")
            {
                reng.Text = "#000";
            }

            System.Drawing.Color customColor = System.Drawing.ColorTranslator.FromHtml(reng.Text);

            for (int y = 0; y < qrImage.Height; y++)
            {
                for (int x = 0; x < qrImage.Width; x++)
                {
                    System.Drawing.Color pixelColor = qrImage.GetPixel(x, y);
                    if (pixelColor.ToArgb() == System.Drawing.Color.Black.ToArgb())
                    {
                        qrImage.SetPixel(x, y, customColor); // Siyah pikselleri özel renkle değiştir
                    }
                }
            }

            pic.Image = qrImage;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}