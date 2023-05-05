using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BeautyAndCosmetics
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }


        public void SplashSorting(string form)
        {
            switch (form)
            {

                case "Cosmetics":

                    frmTableSelect a = new frmTableSelect();
                    this.Hide();
                    a.Show();

                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
          //  progressSplash.ForeColor = Color.HotPink;
            progressSplash.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

            //this.timer1.Start();

            //Timer tma = new Timer();
            //tma.Interval = 10000;

            //tma.Tick += timer1_Tick;
            //tma.Enabled = true;
            //tma.Start();

            tmrSplash.Enabled = true;

            progressSplash.Maximum = 100;
            progressSplash.Minimum = 0;
            progressSplash.Step = 20;
            tmrSplash.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressSplash.Maximum = 100;
            progressSplash.PerformStep();
            if (progressSplash.Value == 100)
            {
                if(ClassLogin.Splash == "Cosmetics")
                {
                SplashSorting(ClassLogin.Splash);
                tmrSplash.Enabled = false;

                }
                else
                {
               tmrSplash.Enabled = false;   //Add this line
                frmMainMenu a = new frmMainMenu();    //Add this line
                a.Show();
                this.Hide();
                }


               
            }

                //this.progressBar1.Increment(10);

                //if(progressBar1.Value == 101)
                //{
                //    Form2 a = new Form2();
                //    this.Hide();
                //    a.Show();
                //    ((Timer)sender).Stop();
                //}


            }
    }
}
