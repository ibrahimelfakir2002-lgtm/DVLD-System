using DVLDDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDAccessLayer
{
    public class clsInternationalLicenseData
    {
        public static int AddNewInternationalLicense(
            int applicationID,
            int driverID,
            int localLicenseID,
            DateTime issueDate,
            DateTime expirationDate,
            bool isActive,
            int createdByUserID)
        {
            int newID = -1;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
INSERT INTO InternationalLicenses
(ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
VALUES
(@ApplicationID, @DriverID, @LocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);

SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                cmd.Parameters.AddWithValue("@DriverID", driverID);
                cmd.Parameters.AddWithValue("@LocalLicenseID", localLicenseID);
                cmd.Parameters.AddWithValue("@IssueDate", issueDate);
                cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        newID = Convert.ToInt32(result);
                }
                catch (Exception )
                {
                    // log later
                }
            }

            return newID;
        }

        public static DataTable GetInternationalLicensesByDriverID(int driverID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
SELECT 
    L.InternationalLicenseID AS LicenseID,
    LC.ClassName AS LicenseClass,
L.IssuedUsingLocalLicenseID,
    L.IssueDate,
    L.ExpirationDate,
    L.IsActive
FROM InternationalLicenses L
INNER JOIN Licenses LS ON L.IssuedUsingLocalLicenseID = LS.LicenseID
INNER JOIN LicenseClasses LC ON LS.LicenseClass = LC.LicenseClassID
WHERE L.DriverID = @driverID
ORDER BY L.InternationalLicenseID DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DriverID", driverID);

                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception)
                {
                }
            }

            return dt;
        }


        public static bool IsExist(int driverId, int localIssue)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT COUNT(1) 
                         FROM InternationalLicenses 
                         WHERE DriverID = @DriverId 
                         AND IssuedUsingLocalLicenseID = @LocalIssue";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DriverID", driverId);
                cmd.Parameters.AddWithValue("@LocalIssue", localIssue);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }

     
            public static bool GetInternationalLicenseByID(int internationalLicenseID,
                ref int applicationID,
                ref int driverID,
                ref int issuedUsingLocalLicenseID,
                ref DateTime issueDate,
                ref DateTime expirationDate,
                ref bool isActive,
                ref int createdByUserID)
            {
                bool isFound = false;

                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT *
                FROM InternationalLicenses
                WHERE InternationalLicenseID = @InternationalLicenseID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            applicationID = (int)reader["ApplicationID"];
                            driverID = (int)reader["DriverID"];
                            issuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                            issueDate = (DateTime)reader["IssueDate"];
                            expirationDate = (DateTime)reader["ExpirationDate"];
                            isActive = (bool)reader["IsActive"];
                            createdByUserID = (int)reader["CreatedByUserID"];
                        }
                    }
                    catch (Exception )
                    {
                        // log if needed
                        isFound = false;
                    }
                }

                return isFound;
            }



        public static DataTable GeinternationalLicensesApps()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
      select InternationalLicenses.InternationalLicenseID,ApplicationID,InternationalLicenses.DriverID,InternationalLicenses.IssuedUsingLocalLicenseID,
						 InternationalLicenses.IssueDate,InternationalLicenses.ExpirationDate,InternationalLicenses.IsActive from InternationalLicenses



";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }
    }
    }
