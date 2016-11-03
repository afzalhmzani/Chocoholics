namespace Chocoholics.Ui.Views
{
    partial class frmManager
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
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnActiveMember = new System.Windows.Forms.Button();
            this.btnActiveProvider = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(26, 94);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtOutput.Size = new System.Drawing.Size(673, 36);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "Choose Report...";
            this.txtOutput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtManagerDisplay_KeyDown);
            // 
            // btnActiveMember
            // 
            this.btnActiveMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnActiveMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveMember.Location = new System.Drawing.Point(108, 159);
            this.btnActiveMember.Name = "btnActiveMember";
            this.btnActiveMember.Size = new System.Drawing.Size(128, 75);
            this.btnActiveMember.TabIndex = 1;
            this.btnActiveMember.Text = "Active Member";
            this.btnActiveMember.UseVisualStyleBackColor = false;
            this.btnActiveMember.Click += new System.EventHandler(this.btnActiveMember_Click);
            // 
            // btnActiveProvider
            // 
            this.btnActiveProvider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnActiveProvider.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveProvider.Location = new System.Drawing.Point(266, 159);
            this.btnActiveProvider.Name = "btnActiveProvider";
            this.btnActiveProvider.Size = new System.Drawing.Size(128, 75);
            this.btnActiveProvider.TabIndex = 2;
            this.btnActiveProvider.Text = "Active Provider";
            this.btnActiveProvider.UseVisualStyleBackColor = false;
            this.btnActiveProvider.Click += new System.EventHandler(this.btnActiveProvider_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.LimeGreen;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(431, 159);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(128, 75);
            this.btnEnter.TabIndex = 3;
            this.btnEnter.Text = "Submit";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // frmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 419);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnActiveProvider);
            this.Controls.Add(this.btnActiveMember);
            this.Controls.Add(this.txtOutput);
            this.Name = "frmManager";
            this.ShowIcon = false;
            this.Text = "Manager Terminal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnActiveMember;
        private System.Windows.Forms.Button btnActiveProvider;
        private System.Windows.Forms.Button btnEnter;
    }
}