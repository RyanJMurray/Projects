
namespace BeautyAndCosmetics
{
    partial class Form2
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BeautyAndCosmetics_RMDataSet = new BeautyAndCosmetics.BeautyAndCosmetics_RMDataSet();
            this.CustomerTableAdapter = new BeautyAndCosmetics.BeautyAndCosmetics_RMDataSetTableAdapters.CustomerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1Test";
            reportDataSource1.Value = this.CustomerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BeautyAndCosmetics.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(55, 33);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(672, 357);
            this.reportViewer1.TabIndex = 0;
            // 
            // CustomerBindingSource
            // 
            this.CustomerBindingSource.DataMember = "Customer";
            this.CustomerBindingSource.DataSource = this.BeautyAndCosmetics_RMDataSet;
            // 
            // BeautyAndCosmetics_RMDataSet
            // 
            this.BeautyAndCosmetics_RMDataSet.DataSetName = "BeautyAndCosmetics_RMDataSet";
            this.BeautyAndCosmetics_RMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CustomerTableAdapter
            // 
            this.CustomerTableAdapter.ClearBeforeFill = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeautyAndCosmetics_RMDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CustomerBindingSource;
        private BeautyAndCosmetics_RMDataSet BeautyAndCosmetics_RMDataSet;
        private BeautyAndCosmetics_RMDataSetTableAdapters.CustomerTableAdapter CustomerTableAdapter;
    }
}