using DVLDBusinessLayer;
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
    public partial class ctrlInternationalApplicationInfo : UserControl
    {
        public ctrlInternationalApplicationInfo()
        {
            InitializeComponent();
        }

        public void SetData(
      clsLicense license,
      decimal fees,
      DateTime applicationDate,
      DateTime expirationDate,
      string createdBy,
      int? applicationID = null,
      int? internationalLicenseID = null)
        {
            LbLocalLicenseID.Text = license.LicenseID.ToString();

            LbIssueDate.Text = license.IssueDate.ToString("yyyy-MM-dd");
            LbAppDate.Text = applicationDate.ToString("yyyy-MM-dd");
            LbExperationDate.Text = expirationDate.ToString("yyyy-MM-dd");

            LbFees.Text = fees.ToString();

            LbCreateBy.Text = createdBy;

            LbInterAppID.Text = applicationID?.ToString() ?? "N/A";
            LbInterLicenseID.Text = internationalLicenseID?.ToString() ?? "N/A";

            
        }
     

        private void ctrlInternationalApplicationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
