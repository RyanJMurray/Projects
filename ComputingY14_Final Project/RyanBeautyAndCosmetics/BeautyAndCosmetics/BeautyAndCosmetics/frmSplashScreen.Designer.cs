namespace BeautyAndCosmetics
{
    partial class frmSplashScreen
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
            this.components = new System.ComponentModel.Container();
            this.tmrSplash = new System.Windows.Forms.Timer(this.components);
            this.progressSplash = new System.Windows.Forms.ProgressBar();
            this.pctLogoSplash = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogoSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrSplash
            // 
            this.tmrSplash.Interval = 1000;
            this.tmrSplash.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressSplash
            // 
            this.progressSplash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.progressSplash.ForeColor = System.Drawing.Color.Red;
            this.progressSplash.Location = new System.Drawing.Point(87, 263);
            this.progressSplash.MarqueeAnimationSpeed = 110;
            this.progressSplash.Maximum = 110;
            this.progressSplash.Name = "progressSplash";
            this.progressSplash.Size = new System.Drawing.Size(370, 28);
            this.progressSplash.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressSplash.TabIndex = 1;
            // 
            // pctLogoSplash
            // 
            this.pctLogoSplash.BackColor = System.Drawing.Color.Transparent;
            this.pctLogoSplash.Image = global::BeautyAndCosmetics.Properties.Resources.SimpsonsLogo;
            this.pctLogoSplash.Location = new System.Drawing.Point(123, 109);
            this.pctLogoSplash.Name = "pctLogoSplash";
            this.pctLogoSplash.Size = new System.Drawing.Size(296, 114);
            this.pctLogoSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogoSplash.TabIndex = 4;
            this.pctLogoSplash.TabStop = false;
            // 
            // frmSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(533, 367);
            this.Controls.Add(this.pctLogoSplash);
            this.Controls.Add(this.progressSplash);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplashScreen";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctLogoSplash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrSplash;
        private System.Windows.Forms.ProgressBar progressSplash;
        private System.Windows.Forms.PictureBox pctLogoSplash;
    }
}

