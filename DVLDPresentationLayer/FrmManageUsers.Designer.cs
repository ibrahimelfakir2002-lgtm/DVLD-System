namespace DVLDPresentationLayer
{
    partial class FrmManageUsers
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
            this.LbNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.pbAddNewUser = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.DGVUsers = new System.Windows.Forms.DataGridView();
            this.ContexMenuStripUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BntClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsers)).BeginInit();
            this.ContexMenuStripUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbNumberOfRecords
            // 
            this.LbNumberOfRecords.AutoSize = true;
            this.LbNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbNumberOfRecords.Location = new System.Drawing.Point(189, 535);
            this.LbNumberOfRecords.Name = "LbNumberOfRecords";
            this.LbNumberOfRecords.Size = new System.Drawing.Size(0, 29);
            this.LbNumberOfRecords.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "#  Records ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbIsActive);
            this.panel1.Controls.Add(this.pbAddNewUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.cbFilterBy);
            this.panel1.Location = new System.Drawing.Point(34, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1165, 114);
            this.panel1.TabIndex = 12;
            // 
            // cbIsActive
            // 
            this.cbIsActive.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbIsActive.DisplayMember = " 0";
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Location = new System.Drawing.Point(639, 54);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(194, 28);
            this.cbIsActive.TabIndex = 9;
            this.cbIsActive.ValueMember = " ";
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // pbAddNewUser
            // 
            this.pbAddNewUser.Image = global::DVLDPresentationLayer.Properties.Resources.Users_2_64;
            this.pbAddNewUser.Location = new System.Drawing.Point(1080, 17);
            this.pbAddNewUser.Name = "pbAddNewUser";
            this.pbAddNewUser.Size = new System.Drawing.Size(73, 41);
            this.pbAddNewUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAddNewUser.TabIndex = 8;
            this.pbAddNewUser.TabStop = false;
            this.pbAddNewUser.Click += new System.EventHandler(this.pbAddNewUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter By :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(389, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(194, 26);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbFilterBy.DisplayMember = " 0";
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Location = new System.Drawing.Point(163, 17);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(194, 28);
            this.cbFilterBy.TabIndex = 2;
            this.cbFilterBy.ValueMember = " ";
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // DGVUsers
            // 
            this.DGVUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUsers.ContextMenuStrip = this.ContexMenuStripUser;
            this.DGVUsers.Location = new System.Drawing.Point(34, 226);
            this.DGVUsers.Name = "DGVUsers";
            this.DGVUsers.RowHeadersWidth = 62;
            this.DGVUsers.RowTemplate.Height = 28;
            this.DGVUsers.Size = new System.Drawing.Size(1165, 244);
            this.DGVUsers.TabIndex = 16;
            this.DGVUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVUsers_CellDoubleClick_1);
            this.DGVUsers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVUsers_CellMouseDown_1);
            // 
            // ContexMenuStripUser
            // 
            this.ContexMenuStripUser.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ContexMenuStripUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.addNewUserToolStripMenuItem,
            this.editToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.ContexMenuStripUser.Name = "contextMenuStrip1";
            this.ContexMenuStripUser.Size = new System.Drawing.Size(249, 197);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.PersonDetails_32;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(248, 32);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Users_2_64;
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(248, 32);
            this.addNewUserToolStripMenuItem.Text = "Add New User";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.addNewUserToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.edit_32;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(248, 32);
            this.editToolStripMenuItem.Text = " Edit ";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Password_321;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(248, 32);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Delete_32;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(248, 32);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // BntClose
            // 
            this.BntClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BntClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BntClose.Image = global::DVLDPresentationLayer.Properties.Resources.icons8_close_30;
            this.BntClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BntClose.Location = new System.Drawing.Point(1052, 476);
            this.BntClose.Name = "BntClose";
            this.BntClose.Size = new System.Drawing.Size(122, 39);
            this.BntClose.TabIndex = 13;
            this.BntClose.Text = "   Close";
            this.BntClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BntClose.UseVisualStyleBackColor = true;
            this.BntClose.Click += new System.EventHandler(this.BntClose_Click);
            // 
            // FrmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 661);
            this.ContextMenuStrip = this.ContexMenuStripUser;
            this.Controls.Add(this.DGVUsers);
            this.Controls.Add(this.LbNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BntClose);
            this.Controls.Add(this.panel1);
            this.Name = "FrmManageUsers";
            this.Text = "ManageUsers";
            this.Load += new System.EventHandler(this.FrmManageUsers_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsers)).EndInit();
            this.ContexMenuStripUser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BntClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbAddNewUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.DataGridView DGVUsers;
        private System.Windows.Forms.ContextMenuStrip ContexMenuStripUser;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}