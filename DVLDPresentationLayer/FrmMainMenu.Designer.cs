namespace DVLDPresentationLayer
{
    partial class FrmMainMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuStripApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicensesApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripApplications,
            this.peopleToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1090, 38);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuStripApplications
            // 
            this.MenuStripApplications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicensToolStripMenuItem,
            this.manageApplicationsToolStripMenuItem,
            this.detainedToolStripMenuItem,
            this.manageApplicationsTypesToolStripMenuItem,
            this.manageToolStripMenuItem});
            this.MenuStripApplications.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.MenuStripApplications.Image = global::DVLDPresentationLayer.Properties.Resources.Manage_Applications_32;
            this.MenuStripApplications.Name = "MenuStripApplications";
            this.MenuStripApplications.Size = new System.Drawing.Size(194, 34);
            this.MenuStripApplications.Text = " Applications ";
            this.MenuStripApplications.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // drivingLicensToolStripMenuItem
            // 
            this.drivingLicensToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenceToolStripMenuItem,
            this.renewToolStripMenuItem});
            this.drivingLicensToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.License_Type_32;
            this.drivingLicensToolStripMenuItem.Name = "drivingLicensToolStripMenuItem";
            this.drivingLicensToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.drivingLicensToolStripMenuItem.Text = "Driving Licenses Services";
            // 
            // newDrivingLicenceToolStripMenuItem
            // 
            this.newDrivingLicenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.internationalLicenseToolStripMenuItem});
            this.newDrivingLicenceToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.New_Driving_License_32;
            this.newDrivingLicenceToolStripMenuItem.Name = "newDrivingLicenceToolStripMenuItem";
            this.newDrivingLicenceToolStripMenuItem.Size = new System.Drawing.Size(353, 38);
            this.newDrivingLicenceToolStripMenuItem.Text = "New Driving Licence";
            // 
            // localLicenseToolStripMenuItem
            // 
            this.localLicenseToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Local_32;
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Size = new System.Drawing.Size(331, 38);
            this.localLicenseToolStripMenuItem.Text = "Local License";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // internationalLicenseToolStripMenuItem
            // 
            this.internationalLicenseToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.International_32;
            this.internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            this.internationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(331, 38);
            this.internationalLicenseToolStripMenuItem.Text = "International License";
            this.internationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseToolStripMenuItem_Click);
            // 
            // manageApplicationsToolStripMenuItem
            // 
            this.manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingToolStripMenuItem,
            this.internationalLicensesApplicationsToolStripMenuItem});
            this.manageApplicationsToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Manage_Applications_321;
            this.manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            this.manageApplicationsToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.manageApplicationsToolStripMenuItem.Text = "Manage applications";
            // 
            // localDrivingToolStripMenuItem
            // 
            this.localDrivingToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.LocalDriving_License;
            this.localDrivingToolStripMenuItem.Name = "localDrivingToolStripMenuItem";
            this.localDrivingToolStripMenuItem.Size = new System.Drawing.Size(482, 38);
            this.localDrivingToolStripMenuItem.Text = "Local Driving  License Applications";
            this.localDrivingToolStripMenuItem.Click += new System.EventHandler(this.localDrivingToolStripMenuItem_Click);
            // 
            // internationalLicensesApplicationsToolStripMenuItem
            // 
            this.internationalLicensesApplicationsToolStripMenuItem.Name = "internationalLicensesApplicationsToolStripMenuItem";
            this.internationalLicensesApplicationsToolStripMenuItem.Size = new System.Drawing.Size(482, 38);
            this.internationalLicensesApplicationsToolStripMenuItem.Text = "International Licenses Applications ";
            this.internationalLicensesApplicationsToolStripMenuItem.Click += new System.EventHandler(this.internationalLicensesApplicationsToolStripMenuItem_Click);
            // 
            // detainedToolStripMenuItem
            // 
            this.detainedToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Detain_32;
            this.detainedToolStripMenuItem.Name = "detainedToolStripMenuItem";
            this.detainedToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.detainedToolStripMenuItem.Text = "Detained  Licenses";
            // 
            // manageApplicationsTypesToolStripMenuItem
            // 
            this.manageApplicationsTypesToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Manage_Applications_322;
            this.manageApplicationsTypesToolStripMenuItem.Name = "manageApplicationsTypesToolStripMenuItem";
            this.manageApplicationsTypesToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.manageApplicationsTypesToolStripMenuItem.Text = "Manage Applications Types";
            this.manageApplicationsTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationsTypesToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Test_32;
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.manageToolStripMenuItem.Text = "Manage  Test Type";
            this.manageToolStripMenuItem.Click += new System.EventHandler(this.manageToolStripMenuItem_Click);
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.peopleToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.People_64;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(135, 34);
            this.peopleToolStripMenuItem.Text = "  People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.driversToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Drivers_64;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(127, 34);
            this.driversToolStripMenuItem.Text = "Drivers";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.usersToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Users_2_64;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(110, 34);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.signOutToolStripMenuItem});
            this.accountSettingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.accountSettingsToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.account_settings_641;
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(229, 34);
            this.accountSettingsToolStripMenuItem.Text = "Account Settings";
            // 
            // currentInfoToolStripMenuItem
            // 
            this.currentInfoToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.User_32__2;
            this.currentInfoToolStripMenuItem.Name = "currentInfoToolStripMenuItem";
            this.currentInfoToolStripMenuItem.Size = new System.Drawing.Size(307, 38);
            this.currentInfoToolStripMenuItem.Text = "Current  User Info ";
            this.currentInfoToolStripMenuItem.Click += new System.EventHandler(this.currentInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Password_32;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(307, 38);
            this.changePasswordToolStripMenuItem.Text = "Change Password ";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.sign_out_32__2;
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(307, 38);
            this.signOutToolStripMenuItem.Text = "Sign Out ";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // renewToolStripMenuItem
            // 
            this.renewToolStripMenuItem.Name = "renewToolStripMenuItem";
            this.renewToolStripMenuItem.Size = new System.Drawing.Size(353, 38);
            this.renewToolStripMenuItem.Text = "Renew  Driving License";
            this.renewToolStripMenuItem.Click += new System.EventHandler(this.renewToolStripMenuItem_Click);
            // 
            // FrmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DVLDPresentationLayer.Properties.Resources.Logo_Final;
            this.ClientSize = new System.Drawing.Size(1090, 639);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.FrmMainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuStripApplications;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingLicensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationsTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicensesApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewToolStripMenuItem;
    }
}