using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsUsersData
    {


        
        public static bool GetUserByID(int userID,
     ref int personID,
     ref string userName,
     ref string password,
     ref bool isActive,
     ref DateTime? deletedAt,
     ref DateTime? lastModifiedAt)
        {
            bool isFound = false;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT PersonID, UserName, Password, IsActive, DeletedAt, LastModifiedAt
                                 FROM Users
                                 WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            personID = (int)reader["PersonID"];
                            userName = (string)reader["UserName"];
                            password = (string)reader["Password"];
                            isActive = (bool)reader["IsActive"];

                            deletedAt = reader["DeletedAt"] == DBNull.Value
                                ? (DateTime?)null
                                : (DateTime)reader["DeletedAt"];

                            lastModifiedAt = reader["LastModifiedAt"] == DBNull.Value
                                ? (DateTime?)null
                                : (DateTime)reader["LastModifiedAt"];
                        }
                    }
                }
            }

            return isFound;
        }
        public static int AddNewUser(int personID, string userName, string password, bool isActive)
        {
            int userID = -1;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive)
                         VALUES (@PersonID, @UserName, @Password, @IsActive);

                         SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PersonID", personID);
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    con.Open();

                    object result = cmd.ExecuteScalar();

                    userID = (result == null || result == DBNull.Value)
                        ? -1
                        : Convert.ToInt32(result);
                }
            }

            return userID;
        }


        public static bool UpdateUser(int userID, string userName, string password, bool isActive)
        {
            int rows = 0;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Users
                         SET UserName = @UserName,
                             Password = @Password,
                             IsActive = @IsActive,
                             LastModifiedAt = GETDATE()
                       WHERE UserID = @UserID AND DeletedAt IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    con.Open();
                    rows = cmd.ExecuteNonQuery();
                }
            }

            return rows > 0;
        }
        public static bool SetActiveStatus(int userID, bool isActive)
        {
            int rows = 0;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                
                string query = @"UPDATE Users
                                 SET IsActive = @IsActive,
                                     LastModifiedAt = GETDATE()
                                 WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    con.Open();
                    rows = cmd.ExecuteNonQuery();
                }
            }

            return rows > 0;
        }
        public static bool DeactivateUser(int userID)
        {
            int rows = 0;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Users
                                 SET IsActive = 0,
                                     DeletedAt = GETDATE(),
                                     LastModifiedAt = GETDATE()
                                 WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    con.Open();
                    rows = cmd.ExecuteNonQuery();
                }
            }

            return rows > 0;
        }
        public static DataTable GetUsers(bool? isActive = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT 
                U.UserID,
                U.PersonID,
                CONCAT(P.FirstName,' ',P.SecondName,' ',P.ThirdName,' ',P.LastName) AS FullName,
                U.UserName,
                U.IsActive
            FROM Users U
            INNER JOIN People P ON P.PersonID = U.PersonID
            WHERE 1 = 1";

                if (isActive != null)
                    query += " AND U.IsActive = @IsActive";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (isActive != null)
                        cmd.Parameters.AddWithValue("@IsActive", isActive);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }


        public static DataTable GetUserByUserNameAndPassword(string userName, string password)
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT * 
                              FROM Users
                              WHERE UserName = @UserName
                              AND Password = @Password
                              AND IsActive = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@Password", password);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }

                return dt;
            }

        public static DataTable GetUsersByFilter(
     int? userId,
     int? personId,
     string userName,
     bool? isActive,
     string fullName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT 
                U.UserID,
                U.UserName,
                U.IsActive,
                P.PersonID,
                P.FirstName + ' ' + P.LastName AS FullName
            FROM Users U
            INNER JOIN People P ON U.PersonID = P.PersonID
            WHERE 1=1";

                if (userId != null)
                    query += " AND U.UserID = @UserID";

                if (personId != null)
                    query += " AND U.PersonID = @PersonID";

                if (!string.IsNullOrEmpty(userName))
                    query += " AND U.UserName LIKE @UserName";

                if (isActive != null)
                    query += " AND U.IsActive = @IsActive";

                if (!string.IsNullOrEmpty(fullName))
                    query += " AND (P.FirstName + ' ' + P.LastName) LIKE @FullName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (userId != null)
                        cmd.Parameters.AddWithValue("@UserID", userId);

                    if (personId != null)
                        cmd.Parameters.AddWithValue("@PersonID", personId);

                    if (!string.IsNullOrEmpty(userName))
                        cmd.Parameters.AddWithValue("@UserName", "%" + userName + "%");

                    if (isActive != null)
                        cmd.Parameters.AddWithValue("@IsActive", isActive);

                    if (!string.IsNullOrEmpty(fullName))
                        cmd.Parameters.AddWithValue("@FullName", "%" + fullName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }
        public static DataTable GetUsersWithFullName()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT 
                U.UserID,
                U.UserName,
                U.IsActive,
                P.PersonID,
                P.FirstName + ' ' + P.LastName AS FullName
            FROM Users U
            INNER JOIN People P ON U.PersonID = P.PersonID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }
        // 🔐 Authentication / Login (مهم جدًا)




        //   bool IsUserNameExists(string UserName)

        //bool IsUserActive(int UserID)


       public static   bool IsPasswordCorrect(int UserID, string Password)
        {
            bool isFound = false;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select * from Users where UserID = @UserID and Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        con.Open();

                        object result = cmd.ExecuteScalar();

                        isFound = (result != null);
                    }
                    catch
                    {
                        isFound = false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return isFound;
        }

        public static bool IsActiveUserExistsByPersonID(int personId)
        {
            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT TOP 1 1
FROM Users
WHERE PersonID = @PersonId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PersonId", personId);

                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        return result != null;
                    }
                    catch (Exception)
                    {
                        // TODO: Logging
                        return false;
                    }
                }
            }

        }
        //👤 2) User Management(CRUD enhancements)


        // bool GetUserByID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref int IsActive, ref DateTime? DeletedAt, ref DateTime? LastModifiedAt)



        //  bool GetUserByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password, ref int IsActive)

        // bool ActivateUser(int UserID)


        //bool RestoreUser(int UserID)


        // 🔎 3) Search Methods (very useful for UI)

        //DataTable SearchUsersByUserName(string UserName)

        //    DataTable SearchActiveUsers(string Filter)

        //    DataTable SearchDeletedUsers(string Filter)



        // 📊 4) Reporting / Filtering


        //DataTable GetUsersByStatus(bool IsActive)

        // DataTable GetRecentlyModifiedUsers(DateTime FromDate)




        //  ⚙️ 5) Security / Audit(مهم جدًا لاحقًا)


        //bool UpdateLastLogin(int UserID)

        //    DateTime? GetLastLogin(int UserID)

        //    bool ChangePassword(int UserID, string OldPassword, string NewPassword)



        // 🚀 6) Advanced (مستوى أعلى – لاحقًا في Service Layer)

        //    bool DisableUserIfTooManyFailedLogins(int UserID)

        //    int GetFailedLoginAttempts(int UserID)

        //IsPersonHasUser(PersonID)
    }
}

