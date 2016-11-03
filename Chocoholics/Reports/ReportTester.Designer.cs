namespace Chocoholics.Reports
{
    partial class ReportTester
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
            this.rpt_providerchargesforthelastweekTableAdapter = new Chocoholics.Reports.DataSetProviderCharges_LWTableAdapters.rpt_providerchargesforthelastweekTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.rpt_summaryforthelastweekTableAdapter = new Chocoholics.Reports.DataSetChocAnSummary_LWTableAdapters.rpt_summaryforthelastweekTableAdapter();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rpt_servicesprovidedinthelastweekTableAdapter = new Chocoholics.Reports.DataSetMemberServicesTableAdapters.rpt_servicesprovidedinthelastweekTableAdapter();
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rpt_simulateEFTextractTableAdapter = new Chocoholics.Reports.DataSetETFTableAdapters.rpt_simulateEFTextractTableAdapter();
            this.reportViewer5 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.listServicesTableAdapter = new Chocoholics.Reports.DataSetServicesDirectoryTableAdapters.listServicesTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.txtActiveMember = new System.Windows.Forms.TextBox();
            this.btnActiveMember = new System.Windows.Forms.Button();
            this.btnActiveProvider = new System.Windows.Forms.Button();
            this.txtActiveProvider = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblResults = new System.Windows.Forms.Label();
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
            this.btnSetTime.Location = new System.Drawing.Point(28, 83);
            this.btnSetTime.Name = "btnSetTime";
            this.btnSetTime.Size = new System.Drawing.Size(170, 23);
            this.btnSetTime.TabIndex = 1;
            this.btnSetTime.Text = "Fast forward to almost midnight";
            this.btnSetTime.UseVisualStyleBackColor = true;
            this.btnSetTime.Click += new System.EventHandler(this.btnSetTime_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 82;
            reportDataSource1.Name = "ChocAnSummary_LW";
            reportDataSource1.Value = this.rpt_summaryforthelastweekBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Chocoholics.Reports.rptChocAnSummary_LW.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(28, 150);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(157, 150);
            this.reportViewer1.TabIndex = 2;
            this.reportViewer1.Visible = false;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // reportViewer2
            // 
            reportDataSource2.Name = "ProviderCharges";
            reportDataSource2.Value = this.rpt_providerchargesforthelastweekBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Chocoholics.Reports.rptProviderCharges.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(202, 150);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(155, 150);
            this.reportViewer2.TabIndex = 4;
            this.reportViewer2.Visible = false;
            this.reportViewer2.Load += new System.EventHandler(this.reportViewer2_Load);
            // 
            // rpt_providerchargesforthelastweekTableAdapter
            // 
            this.rpt_providerchargesforthelastweekTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "--Reports saved to C:\\POC at midnight--";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // rpt_summaryforthelastweekTableAdapter
            // 
            this.rpt_summaryforthelastweekTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer3
            // 
            reportDataSource3.Name = "DataSetMemberServices";
            reportDataSource3.Value = this.rpt_servicesprovidedinthelastweekBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "Chocoholics.Reports.rptMemberServicesProvided_LW.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(372, 150);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(153, 150);
            this.reportViewer3.TabIndex = 7;
            this.reportViewer3.Visible = false;
            // 
            // rpt_servicesprovidedinthelastweekTableAdapter
            // 
            this.rpt_servicesprovidedinthelastweekTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer4
            // 
            reportDataSource4.Name = "DataSetEFT_Extract";
            reportDataSource4.Value = this.rpt_simulateEFTextractBindingSource;
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer4.LocalReport.ReportEmbeddedResource = "Chocoholics.Reports.rptEFT_Extract.rdlc";
            this.reportViewer4.Location = new System.Drawing.Point(531, 150);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.Size = new System.Drawing.Size(153, 150);
            this.reportViewer4.TabIndex = 8;
            this.reportViewer4.Visible = false;
            this.reportViewer4.Load += new System.EventHandler(this.reportViewer4_Load);
            // 
            // rpt_simulateEFTextractTableAdapter
            // 
            this.rpt_simulateEFTextractTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer5
            // 
            reportDataSource5.Name = "DataSetServicesDirectory";
            reportDataSource5.Value = this.listServicesBindingSource;
            this.reportViewer5.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer5.LocalReport.ReportEmbeddedResource = "Chocoholics.Reports.rptServicesDirectory.rdlc";
            this.reportViewer5.Location = new System.Drawing.Point(691, 150);
            this.reportViewer5.Name = "reportViewer5";
            this.reportViewer5.Size = new System.Drawing.Size(145, 150);
            this.reportViewer5.TabIndex = 9;
            this.reportViewer5.Visible = false;
            // 
            // listServicesTableAdapter
            // 
            this.listServicesTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Active Member Report - Enter Member ID or blank (for all)";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtActiveMember
            // 
            this.txtActiveMember.Location = new System.Drawing.Point(512, 83);
            this.txtActiveMember.Name = "txtActiveMember";
            this.txtActiveMember.Size = new System.Drawing.Size(100, 20);
            this.txtActiveMember.TabIndex = 11;
            this.txtActiveMember.Visible = false;
            // 
            // btnActiveMember
            // 
            this.btnActiveMember.Location = new System.Drawing.Point(618, 80);
            this.btnActiveMember.Name = "btnActiveMember";
            this.btnActiveMember.Size = new System.Drawing.Size(75, 23);
            this.btnActiveMember.TabIndex = 12;
            this.btnActiveMember.Text = "Run";
            this.btnActiveMember.UseVisualStyleBackColor = true;
            this.btnActiveMember.Visible = false;
            this.btnActiveMember.Click += new System.EventHandler(this.btnActiveMember_Click);
            // 
            // btnActiveProvider
            // 
            this.btnActiveProvider.Location = new System.Drawing.Point(618, 109);
            this.btnActiveProvider.Name = "btnActiveProvider";
            this.btnActiveProvider.Size = new System.Drawing.Size(75, 23);
            this.btnActiveProvider.TabIndex = 15;
            this.btnActiveProvider.Text = "Run";
            this.btnActiveProvider.UseVisualStyleBackColor = true;
            this.btnActiveProvider.Visible = false;
            this.btnActiveProvider.Click += new System.EventHandler(this.btnActiveProvider_Click);
            // 
            // txtActiveProvider
            // 
            this.txtActiveProvider.Location = new System.Drawing.Point(512, 112);
            this.txtActiveProvider.Name = "txtActiveProvider";
            this.txtActiveProvider.Size = new System.Drawing.Size(100, 20);
            this.txtActiveProvider.TabIndex = 14;
            this.txtActiveProvider.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Active Provider Report - Enter Provider ID or blank (for all)";
            this.label3.Visible = false;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(699, 62);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(0, 13);
            this.lblResults.TabIndex = 16;
            // 
            // ReportTester
            // 
            this.ClientSize = new System.Drawing.Size(872, 166);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.btnActiveProvider);
            this.Controls.Add(this.txtActiveProvider);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnActiveMember);
            this.Controls.Add(this.txtActiveMember);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer5);
            this.Controls.Add(this.reportViewer3);
            this.Controls.Add(this.reportViewer4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnSetTime);
            this.Controls.Add(this.lblClock);
            this.Name = "ReportTester";
            this.Load += new System.EventHandler(this.ReportTester_Load);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtActiveMember;
        private System.Windows.Forms.Button btnActiveMember;
        private System.Windows.Forms.Button btnActiveProvider;
        private System.Windows.Forms.TextBox txtActiveProvider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblResults;
    }
}