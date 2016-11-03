namespace Chocoholics.Ui.Views
{
    partial class frmService
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtServDescription = new System.Windows.Forms.TextBox();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServiceFee = new System.Windows.Forms.TextBox();
            this.txtServiceCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnUpdateService = new System.Windows.Forms.Button();
            this.btnDeleteService = new System.Windows.Forms.Button();
            this.datagService = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSearchService = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnServiceSerarch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSelectAllService = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagService)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtServDescription);
            this.groupBox1.Controls.Add(this.txtServiceName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtServiceFee);
            this.groupBox1.Controls.Add(this.txtServiceCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtServDescription
            // 
            this.txtServDescription.Location = new System.Drawing.Point(142, 146);
            this.txtServDescription.Multiline = true;
            this.txtServDescription.Name = "txtServDescription";
            this.txtServDescription.Size = new System.Drawing.Size(191, 50);
            this.txtServDescription.TabIndex = 7;
            // 
            // txtServiceName
            // 
            this.txtServiceName.Location = new System.Drawing.Point(142, 40);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(191, 20);
            this.txtServiceName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Service Description";
            // 
            // txtServiceFee
            // 
            this.txtServiceFee.Location = new System.Drawing.Point(142, 110);
            this.txtServiceFee.Name = "txtServiceFee";
            this.txtServiceFee.Size = new System.Drawing.Size(191, 20);
            this.txtServiceFee.TabIndex = 5;
            // 
            // txtServiceCode
            // 
            this.txtServiceCode.Location = new System.Drawing.Point(142, 78);
            this.txtServiceCode.Name = "txtServiceCode";
            this.txtServiceCode.Size = new System.Drawing.Size(191, 20);
            this.txtServiceCode.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Service Fee";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Service Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service Name";
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(85, 278);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(75, 37);
            this.btnAddService.TabIndex = 1;
            this.btnAddService.Text = "Add";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnUpdateService
            // 
            this.btnUpdateService.Location = new System.Drawing.Point(166, 278);
            this.btnUpdateService.Name = "btnUpdateService";
            this.btnUpdateService.Size = new System.Drawing.Size(75, 37);
            this.btnUpdateService.TabIndex = 2;
            this.btnUpdateService.Text = "Update";
            this.btnUpdateService.UseVisualStyleBackColor = true;
            this.btnUpdateService.Click += new System.EventHandler(this.btnUpdateService_Click);
            // 
            // btnDeleteService
            // 
            this.btnDeleteService.Location = new System.Drawing.Point(247, 278);
            this.btnDeleteService.Name = "btnDeleteService";
            this.btnDeleteService.Size = new System.Drawing.Size(75, 37);
            this.btnDeleteService.TabIndex = 3;
            this.btnDeleteService.Text = "Delete";
            this.btnDeleteService.UseVisualStyleBackColor = true;
            this.btnDeleteService.Click += new System.EventHandler(this.btnDeleteService_Click);
            // 
            // datagService
            // 
            this.datagService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagService.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.datagService.Location = new System.Drawing.Point(0, 350);
            this.datagService.Name = "datagService";
            this.datagService.ReadOnly = true;
            this.datagService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagService.Size = new System.Drawing.Size(709, 174);
            this.datagService.TabIndex = 4;
            this.datagService.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagService_CellContentClick);
            this.datagService.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagService_RowEnter);
            this.datagService.SelectionChanged += new System.EventHandler(this.datagService_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSearchService);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnServiceSerarch);
            this.groupBox2.Location = new System.Drawing.Point(415, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 186);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search ";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtSearchService
            // 
            this.txtSearchService.Location = new System.Drawing.Point(86, 34);
            this.txtSearchService.Name = "txtSearchService";
            this.txtSearchService.Size = new System.Drawing.Size(191, 20);
            this.txtSearchService.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Service Code";
            // 
            // btnServiceSerarch
            // 
            this.btnServiceSerarch.Location = new System.Drawing.Point(21, 136);
            this.btnServiceSerarch.Name = "btnServiceSerarch";
            this.btnServiceSerarch.Size = new System.Drawing.Size(103, 29);
            this.btnServiceSerarch.TabIndex = 6;
            this.btnServiceSerarch.Text = "Search";
            this.btnServiceSerarch.UseVisualStyleBackColor = true;
            this.btnServiceSerarch.Click += new System.EventHandler(this.btnServiceSerarch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(328, 278);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 37);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtSelectAllService
            // 
            this.txtSelectAllService.Location = new System.Drawing.Point(409, 278);
            this.txtSelectAllService.Name = "txtSelectAllService";
            this.txtSelectAllService.Size = new System.Drawing.Size(72, 37);
            this.txtSelectAllService.TabIndex = 9;
            this.txtSelectAllService.Text = "Select All";
            this.txtSelectAllService.UseVisualStyleBackColor = true;
            this.txtSelectAllService.Click += new System.EventHandler(this.txtSelectAllService_Click);
            // 
            // frmService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 524);
            this.Controls.Add(this.txtSelectAllService);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.datagService);
            this.Controls.Add(this.btnDeleteService);
            this.Controls.Add(this.btnUpdateService);
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmService";
            this.Text = "ChocAn Services";
            this.Load += new System.EventHandler(this.frmService_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagService)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtServiceFee;
        private System.Windows.Forms.TextBox txtServiceCode;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnUpdateService;
        private System.Windows.Forms.Button btnDeleteService;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtServDescription;
        private System.Windows.Forms.DataGridView datagService;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnServiceSerarch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSearchService;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button txtSelectAllService;
    }
}