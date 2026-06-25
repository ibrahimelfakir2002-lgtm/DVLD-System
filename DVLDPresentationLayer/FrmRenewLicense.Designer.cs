namespace DVLDPresentationLayer
{
    partial class FrmRenewLicense
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
            this.LbTitle = new System.Windows.Forms.Label();
            this.ctrlApplicationNewLicense1 = new DVLDPresentationLayer.ctrlApplicationNewLicense();
            this.ctrlLicenseSelector1 = new DVLDPresentationLayer.ctrlLicenseSelector();
            this.LinkLbLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.LinkLbShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btnRenew = new System.Windows.Forms.Button();
            this.BntClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.ForeColor = System.Drawing.Color.Red;
            this.LbTitle.Location = new System.Drawing.Point(305, 18);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(569, 52);
            this.LbTitle.TabIndex = 1;
            this.LbTitle.Text = "Renew License  Application ";
            // 
            // ctrlApplicationNewLicense1
            // 
            this.ctrlApplicationNewLicense1.Location = new System.Drawing.Point(48, 681);
            this.ctrlApplicationNewLicense1.Name = "ctrlApplicationNewLicense1";
            this.ctrlApplicationNewLicense1.Size = new System.Drawing.Size(1013, 288);
            this.ctrlApplicationNewLicense1.TabIndex = 2;
            // 
            // ctrlLicenseSelector1
            // 
            this.ctrlLicenseSelector1.Location = new System.Drawing.Point(27, 73);
            this.ctrlLicenseSelector1.Name = "ctrlLicenseSelector1";
            this.ctrlLicenseSelector1.Size = new System.Drawing.Size(1167, 585);
            this.ctrlLicenseSelector1.TabIndex = 0;
            // 
            // LinkLbLicenseHistory
            // 
            this.LinkLbLicenseHistory.AutoSize = true;
            this.LinkLbLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLbLicenseHistory.Location = new System.Drawing.Point(52, 972);
            this.LinkLbLicenseHistory.Name = "LinkLbLicenseHistory";
            this.LinkLbLicenseHistory.Size = new System.Drawing.Size(311, 36);
            this.LinkLbLicenseHistory.TabIndex = 3;
            this.LinkLbLicenseHistory.TabStop = true;
            this.LinkLbLicenseHistory.Text = "Show License History ";
            this.LinkLbLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLbLicenseHistory_LinkClicked);
            // 
            // LinkLbShowNewLicenseInfo
            // 
            this.LinkLbShowNewLicenseInfo.AutoSize = true;
            this.LinkLbShowNewLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLbShowNewLicenseInfo.Location = new System.Drawing.Point(425, 972);
            this.LinkLbShowNewLicenseInfo.Name = "LinkLbShowNewLicenseInfo";
            this.LinkLbShowNewLicenseInfo.Size = new System.Drawing.Size(328, 36);
            this.LinkLbShowNewLicenseInfo.TabIndex = 4;
            this.LinkLbShowNewLicenseInfo.TabStop = true;
            this.LinkLbShowNewLicenseInfo.Text = "Show New License Info";
            this.LinkLbShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLbShowNewLicenseInfo_LinkClicked);
            // 
            // btnRenew
            // 
            this.btnRenew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRenew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenew.Image = global::DVLDPresentationLayer.Properties.Resources.IssueDrivingLicense_321;
            this.btnRenew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenew.Location = new System.Drawing.Point(973, 969);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(107, 39);
            this.btnRenew.TabIndex = 12;
            this.btnRenew.Text = "Renew";
            this.btnRenew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // BntClose
            // 
            this.BntClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BntClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BntClose.Image = global::DVLDPresentationLayer.Properties.Resources.icons8_close_30;
            this.BntClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BntClose.Location = new System.Drawing.Point(848, 969);
            this.BntClose.Name = "BntClose";
            this.BntClose.Size = new System.Drawing.Size(107, 39);
            this.BntClose.TabIndex = 11;
            this.BntClose.Text = "   Close";
            this.BntClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BntClose.UseVisualStyleBackColor = true;
            // 
            // FrmRenewLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 1050);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.BntClose);
            this.Controls.Add(this.LinkLbShowNewLicenseInfo);
            this.Controls.Add(this.LinkLbLicenseHistory);
            this.Controls.Add(this.ctrlApplicationNewLicense1);
            this.Controls.Add(this.LbTitle);
            this.Controls.Add(this.ctrlLicenseSelector1);
            this.Name = "FrmRenewLicense";
            this.Text = "Renew Local License";
            this.Load += new System.EventHandler(this.FrmRenewLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLicenseSelector ctrlLicenseSelector1;
        private System.Windows.Forms.Label LbTitle;
        private ctrlApplicationNewLicense ctrlApplicationNewLicense1;
        private System.Windows.Forms.LinkLabel LinkLbLicenseHistory;
        private System.Windows.Forms.LinkLabel LinkLbShowNewLicenseInfo;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button BntClose;
    }
}