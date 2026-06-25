using DVLDAccessLayer;
using DVLDDataAccessLayer;
using SharedDvldClasses.Enums;
using System;
using System.Data;

namespace DVLDBussinessLayer
{
    public class clsInternationalLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        // =========================
        // ✅ CONSTRUCTORS
        // =========================

        // 1. Empty constructor (AddNew mode)
        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.IsActive = false;
            this.CreatedByUserID = -1;

            this.Mode = enMode.AddNew;
        }

        // 2. Full constructor (Fill object)
        public clsInternationalLicense(
            int internationalLicenseID,
            int applicationID,
            int driverID,
            int issuedUsingLocalLicenseID,
            DateTime issueDate,
            DateTime expirationDate,
            bool isActive,
            int createdByUserID)
        {
            this.InternationalLicenseID = internationalLicenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.IsActive = isActive;
            this.CreatedByUserID = createdByUserID;

            this.Mode = enMode.Update;
        }

        // =========================
        // ISSUE METHOD
        // =========================

        public static (bool Success, int ApplicationID, int InternationalLicenseID, string Message)
 IssueInternationalLicense(int localLicenseID, int createdByUserID)
        {
            var license = clsLicense.FindByLicenseID(localLicenseID);

            if (license == null)
                return (false, 0, 0, "Local license not found");

            // ✅ NEW: Check expiration
            if (!license.IsLicenseActive())
                return (false, 0, 0, "License is not active");

            ClsDriver driver = ClsDriver.FindDriverByID(license.DriverID);

            if (driver == null)
                return (false, 0, 0, "Driver not found");

            clsApplicationTypes type =
                clsApplicationTypes.FindByID((int)enApplicationType.InternationalLicense);

            if (type == null)
                return (false, 0, 0, "Application type not found");

            decimal fees = Convert.ToDecimal(type.ApplicationTypeFees);

            int applicationID = clsApplication.CreateInternationalApplication(
                driver.PersonID,
                fees,
                createdByUserID
            );

            if (applicationID <= 0)
                return (false, 0, 0, "Failed to create application");

            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = issueDate.AddYears(1);

            int intlID = clsInternationalLicenseData.AddNewInternationalLicense(
                applicationID,
                license.DriverID,
                localLicenseID,
                issueDate,
                expirationDate,
                true,
                createdByUserID
            );

            if (intlID <= 0)
                return (false, applicationID, 0, "Failed to create international license");

            return (true, applicationID, intlID, "Success");
        }

        // =========================
        // GET BY DRIVER
        // =========================

        public static DataTable GetInternationalLicensesByDriverID(int driverID)
        {
            return clsInternationalLicenseData.GetInternationalLicensesByDriverID(driverID);
        }

        // =========================
        // EXISTS
        // =========================

        public static bool IsExist(int driverID, int localIssueID)
        {
            return clsInternationalLicenseData.IsExist(driverID, localIssueID);
        }

        // =========================
        // FIND BY ID
        // =========================

        public static clsInternationalLicense FindByID(int internationalLicenseID)
        {
            int applicationID = 0;
            int driverID = 0;
            int issuedUsingLocalLicenseID = 0;
            DateTime issueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue;
            bool isActive = false;
            int createdByUserID = 0;

            bool found = clsInternationalLicenseData.GetInternationalLicenseByID(
                internationalLicenseID,
                ref applicationID,
                ref driverID,
                ref issuedUsingLocalLicenseID,
                ref issueDate,
                ref expirationDate,
                ref isActive,
                ref createdByUserID
            );

            if (!found)
                return null;

            return new clsInternationalLicense(
                internationalLicenseID,
                applicationID,
                driverID,
                issuedUsingLocalLicenseID,
                issueDate,
                expirationDate,
                isActive,
                createdByUserID
            );
        }

        public static DataTable GeinternationalLicensesApps()
        {
            return clsInternationalLicenseData.GeinternationalLicensesApps();   
        }
    }
}