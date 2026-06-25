using DVLDBussinessLayer;
using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

using SharedDvldClasses.Enums;

namespace DVLDPresentationLayer
{

    // this script for update localApps by when test count = 3 status = compleleted 

//    UPDATE A
//SET A.ApplicationStatus = 3  -- Completed
//FROM Applications A
//INNER JOIN LocalDrivingLicenseApplications L
//    ON A.ApplicationID = L.ApplicationID
//INNER JOIN (
//    SELECT
//        TA.LocalDrivingLicenseApplicationID,
//        COUNT(T.TestID) AS PassedTests
//    FROM TestAppointments TA
//    INNER JOIN Tests T
//        ON TA.TestAppointmentID = T.TestAppointmentID
//    WHERE T.TestResult = 1
//    GROUP BY TA.LocalDrivingLicenseApplicationID
//) X
//    ON L.LocalDrivingLicenseApplicationID = X.LocalDrivingLicenseApplicationID
//WHERE X.PassedTests >= 3
//  AND A.ApplicationStatus<> 3;



    public partial class FrmTakeTest : Form
    {
        private int _appointmentID = -1;
        private clsAppointment _appointment;

        public event Action<bool> OnSaveCompleted;

        public event Action<bool> OnTestPassed;

        public FrmTakeTest(int testAppointmentID)
        {
            InitializeComponent();
            _appointmentID = testAppointmentID;
        }

       

        // 🔥 1. Load Data once
        private void LoadAppointment()
        {
            _appointment = clsAppointment.Find(_appointmentID);

            if (_appointment == null)
            {
                MessageBox.Show("Appointment not found.");
                Close();
                return;
            }

            
        }

        // 🔥 2. Push data to controls
        private void LoadUI()
        {
            
            ctrlVisionTest1.IsLocked = true;
            ctrlVisionTest1.LoadVisionTest(
      _appointment.LocalDrivingLicenseApplicationID,_appointment.TestTypeID,
      _appointment.TestAppointmentID);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_appointment == null)
            {
                MessageBox.Show("Invalid appointment.");
                return;
            }

            // 🔄 Always refresh from DB
            _appointment = clsAppointment.Find(_appointment.TestAppointmentID);

            if (_appointment == null)
            {
                MessageBox.Show("Appointment not found.");
                return;
            }

            if (_appointment.IsLocked)
            {
                MessageBox.Show("This test is already taken.");
                return;
            }

            // 🔴 Extra safety (DB-level duplicate check)
            if (clsTest.IsTestExistsByAppointmentID(_appointment.TestAppointmentID))
            {
                MessageBox.Show("Test already exists.");
                return;
            }

            bool isPassed = radioBtnPass.Checked;

            clsTest test = new clsTest
            {
                TestResult = isPassed ? 1 : 0,
                Notes = txtNotes.Text.Trim(),
                TestAppointmentID = _appointment.TestAppointmentID,
                CreatedByUserID = clsGlobalSettings.CurrentUserID
            };

            // 🔥 IMPORTANT: Save test FIRST
            if (!test.Save())
            {
                MessageBox.Show("Save Failed");
                return;
            }

            // 🔥 Lock AFTER successful save
            bool locked = _appointment.Lock();

            if (!locked)
            {
                MessageBox.Show("Warning: could not lock appointment.");
                // optional: log this
            }

            // 🔥 Update application status (single source of truth)
            var localApp = clsLocalDrivingLicenseApplication
                .Find(_appointment.LocalDrivingLicenseApplicationID);

            if (localApp != null)
            {
                localApp.UpdateParentApplicationStatus();
            }
            else
            {
                MessageBox.Show("Warning: Local application not found.");
            }

            MessageBox.Show(isPassed
                ? "🎉 Passed"
                : "❌ Failed - You can retake");

            OnTestPassed?.Invoke(isPassed);
            OnSaveCompleted?.Invoke(true);

            this.Close();
        }

        private void BntClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmTakeTest_Load_1(object sender, EventArgs e)
        {
            LoadAppointment();
            LoadUI();
        }
    }



}