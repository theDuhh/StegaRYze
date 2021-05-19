using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stegary
{
    public partial class Form2 : Form
    {
        Bitmap newImage;
        ImgManip_T Encode_T = new ImgManip_T();
        FileOperations getFile = new FileOperations();
        Crypto crypto = new Crypto();

        public Form2()
        {
            InitializeComponent();
            Encode_T.ImageFinished += OnImageFinished;
            getFile.FileOpened += OnFileOpened;
            Encode_T.bitSelecT = 1;
            Encode_T.message = null;
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
                DisplayImage(newImage, 1);
            }

        }

        public void DisplayImage(Bitmap b, int window)
        {
            if (b != null)
            {
                if (window == 1)
                {
                    int size = (int)sizeMaxSubstitution(b, Encode_T.bitSelecT);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = b;
                    labelSize.Text = "Capacity : " + size + "/" + size +" Bytes";
                    if (Encode_T.message != null)
                    {
                        int written = 0;
                        written = Encode_T.message.Length;
                        labelSize.Text = "Capacity : " + (size - written) + "/" + size + " Bytes";
                    }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            getFile.OpenFileA();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 8;
            Encode_T.bitSelecT = (int)numericUpDown1.Value;
            if (newImage != null )
            {
                int written = 0;
                if (Encode_T.message != null) written = Encode_T.message.Length;
                int size = (int)sizeMaxSubstitution(newImage, Encode_T.bitSelecT);
                labelSize.Text = "Capacity : " + (size - written) + "/" + size + " Bytes";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (bunifuiOSSwitch1.Value) EncryptButton.Visible = true;
            Encode_T.message = richTextBox1.Text;
            if (newImage != null)
            {
                int size = (int)sizeMaxSubstitution(newImage, Encode_T.bitSelecT);
                labelSize.Text = "Capacity : " + (size - Encode_T.message.Length) + "/" + size + " Bytes";
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (newImage != null)
            {
                if (Encode_T.message != null)
                {
                    if (Encode_T.message.Length >= sizeMaxSubstitution(newImage, Encode_T.bitSelecT) && newImage.Width > 10)
                    {
                        MessageBox.Show("Text too Big!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        
                        if (LSBRadio.Checked)
                        {
                            Encode_T.Insert_T(newImage, false);
                            MessageBox.Show("Message embedded successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (OPAPRadio.Checked)
                            {
                                Encode_T.Insert_T(newImage, true);
                            }
                            MessageBox.Show("Message embedded successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                        newImage = null;
                        pictureBox1.Update();
                        pictureBox1.Image.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Please Make sure to type your message!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Make sure to Open an image!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public long sizeMaxSubstitution(Bitmap bmap, int bitSelect)
        {
            return ((bmap.Height * bmap.Width - 10) * bitSelect) / 8;
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
            if (PasswordTextBox.Text.Length >= 8 && richTextBox1.Text != null)
            {
                byte[] message = Encoding.Unicode.GetBytes(richTextBox1.Text);
                byte[] cryptedBytes = crypto.EncryptAes(message, PasswordTextBox.Text);
                richTextBox1.Text = Convert.ToBase64String(cryptedBytes);
                Encode_T.crypted = true;
                EncryptButton.Visible = false;
            }
            else
            {
                MessageBox.Show("Your password must be at least 8 characters long.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
