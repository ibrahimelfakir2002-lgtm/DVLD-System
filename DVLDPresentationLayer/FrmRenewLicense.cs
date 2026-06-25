using DVLDBussinessLayer;
using DVLDDataAccessLayer;
using SharedDvldClasses.Enums;
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
    public partial class FrmRenewLicense : Form
    {
        private clsLicense _selectedLicense;
        private int RenewLicenseID;

        private int RenewAppID;
        public FrmRenewLicense()
        {
            InitializeComponent();
        }

        private void FrmRenewLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseSelector1.OnLicenseSelected += LicenseSelected;

            LinkLbShowNewLicenseInfo.Enabled = false;
        }


        private void LicenseSelected(clsLicense license)
        {
            _selectedLicense = license;



            if (! (_selectedLicense.ExpirationDate <= DateTime.Now))
            {
                MessageBox.Show($" selected License Is not Expired Yet it will Expired on {_selectedLicense.ExpirationDate}","", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button2);
                this.Close();
                return;
            }


            var type = clsApplicationTypes.FindByID((int)enApplicationType.RenewDrivingLicense);
            decimal Appfees = Convert.ToDecimal(type.ApplicationTypeFees);


            clsLicenseClass licenseClass = clsLicenseClass.Find(_selectedLicense.LicenseClass);

            decimal LicenseFees  = licenseClass.ClassFees;
            ctrlApplicationNewLicense1.LoadData(_selectedLicense, Appfees,
                    
                    clsGlobalSettings.CurrentUser.UserName,
                    LicenseFees);

           


        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            clsLicense activeLicense =
    clsLicense.GetActiveLicenseByDriverIDAndLicenseClass(
        _selectedLicense.DriverID,
        _selectedLicense.LicenseClass);

            if (activeLicense != null)
            {
                MessageBox.Show(
                    $"This license has already been renewed.\n" +
                    $"Active License ID: {activeLicense.LicenseID}");

                return;
            }

            clsApplication oldApplication =
                clsApplication.FindByApplicationID(_selectedLicense.ApplicationID);

            decimal applicationFees =
                Convert.ToDecimal(
                    clsApplicationTypes.FindByID(
                        (int)enApplicationType.RenewDrivingLicense)
                    .ApplicationTypeFees);

            clsApplication renewApplication = new clsApplication
            {
                ApplicantPersonID = oldApplication.ApplicantPersonID,
                ApplicationDate = DateTime.Now,
                ApplicationTypeID = enApplicationType.RenewDrivingLicense,
                ApplicationStatus = oldApplication.ApplicationStatus,
                LastStatusDate = DateTime.Now,
                PaidFees = applicationFees,
                CreatedByUserID = clsGlobalSettings.CurrentUser.UserID
            };

            if (!renewApplication.Save())
            {
                MessageBox.Show("Failed to create renewal application.");
                return;
            }


            LinkLbShowNewLicenseInfo.Enabled = true;


            clsLicenseClass licenseClass =
                clsLicenseClass.Find(_selectedLicense.LicenseClass);

            decimal licenseFees = licenseClass.ClassFees;

            clsLicense newLicense = new clsLicense
            {
                ApplicationID = renewApplication.ApplicationID,
                DriverID = _selectedLicense.DriverID,
                LicenseClass = _selectedLicense.LicenseClass,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(10),
                Notes = _selectedLicense.Notes,
                PaidFees = licenseFees,
                IsActive = 1,
                IssueReason = (int)enIssueReason.Renewal,
                CreatedByUserID = clsGlobalSettings.CurrentUserID
            };

            if (!newLicense.Save())
            {
                MessageBox.Show("Failed to create renewed license.");
                return;
            }

            RenewLicenseID = newLicense.LicenseID;

            _selectedLicense.IsActive = 0;
            _selectedLicense.Save();

            ctrlApplicationNewLicense1.LoadData(
                _selectedLicense,
                applicationFees,
                clsGlobalSettings.CurrentUser.UserName,
                licenseFees,
                renewApplication.ApplicationID,
                newLicense.LicenseID);
        }

        private void LinkLbLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowPersonLicenseHistory Frm = new FrmShowPersonLicenseHistory(_selectedLicense.DriverID);

            Frm.Show();
        }

        private void LinkLbShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowLicense frm = new FrmShowLicense(RenewLicenseID);

            frm.Show(); 
        }
    }
}
