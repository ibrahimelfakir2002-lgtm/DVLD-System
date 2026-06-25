using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

using SharedDvldClasses;

namespace ClassLibrary1
{
    public class clsLicenseData
    {

        public static bool GetLicenseByID(
     int LicenseID,
     ref int ApplicationID,
     ref int DriverID,
     ref int LicenseClass,
     ref DateTime IssueDate,
     ref DateTime ExpirationDate,
     ref string Notes,
     ref decimal PaidFees,
     ref int IsActive,
     ref int IssueReason,
     ref int CreatedByUserID)
        {
            string query = @"
        SELECT ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
               Notes, PaidFees, IsActive, IssueReason, CreatedByUserID
        FROM Licenses
        WHERE LicenseID = @LicenseID";

            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // أفضل من AddWithValue
                    cmd.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                        DriverID = Convert.ToInt32(reader["DriverID"]);
                        LicenseClass = Convert.ToInt32(reader["LicenseClass"]);
                        IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                        ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);

                        Notes = reader["Notes"] as string ?? string.Empty;

                        PaidFees = Convert.ToDecimal(reader["PaidFees"]);

                        // bit → bool → int
                        IsActive = reader["IsActive"] != DBNull.Value && (bool)reader["IsActive"] ? 1 : 0;

                        // tinyint → byte → int
                        IssueReason = reader["IssueReason"] != DBNull.Value
                            ? (byte)reader["IssueReason"]
                            : 0;

                        CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public static int AddNewLicense(
       int ApplicationID,
       int DriverID,
       int LicenseClass,
       DateTime IssueDate,
       DateTime ExpirationDate,
       string Notes,
       decimal PaidFees,
       int IsActive,
       int IssueReason,
       int CreatedByUserID)
        {
            int LicenseID = -1;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
INSERT INTO Licenses (
    ApplicationID,
    DriverID,
    LicenseClass,
    IssueDate,
    ExpirationDate,
    Notes,
    PaidFees,
    IsActive,
    IssueReason,
    CreatedByUserID
)
VALUES (
    @ApplicationID,
    @DriverID,
    @LicenseClass,
    @IssueDate,
    @ExpirationDate,
    @Notes,
    @PaidFees,
    @IsActive,
    @IssueReason,
    @CreatedByUserID
);

SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    cmd.Parameters.AddWithValue("@DriverID", DriverID);
                    cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
                    cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

                    cmd.Parameters.AddWithValue("@Notes",
                        string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);

                    cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        con.Open();

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                            LicenseID = Convert.ToInt32(result);
                    }
                    catch (Exception)
                    {
                        LicenseID = -1;
                    }
                }
            }

            return LicenseID;
        }
        public static bool ExistsByApplicationID(int appId)
        {
            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 1 
                         FROM Licenses 
                         WHERE ApplicationID = @AppId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AppId", appId);

                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();

                        return result != null;
                    }
                    catch (Exception)
                    {
                        // log if needed
                        return false;
                    }
                }
            }
        }

        public static int GetLicenseIDByApplicationID(int applicationID)
        {
            int licenseID = -1;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT LicenseID 
                         FROM Licenses 
                         WHERE ApplicationID = @ApplicationID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", applicationID);

                    try
                    {
                        con.Open();

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            licenseID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception)
                    {
                        // TODO: log error if needed
                        licenseID = -1;
                    }
                }
            }

            return licenseID;
        }

        public static bool GetLicenseByApplicationID(
      ref int LicenseID,
      int ApplicationID,
      ref int DriverID,
      ref int LicenseClass,
      ref DateTime IssueDate,
      ref DateTime ExpirationDate,
      ref string Notes,
      ref decimal PaidFees,
      ref int IsActive,
      ref int IssueReason,
      ref int CreatedByUserID
  )
        {
            string query = @"
        SELECT LicenseID, DriverID, LicenseClass, IssueDate, ExpirationDate,
               Notes, PaidFees, IsActive, IssueReason, CreatedByUserID
        FROM Licenses
        WHERE ApplicationID = @ApplicationID";

            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        LicenseID = Convert.ToInt32(reader["LicenseID"]);
                        DriverID = Convert.ToInt32(reader["DriverID"]);
                        LicenseClass = Convert.ToInt32(reader["LicenseClass"]);
                        IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                        ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);

                        Notes = reader["Notes"] != DBNull.Value
                            ? reader["Notes"].ToString()
                            : string.Empty;

                        PaidFees = Convert.ToDecimal(reader["PaidFees"]);

                        // ✅ bit → bool → int
                        IsActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"]) ? 1 : 0;

                        // ✅ tinyint → byte → int
                        IssueReason = reader["IssueReason"] != DBNull.Value
                            ? Convert.ToByte(reader["IssueReason"])
                            : 0;

                        CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // لا تخفي الخطأ
                Console.WriteLine(ex.Message);
                throw;
            }



        }



        public static clsLicenseDetailsDTO GetLicenseDetails(int licenseID)
        {
            clsLicenseDetailsDTO dto = null;

            string query = @" SELECT 
    l.LicenseID,
    l.ApplicationID,
    l.DriverID,
    l.LicenseClass,
    l.IssueDate,
    l.ExpirationDate,
    l.IsActive,
    l.IssueReason,
    l.Notes,

    lc.ClassName,

    p.FirstName,
    p.SecondName,
    p.ThirdName,
    p.LastName,
    p.NationalNo,
    p.Gendor,
    p.DateOfBirth,

    CASE 
        WHEN EXISTS (
            SELECT 1 
            FROM DetainedLicenses d 
            WHERE d.LicenseID = l.LicenseID
        )
        THEN 1 ELSE 0 
    END AS IsDetained

FROM Licenses l

INNER JOIN LicenseClasses lc 
    ON l.LicenseClass = lc.LicenseClassID

INNER JOIN Applications a 
    ON l.ApplicationID = a.ApplicationID

INNER JOIN People p 
    ON a.ApplicantPersonID = p.PersonID

WHERE l.LicenseID = @LicenseID; ";

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@LicenseID", SqlDbType.Int).Value = licenseID;

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dto = new clsLicenseDetailsDTO
                        {
                            LicenseID = (int)reader["LicenseID"],
                            ClassName = reader["ClassName"].ToString(),

                            FullName = reader["FirstName"] + " " +
                                       reader["SecondName"] + " " +
                                       reader["ThirdName"] + " " +
                                       reader["LastName"],

                            NationalNo = reader["NationalNo"].ToString(),

                            Gender = ((byte)reader["Gendor"] == 0) ? "Male" : "Female",

                            DateOfBirth = (DateTime)reader["DateOfBirth"],

                            DriverID = (int)reader["DriverID"],

                            IssueDate = (DateTime)reader["IssueDate"],
                            ExpirationDate = (DateTime)reader["ExpirationDate"],

                            IssueReason = ((byte)reader["IssueReason"] == 1) ? "First Time" : "Renew",

                            IsActive = (bool)reader["IsActive"] ? "Yes" : "No",

                            Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : "No Notes",

                            IsDetained = (int)reader["IsDetained"] == 1 ? "Yes" : "No"
                        };
                    }
                }
            }

            return dto;
        }

        public static bool Exists(int personID, int licenseClassID)
        {
            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 1
                         FROM Licenses L
                         INNER JOIN Applications A 
                             ON L.ApplicationID = A.ApplicationID
                         WHERE A.ApplicantPersonID = @PersonID
                         AND L.LicenseClass = @LicenseClassID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PersonID", personID);
                    cmd.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

                    try
                    {
                        con.Open();

                        object result = cmd.ExecuteScalar();

                        // ✅ If any row exists → result will NOT be null
                        return result != null;
                    }
                    catch (Exception )
                    {
                        // 🔴 Log error (DON’T swallow silently in real apps)
                        // Logger.Log(ex);

                        return false;
                    }
                }
            }
        }



        public static DataTable GetLocalLicensesByDriverID(int driverID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
       SELECT 
    L.LicenseID,
    LC.ClassName AS LicenseClass,
    L.IssueDate,
    L.ExpirationDate,
    CAST(L.IsActive AS BIT) AS IsActive
FROM Licenses L

INNER JOIN LicenseClasses LC
    ON L.LicenseClass = LC.LicenseClassID

INNER JOIN Applications A 
    ON L.ApplicationID = A.ApplicationID

WHERE L.DriverID = @DriverID
AND A.ApplicationTypeID = 1;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DriverID", driverID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }


        public static void DeactivateExpiredLicenses()
        {
            
        }









        public static int sycronizeExpiredLicense()
        {
            string query = @"
        UPDATE Licenses
        SET IsActive = 0
        WHERE ExpirationDate < GETDATE()
        AND IsActive = 1;
    ";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }


        public static int GetActiveLicenseIDByDriverIDAndLicenseClass(
    int driverID,
    int licenseClass)
        {
            int licenseID = -1;

            string query = @"
        SELECT TOP 1 LicenseID
        FROM Licenses
        WHERE DriverID = @DriverID
        AND LicenseClass = @LicenseClass
        AND IsActive = 1";

            using (SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", driverID);
                    command.Parameters.AddWithValue("@LicenseClass", licenseClass);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                            licenseID = Convert.ToInt32(result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return licenseID;
        }
    }
}
