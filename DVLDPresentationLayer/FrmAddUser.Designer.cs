namespace DVLDPresentationLayer
{
    partial class FrmAddUser
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
            this.TabAddUser = new System.Windows.Forms.TabControl();
            this.tabPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabLoginInfo = new System.Windows.Forms.TabPage();
            this.checkBoxIsActive = new System.Windows.Forms.CheckBox();
            this.txtConfirmdPassword = new System.Windows.Forms.TextBox();
            this.pboxConfirmdPassword = new System.Windows.Forms.PictureBox();
            this.lbTitleConfirmdPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pboxPassword = new System.Windows.Forms.PictureBox();
            this.LbTitlePassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.pboxUserName = new System.Windows.Forms.PictureBox();
            this.lbTitleUserName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LbUserID = new System.Windows.Forms.Label();
            this.LbTitleUserID = new System.Windows.Forms.Label();
            this.BntClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.LbMode = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonSelector1 = new DVLDPresentationLayer.ctrlPersonSelector();
            this.TabAddUser.SuspendLayout();
            this.tabPersonalInfo.SuspendLayout();
            this.tabLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxConfirmdPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TabAddUser
            // 
            this.TabAddUser.Controls.Add(this.tabPersonalInfo);
            this.TabAddUser.Controls.Add(this.tabLoginInfo);
            this.TabAddUser.Location = new System.Drawing.Point(46, 59);
            this.TabAddUser.Name = "TabAddUser";
            this.TabAddUser.SelectedIndex = 0;
            this.TabAddUser.Size = new System.Drawing.Size(923, 655);
            this.TabAddUser.TabIndex = 1;
            // 
            // tabPersonalInfo
            // 
            this.tabPersonalInfo.Controls.Add(this.btnNext);
            this.tabPersonalInfo.Controls.Add(this.ctrlPersonSelector1);
            this.tabPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPersonalInfo.Location = new System.Drawing.Point(4, 29);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonalInfo.Size = new System.Drawing.Size(915, 622);
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
            this.btnNext.Location = new System.Drawing.Point(754, 571);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(121, 45);
            this.btnNext.TabIndex = 50;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // tabLoginInfo
            // 
            this.tabLoginInfo.Controls.Add(this.checkBoxIsActive);
            this.tabLoginInfo.Controls.Add(this.txtConfirmdPassword);
            this.tabLoginInfo.Controls.Add(this.pboxConfirmdPassword);
            this.tabLoginInfo.Controls.Add(this.lbTitleConfirmdPassword);
            this.tabLoginInfo.Controls.Add(this.txtPassword);
            this.tabLoginInfo.Controls.Add(this.pboxPassword);
            this.tabLoginInfo.Controls.Add(this.LbTitlePassword);
            this.tabLoginInfo.Controls.Add(this.txtUserName);
            this.tabLoginInfo.Controls.Add(this.pboxUserName);
            this.tabLoginInfo.Controls.Add(this.lbTitleUserName);
            this.tabLoginInfo.Controls.Add(this.pictureBox1);
            this.tabLoginInfo.Controls.Add(this.LbUserID);
            this.tabLoginInfo.Controls.Add(this.LbTitleUserID);
            this.tabLoginInfo.Location = new System.Drawing.Point(4, 29);
            this.tabLoginInfo.Name = "tabLoginInfo";
            this.tabLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoginInfo.Size = new System.Drawing.Size(915, 622);
            this.tabLoginInfo.TabIndex = 1;
            this.tabLoginInfo.Text = "Login Info";
            this.tabLoginInfo.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsActive
            // 
            this.checkBoxIsActive.AutoSize = true;
            this.checkBoxIsActive.BackColor = System.Drawing.Color.Silver;
            this.checkBoxIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIsActive.Location = new System.Drawing.Point(365, 441);
            this.checkBoxIsActive.Name = "checkBoxIsActive";
            this.checkBoxIsActive.Size = new System.Drawing.Size(153, 36);
            this.checkBoxIsActive.TabIndex = 12;
            this.checkBoxIsActive.Text = " Is Active";
            this.checkBoxIsActive.UseVisualStyleBackColor = false;
            // 
            // txtConfirmdPassword
            // 
            this.txtConfirmdPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmdPassword.Location = new System.Drawing.Point(400, 330);
            this.txtConfirmdPassword.Name = "txtConfirmdPassword";
            this.txtConfirmdPassword.Size = new System.Drawing.Size(204, 35);
            this.txtConfirmdPassword.TabIndex = 11;
            // 
            // pboxConfirmdPassword
            // 
            this.pboxConfirmdPassword.Image = global::DVLDPresentationLayer.Properties.Resources.Password_32;
            this.pboxConfirmdPassword.Location = new System.Drawing.Point(325, 333);
            this.pboxConfirmdPassword.Name = "pboxConfirmdPassword";
            this.pboxConfirmdPassword.Size = new System.Drawing.Size(37, 34);
            this.pboxConfirmdPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxConfirmdPassword.TabIndex = 10;
            this.pboxConfirmdPassword.TabStop = false;
            // 
            // lbTitleConfirmdPassword
            // 
            this.lbTitleConfirmdPassword.AutoSize = true;
            this.lbTitleConfirmdPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleConfirmdPassword.Location = new System.Drawing.Point(33, 330);
            this.lbTitleConfirmdPassword.Name = "lbTitleConfirmdPassword";
            this.lbTitleConfirmdPassword.Size = new System.Drawing.Size(275, 32);
            this.lbTitleConfirmdPassword.TabIndex = 9;
            this.lbTitleConfirmdPassword.Text = "Confirmd Password :";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(400, 254);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(204, 35);
            this.txtPassword.TabIndex = 8;
            // 
            // pboxPassword
            // 
            this.pboxPassword.Image = global::DVLDPresentationLayer.Properties.Resources.Password_32;
            this.pboxPassword.Location = new System.Drawing.Point(325, 257);
            this.pboxPassword.Name = "pboxPassword";
            this.pboxPassword.Size = new System.Drawing.Size(37, 34);
            this.pboxPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxPassword.TabIndex = 7;
            this.pboxPassword.TabStop = false;
            // 
            // LbTitlePassword
            // 
            this.LbTitlePassword.AutoSize = true;
            this.LbTitlePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitlePassword.Location = new System.Drawing.Point(155, 257);
            this.LbTitlePassword.Name = "LbTitlePassword";
            this.LbTitlePassword.Size = new System.Drawing.Size(153, 32);
            this.LbTitlePassword.TabIndex = 6;
            this.LbTitlePassword.Text = "Password :";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(400, 186);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(204, 35);
            this.txtUserName.TabIndex = 5;
            // 
            // pboxUserName
            // 
            this.pboxUserName.Image = global::DVLDPresentationLayer.Properties.Resources.Person_32;
            this.pboxUserName.Location = new System.Drawing.Point(325, 186);
            this.pboxUserName.Name = "pboxUserName";
            this.pboxUserName.Size = new System.Drawing.Size(37, 34);
            this.pboxUserName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxUserName.TabIndex = 4;
            this.pboxUserName.TabStop = false;
            // 
            // lbTitleUserName
            // 
            this.lbTitleUserName.AutoSize = true;
            this.lbTitleUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleUserName.Location = new System.Drawing.Point(138, 186);
            this.lbTitleUserName.Name = "lbTitleUserName";
            this.lbTitleUserName.Size = new System.Drawing.Size(170, 32);
            this.lbTitleUserName.TabIndex = 3;
            this.lbTitleUserName.Text = "User Name :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDPresentationLayer.Properties.Resources.User_32__2;
            this.pictureBox1.Location = new System.Drawing.Point(325, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // LbUserID
            // 
            this.LbUserID.AutoSize = true;
            this.LbUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbUserID.Location = new System.Drawing.Point(394, 107);
            this.LbUserID.Name = "LbUserID";
            this.LbUserID.Size = new System.Drawing.Size(78, 32);
            this.LbUserID.TabIndex = 1;
            this.LbUserID.Text = "[???]";
            // 
            // LbTitleUserID
            // 
            this.LbTitleUserID.AutoSize = true;
            this.LbTitleUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitleUserID.Location = new System.Drawing.Point(186, 107);
            this.LbTitleUserID.Name = "LbTitleUserID";
            this.LbTitleUserID.Size = new System.Drawing.Size(122, 32);
            this.LbTitleUserID.TabIndex = 0;
            this.LbTitleUserID.Text = "User ID :";
            // 
            // BntClose
            // 
            this.BntClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BntClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BntClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BntClose.Image = global::DVLDPresentationLayer.Properties.Resources.icons8_close_30;
            this.BntClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BntClose.Location = new System.Drawing.Point(667, 726);
            this.BntClose.Name = "BntClose";
            this.BntClose.Size = new System.Drawing.Size(121, 45);
            this.BntClose.TabIndex = 49;
            this.BntClose.Text = "   Close";
            this.BntClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BntClose.UseVisualStyleBackColor = true;
            this.BntClose.Click += new System.EventHandler(this.BntClose_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLDPresentationLayer.Properties.Resources.icons8_save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(852, 726);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 45);
            this.btnSave.TabIndex = 48;
            this.btnSave.Text = "   Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // LbMode
            // 
            this.LbMode.AutoSize = true;
            this.LbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbMode.ForeColor = System.Drawing.Color.Red;
            this.LbMode.Location = new System.Drawing.Point(382, 19);
            this.LbMode.Name = "LbMode";
            this.LbMode.Size = new System.Drawing.Size(246, 37);
            this.LbMode.TabIndex = 13;
            this.LbMode.Text = "Add New User ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonSelector1
            // 
            this.ctrlPersonSelector1.Location = new System.Drawing.Point(18, 6);
            this.ctrlPersonSelector1.Name = "ctrlPersonSelector1";
            this.ctrlPersonSelector1.Size = new System.Drawing.Size(836, 564);
            this.ctrlPersonSelector1.TabIndex = 0;
            // 
            // FrmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 783);
            this.Controls.Add(this.LbMode);
            this.Controls.Add(this.BntClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.TabAddUser);
            this.Name = "FrmAddUser";
            this.Text = " Add New User";
            this.Load += new System.EventHandler(this.FrmAddUser_Load);
            this.TabAddUser.ResumeLayout(false);
            this.tabPersonalInfo.ResumeLayout(false);
            this.tabLoginInfo.ResumeLayout(false);
            this.tabLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxConfirmdPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonSelector ctrlPersonSelector1;
        private System.Windows.Forms.TabControl TabAddUser;
        private System.Windows.Forms.TabPage tabPersonalInfo;
        private System.Windows.Forms.TabPage tabLoginInfo;
        private System.Windows.Forms.Label LbTitleUserID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pboxPassword;
        private System.Windows.Forms.Label LbTitlePassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.PictureBox pboxUserName;
        private System.Windows.Forms.Label lbTitleUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LbUserID;
        private System.Windows.Forms.CheckBox checkBoxIsActive;
        private System.Windows.Forms.TextBox txtConfirmdPassword;
        private System.Windows.Forms.PictureBox pboxConfirmdPassword;
        private System.Windows.Forms.Label lbTitleConfirmdPassword;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button BntClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label LbMode;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}