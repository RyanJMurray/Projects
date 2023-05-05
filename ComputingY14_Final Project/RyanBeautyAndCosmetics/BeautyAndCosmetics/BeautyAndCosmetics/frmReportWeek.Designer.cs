
namespace BeautyAndCosmetics
{
    partial class frmReportWeek
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
            this.rptNextWeekBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BeautyAndCosmetics_RMDataSet3 = new BeautyAndCosmetics.BeautyAndCosmetics_RMDataSet3();
            this.BeautyAndCosmetics_RMDataSet = new BeautyAndCosmetics.BeautyAndCosmetics_RMDataSet();
            this.DateGreaterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DateGreaterTableAdapter = new BeautyAndCosmetics.BeautyAndCosmetics_RMDataSetTableAdapters.DateGreaterTableAdapter();
            this.rptNextWeekTableAdapter = new BeautyAndCosmetics.BeautyAndCosmetics_RMDataSet3TableAdapters.rptNextWeekTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BeautyAndCosmetics_RMDataSet4 = new BeautyAndCosmetics.BeautyAndCosmetics_RMDataSet4();
            this.pctReturnSelect = new System.Windows.Forms.PictureBox();
            this.pctHelpmain = new System.Windows.Forms.PictureBox();
            this.pctExitMain = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rptNextWeekBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateGreaterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctReturnSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHelpmain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExitMain)).BeginInit();
            this.SuspendLayout();
            // 
            // rptNextWeekBindingSource
            // 
            this.rptNextWeekBindingSource.DataMember = "rptNextWeek";
            this.rptNextWeekBindingSource.DataSource = this.BeautyAndCosmetics_RMDataSet3;
            // 
            // BeautyAndCosmetics_RMDataSet3
            // 
            this.BeautyAndCosmetics_RMDataSet3.DataSetName = "BeautyAndCosmetics_RMDataSet3";
            this.BeautyAndCosmetics_RMDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BeautyAndCosmetics_RMDataSet
            // 
            this.BeautyAndCosmetics_RMDataSet.DataSetName = "BeautyAndCosmetics_RMDataSet";
            this.BeautyAndCosmetics_RMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DateGreaterBindingSource
            // 
            this.DateGreaterBindingSource.DataMember = "DateGreater";
            this.DateGreaterBindingSource.DataSource = this.BeautyAndCosmetics_RMDataSet;
            // 
            // DateGreaterTableAdapter
            // 
            this.DateGreaterTableAdapter.ClearBeforeFill = true;
            // 
            // rptNextWeekTableAdapter
            // 
            this.rptNextWeekTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "DataSetNextWeek";
            reportDataSource3.Value = this.rptNextWeekBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BeautyAndCosmetics.ReportNextWeek.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 61);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(665, 569);
            this.reportViewer1.TabIndex = 0;
            // 
            // BeautyAndCosmetics_RMDataSet4
            // 
            this.BeautyAndCosmetics_RMDataSet4.DataSetName = "BeautyAndCosmetics_RMDataSet4";
            this.BeautyAndCosmetics_RMDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pctReturnSelect
            // 
            this.pctReturnSelect.BackColor = System.Drawing.Color.Transparent;
            this.pctReturnSelect.Image = global::BeautyAndCosmetics.Properties.Resources._return;
            this.pctReturnSelect.Location = new System.Drawing.Point(542, 3);
            this.pctReturnSelect.Name = "pctReturnSelect";
            this.pctReturnSelect.Size = new System.Drawing.Size(44, 43);
            this.pctReturnSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctReturnSelect.TabIndex = 28;
            this.pctReturnSelect.TabStop = false;
            this.pctReturnSelect.Click += new System.EventHandler(this.pctReturnSelect_Click);
            // 
            // pctHelpmain
            // 
            this.pctHelpmain.BackColor = System.Drawing.Color.Transparent;
            this.pctHelpmain.Image = global::BeautyAndCosmetics.Properties.Resources._7914246;
            this.pctHelpmain.Location = new System.Drawing.Point(592, 3);
            this.pctHelpmain.Name = "pctHelpmain";
            this.pctHelpmain.Size = new System.Drawing.Size(44, 43);
            this.pctHelpmain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctHelpmain.TabIndex = 31;
            this.pctHelpmain.TabStop = false;
            this.pctHelpmain.Click += new System.EventHandler(this.pctHelpmain_Click);
            // 
            // pctExitMain
            // 
            this.pctExitMain.BackColor = System.Drawing.Color.Transparent;
            this.pctExitMain.Image = global::BeautyAndCosmetics.Properties.Resources._458594;
            this.pctExitMain.Location = new System.Drawing.Point(642, 3);
            this.pctExitMain.Name = "pctExitMain";
            this.pctExitMain.Size = new System.Drawing.Size(44, 43);
            this.pctExitMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctExitMain.TabIndex = 30;
            this.pctExitMain.TabStop = false;
            this.pctExitMain.Click += new System.EventHandler(this.pctExitMain_Click);
            // 
            // frmReportWeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(698, 658);
            this.Controls.Add(this.pctHelpmain);
            this.Controls.Add(this.pctExitMain);
            this.Controls.Add(this.pctReturnSelect);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmReportWeek";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReportWeek";
            this.Load += new System.EventHandler(this.frmReportWeek_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReportWeek_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.rptNextWeekBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateGreaterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctReturnSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHelpmain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExitMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource DateGreaterBindingSource;
        private BeautyAndCosmetics_RMDataSet BeautyAndCosmetics_RMDataSet;
        private System.Windows.Forms.BindingSource rptNextWeekBindingSource;
        private BeautyAndCosmetics_RMDataSet3 BeautyAndCosmetics_RMDataSet3;
        private BeautyAndCosmetics_RMDataSetTableAdapters.DateGreaterTableAdapter DateGreaterTableAdapter;
        private BeautyAndCosmetics_RMDataSet3TableAdapters.rptNextWeekTableAdapter rptNextWeekTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private BeautyAndCosmetics_RMDataSet4 BeautyAndCosmetics_RMDataSet4;
        private System.Windows.Forms.PictureBox pctReturnSelect;
        private System.Windows.Forms.PictureBox pctHelpmain;
        private System.Windows.Forms.PictureBox pctExitMain;
    }
}