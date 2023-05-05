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
    public partial class frmReportWeek : Form
    {
        public frmReportWeek()
        {
            InitializeComponent();
        }

        private void frmReportWeek_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BeautyAndCosmetics_RMDataSet.DateGreater' table. You can move, or remove it, as needed.
            this.DateGreaterTableAdapter.Fill(this.BeautyAndCosmetics_RMDataSet.DateGreater);
            // TODO: This line of code loads data into the 'BeautyAndCosmetics_RMDataSet3.rptNextWeek' table. You can move, or remove it, as needed.
            this.rptNextWeekTableAdapter.Fill(this.BeautyAndCosmetics_RMDataSet3.rptNextWeek);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void pctReturnSelect_Click(object sender, EventArgs e)
        {
           frmMainMenu a = new frmMainMenu();
            this.Hide();
            a.Show();
        }

        private void frmReportWeek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.H)
            {
                System.Diagnostics.Process.Start(@"Resources\ComputingUserGuide.pdf");
            }
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

        private void pctHelpmain_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Resources\ComputingUserGuide.pdf");

        }
    }
}
