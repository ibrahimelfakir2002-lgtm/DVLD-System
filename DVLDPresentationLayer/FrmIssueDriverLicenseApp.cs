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
using static DVLDBussinessLayer.clsApplication;

namespace DVLDPresentationLayer
{
    public partial class FrmIssueDriverLicenseApp : Form
    {
        private int _localAppID;
        private int _CrreateUaserID;
        public FrmIssueDriverLicenseApp(int localAppID)
        {
            InitializeComponent();

            _localAppID = localAppID;

            _CrreateUaserID = clsGlobalSettings.CurrentUserID;


        }

        private void FrmIssueDriverLicenseApp_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseAppAndAppInfo1.LoadData(_localAppID);
        }




        private void btnIssue_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            int licenseID = -1;

            bool result = clsLicense.IssueLicense(
                _localAppID,
                txtNotes.Text,
                clsGlobalSettings.CurrentUserID,
                ref licenseID,
                ref errorMessage
            );

            if (result)
            {
                this.Tag = licenseID;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void BntClose_Click(object sender, EventArgs e)
        {

        }
    }
}
