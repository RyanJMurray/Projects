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
    public partial class frmTotalCustomerBooking : Form
    {
        public frmTotalCustomerBooking()
        {
            InitializeComponent();
        }

        private void frmTotalCustomerBooking_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BeautyAndCosmetics_RMDataSet12.rptTotalBookingCustomer' table. You can move, or remove it, as needed.
            this.rptTotalBookingCustomerTableAdapter.Fill(this.BeautyAndCosmetics_RMDataSet12.rptTotalBookingCustomer);

            this.reportViewer1.RefreshReport();
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

        private void pctLogOutMain_Click(object sender, EventArgs e)
        {

        }

        private void pctHelpmain_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Resources\ComputingUserGuide.pdf");

        }

        private void pctReturnSelect_Click(object sender, EventArgs e)
        {
            frmMainMenu m = new frmMainMenu();
            this.Hide();
            m.Show();
        }
    }
}
