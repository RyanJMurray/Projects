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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
        }

       

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Section is Currently Under Maintainance");

        }

        private void rjButton4_Click(object sender, EventArgs e)
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

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("This Section is Currently Under Maintainance");

        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            ClassLogin.Splash = "Cosmetics";
            frmSplashScreen a = new frmSplashScreen();
            this.Hide();
            a.Show();

        }

        private void rjButton6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Section is Currently Under Maintainance");
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Section is Currently Under Maintainance");

        }

        private void rjButton1_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pctExitLogin_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Section is Currently Under Maintainance");
           
        }

        private void pctCosmetics_Click(object sender, EventArgs e)
        {
            ClassLogin.Splash = "Cosmetics";
            frmSplashScreen a = new frmSplashScreen();
            this.Hide();
            a.Show();

               
        }

        private void pctOffice_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Section is Currently Under Maintainance");

        }

        private void pctWedding_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Section is Currently Under Maintainance");

        }

        private void pctDressmaking_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Section is Currently Under Maintainance");

        }

        private void tableSelectFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTableSelect a = new frmTableSelect();
            this.Hide();
                a.Show();
        }

        private void addBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooking a = new frmBooking();
            this.Hide();
            a.Show();
        }

        private void updateBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "BookingUpdate";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void addRoomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "Customer";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "Product";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void addStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "Staff";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void addSlotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "Slots";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void addRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "Room";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void updateRoomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "CustomerUpdate";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void deleteRoomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "CustomerDelete";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void deleteBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "BookingDelete";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void deleteRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "RoomDelete";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void updateRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "RoomUpdate";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void deleteSlotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "SlotsDelete";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void updateSlotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "SlotsUpdate";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void deleteStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "StaffDelete";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void updateStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "StaffUpdate";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void deleteProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "ProductDelete";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void updateProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "ProductUpdate";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {


        }

        private void frmMainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.H)
            {
                System.Diagnostics.Process.Start(@"Resources\ComputingUserGuide.pdf");
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Resources\ComputingUserGuide.pdf");

        }

        private void viewCustomerWhoHaventPaidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportNotPaid a = new frmReportNotPaid();
            this.Hide();
            a.Show();
        }

        private void viewBookingsWithinTheNextWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportWeek a = new frmReportWeek();
            this.Hide();
            a.Show();
        }

        private void viewTotalBookingsMadeByCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTotalCustomerBooking a = new frmTotalCustomerBooking();
            this.Hide();
            a.Show();
        }
    }
}
