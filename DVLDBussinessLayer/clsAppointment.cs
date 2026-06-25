using ClassLibrary1;
using System;
using System.Data;

namespace DVLDBussinessLayer
{
    public class clsAppointment
    {
        // 🔹 هذا خاص بالـ UI (مؤقتًا)
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        // =========================
        // 🔹 Properties
        // =========================
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        // =========================
        // 🔹 Constructor (Add)
        // =========================
        public clsAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;

            Mode = enMode.AddNew;
        }

        // =========================
        // 🔹 Constructor (Load)
        // =========================
        private clsAppointment(int testAppointmentID, int testTypeID,
            int localDrivingLicenseApplicationID, DateTime appointmentDate,
            decimal paidFees, int createdByUserID, bool isLocked)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;

            Mode = enMode.Update;
        }

        // =========================
        // 🔹 Query Methods
        // =========================

        public static bool HasActiveAppointment(int localAppID, int testTypeID)
        {
            return clsAppointmentsData.HasActiveAppointment(localAppID, testTypeID);
        }

        public static bool HasLockedAppointment(int localAppID, int testTypeID)
        {
            return clsAppointmentsData.HasLockedAppointment(localAppID, testTypeID);
        }

        public static bool CanAddNewAppointment(int localAppID, int testTypeID)
        {
            return !HasActiveAppointment(localAppID, testTypeID);
        }

        public static DataTable GetAllAppointmentsByLocalID(int localAppID)
        {
            return clsAppointmentsData.GetAllAppointmentsByLocalID(localAppID);
        }

        public static DataTable GetAllAppointmentsByLocalIDAndTestType(int localAppID, int testTypeID)
        {
           return  clsAppointmentsData.GetAllAppointmentsByLocalIDAndTestType(localAppID, testTypeID);
        }

        // =========================
        // 🔹 Factory
        // =========================
        public static clsAppointment Find(int appointmentID)
        {
            int testTypeID = -1, localAppID = -1, createdByUserID = -1;
            DateTime appointmentDate = DateTime.Now;
            decimal paidFees = 0;
            bool isLocked = false;

            if (clsAppointmentsData.GetAppointmentByID(
                appointmentID,
                ref testTypeID,
                ref localAppID,
                ref appointmentDate,
                ref paidFees,
                ref createdByUserID,
                ref isLocked))
            {
                return new clsAppointment(
                    appointmentID,
                    testTypeID,
                    localAppID,
                    appointmentDate,
                    paidFees,
                    createdByUserID,
                    isLocked);
            }

            return null;
        }

        // =========================
        // 🔹 Command Methods
        // =========================

        public bool Save()
        {
            // 🔹 Add
            if (Mode == enMode.AddNew)
            {
                TestAppointmentID = clsAppointmentsData.AddNewAppointment(
                    TestTypeID,
                    LocalDrivingLicenseApplicationID,
                    AppointmentDate,
                    PaidFees,
                    CreatedByUserID,
                    IsLocked);

                return (TestAppointmentID != -1);
            }

            // 🔹 Update
            else
            {
                // 🔒 لا يمكن تعديل Appointment مقفل
                if (IsLocked)
                    return false;

                return clsAppointmentsData.UpdateAppointment(
                    TestAppointmentID,
                    AppointmentDate,
                    PaidFees,
                    IsLocked);
            }
        }

        // 🔒 Lock Appointment (Business Behavior)
        public bool Lock()
        {
            // ❌ Already locked
            if (IsLocked)
                return false;

            // 🔹 Call DAL
            if (clsAppointmentsData.LockAppointment(TestAppointmentID))
            {
                IsLocked = true;
                return true;
            }

            return false;
        }

        public static  bool HasFailedAppointment(int LocalApp  , int TestTypeID)
        {
            return clsAppointmentsData.HasFailedAppointment(LocalApp , TestTypeID);
        }


        public static bool HasPassedAppointment(int LocalApp, int TestTypeID)
        {

            return clsAppointmentsData.HasPassedAppointment(LocalApp , TestTypeID);
        }


    }
}