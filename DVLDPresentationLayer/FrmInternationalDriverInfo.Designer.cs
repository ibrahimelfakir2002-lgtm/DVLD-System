namespace DVLDPresentationLayer
{
    partial class FrmInternationalDriverInfo
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
            this.ctrlInternationalDriverLicense1 = new DVLDPresentationLayer.ctrlInternationalDriverLicense();
            this.LbTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlInternationalDriverLicense1
            // 
            this.ctrlInternationalDriverLicense1.Location = new System.Drawing.Point(27, 208);
            this.ctrlInternationalDriverLicense1.Name = "ctrlInternationalDriverLicense1";
            this.ctrlInternationalDriverLicense1.Size = new System.Drawing.Size(949, 423);
            this.ctrlInternationalDriverLicense1.TabIndex = 0;
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.ForeColor = System.Drawing.Color.Red;
            this.LbTitle.Location = new System.Drawing.Point(226, 119);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(613, 46);
            this.LbTitle.TabIndex = 1;
            this.LbTitle.Text = "Driver International License Info";
            // 
            // FrmInternationalDriverInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 669);
            this.Controls.Add(this.LbTitle);
            this.Controls.Add(this.ctrlInternationalDriverLicense1);
            this.Name = "FrmInternationalDriverInfo";
            this.Text = "International Driver Info";
            this.Load += new System.EventHandler(this.FrmInternationalDriverInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlInternationalDriverLicense ctrlInternationalDriverLicense1;
        private System.Windows.Forms.Label LbTitle;
    }
}