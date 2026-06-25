namespace DVLDPresentationLayer
{
    partial class FrmNewLocalDrivingLicenseApp
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
            this.LbTitle = new System.Windows.Forms.Label();
            this.tabNewLocalDrivingLicApp = new System.Windows.Forms.TabControl();
            this.tabPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonSelector2 = new DVLDPresentationLayer.ctrlPersonSelector();
            this.tabApplicationInfo = new System.Windows.Forms.TabPage();
            this.LbUserCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LbDLApplicationFees = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxLicenseClasses = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LbDLDate = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LbDLApplicationID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BntClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabNewLocalDrivingLicApp.SuspendLayout();
            this.tabPersonalInfo.SuspendLayout();
            this.tabApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.ForeColor = System.Drawing.Color.Red;
            this.LbTitle.Location = new System.Drawing.Point(184, 28);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(597, 37);
            this.LbTitle.TabIndex = 0;
            this.LbTitle.Text = "New Local Driving License Application\r\n";
            // 
            // tabNewLocalDrivingLicApp
            // 
            this.tabNewLocalDrivingLicApp.Controls.Add(this.tabPersonalInfo);
            this.tabNewLocalDrivingLicApp.Controls.Add(this.tabApplicationInfo);
            this.tabNewLocalDrivingLicApp.Location = new System.Drawing.Point(29, 79);
            this.tabNewLocalDrivingLicApp.Name = "tabNewLocalDrivingLicApp";
            this.tabNewLocalDrivingLicApp.SelectedIndex = 0;
            this.tabNewLocalDrivingLicApp.Size = new System.Drawing.Size(1009, 658);
            this.tabNewLocalDrivingLicApp.TabIndex = 1;
            // 
            // tabPersonalInfo
            // 
            this.tabPersonalInfo.Controls.Add(this.btnNext);
            this.tabPersonalInfo.Controls.Add(this.ctrlPersonSelector2);
            this.tabPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPersonalInfo.Location = new System.Drawing.Point(4, 29);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonalInfo.Size = new System.Drawing.Size(1001, 625);
            this.tabPersonalInfo.TabIndex = 0;
            this.tabPersonalInfo.Text = "Personal Info";
            this.tabPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DVLDPresentationLayer.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(852, 574);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(121, 45);
            this.btnNext.TabIndex = 51;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonSelector2
            // 
            this.ctrlPersonSelector2.Location = new System.Drawing.Point(9, 11);
            this.ctrlPersonSelector2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrlPersonSelector2.Name = "ctrlPersonSelector2";
            this.ctrlPersonSelector2.Size = new System.Drawing.Size(924, 555);
            this.ctrlPersonSelector2.TabIndex = 0;
            this.ctrlPersonSelector2.Load += new System.EventHandler(this.ctrlPersonSelector2_Load);
            // 
            // tabApplicationInfo
            // 
            this.tabApplicationInfo.Controls.Add(this.LbUserCreatedBy);
            this.tabApplicationInfo.Controls.Add(this.pictureBox5);
            this.tabApplicationInfo.Controls.Add(this.label5);
            this.tabApplicationInfo.Controls.Add(this.LbDLApplicationFees);
            this.tabApplicationInfo.Controls.Add(this.pictureBox4);
            this.tabApplicationInfo.Controls.Add(this.label4);
            this.tabApplicationInfo.Controls.Add(this.cboxLicenseClasses);
            this.tabApplicationInfo.Controls.Add(this.pictureBox3);
            this.tabApplicationInfo.Controls.Add(this.label3);
            this.tabApplicationInfo.Controls.Add(this.LbDLDate);
            this.tabApplicationInfo.Controls.Add(this.pictureBox2);
            this.tabApplicationInfo.Controls.Add(this.label2);
            this.tabApplicationInfo.Controls.Add(this.LbDLApplicationID);
            this.tabApplicationInfo.Controls.Add(this.pictureBox1);
            this.tabApplicationInfo.Controls.Add(this.label1);
            this.tabApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabApplicationInfo.Location = new System.Drawing.Point(4, 29);
            this.tabApplicationInfo.Name = "tabApplicationInfo";
            this.tabApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabApplicationInfo.Size = new System.Drawing.Size(1001, 625);
            this.tabApplicationInfo.TabIndex = 1;
            this.tabApplicationInfo.Text = "Application Info";
            this.tabApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // LbUserCreatedBy
            // 
            this.LbUserCreatedBy.AutoSize = true;
            this.LbUserCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbUserCreatedBy.Location = new System.Drawing.Point(509, 414);
            this.LbUserCreatedBy.Name = "LbUserCreatedBy";
            this.LbUserCreatedBy.Size = new System.Drawing.Size(156, 32);
            this.LbUserCreatedBy.TabIndex = 14;
            this.LbUserCreatedBy.Text = "Create By ";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLDPresentationLayer.Properties.Resources.User_32__2;
            this.pictureBox5.Location = new System.Drawing.Point(401, 414);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(68, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(213, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 32);
            this.label5.TabIndex = 12;
            this.label5.Text = "Create By  :";
            // 
            // LbDLApplicationFees
            // 
            this.LbDLApplicationFees.AutoSize = true;
            this.LbDLApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbDLApplicationFees.Location = new System.Drawing.Point(509, 339);
            this.LbDLApplicationFees.Name = "LbDLApplicationFees";
            this.LbDLApplicationFees.Size = new System.Drawing.Size(48, 32);
            this.LbDLApplicationFees.TabIndex = 11;
            this.LbDLApplicationFees.Text = "15";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLDPresentationLayer.Properties.Resources.money_32;
            this.pictureBox4.Location = new System.Drawing.Point(401, 339);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(68, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(119, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = " Application Fees :";
            // 
            // cboxLicenseClasses
            // 
            this.cboxLicenseClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxLicenseClasses.FormattingEnabled = true;
            this.cboxLicenseClasses.Location = new System.Drawing.Point(515, 262);
            this.cboxLicenseClasses.Name = "cboxLicenseClasses";
            this.cboxLicenseClasses.Size = new System.Drawing.Size(341, 37);
            this.cboxLicenseClasses.TabIndex = 8;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLDPresentationLayer.Properties.Resources.License_Type_32;
            this.pictureBox3.Location = new System.Drawing.Point(401, 267);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(68, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "License Classs :";
            // 
            // LbDLDate
            // 
            this.LbDLDate.AutoSize = true;
            this.LbDLDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbDLDate.Location = new System.Drawing.Point(509, 175);
            this.LbDLDate.Name = "LbDLDate";
            this.LbDLDate.Size = new System.Drawing.Size(151, 32);
            this.LbDLDate.TabIndex = 5;
            this.LbDLDate.Text = "4/16/2026";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLDPresentationLayer.Properties.Resources.Applications;
            this.pictureBox2.Location = new System.Drawing.Point(401, 175);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(68, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(130, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Application Date :";
            // 
            // LbDLApplicationID
            // 
            this.LbDLApplicationID.AutoSize = true;
            this.LbDLApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbDLApplicationID.Location = new System.Drawing.Point(509, 94);
            this.LbDLApplicationID.Name = "LbDLApplicationID";
            this.LbDLApplicationID.Size = new System.Drawing.Size(83, 32);
            this.LbDLApplicationID.TabIndex = 2;
            this.LbDLApplicationID.Text = "[???]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDPresentationLayer.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(401, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "D.L Application ID :\r\n";
            // 
            // BntClose
            // 
            this.BntClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BntClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BntClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BntClose.Image = global::DVLDPresentationLayer.Properties.Resources.icons8_close_30;
            this.BntClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BntClose.Location = new System.Drawing.Point(734, 758);
            this.BntClose.Name = "BntClose";
            this.BntClose.Size = new System.Drawing.Size(121, 45);
            this.BntClose.TabIndex = 51;
            this.BntClose.Text = "   Close";
            this.BntClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BntClose.UseVisualStyleBackColor = true;
            this.BntClose.Click += new System.EventHandler(this.BntClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLDPresentationLayer.Properties.Resources.icons8_save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(919, 758);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 45);
            this.btnSave.TabIndex = 50;
            this.btnSave.Text = "   Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmNewLocalDrivingLicenseApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 815);
            this.Controls.Add(this.BntClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabNewLocalDrivingLicApp);
            this.Controls.Add(this.LbTitle);
            this.Name = "FrmNewLocalDrivingLicenseApp";
            this.Text = "New local Driving Lucense App";
            this.Load += new System.EventHandler(this.FrmNewLocalDrivingLicenseApp_Load);
            this.tabNewLocalDrivingLicApp.ResumeLayout(false);
            this.tabPersonalInfo.ResumeLayout(false);
            this.tabApplicationInfo.ResumeLayout(false);
            this.tabApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.TabControl tabNewLocalDrivingLicApp;
        private System.Windows.Forms.TabPage tabPersonalInfo;
        private System.Windows.Forms.TabPage tabApplicationInfo;
        private ctrlPersonSelector ctrlPersonSelector2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button BntClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbDLDate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LbDLApplicationID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxLicenseClasses;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LbDLApplicationFees;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LbUserCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}