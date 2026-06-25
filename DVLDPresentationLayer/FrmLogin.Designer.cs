namespace DVLDPresentationLayer
{
    partial class FrmLogin
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
            this.LbLoginTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.LbPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkRememberMe = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pBoxPasswordImage = new System.Windows.Forms.PictureBox();
            this.pBoxUserNameImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPasswordImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxUserNameImage)).BeginInit();
            this.SuspendLayout();
            // 
            // LbLoginTitle
            // 
            this.LbLoginTitle.AutoSize = true;
            this.LbLoginTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbLoginTitle.Location = new System.Drawing.Point(189, 94);
            this.LbLoginTitle.Name = "LbLoginTitle";
            this.LbLoginTitle.Size = new System.Drawing.Size(347, 32);
            this.LbLoginTitle.TabIndex = 0;
            this.LbLoginTitle.Text = "  Login To Your Account ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserName  : ";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Control;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(418, 170);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(204, 30);
            this.txtUserName.TabIndex = 3;
            // 
            // LbPassword
            // 
            this.LbPassword.AutoSize = true;
            this.LbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbPassword.Location = new System.Drawing.Point(174, 229);
            this.LbPassword.Name = "LbPassword";
            this.LbPassword.Size = new System.Drawing.Size(156, 29);
            this.LbPassword.TabIndex = 4;
            this.LbPassword.Text = " Password  :";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(418, 228);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(204, 30);
            this.txtPassword.TabIndex = 6;
            // 
            // chkRememberMe
            // 
            this.chkRememberMe.AutoSize = true;
            this.chkRememberMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRememberMe.Location = new System.Drawing.Point(336, 317);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Size = new System.Drawing.Size(225, 33);
            this.chkRememberMe.TabIndex = 7;
            this.chkRememberMe.Text = " Remember Me ";
            this.chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Image = global::DVLDPresentationLayer.Properties.Resources.sign_in_32;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(336, 397);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(145, 63);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = " Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pBoxPasswordImage
            // 
            this.pBoxPasswordImage.Image = global::DVLDPresentationLayer.Properties.Resources.Password_32;
            this.pBoxPasswordImage.Location = new System.Drawing.Point(336, 229);
            this.pBoxPasswordImage.Name = "pBoxPasswordImage";
            this.pBoxPasswordImage.Size = new System.Drawing.Size(51, 29);
            this.pBoxPasswordImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxPasswordImage.TabIndex = 5;
            this.pBoxPasswordImage.TabStop = false;
            // 
            // pBoxUserNameImage
            // 
            this.pBoxUserNameImage.Image = global::DVLDPresentationLayer.Properties.Resources.User_32__2;
            this.pBoxUserNameImage.Location = new System.Drawing.Point(335, 171);
            this.pBoxUserNameImage.Name = "pBoxUserNameImage";
            this.pBoxUserNameImage.Size = new System.Drawing.Size(51, 29);
            this.pBoxUserNameImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxUserNameImage.TabIndex = 2;
            this.pBoxUserNameImage.TabStop = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 541);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkRememberMe);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.pBoxPasswordImage);
            this.Controls.Add(this.LbPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.pBoxUserNameImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbLoginTitle);
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.Activated += new System.EventHandler(this.FrmLogin_Activated);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPasswordImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxUserNameImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbLoginTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pBoxUserNameImage;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label LbPassword;
        private System.Windows.Forms.PictureBox pBoxPasswordImage;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkRememberMe;
        private System.Windows.Forms.Button btnLogin;
    }
}