namespace DVLDPresentationLayer
{
    partial class FrmShowPersonLicenseHistory
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
            this.gboxFilter = new System.Windows.Forms.GroupBox();
            this.pboxAddPerson = new System.Windows.Forms.PictureBox();
            this.pboxSearch = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.LbFilterBy = new System.Windows.Forms.Label();
            this.ctrlPersonInfoCard1 = new DVLDPresentationLayer.ctrlPersonInfoCard();
            this.gboxLicensesHistory = new System.Windows.Forms.GroupBox();
            this.tabControlDriverLicesnses = new System.Windows.Forms.TabControl();
            this.tabPageLocal = new System.Windows.Forms.TabPage();
            this.tabPageInternational = new System.Windows.Forms.TabPage();
            this.DGVLocalLicenses = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.gboxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxAddPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSearch)).BeginInit();
            this.gboxLicensesHistory.SuspendLayout();
            this.tabControlDriverLicesnses.SuspendLayout();
            this.tabPageLocal.SuspendLayout();
            this.tabPageInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLocalLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInternationalLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxFilter
            // 
            this.gboxFilter.Controls.Add(this.pboxAddPerson);
            this.gboxFilter.Controls.Add(this.pboxSearch);
            this.gboxFilter.Controls.Add(this.txtSearch);
            this.gboxFilter.Controls.Add(this.cbFilterBy);
            this.gboxFilter.Controls.Add(this.LbFilterBy);
            this.gboxFilter.Location = new System.Drawing.Point(12, 12);
            this.gboxFilter.Name = "gboxFilter";
            this.gboxFilter.Size = new System.Drawing.Size(803, 125);
            this.gboxFilter.TabIndex = 2;
            this.gboxFilter.TabStop = false;
            this.gboxFilter.Text = "Filter ";
            // 
            // pboxAddPerson
            // 
            this.pboxAddPerson.Image = global::DVLDPresentationLayer.Properties.Resources.Add_Person_40;
            this.pboxAddPerson.Location = new System.Drawing.Point(721, 43);
            this.pboxAddPerson.Name = "pboxAddPerson";
            this.pboxAddPerson.Size = new System.Drawing.Size(64, 32);
            this.pboxAddPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxAddPerson.TabIndex = 4;
            this.pboxAddPerson.TabStop = false;
            // 
            // pboxSearch
            // 
            this.pboxSearch.Image = global::DVLDPresentationLayer.Properties.Resources.SearchPerson1;
            this.pboxSearch.Location = new System.Drawing.Point(623, 42);
            this.pboxSearch.Name = "pboxSearch";
            this.pboxSearch.Size = new System.Drawing.Size(64, 32);
            this.pboxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxSearch.TabIndex = 3;
            this.pboxSearch.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(403, 42);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(188, 32);
            this.txtSearch.TabIndex = 2;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Location = new System.Drawing.Point(189, 42);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(177, 28);
            this.cbFilterBy.TabIndex = 1;
            // 
            // LbFilterBy
            // 
            this.LbFilterBy.AutoSize = true;
            this.LbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbFilterBy.Location = new System.Drawing.Point(41, 42);
            this.LbFilterBy.Name = "LbFilterBy";
            this.LbFilterBy.Size = new System.Drawing.Size(124, 29);
            this.LbFilterBy.TabIndex = 0;
            this.LbFilterBy.Text = "Filter By :";
            // 
            // ctrlPersonInfoCard1
            // 
            this.ctrlPersonInfoCard1.AllowEdit = false;
            this.ctrlPersonInfoCard1.Location = new System.Drawing.Point(12, 143);
            this.ctrlPersonInfoCard1.Name = "ctrlPersonInfoCard1";
            this.ctrlPersonInfoCard1.Size = new System.Drawing.Size(760, 377);
            this.ctrlPersonInfoCard1.TabIndex = 3;
            // 
            // gboxLicensesHistory
            // 
            this.gboxLicensesHistory.Controls.Add(this.tabControlDriverLicesnses);
            this.gboxLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxLicensesHistory.Location = new System.Drawing.Point(31, 513);
            this.gboxLicensesHistory.Name = "gboxLicensesHistory";
            this.gboxLicensesHistory.Size = new System.Drawing.Size(835, 301);
            this.gboxLicensesHistory.TabIndex = 4;
            this.gboxLicensesHistory.TabStop = false;
            this.gboxLicensesHistory.Text = "Driver Licenses";
            // 
            // tabControlDriverLicesnses
            // 
            this.tabControlDriverLicesnses.Controls.Add(this.tabPageLocal);
            this.tabControlDriverLicesnses.Controls.Add(this.tabPageInternational);
            this.tabControlDriverLicesnses.Location = new System.Drawing.Point(6, 34);
            this.tabControlDriverLicesnses.Name = "tabControlDriverLicesnses";
            this.tabControlDriverLicesnses.SelectedIndex = 0;
            this.tabControlDriverLicesnses.Size = new System.Drawing.Size(802, 238);
            this.tabControlDriverLicesnses.TabIndex = 7;
            // 
            // tabPageLocal
            // 
            this.tabPageLocal.Controls.Add(this.label1);
            this.tabPageLocal.Controls.Add(this.DGVLocalLicenses);
            this.tabPageLocal.Location = new System.Drawing.Point(4, 38);
            this.tabPageLocal.Name = "tabPageLocal";
            this.tabPageLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLocal.Size = new System.Drawing.Size(794, 196);
            this.tabPageLocal.TabIndex = 0;
            this.tabPageLocal.Text = "Local";
            this.tabPageLocal.UseVisualStyleBackColor = true;
            // 
            // tabPageInternational
            // 
            this.tabPageInternational.Controls.Add(this.label2);
            this.tabPageInternational.Controls.Add(this.DGVInternationalLicenses);
            this.tabPageInternational.Location = new System.Drawing.Point(4, 38);
            this.tabPageInternational.Name = "tabPageInternational";
            this.tabPageInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInternational.Size = new System.Drawing.Size(794, 196);
            this.tabPageInternational.TabIndex = 1;
            this.tabPageInternational.Text = "International";
            this.tabPageInternational.UseVisualStyleBackColor = true;
            // 
            // DGVLocalLicenses
            // 
            this.DGVLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLocalLicenses.Location = new System.Drawing.Point(0, 50);
            this.DGVLocalLicenses.Name = "DGVLocalLicenses";
            this.DGVLocalLicenses.RowHeadersWidth = 62;
            this.DGVLocalLicenses.RowTemplate.Height = 28;
            this.DGVLocalLicenses.Size = new System.Drawing.Size(788, 140);
            this.DGVLocalLicenses.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Licenses";
            // 
            // DGVInternationalLicenses
            // 
            this.DGVInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVInternationalLicenses.Location = new System.Drawing.Point(14, 42);
            this.DGVInternationalLicenses.Name = "DGVInternationalLicenses";
            this.DGVInternationalLicenses.RowHeadersWidth = 62;
            this.DGVInternationalLicenses.RowTemplate.Height = 28;
            this.DGVInternationalLicenses.Size = new System.Drawing.Size(774, 150);
            this.DGVInternationalLicenses.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "International Licenses";
            // 
            // FrmShowPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 826);
            this.Controls.Add(this.gboxLicensesHistory);
            this.Controls.Add(this.ctrlPersonInfoCard1);
            this.Controls.Add(this.gboxFilter);
            this.Name = "FrmShowPersonLicenseHistory";
            this.Text = "FrmShowPersonLicenseHistory";
            this.Load += new System.EventHandler(this.FrmShowPersonLicenseHistory_Load);
            this.gboxFilter.ResumeLayout(false);
            this.gboxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxAddPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSearch)).EndInit();
            this.gboxLicensesHistory.ResumeLayout(false);
            this.tabControlDriverLicesnses.ResumeLayout(false);
            this.tabPageLocal.ResumeLayout(false);
            this.tabPageLocal.PerformLayout();
            this.tabPageInternational.ResumeLayout(false);
            this.tabPageInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLocalLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInternationalLicenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxFilter;
        private System.Windows.Forms.PictureBox pboxAddPerson;
        private System.Windows.Forms.PictureBox pboxSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label LbFilterBy;
        private ctrlPersonInfoCard ctrlPersonInfoCard1;
        private System.Windows.Forms.GroupBox gboxLicensesHistory;
        private System.Windows.Forms.TabControl tabControlDriverLicesnses;
        private System.Windows.Forms.TabPage tabPageLocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVLocalLicenses;
        private System.Windows.Forms.TabPage tabPageInternational;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVInternationalLicenses;
    }
}