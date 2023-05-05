namespace BeautyAndCosmetics
{
    partial class frmLogin
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
            this.panelLogin = new System.Windows.Forms.Panel();
            this.pctShowPassword = new System.Windows.Forms.PictureBox();
            this.pctPass = new System.Windows.Forms.PictureBox();
            this.pctUser = new System.Windows.Forms.PictureBox();
            this.txtPassword = new BeautyAndCosmetics.RJTextbox();
            this.txtUsername = new BeautyAndCosmetics.RJTextbox();
            this.btnLogin = new BeautyAndCosmetics.RJButton();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.lblDisplaylogin = new System.Windows.Forms.Label();
            this.pctExitLogin = new System.Windows.Forms.PictureBox();
            this.pcthelpLogin = new System.Windows.Forms.PictureBox();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctShowPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExitLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcthelpLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelLogin.Controls.Add(this.pctShowPassword);
            this.panelLogin.Controls.Add(this.pctPass);
            this.panelLogin.Controls.Add(this.pctUser);
            this.panelLogin.Controls.Add(this.txtPassword);
            this.panelLogin.Controls.Add(this.txtUsername);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Location = new System.Drawing.Point(94, 187);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(411, 260);
            this.panelLogin.TabIndex = 2;
            // 
            // pctShowPassword
            // 
            this.pctShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.pctShowPassword.Image = global::BeautyAndCosmetics.Properties.Resources.eye;
            this.pctShowPassword.Location = new System.Drawing.Point(338, 106);
            this.pctShowPassword.Name = "pctShowPassword";
            this.pctShowPassword.Size = new System.Drawing.Size(36, 33);
            this.pctShowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctShowPassword.TabIndex = 7;
            this.pctShowPassword.TabStop = false;
            this.pctShowPassword.Click += new System.EventHandler(this.pctShowPassword_Click);
            this.pctShowPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pctShowPassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pctPass
            // 
            this.pctPass.Image = global::BeautyAndCosmetics.Properties.Resources.Padlock_symbol;
            this.pctPass.Location = new System.Drawing.Point(54, 106);
            this.pctPass.Name = "pctPass";
            this.pctPass.Size = new System.Drawing.Size(32, 30);
            this.pctPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctPass.TabIndex = 5;
            this.pctPass.TabStop = false;
            // 
            // pctUser
            // 
            this.pctUser.Image = global::BeautyAndCosmetics.Properties.Resources._768px_User_icon_2_svg;
            this.pctUser.Location = new System.Drawing.Point(56, 53);
            this.pctUser.Name = "pctUser";
            this.pctUser.Size = new System.Drawing.Size(32, 30);
            this.pctUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctUser.TabIndex = 4;
            this.pctUser.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.Bordercolour = System.Drawing.Color.MediumSeaGreen;
            this.txtPassword.Borderfocuscolour = System.Drawing.Color.HotPink;
            this.txtPassword.BorderRadius = 15;
            this.txtPassword.Bordersize = 2;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(89, 106);
            this.txtPassword.mutliline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Padding = new System.Windows.Forms.Padding(7);
            this.txtPassword.PasswordChar = true;
            this.txtPassword.PlaceHolderColour = System.Drawing.Color.DarkGray;
            this.txtPassword.PlaceHolderText = "";
            this.txtPassword.Size = new System.Drawing.Size(250, 31);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Texts = "";
            this.txtPassword.Underlinedstyle = false;
            this.txtPassword._TextChanged += new System.EventHandler(this.rjTextbox1__TextChanged);
            this.txtPassword.Load += new System.EventHandler(this.rjTextbox1_Load);
            this.txtPassword.Click += new System.EventHandler(this.txtPass_Click);
            this.txtPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPass_MouseClick);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsername.Bordercolour = System.Drawing.Color.MediumSeaGreen;
            this.txtUsername.Borderfocuscolour = System.Drawing.Color.HotPink;
            this.txtUsername.BorderRadius = 15;
            this.txtUsername.Bordersize = 2;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.Location = new System.Drawing.Point(89, 53);
            this.txtUsername.mutliline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Padding = new System.Windows.Forms.Padding(7);
            this.txtUsername.PasswordChar = false;
            this.txtUsername.PlaceHolderColour = System.Drawing.Color.DarkGray;
            this.txtUsername.PlaceHolderText = "";
            this.txtUsername.Size = new System.Drawing.Size(250, 31);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Texts = "";
            this.txtUsername.Underlinedstyle = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Red;
            this.btnLogin.BackgroundColor = System.Drawing.Color.Red;
            this.btnLogin.BackgroundColour = System.Drawing.Color.Red;
            this.btnLogin.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLogin.BorderRadius = 20;
            this.btnLogin.BorderSize = 0;
            this.btnLogin.BorderSize1 = 0;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Tai Le", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(59, 178);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(280, 60);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.TextColour = System.Drawing.Color.White;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.rjButton1_Click);
            this.btnLogin.MouseHover += new System.EventHandler(this.rjButton1_MouseHover);
            // 
            // pctLogo
            // 
            this.pctLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctLogo.Image = global::BeautyAndCosmetics.Properties.Resources.SimpsonsLogo;
            this.pctLogo.Location = new System.Drawing.Point(221, 12);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(132, 43);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 1;
            this.pctLogo.TabStop = false;
            // 
            // lblDisplaylogin
            // 
            this.lblDisplaylogin.AutoSize = true;
            this.lblDisplaylogin.BackColor = System.Drawing.Color.Transparent;
            this.lblDisplaylogin.Font = new System.Drawing.Font("Microsoft YaHei", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplaylogin.ForeColor = System.Drawing.Color.Gray;
            this.lblDisplaylogin.Location = new System.Drawing.Point(139, 73);
            this.lblDisplaylogin.Name = "lblDisplaylogin";
            this.lblDisplaylogin.Size = new System.Drawing.Size(327, 100);
            this.lblDisplaylogin.TabIndex = 3;
            this.lblDisplaylogin.Text = " PLEASE SIGN IN\r\n  TO CONTINUE";
            // 
            // pctExitLogin
            // 
            this.pctExitLogin.BackColor = System.Drawing.Color.Transparent;
            this.pctExitLogin.Image = global::BeautyAndCosmetics.Properties.Resources._458594;
            this.pctExitLogin.Location = new System.Drawing.Point(551, 6);
            this.pctExitLogin.Name = "pctExitLogin";
            this.pctExitLogin.Size = new System.Drawing.Size(44, 43);
            this.pctExitLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctExitLogin.TabIndex = 8;
            this.pctExitLogin.TabStop = false;
            this.pctExitLogin.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pcthelpLogin
            // 
            this.pcthelpLogin.BackColor = System.Drawing.Color.Transparent;
            this.pcthelpLogin.Image = global::BeautyAndCosmetics.Properties.Resources._7914246;
            this.pcthelpLogin.Location = new System.Drawing.Point(551, 55);
            this.pcthelpLogin.Name = "pcthelpLogin";
            this.pcthelpLogin.Size = new System.Drawing.Size(44, 43);
            this.pcthelpLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcthelpLogin.TabIndex = 20;
            this.pcthelpLogin.TabStop = false;
            this.pcthelpLogin.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImage = global::BeautyAndCosmetics.Properties.Resources.Untitled_design__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 494);
            this.Controls.Add(this.pcthelpLogin);
            this.Controls.Add(this.pctExitLogin);
            this.Controls.Add(this.lblDisplaylogin);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.pctLogo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.panelLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctShowPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExitLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcthelpLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RJButton btnLogin;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.Panel panelLogin;
        private RJTextbox txtPassword;
        private RJTextbox txtUsername;
        private System.Windows.Forms.PictureBox pctPass;
        private System.Windows.Forms.PictureBox pctUser;
        private System.Windows.Forms.Label lblDisplaylogin;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pctShowPassword;
        private System.Windows.Forms.PictureBox pctExitLogin;
        private System.Windows.Forms.PictureBox pcthelpLogin;
    }
}