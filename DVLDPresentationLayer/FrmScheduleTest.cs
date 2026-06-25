using DVLDBussinessLayer;
using DVLDDataAccessLayer;
using System;
using System.Windows.Forms;

using SharedDvldClasses;
using SharedDvldClasses.Enums;
namespace DVLDPresentationLayer
{
    public partial class FrmScheduleTest : Form
    {
        public enum enMode
        {
            AddNew = 1,
            Update = 2,
            Retake = 3
        }

        private enMode _mode;
        private int _localAppID;
        private int _testTypeID;
        private int _appointmentID = -1;
        enTestResult lastResult = enTestResult.Passed;
        private clsAppointment _appointment;

        public event Action<bool> OnSaveCompleted;


        private decimal GetRetakeFees()
        {
                    return 5;
            
        }

        public FrmScheduleTest(int localAppID, enTestType testType)
    {
        InitializeComponent();

        _localAppID = localAppID;
        _testTypeID = (int)testType;

        _mode = enMode.AddNew;

        lastResult = clsTest.GetLastTestResult(_localAppID,  testType);
    }

    // 🔹 Update
    public FrmScheduleTest(int appointmentID)
        {
            InitializeComponent();

            _appointmentID = appointmentID;
            _mode = enMode.Update;
        }

        private void FrmScheduleTest_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // =========================
        // 🔥 LOAD DATA
        // =========================
      

        private void LoadData()
        {
            // 🔹 UPDATE MODE FIRST
            if (_mode == enMode.Update)
            {
                _appointment = clsAppointment.Find(_appointmentID);

                if (_appointment == null)
                {
                    MessageBox.Show("Appointment not found.");
                    Close();
                    return;
                }

                _localAppID = _appointment.LocalDrivingLicenseApplicationID;
                _testTypeID = _appointment.TestTypeID;
            }

            // =========================
            // 🔥 ONLY FOR ADD NEW LOGIC
            // =========================
            if (_mode == enMode.AddNew)
            {
              

                // ❌ Already Passed → STOP
                if (lastResult == enTestResult.Passed)
                {

                    MessageBox.Show("This Person Already Passed this Test Before . You Can Only Retake Failed Test","",
                    MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                   
                    Close();
                    return;
                }

                // 🔁 Failed → Retake mode
                if (lastResult == enTestResult.Failed)
                {
                    _mode = enMode.Retake;
                }

                // -1 = No test yet → stay AddNew
            }

            // =========================
            // 🔹 LOAD CONTROL
            // =========================
            ctrlVisionTest1.LoadVisionTest(_localAppID, _testTypeID, _appointmentID);

            ApplyMode();
        }

        // =========================
        // 🔥 APPLY MODE UI
        // =========================
        private void ApplyMode()
        {
            switch (_mode)
            {
                case enMode.AddNew:

                    ctrlVisionTest1.SetNormalMode();
                    ctrlVisionTest1.IsLocked = false;
                    gBoxRetakeTestInfo.Enabled = false;
                    btnSave.Enabled = true;

                    break;

                case enMode.Retake:

                    ctrlVisionTest1.SetRetakeMode(GetRetakeFees());
                    ctrlVisionTest1.IsLocked = false;
                    gBoxRetakeTestInfo.Enabled = true;

                    SetupRetakeUI();

                    btnSave.Enabled = true;
                    break;

                case enMode.Update:

                    bool isLocked = _appointment.IsLocked;

                    ctrlVisionTest1.IsLocked = isLocked;
                    gBoxRetakeTestInfo.Enabled = isLocked;

                    if (isLocked)
                        ctrlVisionTest1.SetMode(enMode.Update);
                    else
                        ctrlVisionTest1.SetNormalMode();

                    btnSave.Enabled = !isLocked;
                    break;
            }
        }

        // =========================
        // 🔥 RETAKE UI
        // =========================
        private void SetupRetakeUI()
        {
            decimal testFees = ctrlVisionTest1.TestFees;
            decimal retakeFees = GetRetakeFees();

            LbRetakeTestFees.Text = retakeFees.ToString();
            LbTotalFees.Text = (testFees + retakeFees).ToString();
        }

        // =========================
        // 🔥 SAVE
        // =========================
        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            var appointment = ctrlVisionTest1.GetAppointment();

            // 🔴 Prevent duplicate active appointment
            if (_mode == enMode.AddNew || _mode == enMode.Retake)
            {
                if (clsAppointment.HasActiveAppointment(_localAppID, _testTypeID))
                {
                    MessageBox.Show("Active appointment already exists.");
                    return;
                }

                appointment.CreatedByUserID = clsGlobalSettings.CurrentUserID;
            }

            // =========================
            // 🔥 RETAKE LOGIC (IMPORTANT)
            // =========================
            if (_mode == enMode.Retake)
            {
                var localApp = clsLocalDrivingLicenseApplication.Find(_localAppID);

                if (localApp == null)
                    return;

                var testFees = ctrlVisionTest1.TestFees;
                decimal retakeFees = GetRetakeFees();

                var retakeApp = clsApplication.CreateRetakeApplication(
                    localApp.ApplicantPersonID,
                    retakeFees,
                    clsGlobalSettings.CurrentUserID
                );


                retakeApp.PaidFees = retakeFees;

                if (!retakeApp.Save())
                {
                    MessageBox.Show("Failed to create retake application.");
                    return;
                }

                appointment.PaidFees = testFees;
            }

            // =========================
            // 🔥 SAVE APPOINTMENT
            // =========================
            if (appointment.Save())
            {
                OnSaveCompleted?.Invoke(true);

                MessageBox.Show("Saved successfully.");
                Close();
            }
            else
            {
                MessageBox.Show("Error saving.");
            }
        }
    }
}