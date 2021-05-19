using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stegary
{
    public partial class Form4 : Form
    {
        Bitmap newImage;
        byte[] newFile;
        ImgManip_T Encode_T = new ImgManip_T();
        ImgManip_F Encode_F = new ImgManip_F();
        FileOperations getFile = new FileOperations();
        Crypto crypto = new Crypto();
        private bool ask4Password = false;
        private byte[] secretBytes = null;
        private string secretmessage = null;
        private bool file = false;

        public Form4()
        {
            InitializeComponent();
            Encode_T.ImageFinished += OnImageFinished;
            Encode_F.ImageFinished += OnImageFinished;
            getFile.FileOpened += OnFileOpened;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            getFile.OpenFileA();
        }

        public void OnFileOpened(object source, OpenFileArgs e)
        {
            if (e.path != null)
            {
                textBox1.Text = e.path;
            }

            if (e.image != null)
            {
                newImage = e.image;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = newImage;
            }
        }

        public void OnImageFinished(object sender, ImageEventArgs e)
        {
            if (e.secretMessage != null)
            {
                if (ask4Password)
                {
                    file = false;
                    PasswordTextBox.Visible = true; 
                    labelPassword.Visible = true;
                    checkBoxShow.Visible = true;
                    DecryptButton.Visible = true;
                    secretmessage = e.secretMessage;
                }
                else
                {
                    getFile.SaveTxt(e.secretMessage);
                }
            }

            if (e.FileBytes != null)
            {
                if (ask4Password)
                {
                    file = true;
                    PasswordTextBox.Visible = true;
                    labelPassword.Visible = true;
                    checkBoxShow.Visible = true;
                    DecryptButton.Visible = true;
                    secretBytes = e.FileBytes;
                }
                else
                {
                    getFile.SaveFileB(e.FileBytes);
                }
            }
        }


        private void ExtractButton_Click(object sender, EventArgs e)
        {
            if (newImage != null)
            {
                string watermarkText = "";
                int j = 0, i = 0, watermark = 0;
                Color theColor = new Color();

                //verifier si l'image contient un message

                for (j = 3; j >= 0; j--)
                {
                    theColor = newImage.GetPixel(j, i);
                    watermark += theColor.B % 4;
                    watermark <<= 2;
                    watermark += theColor.G % 4;
                    watermark <<= 2;
                    watermark += theColor.R % 4;
                    if (j != 0)
                    {
                        watermark <<= 2;
                    }
                }
                for (int k = 0; k < 3; k++)
                {
                    char letter = Convert.ToChar(watermark % 256);
                    watermarkText += Encoding.ASCII.GetString(new byte[] { Convert.ToByte(letter) });

                    watermark >>= 8;
                }

                Console.WriteLine(watermarkText);
                switch (watermarkText)
                {
                    case "yoz":
                        ask4Password = false;
                        Encode_T.Extract_T(newImage);
                        MessageBox.Show("Message extracted successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "zoy":
                        ask4Password = false;
                        Encode_F.Extract_F(newImage);
                        MessageBox.Show("File extracted successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "yoc":
                        ask4Password = true;
                        Encode_T.Extract_T(newImage);
                        break;

                    case "zoc":
                        ask4Password = true;
                        Encode_F.Extract_F(newImage);
                        break;

                    default:
                        MessageBox.Show("This Image is empty .", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        break;
                }
               
            }
            else
            {
                MessageBox.Show("Please Make sure to Open an image!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShow.Checked)
            {
                PasswordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        { 
            byte[] decryptedBytes = null;

            
                if (file == false)
                {
                    try
                    {

                        decryptedBytes = crypto.DecryptAes(Convert.FromBase64String(secretmessage), PasswordTextBox.Text);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        MessageBox.Show("Incorrect Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (decryptedBytes != null)
                    {
                        getFile.SaveTxt(Encoding.Unicode.GetString(decryptedBytes));
                        PasswordTextBox.Visible = false;
                        labelPassword.Visible = false;
                        checkBoxShow.Visible = false;
                        DecryptButton.Visible = false;

                    }
                }
                else
                {
                    try
                    {
                        decryptedBytes = crypto.DecryptAes(secretBytes, PasswordTextBox.Text);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        MessageBox.Show("Incorrect Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (decryptedBytes != null)
                    {
                        getFile.SaveFileB(decryptedBytes);
                        PasswordTextBox.Visible = false;
                        labelPassword.Visible = false;
                        checkBoxShow.Visible = false;
                        DecryptButton.Visible = false;

                    }
                }
        }
    }
}
