using DVLDBussinessLayer;
using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobalSettings.CurrentUser = null;

            FrmLogin login = new FrmLogin();
            login.Show();

            this.Close(); // 🔥 مهم جدًا
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManagePeople frm = new FrmManagePeople();

            frm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageUsers frm = new FrmManageUsers();
            frm.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword  Frm = new FrmChangePassword(clsGlobalSettings.CurrentUserID);

            Frm.Show();
        }

        private void currentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmUserDetails frm = new FrmUserDetails(clsGlobalSettings.CurrentUserID);

            frm.Show();
        }

        private void manageApplicationsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageApplicationsTypes frm = new FrmManageApplicationsTypes();
            frm.Show();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageTestTypes frm = new FrmManageTestTypes();

            frm.Show();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewLocalDrivingLicenseApp frm = new FrmNewLocalDrivingLicenseApp();
            frm.Show();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {
            clsLicense.SyncExpiredLicenses();
        }

        private void localDrivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplications frm = new LocalDrivingLicenseApplications();

            frm.Show();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageDrivers frm = new FrmManageDrivers();  

            frm.Show(); 
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewInternationalLicense frm = new FrmNewInternationalLicense();  

            frm.Show(); 
        }

        private void internationalLicensesApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageInternationalLicenseApplications Frm = new FrmManageInternationalLicenseApplications();
            Frm.Show();
        }

        private void renewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRenewLicense frm = new FrmRenewLicense();
            frm.Show(); 
        }
    }
}
