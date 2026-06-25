using System;
using System.Data;
using ClassLibrary1;
using DVLDBussinessLayer;
using DVLDDataAccessLayer;
using SharedDvldClasses.Enums;
using static DVLDBussinessLayer.clsApplication;

namespace DVLDBussinessLayer
{
    public class clsLocalDrivingLicenseApplication

    {

        
        // =========================
        // 🔹 Properties
        // =========================
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public int ApplicantPersonID { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }


        public int TestCount { get; set; }

        public clsLicenseClass LicenseClassInfo { get; set; }

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;


        private bool? _hasLicense;

        // =========================
        // 🔹 Constructor
        // =========================
        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
            ApplicantPersonID = -1;
            PaidFees = 0;
            CreatedByUserID = -1;
            TestCount = 0;

            Mode = enMode.AddNew;
        }


        public enSaveResult Save(enApplicationType type)
        {
            var status = clsApplication.GetApplicationStatus(
                this.ApplicantPersonID,
                this.LicenseClassID);

            // 🔴 0. No application exists → allow creation
            if (status == null)
            {
                // continue to create application
            }
            else
            {
                // 🔴 1. Already has license
                if (status == enApplicationStatus.Completed)
                {
                    return enSaveResult.HasLicense;
                }

                // 🔴 2. ANY active application
                if (status == enApplicationStatus.New ||
                    status == enApplicationStatus.InProgress ||
                    status == enApplicationStatus.PassedTests)
                {
                    return enSaveResult.HasActiveApplication;
                }
            }

            // 🔴 3. Validation
            if (ApplicantPersonID <= 0 || LicenseClassID <= 0)
                return enSaveResult.InvalidData;

            // =========================
            // Create Application
            // =========================
            clsApplication app = new clsApplication();

            app.ApplicantPersonID = this.ApplicantPersonID;
            app.PaidFees = this.PaidFees;
            app.CreatedByUserID = this.CreatedByUserID;
            app.ApplicationTypeID = type;

            int appID = app.SaveAndReturnID();

            if (appID == -1)
                return enSaveResult.FailedToCreateApplication;

            this.ApplicationID = appID;

            // =========================
            // Create Local App
            // =========================
            this.LocalDrivingLicenseApplicationID =
                clsLocalDrivingLicenseApplicationsData.AddNewLocalApplication(
                    this.ApplicationID,
                    this.LicenseClassID
                );

            if (this.LocalDrivingLicenseApplicationID == -1)
                return enSaveResult.FailedToCreateLocalApp;

            this.Mode = enMode.Update;

            return enSaveResult.Success;
        }
        // =========================
        // 🔹 Get All
        // =========================
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsData
                .GetAllLocalDrivingLicenseApplications();
        }

        // =========================
        // 🔹 Get Application ID
        // =========================
        public static int GetApplicationIDByLocalAppID(int LocalAppID)
        {
            return clsLocalDrivingLicenseApplicationsData
                .GetApplicationIDByLocalAppID(LocalAppID);
        }

        // =========================
        // 🔹 Find
        // =========================
        public static clsLocalDrivingLicenseApplication Find(int localAppID)
        {
            clsLocalDrivingLicenseApplication app =
                new clsLocalDrivingLicenseApplication();

            int applicationID = 0;
            int classID = 0;
            string className = "";
            string nationalNo = "";
            string fullName = "";
            DateTime applicationDate = DateTime.Now;
            int passedTests = 0;
            int status = 0;

            bool found =
                clsLocalDrivingLicenseApplicationsData
                .GetLocalDrivingLApplicationByAppID(
                    localAppID,
                    ref applicationID,
                    ref classID,
                    ref className,
                    ref nationalNo,
                    ref fullName,
                    ref applicationDate,
                    ref passedTests,
                    ref status);

            if (!found)
                return null;

            // =========================
            // 🔥 Core IDs (IMPORTANT)
            // =========================
            app.LocalDrivingLicenseApplicationID = localAppID;
            app.ApplicationID = applicationID;   // 🔥 هذا هو الإصلاح الأساسي
            app.LicenseClassID = classID;

            // =========================
            // 🔥 Business Data
            // =========================
            app.TestCount = passedTests;

            // =========================
            // 🔥 Person
            // =========================
            clsPerson person =
                clsPerson.FindPersonByNationalNo(nationalNo);

            app.ApplicantPersonID =
                (person != null) ? person.PersonID : -1;

            // =========================
            // 🔥 Related Data
            // =========================
            app.LicenseClassInfo =
                clsLicenseClass.Find(classID);

            return app;
        }
        public bool DoesPassAllTests()
        {
            return this.TestCount == 3;
        }

        public static void FixAllApplicationStatuses()
        {
            DataTable apps = clsApplicationData.GetAllApplications();

            foreach (DataRow row in apps.Rows)
            {
                int appID = Convert.ToInt32(row["ApplicationID"]);

                clsApplication app = clsApplication.FindByApplicationID(appID);

                if (app == null)
                    continue;

                int localAppID =
                    clsLocalDrivingLicenseApplicationsData
                    .GetLocalAppIDByApplicationID(appID);

                if (localAppID == -1)
                    continue;

                clsLocalDrivingLicenseApplication localApp =
                    clsLocalDrivingLicenseApplication.Find(localAppID);

                if (localApp == null)
                    continue;

                // ✅ New Correct Logic
                if (localApp.TestCount >= 3)
                {
                    // 🔵 Passed tests but NOT completed
                    if (app.ApplicationStatus != enApplicationStatus.PassedTests)
                    {
                        app.ApplicationStatus = enApplicationStatus.PassedTests;
                        app.Save();
                    }
                }
                else
                {
                    // 🟡 Still in progress
                    if (app.ApplicationStatus != enApplicationStatus.InProgress)
                    {
                        app.ApplicationStatus = enApplicationStatus.InProgress;
                        app.Save();
                    }
                }
            }
        }

        public void UpdateParentApplicationStatus()
        {
            var app = clsApplication.FindByApplicationID(this.ApplicationID);

            if (app == null)
                return;

            int passedTests =
                clsTest.GetPassedTestsCountByLocalAppID(
                    this.LocalDrivingLicenseApplicationID);

            enApplicationStatus newStatus;

            if (passedTests >= 3)
                newStatus = enApplicationStatus.PassedTests;   // ✅ correct
            else
                newStatus = enApplicationStatus.InProgress;

            if (app.ApplicationStatus == newStatus)
                return;

            app.ApplicationStatus = newStatus;
            app.LastStatusDate = DateTime.Now;   // 🔥 important
            app.Save();
        }

        public bool HasAnyTestAppointments()
        {
            return clsAppointmentsData.HasTestAppointments(this.LocalDrivingLicenseApplicationID);
        }

        public bool CanDelete()
        {
            bool hasAppointments = HasAnyTestAppointments();
            bool hasResults = clsTest.HasAnyTestResults(this.LocalDrivingLicenseApplicationID);
            bool hasLicense = clsLicense.Exists(this.ApplicantPersonID, this.LicenseClassID);

            // ✔ يسمح بالحذف فقط إذا كلهم FALSE
            return !hasAppointments && !hasResults && !hasLicense;
        }

        public bool Delete(ref string error)
        {
            // 🔴 1. Check if allowed to delete
            if (!CanDelete())
            {
                error = "Cannot delete application (it has appointments, tests, or license).";
                return false;
            }

            // 🔴 2. Delete child (local application)
            bool isLocalDeleted =
                clsLocalDrivingLicenseApplicationsData
                .Delete(this.LocalDrivingLicenseApplicationID);

            if (!isLocalDeleted)
            {
                error = "Failed to delete local application.";
                return false;
            }

            // 🔴 3. Delete parent application
            bool isAppDeleted =
                clsApplication.DeleteApplication(this.ApplicationID);

            if (!isAppDeleted)
            {
                error = "Local application deleted but failed to delete main application.";
                return false;
            }

            return true;
        }



        public static bool HasPassedTestsWithoutLicense(int personID, int licenseClassID)
        {
            return clsLocalDrivingLicenseApplicationsData
                .ExistsPassedTestsWithoutLicense(personID, licenseClassID);
        }
        public static bool HasLicense(int personID, int licenseClassID)
        {
            return clsLicense.Exists(personID, licenseClassID);
        }

        public static bool HasActiveApplication(int personID, int licenseClassID)
        {
           return clsLocalDrivingLicenseApplicationsData.HasActiveApplication(personID, licenseClassID);
        }



        public bool CanIssueLicense()
        {
            return DoesPassAllTests() &&
                   !clsLicense.Exists(ApplicantPersonID, LicenseClassID);
        }

        public bool CanShowLicense()
        {
            return clsLicense.Exists(ApplicantPersonID, LicenseClassID);
        }

        public bool CanEdit()
        {
            return !IsLicenseIssued() && !HasAnyTestAppointments();
        }


        public bool CanScheduleVisionTest()
        {
            return !IsVisionPassed() && !HasLicense(this.ApplicantPersonID, this.LicenseClassID);
        }

        public bool CanScheduleWrittenTest()
        {
            return IsVisionPassed() && !IsWrittenPassed() && !HasLicense(this.ApplicantPersonID,this.LicenseClassID);
        }

        public bool CanScheduleStreetTest()
        {
            return IsWrittenPassed() && !IsStreetPassed() && !HasLicense(this.ApplicantPersonID, this.LicenseClassID);
        }


        private bool IsVisionPassed()
        {
            return clsTest.GetLastTestResult(LocalDrivingLicenseApplicationID, enTestType.Vision)
                   == enTestResult.Passed;
        }

        private bool IsWrittenPassed()
        {
            return clsTest.GetLastTestResult(LocalDrivingLicenseApplicationID, enTestType.Written)
                   == enTestResult.Passed;
        }

        private bool IsStreetPassed()
        {
            return clsTest.GetLastTestResult(LocalDrivingLicenseApplicationID, enTestType.Street)
                   == enTestResult.Passed;
        }

        public bool CanCancel()
        {
            return !IsLicenseIssued() && !HasPassedAllTests();
        }

        public bool IsLicenseIssued()
        {
            return clsLicense.Exists(ApplicantPersonID, LicenseClassID);
        }

        public bool HasPassedAllTests()
        {
            return IsVisionPassed() &&
                   IsWrittenPassed() &&
                   IsStreetPassed();
        }

        public bool HasScheduledTests()
        {
            return HasAnyTestAppointments();
        }
    }
    
}