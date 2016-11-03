namespace Chocoholics.Reports
{
    partial class frmReports
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rpt_summaryforthelastweekBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetChocAnSummary_LW = new Chocoholics.Reports.DataSetChocAnSummary_LW();
            this.rpt_providerchargesforthelastweekBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetProviderCharges_LW = new Chocoholics.Reports.DataSetProviderCharges_LW();
            this.rpt_servicesprovidedinthelastweekBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetMemberServices = new Chocoholics.Reports.DataSetMemberServices();
            this.rpt_simulateEFTextractBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetETF = new Chocoholics.Reports.DataSetETF();
            this.listServicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetServicesDirectory = new Chocoholics.Reports.DataSetServicesDirectory();
            this.lblClock = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSetTime = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer5 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblResults = new System.Windows.Forms.Label();
            this.backgroundWorkerReports = new System.ComponentModel.BackgroundWorker();
            this.progressBarReports = new System.Windows.Forms.ProgressBar();
            this.rpt_simulateEFTextractTableAdapter = new Chocoholics.Reports.DataSetETFTableAdapters.rpt_simulateEFTextractTableAdapter();
            this.listServicesTableAdapter = new Chocoholics.Reports.DataSetServicesDirectoryTableAdapters.listServicesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.rpt_summaryforthelastweekBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetChocAnSummary_LW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt_providerchargesforthelastweekBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetProviderCharges_LW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt_servicesprovidedinthelastweekBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetMemberServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt_simulateEFTextractBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetETF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listServicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetServicesDirectory)).BeginInit();
            this.SuspendLayout();
            // 
            // rpt_summaryforthelastweekBindingSource
            // 
            this.rpt_summaryforthelastweekBindingSource.DataMember = "rpt_summaryforthelastweek";
            this.rpt_summaryforthelastweekBindingSource.DataSource = this.DataSetChocAnSummary_LW;
            // 
            // DataSetChocAnSummary_LW
            // 
            this.DataSetChocAnSummary_LW.DataSetName = "DataSetChocAnSummary_LW";
            this.DataSetChocAnSummary_LW.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpt_providerchargesforthelastweekBindingSource
            // 
            this.rpt_providerchargesforthelastweekBindingSource.DataMember = "rpt_providerchargesforthelastweek";
            this.rpt_providerchargesforthelastweekBindingSource.DataSource = this.DataSetProviderCharges_LW;
            // 
            // DataSetProviderCharges_LW
            // 
            this.DataSetProviderCharges_LW.DataSetName = "DataSetProviderCharges_LW";
            this.DataSetProviderCharges_LW.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpt_servicesprovidedinthelastweekBindingSource
            // 
            this.rpt_servicesprovidedinthelastweekBindingSource.DataMember = "rpt_servicesprovidedinthelastweek";
            this.rpt_servicesprovidedinthelastweekBindingSource.DataSource = this.DataSetMemberServices;
            // 
            // DataSetMemberServices
            // 
            this.DataSetMemberServices.DataSetName = "DataSetMemberServices";
            this.DataSetMemberServices.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpt_simulateEFTextractBindingSource
            // 
            this.rpt_simulateEFTextractBindingSource.DataMember = "rpt_simulateEFTextract";
            this.rpt_simulateEFTextractBindingSource.DataSource = this.DataSetETF;
            // 
            // DataSetETF
            // 
            this.DataSetETF.DataSetName = "DataSetETF";
            this.DataSetETF.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listServicesBindingSource
            // 
            this.listServicesBindingSource.DataMember = "listServices";
            this.listServicesBindingSource.DataSource = this.DataSetServicesDirectory;
            // 
            // DataSetServicesDirectory
            // 
            this.DataSetServicesDirectory.DataSetName = "DataSetServicesDirectory";
            this.DataSetServicesDirectory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.Location = new System.Drawing.Point(22, 35);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(134, 31);
            this.lblClock.TabIndex = 0;
            this.lblClock.Text = "Loading...";
            this.lblClock.TextChanged += new System.EventHandler(this.lblClock_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSetTime
            // 
            this.btnSetTime.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSetTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetTime.Location = new System.Drawing.Point(59, 71);
            this.btnSetTime.Name = "btnSetTime";
            this.btnSetTime.Size = new System.Drawing.Size(148, 60);
            this.btnSetTime.TabIndex = 1;
            this.btnSetTime.Text = "Fast forward to 11:59:45 pm";
            this.btnSetTime.UseVisualStyleBackColor = false;
            this.btnSetTime.Click += new System.EventHandler(this.btnSetTime_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 82;
            reportDataSource1.Name = "ChocAnSummary_LW";
            reportDataSource1.Value = this.rpt_summaryforthelastweekBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Chocoholics.Reports.rptChocAnSummary_LW.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(28, 178);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(157, 150);
            this.reportViewer1.TabIndex = 2;
            this.reportViewer1.Visible = false;
            // 
            // reportViewer2
            // 
            reportDataSource2.Name = "ProviderCharges";
            reportDataSource2.Value = this.rpt_providerchargesforthelastweekBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Chocoholics.Reports.rptProviderCharges.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(202, 178);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(155, 150);
            this.reportViewer2.TabIndex = 4;
            this.reportViewer2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "--Reports saved to C:\\POC--";
            // 
            // reportViewer3
            // 
            reportDataSource3.Name = "DataSetMemberServices";
            reportDataSource3.Value = this.rpt_servicesprovidedinthelastweekBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "Chocoholics.Reports.rptMemberServicesProvided_LW.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(372, 178);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(153, 150);
            this.reportViewer3.TabIndex = 7;
            this.reportViewer3.Visible = false;
            // 
            // reportViewer4
            // 
            reportDataSource4.Name = "DataSetEFT_Extract";
            reportDataSource4.Value = this.rpt_simulateEFTextractBindingSource;
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer4.LocalReport.ReportEmbeddedResource = "Chocoholics.Reports.rptEFT_Extract.rdlc";
            this.reportViewer4.Location = new System.Drawing.Point(531, 178);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.Size = new System.Drawing.Size(153, 150);
            this.reportViewer4.TabIndex = 8;
            this.reportViewer4.Visible = false;
            // 
            // reportViewer5
            // 
            reportDataSource5.Name = "DataSetServicesDirectory";
            reportDataSource5.Value = this.listServicesBindingSource;
            this.reportViewer5.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer5.LocalReport.ReportEmbeddedResource = "Chocoholics.Reports.rptServicesDirectory.rdlc";
            this.reportViewer5.Location = new System.Drawing.Point(691, 178);
            this.reportViewer5.Name = "reportViewer5";
            this.reportViewer5.Size = new System.Drawing.Size(145, 150);
            this.reportViewer5.TabIndex = 9;
            this.reportViewer5.Visible = false;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.Location = new System.Drawing.Point(228, 97);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(131, 18);
            this.lblResults.TabIndex = 16;
            this.lblResults.Text = "Running Reports...";
            this.lblResults.Visible = false;
            this.lblResults.Click += new System.EventHandler(this.lblResults_Click);
            // 
            // backgroundWorkerReports
            // 
            this.backgroundWorkerReports.WorkerReportsProgress = true;
            this.backgroundWorkerReports.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReports_DoWork);
            this.backgroundWorkerReports.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerReports_ProgressChanged);
            this.backgroundWorkerReports.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReports_RunWorkerCompleted);
            // 
            // progressBarReports
            // 
            this.progressBarReports.Location = new System.Drawing.Point(226, 71);
            this.progressBarReports.Name = "progressBarReports";
            this.progressBarReports.Size = new System.Drawing.Size(299, 23);
            this.progressBarReports.TabIndex = 17;
            this.progressBarReports.Visible = false;
            // 
            // rpt_simulateEFTextractTableAdapter
            // 
            this.rpt_simulateEFTextractTableAdapter.ClearBeforeFill = true;
            // 
            // listServicesTableAdapter
            // 
            this.listServicesTableAdapter.ClearBeforeFill = true;
            // 
            // frmReports
            // 
            this.ClientSize = new System.Drawing.Size(539, 359);
            this.Controls.Add(this.progressBarReports);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.reportViewer5);
            this.Controls.Add(this.reportViewer3);
            this.Controls.Add(this.reportViewer4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnSetTime);
            this.Controls.Add(this.lblClock);
            this.Name = "frmReports";
            ((System.ComponentModel.ISupportInitialize)(this.rpt_summaryforthelastweekBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetChocAnSummary_LW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt_providerchargesforthelastweekBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetProviderCharges_LW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt_servicesprovidedinthelastweekBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetMemberServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt_simulateEFTextractBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetETF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listServicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetServicesDirectory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSetTime;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private DataSetProviderCharges_LW DataSetProviderCharges_LW;
        private System.Windows.Forms.BindingSource rpt_providerchargesforthelastweekBindingSource;
        private DataSetProviderCharges_LWTableAdapters.rpt_providerchargesforthelastweekTableAdapter rpt_providerchargesforthelastweekTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource rpt_summaryforthelastweekBindingSource;
        private DataSetChocAnSummary_LW DataSetChocAnSummary_LW;
        private DataSetChocAnSummary_LWTableAdapters.rpt_summaryforthelastweekTableAdapter rpt_summaryforthelastweekTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.BindingSource rpt_servicesprovidedinthelastweekBindingSource;
        private DataSetMemberServices DataSetMemberServices;
        private DataSetMemberServicesTableAdapters.rpt_servicesprovidedinthelastweekTableAdapter rpt_servicesprovidedinthelastweekTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer4;
        private System.Windows.Forms.BindingSource rpt_simulateEFTextractBindingSource;
        private DataSetETF DataSetETF;
        private DataSetETFTableAdapters.rpt_simulateEFTextractTableAdapter rpt_simulateEFTextractTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer5;
        private System.Windows.Forms.BindingSource listServicesBindingSource;
        private DataSetServicesDirectory DataSetServicesDirectory;
        private DataSetServicesDirectoryTableAdapters.listServicesTableAdapter listServicesTableAdapter;
        private System.Windows.Forms.Label lblResults;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReports;
        private System.Windows.Forms.ProgressBar progressBarReports;
    }
}