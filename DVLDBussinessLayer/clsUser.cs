using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace DVLDBusinessLayer
{
    public class clsUser
    {
        // =========================
        // ENUM
        // =========================
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        // =========================
        // PROPERTIES
        // =========================
        public int UserID { get; private set; }
        public int PersonID { get;  set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public DateTime? DeletedAt { get; private set; }
        public DateTime? LastModifiedAt { get; private set; }

        // =========================
        // CONSTRUCTORS
        // =========================

        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = true;

            DeletedAt = null;
            LastModifiedAt = null;

            Mode = enMode.AddNew;
        }

        public clsUser(int personID)
        {
            this.PersonID = personID;
            this.Mode = enMode.AddNew;
            this.IsActive = true;
        }

        private clsUser(int userID, int personID, string userName, string password,
                        bool isActive, DateTime? deletedAt, DateTime? lastModifiedAt)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;

            DeletedAt = deletedAt;
            LastModifiedAt = lastModifiedAt;

            Mode = enMode.Update;
        }

        // =========================
        // FACTORY METHODS (IMPORTANT)
        // =========================

        public static clsUser Find(int userID)
        {
            int personID = 0;
            string userName = "";
            string password = "";
            bool isActive = false;
            DateTime? deletedAt = null;
            DateTime? lastModifiedAt = null;

            bool found = clsUsersData.GetUserByID(
                userID,
                ref personID,
                ref userName,
                ref password,
                ref isActive,
                ref deletedAt,
                ref lastModifiedAt);

            if (!found)
                return null;

            return new clsUser(
                userID,
                personID,
                userName,
                password,
                isActive,
                deletedAt,
                lastModifiedAt
            );
        }

        // =========================
        // SAVE (Add / Update)
        // =========================

        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                int newID = clsUsersData.AddNewUser(PersonID, UserName, Password,IsActive);

                if (newID != -1)
                {
                    UserID = newID;
                    Mode = enMode.Update;
                    return true;
                }

                return false;
            }
            else
            {
                return clsUsersData.UpdateUser(UserID, UserName, Password,IsActive);
            }
        }

        // =========================
        // BUSINESS ACTIONS
        // =========================

        public bool Deactivate()
        {
            if (UserID == -1)
                return false;

            return clsUsersData.DeactivateUser(UserID);
        }

        public bool SetActive(bool isActive)
        {
            return clsUsersData.SetActiveStatus(UserID, isActive);
        }

        // =========================
        // FILTERING (CLEAN VERSION)
        // =========================

        public static DataTable GetUsersByFilter(
    int? userID,
    int? personID,
    string userName,
    bool? isActive,
    string fullName)
        {
            return clsUsersData.GetUsersByFilter(
                userID,
                personID,
                userName,
                isActive,
                fullName
                
            );
        }


        public static clsUser GetUserByUserNameAndPassword(string userName, string password)
        {
            DataTable dt = clsUsersData.GetUserByUserNameAndPassword(userName, password);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            bool isActive = (bool)row["IsActive"];

            if (!isActive)
                return null;

            return new clsUser(
      (int)row["UserID"],
      (int)row["PersonID"],
      (string)row["UserName"],
      (string)row["Password"],
      isActive,
      row["DeletedAt"] == DBNull.Value ? null : (DateTime?)row["DeletedAt"],
      row["LastModifiedAt"] == DBNull.Value ? null : (DateTime?)row["LastModifiedAt"]
  );
        }


        public static DataTable GetUsers()
        {
            return clsUsersData.GetUsers();
        }

        public static bool IsPasswordCorrect(int UserID ,string Password)
        {
            return clsUsersData.IsPasswordCorrect(UserID, Password);
        }

        public static bool IsPersonUser(int PersonID)
        {
            return clsUsersData.IsUserExistsByPersonID((int)PersonID);
        }

      

        public static bool DeleteUser(int UersID)
        {
            return clsUsersData.DeactivateUser(UersID); 
        }
    }
}