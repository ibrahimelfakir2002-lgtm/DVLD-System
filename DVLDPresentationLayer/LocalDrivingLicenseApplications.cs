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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using SharedDvldClasses.Enums;
namespace DVLDPresentationLayer
{
    public partial class LocalDrivingLicenseApplications : Form
    {
        private DataTable _LocalApplications;

        private int _LicenseID;

        private clsLocalDrivingLicenseApplication LocalApp;

      
        public LocalDrivingLicenseApplications()
        {
            InitializeComponent();



        }

        private void RefreshLocalDrivingLApplicationsList()
        {
            _LocalApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

            DGVLocalDLApplications.DataSource = _LocalApplications;

            _LocalApplications.DefaultView.RowFilter = "";
            txtSearch.Text = "";

           
        }
        private void SetupFilters()
        {
            var filters = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("None", "None"),
        new KeyValuePair<string, string>("L DL AppID", "LocalDrivingLicenseApplicationID"),
        new KeyValuePair<string, string>("National No", "NationalNo"),
         new KeyValuePair<string, string>("Full Name", "FullName"),
            new KeyValuePair<string, string>("Status", "Status"),


    };

            cbFilterBy.DataSource = filters;
            cbFilterBy.DisplayMember = "Key";
            cbFilterBy.ValueMember = "Value";
        }

        private void UpdateSearchVisibility()
        {
            txtSearch.Visible = cbFilterBy.SelectedValue.ToString() != "None";
        }
        private void UpdateScheduleTestMenuState()
        {
            if (DGVLocalDLApplications.CurrentRow == null)
                return;

            int localAppID =
                (int)DGVLocalDLApplications.CurrentRow
                .Cells["LocalDrivingLicenseApplicationID"].Value;

            LocalApp =
                clsLocalDrivingLicenseApplication.Find(localAppID);

            if (LocalApp == null)
            {
                sechduleTestToolStripMenuItem.Enabled = false;
                return;
            }

            sechduleTestToolStripMenuItem.Enabled =
                !LocalApp.DoesPassAllTests();
        }
        private void FrmManagePeople_Load_1(object sender, EventArgs e)
        {
          //  RefreshLocalDrivingLApplicationsList();

           // UpdateScheduleTestMenuState();

            //LbNumberOfRecords.Text = _LocalApplications.DefaultView.Count.ToString();

            //SetupFilters();

            //cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
           // DgvPeople.CellDoubleClick += DgvPeople_CellDoubleClick;

           // pbAddPerson.Cursor = Cursors.Hand;
           // toolTip1.SetToolTip(pbAddPerson, "Add New Person");

            //UpdateSearchVisibility();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                if (cbFilterBy.SelectedValue == null)
                    return;

                txtSearch.Visible = cbFilterBy.SelectedValue.ToString() != "None";
            }
        
        private void pBoxAddImage_Click(object sender, EventArgs e)
        {
            FrmNewLocalDrivingLicenseApp frm = new FrmNewLocalDrivingLicenseApp();
            frm.OnLocalAppSaved += (success) =>
            {
                RefreshLocalDrivingLApplicationsList(); // 🔥 تحديث الجدول مباشرة
            };
            frm.Show();
        }

        private void Frm_OnLocalAppSaved(bool obj)
        {
            throw new NotImplementedException();
        }

        private void LocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            RefreshLocalDrivingLApplicationsList();

            LbNumberOfRecords.Text = _LocalApplications.DefaultView.Count.ToString();

            SetupFilters();

          

            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;

            cbFilterBy.SelectedIndex = 0; // مهم جدًا

            UpdateSearchVisibility();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {


            if (_LocalApplications == null || cbFilterBy.SelectedValue == null)
                return;

            string column = cbFilterBy.SelectedValue.ToString();
            string value = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(value))
            {
                _LocalApplications.DefaultView.RowFilter = "";
                return;
            }

            if (!_LocalApplications.Columns.Contains(column))
                return;

            Type columnType = _LocalApplications.Columns[column].DataType;

            if (columnType == typeof(int) || columnType == typeof(short) || columnType == typeof(long))
            {
                if (int.TryParse(value, out int number))
                    _LocalApplications.DefaultView.RowFilter = $"{column} = {number}";
                else
                    _LocalApplications.DefaultView.RowFilter = "0 = 1";
            }
            else
            {
                value = value.Replace("'", "''");

                
                    _LocalApplications.DefaultView.RowFilter = $"{column} LIKE '%{value}%'";
                
            }
        }

        private void BntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

          
        }

        private void canceledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalAppID =  (int)DGVLocalDLApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;

            int ApplicationID = clsLocalDrivingLicenseApplication.GetApplicationIDByLocalAppID(LocalAppID);


           

            clsApplication App = clsApplication.FindByApplicationID(ApplicationID);

            if (App == null)
            {
                MessageBox.Show("Application not found!");
                return;
            }

            if (App.Cancel())

            {
                RefreshLocalDrivingLApplicationsList();


                MessageBox.Show("Application canceled successfully");
            }
            else
            {
                MessageBox.Show("Failed to cancel application");
            }

            RefreshLocalDrivingLApplicationsList();
        }

      
            private void contextMenuStripLocalApplications_Opening(object sender, CancelEventArgs e)
            {
                if (DGVLocalDLApplications.CurrentRow == null)
                {
                    e.Cancel = true;
                    return;
                }

                int localAppID =
                    Convert.ToInt32(DGVLocalDLApplications.CurrentRow
                    .Cells["LocalDrivingLicenseApplicationID"].Value);

            var LocalApp = clsLocalDrivingLicenseApplication.Find(localAppID);

            RefreshTestMenu(LocalApp);

            }


        private void sechduleWrittingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localAppID = GetSelectedLocalAppID();

            FrmTestAppointments frm =
                new FrmTestAppointments(localAppID, enTestType.Written);

            frm.OnTestPassed += (s) => RefreshLocalDrivingLApplicationsList();

            frm.Show();
        }

        private void sechduleViewTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localAppID = GetSelectedLocalAppID();

            FrmTestAppointments frm =
                new FrmTestAppointments(localAppID, enTestType.Vision);

            frm.OnTestPassed += (s) => RefreshLocalDrivingLApplicationsList();

            frm.Show();
        }

        private void RefreshTestMenu(clsLocalDrivingLicenseApplication app)
        {
            // Reset all
            canceledToolStripMenuItem.Enabled = false;
            sechduleViewTestToolStripMenuItem.Enabled = false;
            sechduleWrittingToolStripMenuItem.Enabled = false;
            sechduleStreetToolStripMenuItem.Enabled = false;
            issueDriverLicenseToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
            showApplicationDetailsToolStripMenuItem.Enabled = false;
            editApplicationToolStripMenuItem.Enabled = false;
            deleteApplicationToolStripMenuItem.Enabled = false;

            bool hasAppointments = app.HasScheduledTests();
            bool isIssued = app.IsLicenseIssued();
            bool passedAll = app.HasPassedAllTests();

            // 🟢 NEW APPLICATION
            if (!hasAppointments && !passedAll && !isIssued)
            {
                showApplicationDetailsToolStripMenuItem.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
                canceledToolStripMenuItem.Enabled = true;

                sechduleViewTestToolStripMenuItem.Enabled = true;
                sechduleWrittingToolStripMenuItem.Enabled = true;
                sechduleStreetToolStripMenuItem.Enabled = true;

                return;
            }


            if (hasAppointments && !passedAll && !isIssued)
            {
                showApplicationDetailsToolStripMenuItem.Enabled = true;

                editApplicationToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
                canceledToolStripMenuItem.Enabled = true;

                sechduleViewTestToolStripMenuItem.Enabled = app.CanScheduleVisionTest();
                sechduleWrittingToolStripMenuItem.Enabled = app.CanScheduleWrittenTest();
                sechduleStreetToolStripMenuItem.Enabled = app.CanScheduleStreetTest();

                // Issue فقط إذا passed all
                issueDriverLicenseToolStripMenuItem.Enabled =
                    passedAll && app.CanIssueLicense();

                return;
            }

            if (passedAll && !isIssued)
            {
                showApplicationDetailsToolStripMenuItem.Enabled = true;

                issueDriverLicenseToolStripMenuItem.Enabled = true;

                return;
            }
            if (isIssued)
            {
                showApplicationDetailsToolStripMenuItem.Enabled = true;
                showLicenseToolStripMenuItem.Enabled = true;

                // history يظهر فقط بعد الإصدار
                showApplicationDetailsToolStripMenuItem.Enabled = true;

                return;
            }
        
    }
      
        private void sechduleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localAppID =
          (int)DGVLocalDLApplications.CurrentRow
          .Cells["LocalDrivingLicenseApplicationID"].Value;

            clsLocalDrivingLicenseApplication app = clsLocalDrivingLicenseApplication.Find(localAppID);

            RefreshTestMenu(app);
        }
        private int GetSelectedLocalAppID()
        {
            return Convert.ToInt32(
                DGVLocalDLApplications.CurrentRow
                .Cells["LocalDrivingLicenseApplicationID"].Value);
        }

        private void sechduleStreetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localAppID = GetSelectedLocalAppID();

            FrmTestAppointments frm =
                new FrmTestAppointments(localAppID, enTestType.Street);

            frm.OnTestPassed += (s) => RefreshLocalDrivingLApplicationsList();

            frm.Show();
        }
    //    private void UpdateTestMenuState(clsLocalDrivingLicenseApplication app)
    //    {
    //        int localAppID = app.LocalDrivingLicenseApplicationID;

    //        // 🔵 Test results
    //        bool passedVision = clsTest.GetLastTestResult(localAppID, enTestType.Vision)
    //                            == enTestResult.Passed;

    //        bool passedWritten = clsTest.GetLastTestResult(localAppID, enTestType.Written)
    //                             == enTestResult.Passed;

    //        bool passedStreet = clsTest.GetLastTestResult(localAppID, enTestType.Street)
    //                            == enTestResult.Passed;

    //        bool allTestsPassed = passedVision && passedWritten && passedStreet;

    //        // 🟣 License state (SINGLE SOURCE OF TRUTH)
        

    //        bool hasLicense = clsLocalDrivingLicenseApplication
    //.HasLicense(app.ApplicantPersonID, app.LicenseClassID);
    //        sechduleViewTestToolStripMenuItem.Enabled = !passedVision && !hasLicense;

    //        sechduleWrittingToolStripMenuItem.Enabled =
    //            passedVision && !passedWritten && !hasLicense;

    //        sechduleStreetToolStripMenuItem.Enabled =
    //            passedWritten && !passedStreet && !hasLicense;



    //        issueDriverLicenseToolStripMenuItem.Enabled = app.CanIssueLicense();
    //        showLicenseToolStripMenuItem.Enabled = app.CanShowLicense();
    //        editApplicationToolStripMenuItem.Enabled = app.CanEdit();
    //        deleteApplicationToolStripMenuItem.Enabled = app.CanDelete();
    //        canceledToolStripMenuItem.Enabled = app.CanCancel();    



    //    }

            private void contextMenuStripAppointments_Opening(object sender, CancelEventArgs e)
        {
          
        }
        private void DGVLocalDLApplications_SelectionChanged(object sender, EventArgs e)
        {
            UpdateScheduleTestMenuState();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGVLocalDLApplications.CurrentRow == null)
                return;

            int localAppID =
                (int)DGVLocalDLApplications.CurrentRow
                .Cells["LocalDrivingLicenseApplicationID"].Value;

            clsLocalDrivingLicenseApplication localApp =
                clsLocalDrivingLicenseApplication.Find(localAppID);

            if (localApp == null)
            {
                MessageBox.Show("Application not found.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this application?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            string error = "";

            if (localApp.Delete(ref error))
            {
                RefreshLocalDrivingLApplicationsList();
                MessageBox.Show("Application deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(error,
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void issueDriverLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localAppID = GetSelectedLocalAppID();

            FrmIssueDriverLicenseApp frm = new FrmIssueDriverLicenseApp(localAppID);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                int licenseID = (int)frm.Tag;

                MessageBox.Show("License Issued Successfully: " + licenseID);

                RefreshLocalDrivingLApplicationsList();
            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localAppID = GetSelectedLocalAppID();

            var localApp = clsLocalDrivingLicenseApplication.Find(localAppID);

            if (localApp == null)
                return;

            var license =
                clsLicense.GetLicenseIDByApplicationID(localApp.ApplicationID);

            if (license == null || license.LicenseID <= 0)
            {
                MessageBox.Show("No license issued yet.");
                return;
            }

            FrmShowLicense frm = new FrmShowLicense(license.LicenseID);
            frm.Show();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {


            int localAppID = GetSelectedLocalAppID();
            var localApp = clsLocalDrivingLicenseApplication.Find(localAppID);

            if (localApp == null)
                return;

            int PersonID = localApp.ApplicantPersonID;

            ClsDriver driver = ClsDriver.FindByPersonID(PersonID);

            if (driver == null)
                return;


            FrmShowPersonLicenseHistory frm = new FrmShowPersonLicenseHistory(driver.DriverID);
            
            frm.Show(); 
        }
    }
    

}
