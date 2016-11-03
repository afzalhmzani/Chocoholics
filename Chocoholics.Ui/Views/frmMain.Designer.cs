namespace Chocoholics.Ui.Views
{
    partial class frmMain
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainActions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainActionsManagerTerminal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainActionsProviderTerminal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainActionsOperatorForm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainActionsOperatorFormMemberForm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainActionsOperatorFormServiceForm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainActionsOperatorFormProviderForm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainActionsReportingForm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainWindowTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainWindowTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainWindowCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainWindowCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainFile,
            this.mnuMainActions,
            this.mnuMainWindow});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.MdiWindowListItem = this.mnuMainWindow;
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mnuMain.Size = new System.Drawing.Size(526, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuMainFile
            // 
            this.mnuMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainFileExit});
            this.mnuMainFile.Name = "mnuMainFile";
            this.mnuMainFile.Size = new System.Drawing.Size(37, 20);
            this.mnuMainFile.Text = "&File";
            // 
            // mnuMainFileExit
            // 
            this.mnuMainFileExit.Name = "mnuMainFileExit";
            this.mnuMainFileExit.Size = new System.Drawing.Size(92, 22);
            this.mnuMainFileExit.Text = "&Exit";
            this.mnuMainFileExit.Click += new System.EventHandler(this.mnuMainFileExit_Click);
            // 
            // mnuMainActions
            // 
            this.mnuMainActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainActionsOperatorForm,
            this.mnuMainActionsProviderTerminal,
            this.mnuMainActionsManagerTerminal,
            this.mnuMainActionsReportingForm});
            this.mnuMainActions.Name = "mnuMainActions";
            this.mnuMainActions.Size = new System.Drawing.Size(59, 20);
            this.mnuMainActions.Text = "&Actions";
            // 
            // mnuMainActionsManagerTerminal
            // 
            this.mnuMainActionsManagerTerminal.Name = "mnuMainActionsManagerTerminal";
            this.mnuMainActionsManagerTerminal.Size = new System.Drawing.Size(171, 22);
            this.mnuMainActionsManagerTerminal.Text = "&Manager Terminal";
            this.mnuMainActionsManagerTerminal.Click += new System.EventHandler(this.mnuMainActionsManagerTerminal_Click);
            // 
            // mnuMainActionsProviderTerminal
            // 
            this.mnuMainActionsProviderTerminal.Name = "mnuMainActionsProviderTerminal";
            this.mnuMainActionsProviderTerminal.Size = new System.Drawing.Size(171, 22);
            this.mnuMainActionsProviderTerminal.Text = "&Provider Terminal";
            this.mnuMainActionsProviderTerminal.Click += new System.EventHandler(this.mnuMainActionsProviderTerminal_Click);
            // 
            // mnuMainActionsOperatorForm
            // 
            this.mnuMainActionsOperatorForm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainActionsOperatorFormServiceForm,
            this.mnuMainActionsOperatorFormMemberForm,
            this.mnuMainActionsOperatorFormProviderForm});
            this.mnuMainActionsOperatorForm.Name = "mnuMainActionsOperatorForm";
            this.mnuMainActionsOperatorForm.Size = new System.Drawing.Size(171, 22);
            this.mnuMainActionsOperatorForm.Text = "&Operator Form";
            // 
            // mnuMainActionsOperatorFormMemberForm
            // 
            this.mnuMainActionsOperatorFormMemberForm.Name = "mnuMainActionsOperatorFormMemberForm";
            this.mnuMainActionsOperatorFormMemberForm.Size = new System.Drawing.Size(152, 22);
            this.mnuMainActionsOperatorFormMemberForm.Text = "&Member Form";
            this.mnuMainActionsOperatorFormMemberForm.Click += new System.EventHandler(this.mnuMainActionsOperatorFormMemberForm_Click);
            // 
            // mnuMainActionsOperatorFormServiceForm
            // 
            this.mnuMainActionsOperatorFormServiceForm.Name = "mnuMainActionsOperatorFormServiceForm";
            this.mnuMainActionsOperatorFormServiceForm.Size = new System.Drawing.Size(152, 22);
            this.mnuMainActionsOperatorFormServiceForm.Text = "&Service Form";
            this.mnuMainActionsOperatorFormServiceForm.Click += new System.EventHandler(this.mnuMainActionsOperatorFormServiceForm_Click);
            // 
            // mnuMainActionsOperatorFormProviderForm
            // 
            this.mnuMainActionsOperatorFormProviderForm.Name = "mnuMainActionsOperatorFormProviderForm";
            this.mnuMainActionsOperatorFormProviderForm.Size = new System.Drawing.Size(152, 22);
            this.mnuMainActionsOperatorFormProviderForm.Text = "&Provider Form ";
            this.mnuMainActionsOperatorFormProviderForm.Click += new System.EventHandler(this.mnuMainActionsOperatorFormProviderForm_Click);
            // 
            // mnuMainActionsReportingForm
            // 
            this.mnuMainActionsReportingForm.Name = "mnuMainActionsReportingForm";
            this.mnuMainActionsReportingForm.Size = new System.Drawing.Size(171, 22);
            this.mnuMainActionsReportingForm.Text = "&Reporting Form";
            this.mnuMainActionsReportingForm.Click += new System.EventHandler(this.reportingFormToolStripMenuItem_Click);
            // 
            // mnuMainWindow
            // 
            this.mnuMainWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainWindowTileHorizontal,
            this.mnuMainWindowTileVertical,
            this.mnuMainWindowCascade,
            this.mnuMainWindowCloseAll,
            this.toolStripSeparator1});
            this.mnuMainWindow.Name = "mnuMainWindow";
            this.mnuMainWindow.Size = new System.Drawing.Size(63, 20);
            this.mnuMainWindow.Text = "&Window";
            // 
            // mnuMainWindowTileHorizontal
            // 
            this.mnuMainWindowTileHorizontal.Name = "mnuMainWindowTileHorizontal";
            this.mnuMainWindowTileHorizontal.Size = new System.Drawing.Size(151, 22);
            this.mnuMainWindowTileHorizontal.Text = "Tile &Horizontal";
            this.mnuMainWindowTileHorizontal.Click += new System.EventHandler(this.mnuMainWindowTileHorizontal_Click);
            // 
            // mnuMainWindowTileVertical
            // 
            this.mnuMainWindowTileVertical.Name = "mnuMainWindowTileVertical";
            this.mnuMainWindowTileVertical.Size = new System.Drawing.Size(151, 22);
            this.mnuMainWindowTileVertical.Text = "Tile &Vertical";
            this.mnuMainWindowTileVertical.Click += new System.EventHandler(this.mnuMainWindowTileVertical_Click);
            // 
            // mnuMainWindowCascade
            // 
            this.mnuMainWindowCascade.Name = "mnuMainWindowCascade";
            this.mnuMainWindowCascade.Size = new System.Drawing.Size(151, 22);
            this.mnuMainWindowCascade.Text = "&Cascade";
            this.mnuMainWindowCascade.Click += new System.EventHandler(this.mnuMainWindowCascade_Click);
            // 
            // mnuMainWindowCloseAll
            // 
            this.mnuMainWindowCloseAll.Name = "mnuMainWindowCloseAll";
            this.mnuMainWindowCloseAll.Size = new System.Drawing.Size(151, 22);
            this.mnuMainWindowCloseAll.Text = "Close &All";
            this.mnuMainWindowCloseAll.Click += new System.EventHandler(this.mnuMainWindowCloseAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 420);
            this.Controls.Add(this.mnuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "ChocAn System";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuMainFile;
        private System.Windows.Forms.ToolStripMenuItem mnuMainFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuMainActions;
        private System.Windows.Forms.ToolStripMenuItem mnuMainActionsManagerTerminal;
        private System.Windows.Forms.ToolStripMenuItem mnuMainActionsProviderTerminal;
        private System.Windows.Forms.ToolStripMenuItem mnuMainActionsOperatorForm;
        private System.Windows.Forms.ToolStripMenuItem mnuMainActionsReportingForm;
        private System.Windows.Forms.ToolStripMenuItem mnuMainActionsOperatorFormMemberForm;
        private System.Windows.Forms.ToolStripMenuItem mnuMainActionsOperatorFormServiceForm;
        private System.Windows.Forms.ToolStripMenuItem mnuMainActionsOperatorFormProviderForm;
        private System.Windows.Forms.ToolStripMenuItem mnuMainWindow;
        private System.Windows.Forms.ToolStripMenuItem mnuMainWindowTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuMainWindowTileVertical;
        private System.Windows.Forms.ToolStripMenuItem mnuMainWindowCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuMainWindowCloseAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}