
namespace BeautyAndCosmetics
{
    partial class frmTotalCustomerBooking
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rptTotalBookingCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BeautyAndCosmetics_RMDataSet12 = new BeautyAndCosmetics.BeautyAndCosmetics_RMDataSet12();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptTotalBookingCustomerTableAdapter = new BeautyAndCosmetics.BeautyAndCosmetics_RMDataSet12TableAdapters.rptTotalBookingCustomerTableAdapter();
            this.pctHelpmain = new System.Windows.Forms.PictureBox();
            this.pctExitMain = new System.Windows.Forms.PictureBox();
            this.pctReturnSelect = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rptTotalBookingCustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHelpmain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExitMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctReturnSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // rptTotalBookingCustomerBindingSource
            // 
            this.rptTotalBookingCustomerBindingSource.DataMember = "rptTotalBookingCustomer";
            this.rptTotalBookingCustomerBindingSource.DataSource = this.BeautyAndCosmetics_RMDataSet12;
            // 
            // BeautyAndCosmetics_RMDataSet12
            // 
            this.BeautyAndCosmetics_RMDataSet12.DataSetName = "BeautyAndCosmetics_RMDataSet12";
            this.BeautyAndCosmetics_RMDataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetTotalCustomerBooking";
            reportDataSource1.Value = this.rptTotalBookingCustomerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BeautyAndCosmetics.rptTotalCustomerBooking.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 73);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(508, 359);
            this.reportViewer1.TabIndex = 0;
            // 
            // rptTotalBookingCustomerTableAdapter
            // 
            this.rptTotalBookingCustomerTableAdapter.ClearBeforeFill = true;
            // 
            // pctHelpmain
            // 
            this.pctHelpmain.BackColor = System.Drawing.Color.Transparent;
            this.pctHelpmain.Image = global::BeautyAndCosmetics.Properties.Resources._7914246;
            this.pctHelpmain.Location = new System.Drawing.Point(426, 12);
            this.pctHelpmain.Name = "pctHelpmain";
            this.pctHelpmain.Size = new System.Drawing.Size(44, 43);
            this.pctHelpmain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctHelpmain.TabIndex = 22;
            this.pctHelpmain.TabStop = false;
            this.pctHelpmain.Click += new System.EventHandler(this.pctHelpmain_Click);
            // 
            // pctExitMain
            // 
            this.pctExitMain.BackColor = System.Drawing.Color.Transparent;
            this.pctExitMain.Image = global::BeautyAndCosmetics.Properties.Resources._458594;
            this.pctExitMain.Location = new System.Drawing.Point(476, 12);
            this.pctExitMain.Name = "pctExitMain";
            this.pctExitMain.Size = new System.Drawing.Size(44, 43);
            this.pctExitMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctExitMain.TabIndex = 20;
            this.pctExitMain.TabStop = false;
            this.pctExitMain.Click += new System.EventHandler(this.pctExitMain_Click);
            // 
            // pctReturnSelect
            // 
            this.pctReturnSelect.BackColor = System.Drawing.Color.Transparent;
            this.pctReturnSelect.Image = global::BeautyAndCosmetics.Properties.Resources._return;
            this.pctReturnSelect.Location = new System.Drawing.Point(376, 12);
            this.pctReturnSelect.Name = "pctReturnSelect";
            this.pctReturnSelect.Size = new System.Drawing.Size(44, 43);
            this.pctReturnSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctReturnSelect.TabIndex = 28;
            this.pctReturnSelect.TabStop = false;
            this.pctReturnSelect.Click += new System.EventHandler(this.pctReturnSelect_Click);
            // 
            // frmTotalCustomerBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(543, 467);
            this.Controls.Add(this.pctReturnSelect);
            this.Controls.Add(this.pctHelpmain);
            this.Controls.Add(this.pctExitMain);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTotalCustomerBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTotalCustomerBooking";
            this.Load += new System.EventHandler(this.frmTotalCustomerBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rptTotalBookingCustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHelpmain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExitMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctReturnSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rptTotalBookingCustomerBindingSource;
        private BeautyAndCosmetics_RMDataSet12 BeautyAndCosmetics_RMDataSet12;
        private BeautyAndCosmetics_RMDataSet12TableAdapters.rptTotalBookingCustomerTableAdapter rptTotalBookingCustomerTableAdapter;
        private System.Windows.Forms.PictureBox pctHelpmain;
        private System.Windows.Forms.PictureBox pctExitMain;
        private System.Windows.Forms.PictureBox pctReturnSelect;
    }
}