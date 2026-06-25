using ClassLibrary1;
using SharedDvldClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLDBussinessLayer.clsApplication;
using static DVLDBussinessLayer.clsLicense;

using SharedDvldClasses.Enums;
using System.Runtime.CompilerServices;
using System.Data;
namespace DVLDBussinessLayer
{
    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;


      

        

        public int  LicenseID { get; set; }
    public int   ApplicationID    { get; set; }
    public int   DriverID         { get; set; }
    public int   LicenseClass     { get; set; }
    public DateTime   IssueDate   { get; set; }
  public DateTime ExpirationDate  { get; set; }
    public string   Notes         { get; set; }
    public decimal   PaidFees     { get; set; }
    public int   IsActive         { get; set; }
    public int   IssueReason      { get; set; }
    public int CreatedByUserID { get; set; }


        public clsLicense()

        {
            this.LicenseID = -1;
            this.ApplicationID = -1;    

            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = -1; 
            this.IsActive = -1;
            
            this.IssueReason = -1;
            this.CreatedByUserID = -1;

            this.Mode = enMode.AddNew;


        }

        private clsLicense(int LicenseID,
      int   ApplicationID,
      int   DriverID     ,
      int   LicenseClass ,
     DateTime   IssueDate    ,
     DateTime   ExpirationDat,
     string  Notes        ,
      decimal   PaidFees     ,
      int   IsActive     ,
      int   IssueReason  ,
      int  CreatedByUserID
)
        {

            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDat;
              this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive =IsActive;
            this.IssueReason    =(int)IssueReason;
            this.CreatedByUserID =(int)CreatedByUserID;

            this.Mode = enMode.Update;

        }


        public static clsLicense FindByLicenseID(int LicenseID)
        {
            int ApplicationID = -1,
        DriverID = -1,
        LicenseClass = -1, IsActive = -1,
        IssueReason = -1,
       CreatedByUserID = -1;


     DateTime   IssueDate = DateTime.Now  ,
        ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = -1;


            bool Found = clsLicenseData.GetLicenseByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate,
                ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);

            if(! Found)
            {
                return null;
            }

            return  new clsLicense(LicenseID,ApplicationID,DriverID, LicenseClass,  IssueDate,ExpirationDate,  Notes,PaidFees,IsActive,IssueReason, CreatedByUserID);

        
        }


        private bool _AddNewLicense()
        {

            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID,this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate,this.Notes,this.PaidFees,this.IsActive,
                this.IssueReason,this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }



            }




            return false;
        }


        public static clsLicenseDetailsDTO GetLicenseDetails(int id)
        {
            return clsLicenseData.GetLicenseDetails(id);
        }
        public static bool ExistsByApplicationID(int AppID)
        {

            return clsLicenseData.ExistsByApplicationID(AppID);
        }


        public static bool IsLicenseIssued(int appID)
        {
            return clsLicense.ExistsByApplicationID(appID);
        }


        public static bool Exists(int personID, int licenseClassID)
        {
            return clsLicenseData.Exists(personID, licenseClassID);
        }

        public static bool IssueLicense(
    int localAppID,
    string notes,
    int createdByUserID,
    ref int licenseID,
    ref string error)
        {
            var localApp = clsLocalDrivingLicenseApplication.Find(localAppID);

            if (localApp == null)
            {
                error = "Local application not found";
                return false;
            }

            if (!localApp.DoesPassAllTests())
            {
                error = "Applicant did not pass all tests";
                return false;
            }

            var app = clsApplication.FindByApplicationID(localApp.ApplicationID);

            if (app == null)
            {
                error = "Application not found";
                return false;
            }

            

            if (clsLicense.Exists(app.ApplicantPersonID, localApp.LicenseClassID))
            {
                error = "License already issued for this person and class";
                return false;
            }

            // 🔹 Driver
            var driver = ClsDriver.FindByPersonID(app.ApplicantPersonID);

            if (driver == null)
            {
                driver = new ClsDriver
                {
                    PersonID = app.ApplicantPersonID,
                    CreatedByUserID = app.CreatedByUserID,
                    CreatedDate = DateTime.Now
                };

                if (!driver.Save())
                {
                    error = "Failed to create driver";
                    return false;
                }

                driver = ClsDriver.FindByPersonID(app.ApplicantPersonID);
            }

            // 🔹 License
            var license = new clsLicense
            {
                ApplicationID = app.ApplicationID,
                DriverID = driver.DriverID,
                LicenseClass = localApp.LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(10),
                Notes = string.IsNullOrWhiteSpace(notes) ? "" : notes,
                PaidFees = 0,
                IsActive = 1,
                IssueReason = (int)enIssueReason.FirstTime,
                CreatedByUserID = createdByUserID
            };

            if (!license.Save())
            {
                error = "Failed to issue license";
                return false;
            }

            // 🔥 NEW: mark application as Completed
            app.ApplicationStatus = enApplicationStatus.Completed;
            app.LastStatusDate = DateTime.Now;

            if (!app.Save())
            {
                error = "License issued but failed to update application status";
                return false;
            }

            // optional: link license ID back
            licenseID = license.LicenseID;

            return true;
        }


        public static clsLicense GetLicenseIDByApplicationID(int AppID)
        {



            int Licenseid = -1,
        DriverID = -1,
        LicenseClass = -1, IsActive = -1,
        IssueReason = -1,
       CreatedByUserID = -1;


            DateTime IssueDate = DateTime.Now,
               ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = -1;


            bool Found = clsLicenseData.GetLicenseByApplicationID(ref Licenseid, AppID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate,
                ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);

            if (!Found)
            {
                return null;
            }

            return new clsLicense(Licenseid, AppID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);

        }


        public static DataTable GetLocalLicensesByDriverID(int DRiverID)
        {
            return clsLicenseData.GetLocalLicensesByDriverID(DRiverID);
        }


        public bool IsLicenseActive()
        {
            // Expired
            if (this.ExpirationDate < DateTime.Now)
                return false;

           
            return true;
        }


        public static int SyncExpiredLicenses()
        {
            return clsLicenseData.sycronizeExpiredLicense();
        }



        public static clsLicense GetActiveLicenseByDriverIDAndLicenseClass(
    int driverID,
    int licenseClass)
        {
            int licenseID =
                clsLicenseData.GetActiveLicenseIDByDriverIDAndLicenseClass(
                    driverID,
                    licenseClass);

            if (licenseID == -1)
                return null;

            return FindByLicenseID(licenseID);
        }

    }
}
