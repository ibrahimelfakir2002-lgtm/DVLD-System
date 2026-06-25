namespace DVLDPresentationLayer
{
    partial class ctrlPersonSelector
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
            this.gboxFilter = new System.Windows.Forms.GroupBox();
            this.pboxAddPerson = new System.Windows.Forms.PictureBox();
            this.pboxSearch = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddNewToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ctrlPersonInfoCard1 = new DVLDPresentationLayer.ctrlPersonInfoCard();
            this.gboxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxAddPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxFilter
            // 
            this.gboxFilter.Controls.Add(this.pboxAddPerson);
            this.gboxFilter.Controls.Add(this.pboxSearch);
            this.gboxFilter.Controls.Add(this.txtSearch);
            this.gboxFilter.Controls.Add(this.cbFilterBy);
            this.gboxFilter.Controls.Add(this.label1);
            this.gboxFilter.Location = new System.Drawing.Point(22, 32);
            this.gboxFilter.Name = "gboxFilter";
            this.gboxFilter.Size = new System.Drawing.Size(803, 125);
            this.gboxFilter.TabIndex = 1;
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
            this.pboxAddPerson.Click += new System.EventHandler(this.pboxAddPerson_Click_1);
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
            this.pboxSearch.Click += new System.EventHandler(this.pboxSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(403, 42);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(188, 32);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Location = new System.Drawing.Point(189, 42);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(177, 28);
            this.cbFilterBy.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter By :";
            // 
            // ctrlPersonInfoCard1
            // 
            this.ctrlPersonInfoCard1.AllowEdit = false;
            this.ctrlPersonInfoCard1.Location = new System.Drawing.Point(22, 181);
            this.ctrlPersonInfoCard1.Name = "ctrlPersonInfoCard1";
            this.ctrlPersonInfoCard1.Size = new System.Drawing.Size(760, 377);
            this.ctrlPersonInfoCard1.TabIndex = 5;
            this.ctrlPersonInfoCard1.Load += new System.EventHandler(this.ctrlPersonInfoCard1_Load);
            // 
            // ctrlPersonSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPersonInfoCard1);
            this.Controls.Add(this.gboxFilter);
            this.Name = "ctrlPersonSelector";
            this.Size = new System.Drawing.Size(836, 564);
            this.Load += new System.EventHandler(this.ctrlPersonSelector_Load);
            this.gboxFilter.ResumeLayout(false);
            this.gboxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxAddPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxFilter;
        private System.Windows.Forms.PictureBox pboxAddPerson;
        private System.Windows.Forms.PictureBox pboxSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip SearchToolTip;
        private System.Windows.Forms.ToolTip AddNewToolTip;
        private ctrlPersonInfoCard ctrlPersonInfoCard1;
    }
}
