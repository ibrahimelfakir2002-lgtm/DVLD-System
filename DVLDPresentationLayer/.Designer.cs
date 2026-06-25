namespace DVLDPresentationLayer
{
    partial class LocalDrivingLicenseApplications
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.LbTitle = new System.Windows.Forms.Label();
            this.DGVLocalDLApplications = new System.Windows.Forms.DataGridView();
            this.contextMenuStripLocalApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canceledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleViewTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleWrittingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleStreetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDriverLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.LbNumberOfRecords = new System.Windows.Forms.Label();
            this.BntClose = new System.Windows.Forms.Button();
            this.pBoxAddImage = new System.Windows.Forms.PictureBox();
            this.showPersonLicensesHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLocalDLApplications)).BeginInit();
            this.contextMenuStripLocalApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAddImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter By :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(435, 120);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(194, 26);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbFilterBy.DisplayMember = " 0";
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "Person ID",
            "National No"});
            this.cbFilterBy.Location = new System.Drawing.Point(209, 118);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(194, 28);
            this.cbFilterBy.TabIndex = 6;
            this.cbFilterBy.ValueMember = " ";
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.ForeColor = System.Drawing.Color.Red;
            this.LbTitle.Location = new System.Drawing.Point(292, 37);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(570, 39);
            this.LbTitle.TabIndex = 8;
            this.LbTitle.Text = "Local Driving License Applications";
            // 
            // DGVLocalDLApplications
            // 
            this.DGVLocalDLApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLocalDLApplications.ContextMenuStrip = this.contextMenuStripLocalApplications;
            this.DGVLocalDLApplications.Location = new System.Drawing.Point(42, 194);
            this.DGVLocalDLApplications.Name = "DGVLocalDLApplications";
            this.DGVLocalDLApplications.RowHeadersWidth = 62;
            this.DGVLocalDLApplications.RowTemplate.Height = 28;
            this.DGVLocalDLApplications.Size = new System.Drawing.Size(1167, 314);
            this.DGVLocalDLApplications.TabIndex = 9;
            this.DGVLocalDLApplications.SelectionChanged += new System.EventHandler(this.DGVLocalDLApplications_SelectionChanged);
            // 
            // contextMenuStripLocalApplications
            // 
            this.contextMenuStripLocalApplications.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripLocalApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.canceledToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.sechduleTestToolStripMenuItem,
            this.issueDriverLicenseToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonLicensesHistoryToolStripMenuItem});
            this.contextMenuStripLocalApplications.Name = "contextMenuStripLocalApplications";
            this.contextMenuStripLocalApplications.Size = new System.Drawing.Size(396, 325);
            this.contextMenuStripLocalApplications.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripLocalApplications_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.PersonDetails_321;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(395, 36);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details ";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.editApplicationToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.edit_321;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(395, 36);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            // 
            // canceledToolStripMenuItem
            // 
            this.canceledToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.canceledToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Delete_32;
            this.canceledToolStripMenuItem.Name = "canceledToolStripMenuItem";
            this.canceledToolStripMenuItem.Size = new System.Drawing.Size(395, 36);
            this.canceledToolStripMenuItem.Text = "Cancel Application";
            this.canceledToolStripMenuItem.Click += new System.EventHandler(this.canceledToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.deleteApplicationToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Delete_32_2;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(395, 36);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application ";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // sechduleTestToolStripMenuItem
            // 
            this.sechduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sechduleViewTestToolStripMenuItem,
            this.sechduleWrittingToolStripMenuItem,
            this.sechduleStreetToolStripMenuItem});
            this.sechduleTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.sechduleTestToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Test_32;
            this.sechduleTestToolStripMenuItem.Name = "sechduleTestToolStripMenuItem";
            this.sechduleTestToolStripMenuItem.Size = new System.Drawing.Size(395, 36);
            this.sechduleTestToolStripMenuItem.Text = "Sechdule Test";
            this.sechduleTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleTestToolStripMenuItem_Click);
            // 
            // sechduleViewTestToolStripMenuItem
            // 
            this.sechduleViewTestToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Vision_Test_32;
            this.sechduleViewTestToolStripMenuItem.Name = "sechduleViewTestToolStripMenuItem";
            this.sechduleViewTestToolStripMenuItem.Size = new System.Drawing.Size(326, 38);
            this.sechduleViewTestToolStripMenuItem.Text = "Sechdule View Test";
            this.sechduleViewTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleViewTestToolStripMenuItem_Click);
            // 
            // sechduleWrittingToolStripMenuItem
            // 
            this.sechduleWrittingToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Written_Test_32;
            this.sechduleWrittingToolStripMenuItem.Name = "sechduleWrittingToolStripMenuItem";
            this.sechduleWrittingToolStripMenuItem.Size = new System.Drawing.Size(326, 38);
            this.sechduleWrittingToolStripMenuItem.Text = "Sechdule Written Test";
            this.sechduleWrittingToolStripMenuItem.Click += new System.EventHandler(this.sechduleWrittingToolStripMenuItem_Click);
            // 
            // sechduleStreetToolStripMenuItem
            // 
            this.sechduleStreetToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Street_Test_32;
            this.sechduleStreetToolStripMenuItem.Name = "sechduleStreetToolStripMenuItem";
            this.sechduleStreetToolStripMenuItem.Size = new System.Drawing.Size(326, 38);
            this.sechduleStreetToolStripMenuItem.Text = "Sechdule Street Test";
            this.sechduleStreetToolStripMenuItem.Click += new System.EventHandler(this.sechduleStreetToolStripMenuItem_Click);
            // 
            // issueDriverLicenseToolStripMenuItem
            // 
            this.issueDriverLicenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.issueDriverLicenseToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.IssueDrivingLicense_32;
            this.issueDriverLicenseToolStripMenuItem.Name = "issueDriverLicenseToolStripMenuItem";
            this.issueDriverLicenseToolStripMenuItem.Size = new System.Drawing.Size(395, 36);
            this.issueDriverLicenseToolStripMenuItem.Text = "issue Driver License (First Time)";
            this.issueDriverLicenseToolStripMenuItem.Click += new System.EventHandler(this.issueDriverLicenseToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.showLicenseToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(395, 36);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(95, 572);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = " # Records:";
            // 
            // LbNumberOfRecords
            // 
            this.LbNumberOfRecords.AutoSize = true;
            this.LbNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbNumberOfRecords.Location = new System.Drawing.Point(285, 572);
            this.LbNumberOfRecords.Name = "LbNumberOfRecords";
            this.LbNumberOfRecords.Size = new System.Drawing.Size(126, 32);
            this.LbNumberOfRecords.TabIndex = 12;
            this.LbNumberOfRecords.Text = " Records";
            // 
            // BntClose
            // 
            this.BntClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BntClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BntClose.Image = global::DVLDPresentationLayer.Properties.Resources.icons8_close_30;
            this.BntClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BntClose.Location = new System.Drawing.Point(1086, 514);
            this.BntClose.Name = "BntClose";
            this.BntClose.Size = new System.Drawing.Size(107, 39);
            this.BntClose.TabIndex = 13;
            this.BntClose.Text = "   Close";
            this.BntClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BntClose.UseVisualStyleBackColor = true;
            this.BntClose.Click += new System.EventHandler(this.BntClose_Click);
            // 
            // pBoxAddImage
            // 
            this.pBoxAddImage.Image = global::DVLDPresentationLayer.Properties.Resources.New_Application_641;
            this.pBoxAddImage.Location = new System.Drawing.Point(1086, 114);
            this.pBoxAddImage.Name = "pBoxAddImage";
            this.pBoxAddImage.Size = new System.Drawing.Size(77, 41);
            this.pBoxAddImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxAddImage.TabIndex = 10;
            this.pBoxAddImage.TabStop = false;
            this.pBoxAddImage.Click += new System.EventHandler(this.pBoxAddImage_Click);
            // 
            // showPersonLicensesHistoryToolStripMenuItem
            // 
            this.showPersonLicensesHistoryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.showPersonLicensesHistoryToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.License_View_321;
            this.showPersonLicensesHistoryToolStripMenuItem.Name = "showPersonLicensesHistoryToolStripMenuItem";
            this.showPersonLicensesHistoryToolStripMenuItem.Size = new System.Drawing.Size(395, 36);
            this.showPersonLicensesHistoryToolStripMenuItem.Text = "Show Person Licenses History";
            this.showPersonLicensesHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicensesHistoryToolStripMenuItem_Click);
            // 
            // LocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 643);
            this.Controls.Add(this.BntClose);
            this.Controls.Add(this.LbNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pBoxAddImage);
            this.Controls.Add(this.DGVLocalDLApplications);
            this.Controls.Add(this.LbTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbFilterBy);
            this.Name = "LocalDrivingLicenseApplications";
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.LocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLocalDLApplications)).EndInit();
            this.contextMenuStripLocalApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAddImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.DataGridView DGVLocalDLApplications;
        private System.Windows.Forms.PictureBox pBoxAddImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LbNumberOfRecords;
        private System.Windows.Forms.Button BntClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLocalApplications;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canceledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleViewTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleWrittingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleStreetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDriverLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicensesHistoryToolStripMenuItem;
    }
}