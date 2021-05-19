namespace stegary
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ExtractButton = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.checkBoxShow = new System.Windows.Forms.CheckBox();
            this.DecryptButton = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.DecryptButton);
            this.panel1.Controls.Add(this.labelPassword);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.PasswordTextBox);
            this.panel1.Controls.Add(this.checkBoxShow);
            this.panel1.Controls.Add(this.ExtractButton);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 424);
            this.panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(193, 203);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(213, 21);
            this.textBox1.TabIndex = 10;
            // 
            // ExtractButton
            // 
            this.ExtractButton.ActiveBorderThickness = 1;
            this.ExtractButton.ActiveCornerRadius = 50;
            this.ExtractButton.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.ExtractButton.ActiveForecolor = System.Drawing.Color.Silver;
            this.ExtractButton.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.ExtractButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ExtractButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExtractButton.BackgroundImage")));
            this.ExtractButton.ButtonText = "Extract";
            this.ExtractButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExtractButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtractButton.ForeColor = System.Drawing.Color.SeaGreen;
            this.ExtractButton.IdleBorderThickness = 1;
            this.ExtractButton.IdleCornerRadius = 50;
            this.ExtractButton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.ExtractButton.IdleForecolor = System.Drawing.Color.Silver;
            this.ExtractButton.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.ExtractButton.Location = new System.Drawing.Point(236, 289);
            this.ExtractButton.Margin = new System.Windows.Forms.Padding(5);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(139, 51);
            this.ExtractButton.TabIndex = 9;
            this.ExtractButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(217, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPassword.Location = new System.Drawing.Point(134, 264);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(77, 17);
            this.labelPassword.TabIndex = 19;
            this.labelPassword.Text = "Password :";
            this.labelPassword.Visible = false;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(217, 261);
            this.PasswordTextBox.MaxLength = 24;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(181, 20);
            this.PasswordTextBox.TabIndex = 18;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.Visible = false;
            // 
            // checkBoxShow
            // 
            this.checkBoxShow.AutoSize = true;
            this.checkBoxShow.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShow.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxShow.Location = new System.Drawing.Point(404, 260);
            this.checkBoxShow.Name = "checkBoxShow";
            this.checkBoxShow.Size = new System.Drawing.Size(62, 21);
            this.checkBoxShow.TabIndex = 17;
            this.checkBoxShow.Text = "Show";
            this.checkBoxShow.UseVisualStyleBackColor = true;
            this.checkBoxShow.Visible = false;
            this.checkBoxShow.CheckedChanged += new System.EventHandler(this.checkBoxShow_CheckedChanged);
            // 
            // DecryptButton
            // 
            this.DecryptButton.ActiveBorderThickness = 1;
            this.DecryptButton.ActiveCornerRadius = 50;
            this.DecryptButton.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.DecryptButton.ActiveForecolor = System.Drawing.Color.Silver;
            this.DecryptButton.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.DecryptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.DecryptButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DecryptButton.BackgroundImage")));
            this.DecryptButton.ButtonText = "Decrypt";
            this.DecryptButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DecryptButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecryptButton.ForeColor = System.Drawing.Color.SeaGreen;
            this.DecryptButton.IdleBorderThickness = 1;
            this.DecryptButton.IdleCornerRadius = 50;
            this.DecryptButton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(60)))), ((int)(((byte)(97)))));
            this.DecryptButton.IdleForecolor = System.Drawing.Color.Silver;
            this.DecryptButton.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.DecryptButton.Location = new System.Drawing.Point(236, 350);
            this.DecryptButton.Margin = new System.Windows.Forms.Padding(5);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(139, 51);
            this.DecryptButton.TabIndex = 28;
            this.DecryptButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DecryptButton.Visible = false;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(600, 512);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form4";
            this.Text = "Form4";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuThinButton2 ExtractButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.CheckBox checkBoxShow;
        private Bunifu.Framework.UI.BunifuThinButton2 DecryptButton;
    }
}