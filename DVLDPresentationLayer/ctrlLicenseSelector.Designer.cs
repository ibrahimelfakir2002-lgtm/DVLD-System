namespace DVLDPresentationLayer
{
    partial class ctrlLicenseSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gBoxFilter = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.picBoxNewInterational = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ctrlLicenseInfo1 = new DVLDPresentationLayer.ctrlLicenseInfo();
            this.gBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxNewInterational)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxFilter
            // 
            this.gBoxFilter.Controls.Add(this.picBoxNewInterational);
            this.gBoxFilter.Controls.Add(this.txtSearch);
            this.gBoxFilter.Controls.Add(this.label);
            this.gBoxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxFilter.Location = new System.Drawing.Point(15, 23);
            this.gBoxFilter.Name = "gBoxFilter";
            this.gBoxFilter.Size = new System.Drawing.Size(868, 110);
            this.gBoxFilter.TabIndex = 3;
            this.gBoxFilter.TabStop = false;
            this.gBoxFilter.Text = "Filter";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(202, 38);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(198, 35);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(41, 41);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(138, 29);
            this.label.TabIndex = 1;
            this.label.Text = "License ID :";
            // 
            // picBoxNewInterational
            // 
            this.picBoxNewInterational.Image = global::DVLDPresentationLayer.Properties.Resources.License_Type_32;
            this.picBoxNewInterational.Location = new System.Drawing.Point(470, 38);
            this.picBoxNewInterational.Name = "picBoxNewInterational";
            this.picBoxNewInterational.Size = new System.Drawing.Size(66, 39);
            this.picBoxNewInterational.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxNewInterational.TabIndex = 3;
            this.picBoxNewInterational.TabStop = false;
            this.picBoxNewInterational.Click += new System.EventHandler(this.picBoxNewInterational_Click);
            this.picBoxNewInterational.MouseEnter += new System.EventHandler(this.picBoxNewInterational_MouseEnter);
            this.picBoxNewInterational.MouseLeave += new System.EventHandler(this.picBoxNewInterational_MouseLeave);
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(15, 155);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(1060, 496);
            this.ctrlLicenseInfo1.TabIndex = 4;
            // 
            // ctrlLicenseSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Controls.Add(this.gBoxFilter);
            this.Name = "ctrlLicenseSelector";
            this.Size = new System.Drawing.Size(1167, 707);
            this.Load += new System.EventHandler(this.ctrlLicenseSelector_Load);
            this.gBoxFilter.ResumeLayout(false);
            this.gBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxNewInterational)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxFilter;
        private System.Windows.Forms.PictureBox picBoxNewInterational;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label;
        private ctrlLicenseInfo ctrlLicenseInfo1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
