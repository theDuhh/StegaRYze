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
    public partial class STEGARYSE : Form
    {
        public STEGARYSE()
        {
            InitializeComponent();
            customizeDesign();
            textNull();
            textNotNull();
        }

      
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customizeDesign()
        {
            subInsert.Visible = false;
        }
        private void hideSubMenu()
        {

            if (subInsert.Visible == true)
                subInsert.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
        else
        subMenu.Visible = false;

        }
        private void textNull()
        {
            btnInsertFile.Text = null;
            btnInsertMsg.Text = null;
            btnInsert.Text = null;
            btnExtract.Text = null;
            btnPsnr.Text = null;
            btnHelp.Text = null;
        }
        private void textNotNull()
        {
            btnInsertFile.Text = "                  File";
            btnInsertMsg.Text = "                  Message";
            btnInsert.Text = "             Insert";
            btnExtract.Text = "             Extract";
            btnPsnr.Text = "             PSNR";
            btnHelp.Text = "             Help";
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            textNull();
            subInsert.Visible = false;
            btnMenu.Visible = false;
            btnMenu2.Visible = true;
            logoAnimator.Hide(logo);
            sidemenupanel.Visible = false;
            sidemenupanel.Width = 50;
            panelAnimator.ShowSync(sidemenupanel);
            
        }

        private void btnMenu2_Click(object sender, EventArgs e)
        {
            textNotNull();
            subInsert.Visible = false;
            btnMenu.Visible = true;
            btnMenu2.Visible = false;
            sidemenupanel.Visible = false;
            sidemenupanel.Width = 200; 
            panelAnimator.ShowSync(sidemenupanel);
            logoAnimator.ShowSync(logo);
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(btnMenu.Visible==true)
            showSubMenu(subInsert);

        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openForm(new Form4());
        }

        private void btnInsertMsg_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openForm(new Form2());
        }

        private void btnInsertFile_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openForm(new Form3());
        }

  
        private void btnPsnr_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openForm(new Form5());
        }

      
        private void btnHelp_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openForm(new Form6());
        }

        private Form activeForm = null;
        private void openForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childFormPanel.Controls.Add(childForm);
            childFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
            if (bunifuiOSSwitch1.Value)
            {
                panelHeader.BackColor = Color.FromArgb(16, 55, 92);
                bunifuImageButton1.BackColor = Color.FromArgb(16, 55, 92);
                bunifuImageButton2.BackColor = Color.FromArgb(16, 55, 92);
                sidemenupanel.BackColor = Color.FromArgb(18, 118, 129);
                childFormPanel.BackColor = Color.FromArgb(244, 246, 255);
                /*Form2.BackColor = Color.FromArgb(244, 246, 255);
                Form3.BackColor = Color.FromArgb(244, 246, 255);
                Form4.BackColor = Color.FromArgb(244, 246, 255);
                Form5.BackColor = Color.FromArgb(244, 246, 255);*/
                time.ForeColor = Color.FromArgb(16, 55, 92);
                date.ForeColor = Color.FromArgb(16, 55, 92);
                btnMenu2.BackColor = Color.FromArgb(18, 118, 129);
                btnMenu.BackColor = Color.FromArgb(18, 118, 129);
                btnExtract.BackColor = Color.FromArgb(18, 118, 129);
                btnHelp.BackColor = Color.FromArgb(18, 118, 129);
                btnInsert.BackColor = Color.FromArgb(18, 118, 129);
                btnInsertFile.BackColor = Color.FromArgb(18, 118, 129);
                btnInsertMsg.BackColor = Color.FromArgb(18, 118, 129);
                btnPsnr.BackColor = Color.FromArgb(18, 118, 129);
                btnExtract.Activecolor = Color.FromArgb(243, 198, 35);
                btnHelp.Activecolor = Color.FromArgb(243, 198, 35);
                btnInsert.Activecolor = Color.FromArgb(243, 198, 35);
                btnInsertFile.Activecolor = Color.FromArgb(243, 198, 35);
                btnInsertMsg.Activecolor = Color.FromArgb(243, 198, 35);
                btnPsnr.Activecolor = Color.FromArgb(243, 198, 35);
                btnExtract.Normalcolor = Color.FromArgb(18, 118, 129);
                btnHelp.Normalcolor = Color.FromArgb(18, 118, 129);
                btnInsert.Normalcolor = Color.FromArgb(18, 118, 129);
                btnInsertFile.Normalcolor = Color.FromArgb(18, 118, 129);
                btnInsertMsg.Normalcolor = Color.FromArgb(18, 118, 129);
                btnPsnr.Normalcolor = Color.FromArgb(18, 118, 129);
                btnExtract.OnHovercolor = Color.FromArgb(18, 118, 129);
                btnHelp.OnHovercolor = Color.FromArgb(18, 118, 129);
                btnInsert.OnHovercolor = Color.FromArgb(18, 118, 129);
                btnInsertFile.OnHovercolor = Color.FromArgb(18, 118, 129);
                btnInsertMsg.OnHovercolor = Color.FromArgb(18, 118, 129);
                btnPsnr.OnHovercolor = Color.FromArgb(18, 118, 129);
                btnExtract.OnHoverTextColor = Color.FromArgb(243, 198, 35);
                btnHelp.OnHoverTextColor = Color.FromArgb(243, 198, 35);
                btnInsert.OnHoverTextColor = Color.FromArgb(243, 198, 35);
                btnInsertFile.OnHoverTextColor = Color.FromArgb(243, 198, 35);
                btnInsertMsg.OnHoverTextColor = Color.FromArgb(243, 198, 35);
                btnPsnr.OnHoverTextColor = Color.FromArgb(243, 198, 35);
                btnExtract.Textcolor = Color.FromArgb(16, 55, 92);
                btnHelp.Textcolor = Color.FromArgb(16, 55, 92);
                btnInsert.Textcolor = Color.FromArgb(16, 55, 92);
                btnInsertFile.Textcolor = Color.FromArgb(16, 55, 92);
                btnInsertMsg.Textcolor = Color.FromArgb(16, 55, 92);
                btnPsnr.Textcolor = Color.FromArgb(16, 55, 92);
            }
            else
            {
                ///////////////////////////////////////////////////////
                panelHeader.BackColor = Color.FromArgb(0, 102, 204);
                bunifuImageButton1.BackColor = Color.FromArgb(0, 102, 204);
                bunifuImageButton2.BackColor = Color.FromArgb(0, 102, 204);
                sidemenupanel.BackColor = Color.FromArgb(26, 32, 40);
                childFormPanel.BackColor = Color.FromArgb(37, 46, 59);
                /*Form2.BackColor = Color.FromArgb(244, 246, 255);
                Form3.BackColor = Color.FromArgb(244, 246, 255);
                Form4.BackColor = Color.FromArgb(244, 246, 255);
                Form5.BackColor = Color.FromArgb(244, 246, 255);*/
                time.ForeColor = Color.White;
                date.ForeColor = Color.White;
                btnMenu2.BackColor = Color.FromArgb(26, 32, 40);
                btnMenu.BackColor = Color.FromArgb(26, 32, 40);
                btnExtract.BackColor = Color.FromArgb(26, 32, 40);
                btnHelp.BackColor = Color.FromArgb(26, 32, 40);
                btnInsert.BackColor = Color.FromArgb(26, 32, 40);
                btnInsertFile.BackColor = Color.FromArgb(26, 32, 40);
                btnInsertMsg.BackColor = Color.FromArgb(26, 32, 40);
                btnPsnr.BackColor = Color.FromArgb(26, 32, 40);
                btnExtract.Activecolor = Color.FromArgb(0, 102, 204);
                btnHelp.Activecolor = Color.FromArgb(0, 102, 204);
                btnInsert.Activecolor = Color.FromArgb(0, 102, 204);
                btnInsertFile.Activecolor = Color.FromArgb(0, 102, 204);
                btnInsertMsg.Activecolor = Color.FromArgb(0, 102, 204);
                btnPsnr.Activecolor = Color.FromArgb(0, 102, 204);
                btnExtract.Normalcolor = Color.FromArgb(26, 32, 40);
                btnHelp.Normalcolor = Color.FromArgb(26, 32, 40);
                btnInsert.Normalcolor = Color.FromArgb(26, 32, 40);
                btnInsertFile.Normalcolor = Color.FromArgb(26, 32, 40);
                btnInsertMsg.Normalcolor = Color.FromArgb(26, 32, 40);
                btnPsnr.Normalcolor = Color.FromArgb(26, 32, 40);
                btnExtract.OnHovercolor = Color.FromArgb(26, 32, 40);
                btnHelp.OnHovercolor = Color.FromArgb(26, 32, 40);
                btnInsert.OnHovercolor = Color.FromArgb(26, 32, 40);
                btnInsertFile.OnHovercolor = Color.FromArgb(26, 32, 40);
                btnInsertMsg.OnHovercolor = Color.FromArgb(26, 32, 40);
                btnPsnr.OnHovercolor = Color.FromArgb(26, 32, 40);
                btnExtract.OnHoverTextColor = Color.FromArgb(0, 102, 204);
                btnHelp.OnHoverTextColor = Color.FromArgb(0, 102, 204);
                btnInsert.OnHoverTextColor = Color.FromArgb(0, 102, 204);
                btnInsertFile.OnHoverTextColor = Color.FromArgb(0, 102, 204);
                btnInsertMsg.OnHoverTextColor = Color.FromArgb(0, 102, 204);
                btnPsnr.OnHoverTextColor = Color.FromArgb(0, 102, 204);
                btnExtract.Textcolor = Color.Silver;
                btnHelp.Textcolor = Color.Silver;
                btnInsert.Textcolor = Color.Silver;
                btnInsertFile.Textcolor = Color.Silver;
                btnInsertMsg.Textcolor = Color.Silver;
                btnPsnr.Textcolor = Color.Silver;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            time.Text = DateTime.Now.ToLongTimeString();
            date.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}