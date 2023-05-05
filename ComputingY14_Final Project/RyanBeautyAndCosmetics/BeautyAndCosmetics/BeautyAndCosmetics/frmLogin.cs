using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BeautyAndCosmetics
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        int Attempts;


        public void LockingOut()
        {
            switch (Attempts)
            {

                case 1:

                    MessageBox.Show("Login Details Are Incorrect, You Have 2 Attempts Remaining");
                    break;

                case 2:

                    MessageBox.Show("Login Details Are Incorrect, You Have 1 Attempts Remaining");
                    break;

                case 3:


                   
                    
                         MessageBox.Show("You have temporarily been locked out, please wait " + counter.ToString() + " Seconds until you can attempt to login again");
                    timer1 = new System.Windows.Forms.Timer();
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Interval = 1000; // 1 second
                    timer1.Start();
                    txtPassword.Bordercolour = Color.Red;
                    txtUsername.Bordercolour = Color.Red;



                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;

                    
              
                    break;

                case 4:

                    MessageBox.Show("You are currently locked out, please wait " + counter.ToString() + " Seconds until you can attempt to log in again");


                    break;

            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

          

                try
            {
                ClassLogin a = new ClassLogin(txtUsername.Texts, txtPassword.Texts);


                ConnectionString.Connect.Close();

                bool login = false;
                string user = txtUsername.Texts;
                string pass = txtPassword.Texts;
                ConnectionString.Connect.Open();
                SqlCommand command = new SqlCommand("LOGIN", ConnectionString.Connect);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    if (read["Username"].ToString() == user && read["Password"].ToString() == pass)
                    {
                        login = true;
                    }
                }
                if (login == true)
                {
                    frmSplashScreen s = new frmSplashScreen();
                    this.Hide();
                    s.Show();
                }
                else
                {
                    if (login == false)

                    {
                        if(Attempts == 4)
                        {
                            Attempts = 3;
                            Attempts = Attempts + 1;
                            LockingOut();
                            //add this in testing as not working
                        }
                        else
                        {
                       Attempts = Attempts + 1;
                        LockingOut();
                        }

                       


                        
                    }
                }

            }
            catch(Exception ex)
            {
              
                MessageBox.Show(ex.Message);

               
            }

           


        }
        private int counter = 10;


     

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                txtUsername.Clear();
                txtPassword.Clear();
                Attempts = 0;
                timer1.Stop();
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
                txtUsername.Bordercolour = Color.MediumSeaGreen;
                txtPassword.Bordercolour = Color.MediumSeaGreen;
                counter = 10;
            }
            
        }


        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void rjTextbox1_Load(object sender, EventArgs e)
        {

        }

        private void rjTextbox1__TextChanged(object sender, EventArgs e)
        {
          
        }

        private void rjTextbox3__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjButton1_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.Yellow;
        }

        private void txtPass_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void txtPass_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = false;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = false;
            pctShowPassword.Image = Properties.Resources.EyeNo;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = true;
            pctShowPassword.Image = Properties.Resources.eye;

        }

        private void pctShowPassword_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            const string message =
"Are You Sure You Want To Exit?";
            const string caption = "Exit System";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);





            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Resources\ComputingUserGuide.pdf");

        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
    }
    
}
