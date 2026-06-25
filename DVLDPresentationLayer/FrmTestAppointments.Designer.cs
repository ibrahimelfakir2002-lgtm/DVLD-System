namespace DVLDPresentationLayer
{
    partial class FrmTestAppointments
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
            this.LbAppointmentsTitle = new System.Windows.Forms.Label();
            this.DGVAppointments = new System.Windows.Forms.DataGridView();
            this.contextMenuStripAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LbNumberOfRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BntClose = new System.Windows.Forms.Button();
            this.picBoxAddApointment = new System.Windows.Forms.PictureBox();
            this.ctrlDrivingLicenseAppAndAppInfo1 = new DVLDPresentationLayer.ctrlDrivingLicenseAppAndAppInfo();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAppointments)).BeginInit();
            this.contextMenuStripAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAddApointment)).BeginInit();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.ForeColor = System.Drawing.Color.Red;
            this.LbTitle.Location = new System.Drawing.Point(327, 23);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(406, 37);
            this.LbTitle.TabIndex = 1;
            this.LbTitle.Text = "Vision Test Appointments";
            // 
            // LbAppointmentsTitle
            // 
            this.LbAppointmentsTitle.AutoSize = true;
            this.LbAppointmentsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbAppointmentsTitle.Location = new System.Drawing.Point(41, 648);
            this.LbAppointmentsTitle.Name = "LbAppointmentsTitle";
            this.LbAppointmentsTitle.Size = new System.Drawing.Size(210, 32);
            this.LbAppointmentsTitle.TabIndex = 3;
            this.LbAppointmentsTitle.Text = "Appointments:";
            // 
            // DGVAppointments
            // 
            this.DGVAppointments.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGVAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAppointments.ContextMenuStrip = this.contextMenuStripAppointments;
            this.DGVAppointments.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.DGVAppointments.Location = new System.Drawing.Point(47, 694);
            this.DGVAppointments.Name = "DGVAppointments";
            this.DGVAppointments.RowHeadersWidth = 62;
            this.DGVAppointments.RowTemplate.Height = 28;
            this.DGVAppointments.Size = new System.Drawing.Size(1008, 179);
            this.DGVAppointments.TabIndex = 4;
            // 
            // contextMenuStripAppointments
            // 
            this.contextMenuStripAppointments.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStripAppointments.Name = "contextMenuStripAppointments";
            this.contextMenuStripAppointments.Size = new System.Drawing.Size(249, 109);
            this.contextMenuStripAppointments.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripAppointments_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.editToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.edit_321;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(248, 36);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.takeTestToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Test_32;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(248, 36);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // LbNumberOfRecords
            // 
            this.LbNumberOfRecords.AutoSize = true;
            this.LbNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbNumberOfRecords.Location = new System.Drawing.Point(292, 893);
            this.LbNumberOfRecords.Name = "LbNumberOfRecords";
            this.LbNumberOfRecords.Size = new System.Drawing.Size(142, 32);
            this.LbNumberOfRecords.TabIndex = 5;
            this.LbNumberOfRecords.Text = " Records ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 893);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "# Records :";
            // 
            // BntClose
            // 
            this.BntClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BntClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BntClose.Image = global::DVLDPresentationLayer.Properties.Resources.icons8_close_30;
            this.BntClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BntClose.Location = new System.Drawing.Point(926, 886);
            this.BntClose.Name = "BntClose";
            this.BntClose.Size = new System.Drawing.Size(107, 39);
            this.BntClose.TabIndex = 14;
            this.BntClose.Text = "   Close";
            this.BntClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BntClose.UseVisualStyleBackColor = true;
            // 
            // picBoxAddApointment
            // 
            this.picBoxAddApointment.Image = global::DVLDPresentationLayer.Properties.Resources.AddAppointment_32;
            this.picBoxAddApointment.Location = new System.Drawing.Point(993, 618);
            this.picBoxAddApointment.Name = "picBoxAddApointment";
            this.picBoxAddApointment.Size = new System.Drawing.Size(62, 50);
            this.picBoxAddApointment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxAddApointment.TabIndex = 2;
            this.picBoxAddApointment.TabStop = false;
            this.picBoxAddApointment.Click += new System.EventHandler(this.picBoxAddApointment_Click);
            // 
            // ctrlDrivingLicenseAppAndAppInfo1
            // 
            this.ctrlDrivingLicenseAppAndAppInfo1.LocalAppID = 0;
            this.ctrlDrivingLicenseAppAndAppInfo1.Location = new System.Drawing.Point(6, 12);
            this.ctrlDrivingLicenseAppAndAppInfo1.Name = "ctrlDrivingLicenseAppAndAppInfo1";
            this.ctrlDrivingLicenseAppAndAppInfo1.Size = new System.Drawing.Size(1087, 615);
            this.ctrlDrivingLicenseAppAndAppInfo1.TabIndex = 15;
            this.ctrlDrivingLicenseAppAndAppInfo1.Load += new System.EventHandler(this.ctrlDrivingLicenseAppAndAppInfo1_Load);
            // 
            // FrmTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 946);
            this.Controls.Add(this.ctrlDrivingLicenseAppAndAppInfo1);
            this.Controls.Add(this.BntClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbNumberOfRecords);
            this.Controls.Add(this.DGVAppointments);
            this.Controls.Add(this.LbAppointmentsTitle);
            this.Controls.Add(this.picBoxAddApointment);
            this.Controls.Add(this.LbTitle);
            this.Name = "FrmTestAppointments";
            this.Text = " Test Appointments";
            this.Load += new System.EventHandler(this.FrmTestAppointments_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAppointments)).EndInit();
            this.contextMenuStripAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAddApointment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.PictureBox picBoxAddApointment;
        private System.Windows.Forms.Label LbAppointmentsTitle;
        private System.Windows.Forms.DataGridView DGVAppointments;
        private System.Windows.Forms.Label LbNumberOfRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BntClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAppointments;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private ctrlDrivingLicenseAppAndAppInfo ctrlDrivingLicenseAppAndAppInfo1;
    }
}