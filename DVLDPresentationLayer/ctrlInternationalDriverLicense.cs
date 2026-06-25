using DVLDBussinessLayer;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class ctrlInternationalDriverLicense : UserControl
    {
        private int _interLicenseID = -1;
        private clsInternationalLicense _interLicense;

        public ctrlInternationalDriverLicense()
        {
            InitializeComponent();
        }

        // 🔹 Public setter
        public void SetInterLicenseID(int interLicenseID)
        {
            if (_interLicenseID == interLicenseID)
                return;

            _interLicenseID = interLicenseID;

            LoadInternationalLicense();
        }

        // 🔹 Main loader
        private void LoadInternationalLicense()
        {
            ResetUI();

            if (_interLicenseID <= 0)
            {
                ShowError("Invalid License ID.");
                return;
            }

            _interLicense = clsInternationalLicense.FindByID(_interLicenseID);

            if (_interLicense == null)
            {
                ShowError($"License with ID {_interLicenseID} not found.");
                return;
            }

            BindLicenseData();
            LoadPersonData();
        }

        // 🔹 Bind License Info
        private void BindLicenseData()
        {
            LbInterLicenseId.Text = _interLicense.InternationalLicenseID.ToString();
            LbIssueDate.Text = _interLicense.IssueDate.ToShortDateString();
            LbExperationDate.Text = _interLicense.ExpirationDate.ToShortDateString();
            LbDriverID.Text = _interLicense.DriverID.ToString();
            LbAppID.Text = _interLicense.ApplicationID.ToString();
            LbIsActive.Text = _interLicense.IsActive ? "Yes" : "No";
            LbLocalLicenseID.Text = _interLicense.IssuedUsingLocalLicenseID.ToString();
        }

        // 🔹 Load related Person
        private void LoadPersonData()
        {
            var app = clsApplication.FindByApplicationID(_interLicense.ApplicationID);

            if (app == null)
            {
                ShowError("Application not found.");
                return;
            }

            var person = clsPerson.GetPersonByID(app.ApplicantPersonID);

            if (person == null)
            {
                ShowError("Person not found.");
                return;
            }

            BindPersonData(person);
        }

        // 🔹 Bind Person Info
        private void BindPersonData(clsPerson person)
        {
            LbName.Text = $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}";
            LbNationalNo.Text = person.NationalNo;
            LbDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
            LbGendor.Text = person.Gendor == 0 ? "Male" : "Female";
        }

        // 🔹 Reset UI safely
        private void ResetUI()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                    lbl.Text = string.Empty;
            }
        }

        // 🔹 Debug helper (you can remove later)
        private void ShowError(string message)
        {
            // During development:
            MessageBox.Show(message, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ctrlInternationalDriverLicense_Load(object sender, EventArgs e)
        {
            // Optional: keep empty
        }
    }
}