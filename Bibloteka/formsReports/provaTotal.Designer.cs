namespace Bibloteka.formsReports
{
    partial class provaTotal
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
            this.liberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.provaTotal1 = new Bibloteka.dataset.ProvaTotal();
            this.liberTableAdapter = new Bibloteka.dataset.ProvaTotalTableAdapters.LiberTableAdapter();
            this.provaTotal1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.liberBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.liberBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provaTotal1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provaTotal1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liberBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.liberBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bibloteka.reports.provaTotal.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // liberBindingSource
            // 
            this.liberBindingSource.DataMember = "Liber";
            this.liberBindingSource.DataSource = this.provaTotal1;
            // 
            // provaTotal1
            // 
            this.provaTotal1.DataSetName = "ProvaTotal";
            this.provaTotal1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // liberTableAdapter
            // 
            this.liberTableAdapter.ClearBeforeFill = true;
            // 
            // provaTotal1BindingSource
            // 
            this.provaTotal1BindingSource.DataSource = this.provaTotal1;
            this.provaTotal1BindingSource.Position = 0;
            // 
            // liberBindingSource1
            // 
            this.liberBindingSource1.DataMember = "Liber";
            this.liberBindingSource1.DataSource = this.provaTotal1;
            // 
            // provaTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "provaTotal";
            this.Text = "provaTotal";
            this.Load += new System.EventHandler(this.provaTotal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.liberBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provaTotal1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provaTotal1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liberBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dataset.ProvaTotal provaTotal1;
        private System.Windows.Forms.BindingSource liberBindingSource;
        private dataset.ProvaTotalTableAdapters.LiberTableAdapter liberTableAdapter;
        private System.Windows.Forms.BindingSource provaTotal1BindingSource;
        private System.Windows.Forms.BindingSource liberBindingSource1;
    }
}