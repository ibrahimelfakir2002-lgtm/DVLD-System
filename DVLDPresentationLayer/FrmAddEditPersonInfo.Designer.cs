namespace DVLDPresentationLayer
{
    partial class FrmAddEditPersonInfo
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlAddEditNewVersion1 = new DVLDPresentationLayer.ctrlAddEditNewVersion();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlAddEditNewVersion1
            // 
            this.ctrlAddEditNewVersion1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctrlAddEditNewVersion1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ctrlAddEditNewVersion1.Location = new System.Drawing.Point(12, 12);
            this.ctrlAddEditNewVersion1.Name = "ctrlAddEditNewVersion1";
            this.ctrlAddEditNewVersion1.PersonID = -1;
            this.ctrlAddEditNewVersion1.Size = new System.Drawing.Size(1260, 661);
            this.ctrlAddEditNewVersion1.TabIndex = 0;
            // 
            // FrmAddEditPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 712);
            this.Controls.Add(this.ctrlAddEditNewVersion1);
            this.Name = "FrmAddEditPersonInfo";
            this.Text = "Add / Edit Person Info";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ctrlAddEditNewVersion ctrlAddEditNewVersion1;
    }
}

