namespace DVLDPresentationLayer
{
    partial class FrmManageTestTypes
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
            this.pboxImage = new System.Windows.Forms.PictureBox();
            this.DGVTestTypes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.LbNumberOfRecords = new System.Windows.Forms.Label();
            this.BntClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextmenuStripTestTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTestTypes)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextmenuStripTestTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.ForeColor = System.Drawing.Color.Red;
            this.LbTitle.Location = new System.Drawing.Point(293, 151);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(315, 37);
            this.LbTitle.TabIndex = 0;
            this.LbTitle.Text = "Manage Test Types";
            // 
            // pboxImage
            // 
            this.pboxImage.Image = global::DVLDPresentationLayer.Properties.Resources.Test_321;
            this.pboxImage.Location = new System.Drawing.Point(377, 21);
            this.pboxImage.Name = "pboxImage";
            this.pboxImage.Size = new System.Drawing.Size(147, 114);
            this.pboxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxImage.TabIndex = 1;
            this.pboxImage.TabStop = false;
            // 
            // DGVTestTypes
            // 
            this.DGVTestTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTestTypes.ContextMenuStrip = this.contextmenuStripTestTypes;
            this.DGVTestTypes.Location = new System.Drawing.Point(6, 3);
            this.DGVTestTypes.Name = "DGVTestTypes";
            this.DGVTestTypes.RowHeadersWidth = 62;
            this.DGVTestTypes.RowTemplate.Height = 28;
            this.DGVTestTypes.Size = new System.Drawing.Size(903, 271);
            this.DGVTestTypes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 513);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "# Records";
            // 
            // LbNumberOfRecords
            // 
            this.LbNumberOfRecords.AutoSize = true;
            this.LbNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbNumberOfRecords.Location = new System.Drawing.Point(210, 513);
            this.LbNumberOfRecords.Name = "LbNumberOfRecords";
            this.LbNumberOfRecords.Size = new System.Drawing.Size(111, 29);
            this.LbNumberOfRecords.TabIndex = 4;
            this.LbNumberOfRecords.Text = "Records";
            // 
            // BntClose
            // 
            this.BntClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BntClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BntClose.Image = global::DVLDPresentationLayer.Properties.Resources.icons8_close_30;
            this.BntClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BntClose.Location = new System.Drawing.Point(821, 524);
            this.BntClose.Name = "BntClose";
            this.BntClose.Size = new System.Drawing.Size(107, 39);
            this.BntClose.TabIndex = 8;
            this.BntClose.Text = "   Close";
            this.BntClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BntClose.UseVisualStyleBackColor = true;
            this.BntClose.Click += new System.EventHandler(this.BntClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DGVTestTypes);
            this.panel1.Location = new System.Drawing.Point(31, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 295);
            this.panel1.TabIndex = 9;
            // 
            // contextmenuStripTestTypes
            // 
            this.contextmenuStripTestTypes.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextmenuStripTestTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTestTypesToolStripMenuItem});
            this.contextmenuStripTestTypes.Name = "contextmenuStripTestTypes";
            this.contextmenuStripTestTypes.Size = new System.Drawing.Size(252, 75);
            // 
            // editTestTypesToolStripMenuItem
            // 
            this.editTestTypesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.editTestTypesToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Test_32;
            this.editTestTypesToolStripMenuItem.Name = "editTestTypesToolStripMenuItem";
            this.editTestTypesToolStripMenuItem.Size = new System.Drawing.Size(251, 38);
            this.editTestTypesToolStripMenuItem.Text = "Edit Test Types";
            this.editTestTypesToolStripMenuItem.Click += new System.EventHandler(this.editTestTypesToolStripMenuItem_Click);
            // 
            // FrmManageTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 598);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BntClose);
            this.Controls.Add(this.LbNumberOfRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pboxImage);
            this.Controls.Add(this.LbTitle);
            this.Name = "FrmManageTestTypes";
            this.Text = "List Test Types";
            this.Load += new System.EventHandler(this.FrmManageTestTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTestTypes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextmenuStripTestTypes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.PictureBox pboxImage;
        private System.Windows.Forms.DataGridView DGVTestTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbNumberOfRecords;
        private System.Windows.Forms.Button BntClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextmenuStripTestTypes;
        private System.Windows.Forms.ToolStripMenuItem editTestTypesToolStripMenuItem;
    }
}