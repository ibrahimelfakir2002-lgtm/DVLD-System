using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharedDvldClasses;
using SharedDvldClasses.Enums;
using DVLDDataAccessLayer;

namespace DVLDPresentationLayer
{
    public partial class ctrlApplicationNewLicense : UserControl
    {
        public ctrlApplicationNewLicense()
        {
            InitializeComponent();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void ctrlApplicationNewLicense_Load(object sender, EventArgs e)
        {

        }

        public void LoadData(clsLicense license,
      decimal fees,
      string CreateBy,
      decimal LicenseFees,
             int? applicationID = null,
      int? RnewlLicenseID = null)
        {


           

                LbAppDate.Text = license.IssueDate.ToString();
                LbIssueDate.Text = license.IssueDate.ToString();

            LbAppFees.Text = fees.ToString();


            LbLicenseFees.Text = LicenseFees.ToString();

                txtNotes.Text = license.Notes.ToString();

                LbOldLicenseID.Text = license.LicenseID.ToString();
                LbEXpertaionDate.Text = license.ExpirationDate.ToString();

                LbCreateBy.Text = clsGlobalSettings.CurrentUser.UserName;

                LbTotalFees.Text = ((LicenseFees) + (fees)).ToString();


           LbRenewAppID.Text = applicationID?.ToString() ?? "N/A";
            LbRenewLicenseId.Text = RnewlLicenseID?.ToString() ?? "N/A";



        }
    }
}
