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
    public partial class Form5 : Form
    {
        Bitmap newImage1, newImage2, newImage3;

        public Form5()
        {
            InitializeComponent();
        }

        private void PSNRButton_Click(object sender, EventArgs e)
        {
            
            if ((newImage1 != null && newImage2 != null) )
            {
                double mse1_2 = msecalcul(newImage1, newImage2);
                if (mse1_2 != 0)
                {
                    double psnr1_2 = psnrcalcul(mse1_2);
                    label6.Text ="PSNR:" + psnr1_2;
                    label5.Text = "PSNR LSB:" + psnr1_2;
                    label8.Text = " MSE LSB:" + mse1_2;
                    chart1.Series["LSB Substitution"].Points.AddXY("PSNR2", psnr1_2);

                    if (checkBox1.Checked)
                    {
                        if (newImage3 != null)
                        {
                            double mse1_3 = msecalcul(newImage1, newImage3);
                            if (mse1_3 != 0)
                            {
                                double psnr1_3 = psnrcalcul(mse1_3);
                                label4.Text = "PSNR OPAP:" + psnr1_3;
                                label7.Text = " MSE OPAP:" + mse1_3;
                                chart1.Series["OPAP"].Points.AddXY("PSNR1", psnr1_3);
                            }
                            else
                            {
                                MessageBox.Show("The Original and OPAP stego-image are either Identical or not appropriate !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Make sure to Open the OPAP stego-image !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The Original and LSB stego-image are Identical or not appropriate !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("Please Make sure to at least Open 2 images (Original & LSB stego-image !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg files|*.jpg|png files|*.png|bmp files | *.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                newImage2 = new Bitmap(Image.FromFile(ofd.FileName));
                textBox2.Text = ofd.FileName;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Image = newImage2;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg files|*.jpg|png files|*.png|bmp files | *.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                newImage1 = new Bitmap(Image.FromFile(ofd.FileName));
                textBox1.Text = ofd.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = newImage1;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg files|*.jpg|png files|*.png|bmp files | *.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                newImage3 = new Bitmap(Image.FromFile(ofd.FileName));
                textBox3.Text = ofd.FileName;
                pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox3.Image = newImage3;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) 
            {
                textBox3.Visible = true;
                pictureBox3.Visible = true;
                label3.Visible = true;
                label2.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label6.Visible = false;
            }
            else
            {
                textBox3.Visible = false;
                pictureBox3.Visible = false;
                label3.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label5.Visible = false;
                label6.Visible = true;
            }
        }

        public double msecalcul(Bitmap bmp1, Bitmap bmp2)
        {
            double mse = 0;
            Color theColor2 = new Color();
            Color theColor1 = new Color();
            if (bmp1.Height == bmp2.Height && bmp1.Width == bmp2.Width)
            {
                for (int i = 0; i < bmp1.Width; i++)
                {

                    for (int j = 0; j < bmp1.Height; j++)
                    {
                        theColor1 = bmp1.GetPixel(i, j);
                        theColor2 = bmp2.GetPixel(i, j);
                        int newr = (theColor1.R - theColor2.R) * (theColor1.R - theColor2.R);
                        int newg = (theColor1.G - theColor2.G) * (theColor1.G - theColor2.G);
                        int newb = (theColor1.B - theColor2.B) * (theColor1.B - theColor2.B);
                        mse = mse + (double)(0.3*newr + 0.59*newg + 0.11*newb);
                    }
                }
                mse = mse / (bmp1.Width * bmp1.Height);
            }

            return mse;
        }

        public double psnrcalcul(double mse)
        {
            double psnr = 0;
            psnr = 10 * Math.Log10(Math.Pow(255, 2) / mse);
            return psnr;
        }


    }
}
