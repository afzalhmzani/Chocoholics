namespace Chocoholics.Ui.Views
{
    partial class frmProviderTerminal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTerminalDisplay = new System.Windows.Forms.TextBox();
            this.chbxOnOff = new System.Windows.Forms.CheckBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefreshServices = new System.Windows.Forms.Button();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnProviderReport = new System.Windows.Forms.Button();
            this.btnServicesDirectory = new System.Windows.Forms.Button();
            this.lblReportStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTerminalDisplay
            // 
            this.txtTerminalDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTerminalDisplay.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerminalDisplay.Location = new System.Drawing.Point(42, 94);
            this.txtTerminalDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.txtTerminalDisplay.Name = "txtTerminalDisplay";
            this.txtTerminalDisplay.Size = new System.Drawing.Size(675, 47);
            this.txtTerminalDisplay.TabIndex = 1;
            this.txtTerminalDisplay.Text = "ChocAn Terminal";
            this.txtTerminalDisplay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTerminalDisplay_KeyDown);
            // 
            // chbxOnOff
            // 
            this.chbxOnOff.AutoSize = true;
            this.chbxOnOff.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxOnOff.Location = new System.Drawing.Point(42, 42);
            this.chbxOnOff.Name = "chbxOnOff";
            this.chbxOnOff.Size = new System.Drawing.Size(112, 24);
            this.chbxOnOff.TabIndex = 0;
            this.chbxOnOff.Text = "Power Off";
            this.chbxOnOff.UseVisualStyleBackColor = true;
            this.chbxOnOff.CheckedChanged += new System.EventHandler(this.chbxOnOff_CheckedChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.Yellow;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(725, 94);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(305, 47);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.AllowUserToResizeRows = false;
            this.dgvServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServices.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServices.Location = new System.Drawing.Point(19, 81);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.RowHeadersWidth = 25;
            this.dgvServices.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvServices.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);
            this.dgvServices.RowTemplate.Height = 32;
            this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvServices.Size = new System.Drawing.Size(437, 265);
            this.dgvServices.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnRefreshServices);
            this.groupBox1.Controls.Add(this.dgvServices);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(42, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 366);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Services Offered";
            // 
            // btnRefreshServices
            // 
            this.btnRefreshServices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshServices.BackColor = System.Drawing.Color.LimeGreen;
            this.btnRefreshServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshServices.Location = new System.Drawing.Point(305, 27);
            this.btnRefreshServices.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshServices.Name = "btnRefreshServices";
            this.btnRefreshServices.Size = new System.Drawing.Size(151, 47);
            this.btnRefreshServices.TabIndex = 6;
            this.btnRefreshServices.Text = "Refresh";
            this.btnRefreshServices.UseVisualStyleBackColor = false;
            this.btnRefreshServices.Click += new System.EventHandler(this.btnRefreshServices_Click);
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.Color.Blue;
            this.lblInstructions.Location = new System.Drawing.Point(57, 145);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(63, 20);
            this.lblInstructions.TabIndex = 7;
            this.lblInstructions.Text = "label1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnProviderReport);
            this.groupBox2.Controls.Add(this.lblReportStatus);
            this.groupBox2.Controls.Add(this.btnServicesDirectory);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(530, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 366);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reports";
            // 
            // btnProviderReport
            // 
            this.btnProviderReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProviderReport.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnProviderReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProviderReport.Location = new System.Drawing.Point(85, 207);
            this.btnProviderReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnProviderReport.Name = "btnProviderReport";
            this.btnProviderReport.Size = new System.Drawing.Size(392, 95);
            this.btnProviderReport.TabIndex = 5;
            this.btnProviderReport.Text = "My Provider Report";
            this.btnProviderReport.UseVisualStyleBackColor = false;
            this.btnProviderReport.Click += new System.EventHandler(this.btnProviderReport_Click);
            // 
            // btnServicesDirectory
            // 
            this.btnServicesDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServicesDirectory.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnServicesDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServicesDirectory.Location = new System.Drawing.Point(85, 81);
            this.btnServicesDirectory.Margin = new System.Windows.Forms.Padding(4);
            this.btnServicesDirectory.Name = "btnServicesDirectory";
            this.btnServicesDirectory.Size = new System.Drawing.Size(392, 98);
            this.btnServicesDirectory.TabIndex = 4;
            this.btnServicesDirectory.Text = "Services Directory";
            this.btnServicesDirectory.UseVisualStyleBackColor = false;
            this.btnServicesDirectory.Click += new System.EventHandler(this.btnServicesDirectory_Click);
            // 
            // lblReportStatus
            // 
            this.lblReportStatus.AutoSize = true;
            this.lblReportStatus.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblReportStatus.Location = new System.Drawing.Point(29, 38);
            this.lblReportStatus.Name = "lblReportStatus";
            this.lblReportStatus.Size = new System.Drawing.Size(144, 20);
            this.lblReportStatus.TabIndex = 8;
            this.lblReportStatus.Text = "Select a report";
            // 
            // frmProviderTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 588);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.chbxOnOff);
            this.Controls.Add(this.txtTerminalDisplay);
            this.Name = "frmProviderTerminal";
            this.ShowIcon = false;
            this.Text = "Provider Terminal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTerminalDisplay;
        private System.Windows.Forms.CheckBox chbxOnOff;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefreshServices;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnProviderReport;
        private System.Windows.Forms.Button btnServicesDirectory;
        private System.Windows.Forms.Label lblReportStatus;
    }
}