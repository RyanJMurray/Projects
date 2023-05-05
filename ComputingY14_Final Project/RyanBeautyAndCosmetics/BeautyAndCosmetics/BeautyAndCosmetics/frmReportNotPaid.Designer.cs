
namespace BeautyAndCosmetics
{
    partial class frmReportNotPaid
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.RptCustomersNotPaidBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BeautyAndCosmetics_RMDataSet7 = new BeautyAndCosmetics.BeautyAndCosmetics_RMDataSet7();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RptCustomersNotPaidTableAdapter = new BeautyAndCosmetics.BeautyAndCosmetics_RMDataSet7TableAdapters.RptCustomersNotPaidTableAdapter();
            this.BeautyAndCosmetics_RMDataSet8 = new BeautyAndCosmetics.BeautyAndCosmetics_RMDataSet8();
            this.pctReturnSelect = new System.Windows.Forms.PictureBox();
            this.pctHelpmain = new System.Windows.Forms.PictureBox();
            this.pctExitMain = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RptCustomersNotPaidBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctReturnSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHelpmain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExitMain)).BeginInit();
            this.SuspendLayout();
            // 
            // RptCustomersNotPaidBindingSource
            // 
            this.RptCustomersNotPaidBindingSource.DataMember = "RptCustomersNotPaid";
            this.RptCustomersNotPaidBindingSource.DataSource = this.BeautyAndCosmetics_RMDataSet7;
            // 
            // BeautyAndCosmetics_RMDataSet7
            // 
            this.BeautyAndCosmetics_RMDataSet7.DataSetName = "BeautyAndCosmetics_RMDataSet7";
            this.BeautyAndCosmetics_RMDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.RptCustomersNotPaidBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BeautyAndCosmetics.rptNotPaid.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(33, 57);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(568, 358);
            this.reportViewer1.TabIndex = 0;
            // 
            // RptCustomersNotPaidTableAdapter
            // 
            this.RptCustomersNotPaidTableAdapter.ClearBeforeFill = true;
            // 
            // BeautyAndCosmetics_RMDataSet8
            // 
            this.BeautyAndCosmetics_RMDataSet8.DataSetName = "BeautyAndCosmetics_RMDataSet8";
            this.BeautyAndCosmetics_RMDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pctReturnSelect
            // 
            this.pctReturnSelect.BackColor = System.Drawing.Color.Transparent;
            this.pctReturnSelect.Image = global::BeautyAndCosmetics.Properties.Resources._return;
            this.pctReturnSelect.Location = new System.Drawing.Point(481, 2);
            this.pctReturnSelect.Name = "pctReturnSelect";
            this.pctReturnSelect.Size = new System.Drawing.Size(44, 43);
            this.pctReturnSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctReturnSelect.TabIndex = 27;
            this.pctReturnSelect.TabStop = false;
            this.pctReturnSelect.Click += new System.EventHandler(this.pctReturnSelect_Click);
            // 
            // pctHelpmain
            // 
            this.pctHelpmain.BackColor = System.Drawing.Color.Transparent;
            this.pctHelpmain.Image = global::BeautyAndCosmetics.Properties.Resources._7914246;
            this.pctHelpmain.Location = new System.Drawing.Point(531, 2);
            this.pctHelpmain.Name = "pctHelpmain";
            this.pctHelpmain.Size = new System.Drawing.Size(44, 43);
            this.pctHelpmain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctHelpmain.TabIndex = 29;
            this.pctHelpmain.TabStop = false;
            this.pctHelpmain.Click += new System.EventHandler(this.pctHelpmain_Click);
            // 
            // pctExitMain
            // 
            this.pctExitMain.BackColor = System.Drawing.Color.Transparent;
            this.pctExitMain.Image = global::BeautyAndCosmetics.Properties.Resources._458594;
            this.pctExitMain.Location = new System.Drawing.Point(581, 2);
            this.pctExitMain.Name = "pctExitMain";
            this.pctExitMain.Size = new System.Drawing.Size(44, 43);
            this.pctExitMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctExitMain.TabIndex = 28;
            this.pctExitMain.TabStop = false;
            this.pctExitMain.Click += new System.EventHandler(this.pctExitMain_Click);
            // 
            // frmReportNotPaid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(626, 450);
            this.Controls.Add(this.pctHelpmain);
            this.Controls.Add(this.pctExitMain);
            this.Controls.Add(this.pctReturnSelect);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmReportNotPaid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReportNotPaid";
            this.Load += new System.EventHandler(this.frmReportNotPaid_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReportNotPaid_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.RptCustomersNotPaidBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctReturnSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHelpmain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExitMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource RptCustomersNotPaidBindingSource;
        private BeautyAndCosmetics_RMDataSet7 BeautyAndCosmetics_RMDataSet7;
        private BeautyAndCosmetics_RMDataSet7TableAdapters.RptCustomersNotPaidTableAdapter RptCustomersNotPaidTableAdapter;
        private BeautyAndCosmetics_RMDataSet8 BeautyAndCosmetics_RMDataSet8;
        private System.Windows.Forms.PictureBox pctReturnSelect;
        private System.Windows.Forms.PictureBox pctHelpmain;
        private System.Windows.Forms.PictureBox pctExitMain;
    }
}