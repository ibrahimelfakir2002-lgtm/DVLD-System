namespace DVLDPresentationLayer
{
    partial class FrmNewInternationalLicense
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
            this.btnIssue = new System.Windows.Forms.Button();
            this.BntClose = new System.Windows.Forms.Button();
            this.LinkLBShowLicesneHistory = new System.Windows.Forms.LinkLabel();
            this.LinkLbShowLicenseINfo = new System.Windows.Forms.LinkLabel();
            this.ctrlInternationalApplicationInfo1 = new DVLDPresentationLayer.ctrlInternationalApplicationInfo();
            this.ctrlLicenseSelector1 = new DVLDPresentationLayer.ctrlLicenseSelector();
            this.SuspendLayout();
            // 
            // btnIssue
            // 
            this.btnIssue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::DVLDPresentationLayer.Properties.Resources.IssueDrivingLicense_321;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(885, 929);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(107, 39);
            this.btnIssue.TabIndex = 10;
            this.btnIssue.Text = "   Issue";
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // BntClose
            // 
            this.BntClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BntClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BntClose.Image = global::DVLDPresentationLayer.Properties.Resources.icons8_close_30;
            this.BntClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BntClose.Location = new System.Drawing.Point(760, 929);
            this.BntClose.Name = "BntClose";
            this.BntClose.Size = new System.Drawing.Size(107, 39);
            this.BntClose.TabIndex = 9;
            this.BntClose.Text = "   Close";
            this.BntClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BntClose.UseVisualStyleBackColor = true;
            // 
            // LinkLBShowLicesneHistory
            // 
            this.LinkLBShowLicesneHistory.AutoSize = true;
            this.LinkLBShowLicesneHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLBShowLicesneHistory.Location = new System.Drawing.Point(23, 933);
            this.LinkLBShowLicesneHistory.Name = "LinkLBShowLicesneHistory";
            this.LinkLBShowLicesneHistory.Size = new System.Drawing.Size(250, 29);
            this.LinkLBShowLicesneHistory.TabIndex = 11;
            this.LinkLBShowLicesneHistory.TabStop = true;
            this.LinkLBShowLicesneHistory.Text = "Show License History ";
            this.LinkLBShowLicesneHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLBShowLicesneHistory_LinkClicked);
            // 
            // LinkLbShowLicenseINfo
            // 
            this.LinkLbShowLicenseINfo.AutoSize = true;
            this.LinkLbShowLicenseINfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLbShowLicenseINfo.Location = new System.Drawing.Point(313, 939);
            this.LinkLbShowLicenseINfo.Name = "LinkLbShowLicenseINfo";
            this.LinkLbShowLicenseINfo.Size = new System.Drawing.Size(209, 29);
            this.LinkLbShowLicenseINfo.TabIndex = 12;
            this.LinkLbShowLicenseINfo.TabStop = true;
            this.LinkLbShowLicenseINfo.Text = "Show License Info";
            this.LinkLbShowLicenseINfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLbShowLicenseINfo_LinkClicked);
            // 
            // ctrlInternationalApplicationInfo1
            // 
            this.ctrlInternationalApplicationInfo1.Location = new System.Drawing.Point(48, 585);
            this.ctrlInternationalApplicationInfo1.Name = "ctrlInternationalApplicationInfo1";
            this.ctrlInternationalApplicationInfo1.Size = new System.Drawing.Size(927, 338);
            this.ctrlInternationalApplicationInfo1.TabIndex = 1;
            // 
            // ctrlLicenseSelector1
            // 
            this.ctrlLicenseSelector1.Location = new System.Drawing.Point(0, 0);
            this.ctrlLicenseSelector1.Name = "ctrlLicenseSelector1";
            this.ctrlLicenseSelector1.Size = new System.Drawing.Size(1167, 591);
            this.ctrlLicenseSelector1.TabIndex = 0;
            // 
            // FrmNewInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 1050);
            this.Controls.Add(this.LinkLbShowLicenseINfo);
            this.Controls.Add(this.LinkLBShowLicesneHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.BntClose);
            this.Controls.Add(this.ctrlInternationalApplicationInfo1);
            this.Controls.Add(this.ctrlLicenseSelector1);
            this.Name = "FrmNewInternationalLicense";
            this.Text = "New International License";
            this.Load += new System.EventHandler(this.FrmNewInternationalLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLicenseSelector ctrlLicenseSelector1;
        private ctrlInternationalApplicationInfo ctrlInternationalApplicationInfo1;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button BntClose;
        private System.Windows.Forms.LinkLabel LinkLBShowLicesneHistory;
        private System.Windows.Forms.LinkLabel LinkLbShowLicenseINfo;
    }
}