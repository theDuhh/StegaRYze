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
    public partial class Form3 : Form
    {
        Bitmap newImage;
        byte[] newFile;
        ImgManip_F Encode_F = new ImgManip_F();
        FileOperations getFile = new FileOperations();
        Crypto crypto = new Crypto();

        public Form3()
        {
            InitializeComponent();
            Encode_F.ImageFinished += OnImageFinished;
            getFile.FileOpened += OnFileOpened;
            Encode_F.bitSelecT = 1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            getFile.OpenFileA();
            DisplayImage(newImage, 1);
        }

        public void OnFileOpened(object source, OpenFileArgs e)
        {


            if (e.image != null && e.path != null)
            {
                newImage = e.image;
                textBox1.Text = e.path;
            }

            if (e.file != null && e.path != null)
            {
                newFile = e.file;
                textBox2.Text = e.path;
            }

        }

        public void DisplayImage(Bitmap b, int window)
        {
            if (b != null)
            {
                if (window == 1)
                {
                    int size = (int)sizeMaxSubstitution(b, Encode_F.bitSelecT);
                    labelSize.Text = "Capacity : " + size + " Bytes";
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = b;
                }
                else if (window == 2)
                {
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox2.Image = b;
                }
            }
        }

        public void OnImageFinished(object sender, ImageEventArgs e)
        {
            if (e.bmap != null)
            {
                getFile.SaveFileA(e.bmap);
                DisplayImage(e.bmap, 2);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 8;
            Encode_F.bitSelecT = (int)numericUpDown1.Value;
            if (newImage != null )
            {
                int size = (int)sizeMaxSubstitution(newImage, Encode_F.bitSelecT);
                labelSize.Text = "Capacity : " + size + " Bytes";
            }
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            getFile.OpenFileB();
            if(bunifuiOSSwitch1.Value) EncryptButton.Visible = true;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (newImage != null)
            {
                if (newFile != null)
                {
                    Encode_F.FileBytes = newFile;
                    if (Encode_F.FileBytes.Length >= sizeMaxSubstitution(newImage, Encode_F.bitSelecT) && newImage.Width > 10) //+ extension
                    {
                        MessageBox.Show("File too Big!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        if (LSBRadio.Checked)
                        {
                            Encode_F.Insert_F(newImage,false);
                            MessageBox.Show("File embedded successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (OPAPRadio.Checked)
                            {
                                Encode_F.Insert_F(newImage,true);
                            }
                            MessageBox.Show("File embedded successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                        newImage = null;
                        pictureBox1.Image.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Please Make sure to choose a File!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Make sure to Open an image!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public long sizeMaxSubstitution(Bitmap bmap, int bitSelect)
        {
            return ((bmap.Height * bmap.Width - 10) * bitSelect) / 8; // + extension meshi + 10 berk
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


        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
            if (bunifuiOSSwitch1.Value) 
            {
                labelPassword.Visible = true;
                PasswordTextBox.Visible = true;
                checkBoxShow.Visible = true;
                EncryptButton.Visible = true;
            }
            else
            {
                labelPassword.Visible = false;
                PasswordTextBox.Visible = false;
                checkBoxShow.Visible = false;
                EncryptButton.Visible = false;
            }
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text.Length >= 8 && newFile != null)
            {
                Encode_F.crypted = true;
                newFile = crypto.EncryptAes(newFile, PasswordTextBox.Text);
                EncryptButton.Visible = false;
                MessageBox.Show("Your File Encryption was successful.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Your password must be at least 8 characters long.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
