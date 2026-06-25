using DVLDBussinessLayer;
using DVLDDataAccessLayer;
using SharedDvldClasses.Enums;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class FrmNewInternationalLicense : Form
    {
        public FrmNewInternationalLicense()
        {
            InitializeComponent();
        }

        private clsLicense _selectedLicense;

        private int _InternationalLicenseID;

        private void FrmNewInternationalLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseSelector1.OnLicenseSelected += LicenseSelected;

            LinkLbShowLicenseINfo.Enabled = false;
        }

        private void LicenseSelected(clsLicense license)
        {
            _selectedLicense = license;

            var type = clsApplicationTypes.FindByID((int)enApplicationType.InternationalLicense);
            decimal fees = Convert.ToDecimal(type.ApplicationTypeFees);

            // show only basic info (no DB logic in control)
            ctrlInternationalApplicationInfo1.SetData(
                license,
               fees,
                DateTime.Now,
                DateTime.Now.AddYears(1),
                clsGlobalSettings.CurrentUser.UserName
            );




            if (license.ExpirationDate <= DateTime.Now)
            {
                MessageBox.Show(" License Is Expired");
                this.Close();
                return;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (_selectedLicense == null)
            {
                MessageBox.Show("Select license first");
                return;
            }

            // ✅ NEW: Check expiration BEFORE confirmation
            //if (_selectedLicense.ExpirationDate < DateTime.Now)
            //{
            //    MessageBox.Show("Cannot issue international license. Local license is expired.");
            //    return;
            //}

            // Confirm
            var confirm = MessageBox.Show(
                "Are you sure you want to issue the international license?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
            {
                MessageBox.Show("Operation canceled");
                return;
            }

            btnIssue.Enabled = false;

            try
            {
                // Check duplicate
                if (clsInternationalLicense.IsExist(_selectedLicense.DriverID, _selectedLicense.LicenseID))
                {
                    MessageBox.Show("International license already exists for this license.");
                    return;
                }

                var result = clsInternationalLicense.IssueInternationalLicense(
                    _selectedLicense.LicenseID,
                    clsGlobalSettings.CurrentUser.UserID
                );

                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                _InternationalLicenseID = result.InternationalLicenseID;

                MessageBox.Show(
                    $"International License issued successfully!\n\n" +
                    $"International License ID: {result.InternationalLicenseID}\n" +
                    $"Application ID: {result.ApplicationID}",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                var type = clsApplicationTypes.FindByID((int)enApplicationType.InternationalLicense);
                decimal fees = Convert.ToDecimal(type.ApplicationTypeFees);

                ctrlInternationalApplicationInfo1.SetData(
                    _selectedLicense,
                    fees,
                    DateTime.Now,
                    DateTime.Now.AddYears(1),
                    clsGlobalSettings.CurrentUser.UserName,
                    result.ApplicationID,
                    result.InternationalLicenseID
                );
            }
            finally
            {
                btnIssue.Enabled = true;

                LinkLbShowLicenseINfo.Enabled = true;
            }
        }
        private void LinkLBShowLicesneHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowPersonLicenseHistory frm = new FrmShowPersonLicenseHistory(_selectedLicense.DriverID);

            frm.Show();
        }

        private void LinkLbShowLicenseINfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (_InternationalLicenseID <= 0)
            {
                MessageBox.Show("Invalid License ID");
                return;
            }
            FrmInternationalDriverInfo frm = new FrmInternationalDriverInfo(_InternationalLicenseID);

            frm.Show();
        }
    }
    }
