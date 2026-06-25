using DVLDBussinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using SharedDvldClasses;
using SharedDvldClasses.Enums;
namespace DVLDPresentationLayer
{
    public partial class FrmTestAppointments : Form
    {
        private readonly int _localAppID;
        private readonly enTestType _testType;

        private DataTable _dtAppointments;

        public event Action<bool> OnTestPassed;

        public FrmTestAppointments(int localAppID, SharedDvldClasses.Enums.enTestType testType)
        {
            InitializeComponent();

            _localAppID = localAppID;
            _testType = testType;
        }

        private void FrmTestAppointments_Load(object sender, EventArgs e)
        {

        }

        private void SetFormTitle()
        {
            switch (_testType)
            {
                case enTestType.Vision:
                    this.Text = "Vision Test Appointments";
                    break;

                case enTestType.Written:
                   this. Text = "Written Test Appointments";
                    break;

                case enTestType.Street:
                   this. Text = "Street Test Appointments";
                    break;
            }
        }

        private void RefreshAppointmentsList()
        {
            _dtAppointments =
     clsAppointment.GetAllAppointmentsByLocalIDAndTestType(
         _localAppID,
         (int)_testType);


            DGVAppointments.DataSource = _dtAppointments;

            LbNumberOfRecords.Text =
                _dtAppointments.Rows.Count.ToString();
        }


        
        private bool IsTestPassed()
        {
            return clsTest.GetLastTestResult(_localAppID, _testType)
                   == SharedDvldClasses.Enums.enTestResult.Passed;
        }

        private bool HasActiveAppointment()
        {
            return clsAppointment.HasActiveAppointment(
                _localAppID,
                (int)_testType);
        }

        private bool CanTakeTest(int appointmentID)
        {
            clsAppointment appointment =
                clsAppointment.Find(appointmentID);

            if (appointment == null)
                return false;

            return !appointment.IsLocked;
        }

        private void picBoxAddApointment_Click(object sender, EventArgs e)
        {
            if (HasActiveAppointment())
            {
                MessageBox.Show(
                    "This person already has an active appointment for this test.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmScheduleTest frm =
                new FrmScheduleTest(_localAppID, _testType);

            frm.OnSaveCompleted += (success) =>
            {
                RefreshAppointmentsList();
            };

            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appointmentID =
                (int)DGVAppointments.CurrentRow
                .Cells["TestAppointmentID"].Value;

            FrmScheduleTest frm =
                new FrmScheduleTest(appointmentID);

            frm.OnSaveCompleted += (success) =>
            {
                RefreshAppointmentsList();
            };

            frm.ShowDialog();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appointmentID =
                (int)DGVAppointments.CurrentRow
                .Cells["TestAppointmentID"].Value;

            if (!CanTakeTest(appointmentID))
            {
                MessageBox.Show(
                    "This test already taken.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmTakeTest frm =
                new FrmTakeTest(appointmentID);

            frm.OnSaveCompleted += (success) =>
            {
                RefreshAppointmentsList();
            };

            frm.OnTestPassed += (success) =>
            {
                OnTestPassed?.Invoke(true);
            };

            frm.ShowDialog();
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ctrlDrivingLicenseAppAndAppInfo1_Load(object sender, EventArgs e)
        {

        }

        private void FrmTestAppointments_Load_1(object sender, EventArgs e)
        {

            SetFormTitle();

            ctrlDrivingLicenseAppAndAppInfo1.LoadData(_localAppID);

            RefreshAppointmentsList();
        }

        private void contextMenuStripAppointments_Opening(object sender, CancelEventArgs e)
        {
            if (IsTestPassed())
            {
                e.Cancel = true; // 🚫 prevents the menu from showing
                return;
            }
        }
    }
}