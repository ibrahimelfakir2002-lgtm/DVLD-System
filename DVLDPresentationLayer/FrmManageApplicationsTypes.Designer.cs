namespace DVLDPresentationLayer
{
    partial class FrmManageApplicationsTypes
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
            this.LbTitle = new System.Windows.Forms.Label();
            this.DGVManageAppTypes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.LbNumberOfRecord = new System.Windows.Forms.Label();
            this.contexMenuStripAppTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BntClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVManageAppTypes)).BeginInit();
            this.contexMenuStripAppTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.ForeColor = System.Drawing.Color.Red;
            this.LbTitle.Location = new System.Drawing.Point(166, 55);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(535, 46);
            this.LbTitle.TabIndex = 0;
            this.LbTitle.Text = "Manage Applications Types";
            // 
            // DGVManageAppTypes
            // 
            this.DGVManageAppTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVManageAppTypes.ContextMenuStrip = this.contexMenuStripAppTypes;
            this.DGVManageAppTypes.Location = new System.Drawing.Point(27, 132);
            this.DGVManageAppTypes.Name = "DGVManageAppTypes";
            this.DGVManageAppTypes.RowHeadersWidth = 62;
            this.DGVManageAppTypes.RowTemplate.Height = 28;
            this.DGVManageAppTypes.Size = new System.Drawing.Size(856, 387);
            this.DGVManageAppTypes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 565);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "# Records";
            // 
            // LbNumberOfRecord
            // 
            this.LbNumberOfRecord.AutoSize = true;
            this.LbNumberOfRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbNumberOfRecord.Location = new System.Drawing.Point(198, 565);
            this.LbNumberOfRecord.Name = "LbNumberOfRecord";
            this.LbNumberOfRecord.Size = new System.Drawing.Size(118, 29);
            this.LbNumberOfRecord.TabIndex = 3;
            this.LbNumberOfRecord.Text = " Records";
            // 
            // contexMenuStripAppTypes
            // 
            this.contexMenuStripAppTypes.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contexMenuStripAppTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.contexMenuStripAppTypes.Name = "contexMenuStripAppTypes";
            this.contexMenuStripAppTypes.Size = new System.Drawing.Size(339, 42);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.editToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.ApplicationType;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(338, 38);
            this.editToolStripMenuItem.Text = "Edit Application Type";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // BntClose
            // 
            this.BntClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BntClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BntClose.Image = global::DVLDPresentationLayer.Properties.Resources.icons8_close_30;
            this.BntClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BntClose.Location = new System.Drawing.Point(758, 555);
            this.BntClose.Name = "BntClose";
            this.BntClose.Size = new System.Drawing.Size(107, 39);
            this.BntClose.TabIndex = 7;
            this.BntClose.Text = "   Close";
            this.BntClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BntClose.UseVisualStyleBackColor = true;
            this.BntClose.Click += new System.EventHandler(this.BntClose_Click);
            // 
            // FrmManageApplicationsTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 609);
            this.Controls.Add(this.BntClose);
            this.Controls.Add(this.LbNumberOfRecord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVManageAppTypes);
            this.Controls.Add(this.LbTitle);
            this.Name = "FrmManageApplicationsTypes";
            this.Text = "FrmManageApplicationsTypes";
            this.Load += new System.EventHandler(this.FrmManageApplicationsTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVManageAppTypes)).EndInit();
            this.contexMenuStripAppTypes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.DataGridView DGVManageAppTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbNumberOfRecord;
        private System.Windows.Forms.ContextMenuStrip contexMenuStripAppTypes;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button BntClose;
    }
}