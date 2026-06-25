using DVLDDataAccessLayer;
using SharedDvldClasses.Enums;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace DVLDBussinessLayer
{
    public class clsApplication
    {
        // =========================
        // 🔹 Mode
        // =========================
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        // =========================
        // 🔹 Status
        // =========================
      

        // =========================
        // 🔹 Types
        // =========================
        //public enum enApplicationTypes
        //{
        //    NewLocalDrivingLicense = 1,
        //    RenewDrivingLicense = 2,
        //    ReplacementLostLicense = 3,
        //    ReplacementDamagedLicense = 4,
        //    ReleaseDetainedLicense = 5,
        //    NewInternationalLicense = 6,
        //    RetakeTest = 8
        //}

        // =========================
        // 🔹 Properties
        // =========================
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }

        public enApplicationType ApplicationTypeID { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }

        public DateTime LastStatusDate { get; set; }

        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        // =========================
        // 🔹 Constructor
        // =========================
        public clsApplication()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;

            ApplicationTypeID = enApplicationType.NewLocalDrivingLicense;
            ApplicationStatus = enApplicationStatus.New;

            LastStatusDate = DateTime.Now;

            PaidFees = 0;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        // =========================
        // 🔹 Private Constructor (Find)
        // =========================
        private clsApplication(
            int applicationID,
            int applicantPersonID,
            DateTime applicationDate,
            enApplicationType applicationTypeID,
            enApplicationStatus applicationStatus,
            DateTime lastStatusDate,
            decimal paidFees,
            int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;

            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;

            LastStatusDate = lastStatusDate;

            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }

        // =========================
        // 🔥 SAFE CAST HELPERS
        // =========================
        private static enApplicationType SafeCastType(int value)
        {
            if (Enum.IsDefined(typeof(enApplicationType), value))
                return (enApplicationType)value;

            return enApplicationType.NewLocalDrivingLicense;
        }

        private static enApplicationStatus SafeCastStatus(int value)
        {
            if (Enum.IsDefined(typeof(enApplicationStatus), value))
                return (enApplicationStatus)value;

            return enApplicationStatus.New;
        }

        // =========================
        // 🔥 SAVE
        // =========================
        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                ApplicationDate = DateTime.Now;
                ApplicationStatus = enApplicationStatus.InProgress;
                LastStatusDate = DateTime.Now;

                int appID = clsApplicationData.AddNewApplication(
                    ApplicantPersonID,
                    ApplicationDate,
                    (int)ApplicationTypeID,
                    (int)ApplicationStatus,
                    LastStatusDate,
                    PaidFees,
                    CreatedByUserID
                );

                if (appID != -1)
                {
                    ApplicationID = appID;
                    Mode = enMode.Update;
                    return true;
                }

                return false;
            }

            // 🔥 Update (future-ready)
            return clsApplicationData.UpdateApplication(
       ApplicationID,
       ApplicantPersonID,
       (int)ApplicationTypeID,
       (int)ApplicationStatus,
       LastStatusDate,   // 🔥 ADD THIS
       PaidFees
   );
        }
        public static int CreateInternationalApplication(
    int applicantPersonID,
    decimal fees,
    int createdByUserID)
        {
            int applicationTypeID = (int)enApplicationType.InternationalLicense;
            int status = (int)enApplicationStatus.New;

            DateTime now = DateTime.Now;

            return clsApplicationData.AddNewApplication(
                applicantPersonID,
                now,
                applicationTypeID,
                status,
                now,
                fees,
                createdByUserID
            );
        }
        // =========================
        // 🔥 Find
        // =========================
        public static clsApplication FindByApplicationID(int applicationID)
        {
            int applicantPersonID = -1;
            int applicationTypeID = -1;
            int applicationStatus = -1;
            int createdByUserID = -1;

            DateTime applicationDate = DateTime.Now;
            DateTime lastStatusDate = DateTime.Now;

            decimal fees = 0;

            bool found = clsApplicationData.GetApplicationByApplicationID(
                applicationID,
                ref applicantPersonID,
                ref applicationDate,
                ref applicationTypeID,
                ref applicationStatus,
                ref lastStatusDate,
                ref fees,
                ref createdByUserID
            );

            if (!found)
                return null;

            return new clsApplication(
                applicationID,
                applicantPersonID,
                applicationDate,
                SafeCastType(applicationTypeID),
                SafeCastStatus(applicationStatus),
                lastStatusDate,
                fees,
                createdByUserID
            );
        }

        // =========================
        // 🔥 Cancel
        // =========================
        public bool Cancel()
        {
            ApplicationStatus = enApplicationStatus.Cancelled;

            return clsApplicationData.UpdateApplicationStatus(
                ApplicationID,
                (int)ApplicationStatus
            );
        }

        // =========================
        // 🔥 Helpers
        // =========================
        public int SaveAndReturnID()
        {
            return Save() ? ApplicationID : -1;
        }

        public bool IsRetake()
        {
            return ApplicationTypeID == enApplicationType.RetakeTest;
        }

        // =========================
        // 🔥 Retake Factory
        // =========================
        public static clsApplication CreateRetakeApplication(
       int applicantPersonID,
       decimal fees,
       int createdByUserID)
        {
            return new clsApplication
            {
                ApplicantPersonID = applicantPersonID,
                PaidFees = fees,
                CreatedByUserID = createdByUserID,

                ApplicationTypeID = enApplicationType.RetakeTest,
                ApplicationStatus = enApplicationStatus.New,

                ApplicationDate = DateTime.Now,
                LastStatusDate = DateTime.Now
            };
        }
        // =========================
        // 🔥 Display Helper
        // =========================
        public string ApplicationTypeTitle
        {
            get
            {
                return clsApplicationData.GetApplicationTypeTitle((int)ApplicationTypeID);
            }
        }
       
        public static bool DeleteApplication(int AppId)
        {
            return clsApplicationData.DeleteApplication( AppId );
        }


        public static enApplicationStatus? GetApplicationStatus(int personID, int licenseClassID)
        {
            return clsApplicationData.GetApplicationStatus(personID, licenseClassID);
        }
    }
}