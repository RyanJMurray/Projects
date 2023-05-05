using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeautyAndCosmetics
{
    public partial class frmTableSelect : Form
    {
        public frmTableSelect()
        {
            InitializeComponent();
        }

        private void rjButton6_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "Customer";
            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void rjButton7_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "Product";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void rjButton8_Click(object sender, EventArgs e)
        {
            const string message =
     "Are You Sure You Want To Sign Out";
            const string caption = "Singing Out Of The System...";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);





            if (result == DialogResult.OK)
            {
                frmLogin a = new frmLogin();
                this.Hide();
                a.Show();
            }

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "Slots";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "Staff";
            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "BookingSlots";
            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "Rooms";
            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
         
            frmBooking d = new frmBooking();
            this.Hide();
            d.Show();
        }

        private void frmTableSelect_Load(object sender, EventArgs e)
        {

        }

        private void btnExitSelect_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPreviousTable_Click(object sender, EventArgs e)
        {
            frmMainMenu a = new frmMainMenu();
            this.Hide();
            a.Show();
        }

        private void pctExitMain_Click(object sender, EventArgs e)
        {
            const string message =
"Are You Sure You Want To Exit?";
            const string caption = "Exit Applicaiton";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);





            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void pctLogOutSelect_Click(object sender, EventArgs e)
        {
            const string message =
"Are You Sure You Want To Log Out?";
            const string caption = "Log Out";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);





            if (result == DialogResult.OK)
            {
                frmLogin a = new frmLogin();
                this.Hide();
                a.Show();
            }
        }

        private void pctReturnSelect_Click(object sender, EventArgs e)
        {
            const string message =
"Are You Sure You Want To Return to the Previous Form?";
            const string caption = "Return?";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);





            if (result == DialogResult.OK)
            {
                frmMainMenu a = new frmMainMenu();
                this.Hide();
                a.Show();

            }
        }

        private void pcthelpLogin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Resources\ComputingUserGuide.pdf");

        }

        private void frmTableSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void frmTableSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.H)
            {
                System.Diagnostics.Process.Start(@"Resources\ComputingUserGuide.pdf");
            }
        }
    }
}
