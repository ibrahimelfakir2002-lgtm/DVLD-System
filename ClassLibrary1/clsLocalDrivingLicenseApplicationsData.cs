using DVLDDataAccessLayer;
using SharedDvldClasses.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary1
{
    public class clsLocalDrivingLicenseApplicationsData
    {

        public static bool GetLocalDrivingLApplicationByNationalNo(ref int LocalDrivingLicenseApplicationID, ref string ClassName, string NationalNo,
            ref string FullName, ref DateTime ApplicationDate, ref int PassedTesctCount, ref int Status)
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from(
SELECT dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, dbo.LicenseClasses.ClassName, dbo.People.NationalNo, dbo.People.FirstName + ' ' + dbo.People.SecondName + ' ' + ISNULL(dbo.People.ThirdName, '') + ' ' + dbo.People.LastName AS FullName, 
             dbo.Applications.ApplicationDate,
                 (SELECT COUNT(dbo.TestAppointments.TestTypeID) AS PassedTestCount
                 FROM    dbo.Tests INNER JOIN
                              dbo.TestAppointments ON dbo.Tests.TestAppointmentID = dbo.TestAppointments.TestAppointmentID
                 WHERE (dbo.TestAppointments.LocalDrivingLicenseApplicationID = dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID) AND (dbo.Tests.TestResult = 1)) AS PassedTestCount, 
             Applications.ApplicationStatus  AS Status
FROM   dbo.LocalDrivingLicenseApplications INNER JOIN
             dbo.Applications ON dbo.LocalDrivingLicenseApplications.ApplicationID = dbo.Applications.ApplicationID INNER JOIN
             dbo.LicenseClasses ON dbo.LocalDrivingLicenseApplications.LicenseClassID = dbo.LicenseClasses.LicenseClassID INNER JOIN
             dbo.People ON dbo.Applications.ApplicantPersonID = dbo.People.PersonID) as c
			 where c.NationalNo = @NationalNo
";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    ClassName = (string)reader["ClassName"];
                    FullName = (string)reader["FullName"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    PassedTesctCount = (int)reader["PassedTestCount"];
                    Status = (int)reader["Status"];

                }
                else
                {
                    isFound = false;
                }

                reader.Close();

            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                con.Close();
            }
            return isFound;
        }

        public static bool GetLocalDrivingLApplicationByAppID(int LocalDrivingLicenseApplicationID, ref string ClassName, ref string NationalNo,
            ref string FullName, ref DateTime ApplicationDate, ref int PassedTesctCount, ref int Status)
        {
            bool isFound = false;
            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from(
SELECT dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, dbo.LicenseClasses.ClassName, dbo.People.NationalNo, dbo.People.FirstName + ' ' + dbo.People.SecondName + ' ' + ISNULL(dbo.People.ThirdName, '') + ' ' + dbo.People.LastName AS FullName, 
             dbo.Applications.ApplicationDate,
                 (SELECT COUNT(dbo.TestAppointments.TestTypeID) AS PassedTestCount
                 FROM    dbo.Tests INNER JOIN
                              dbo.TestAppointments ON dbo.Tests.TestAppointmentID = dbo.TestAppointments.TestAppointmentID
                 WHERE (dbo.TestAppointments.LocalDrivingLicenseApplicationID = dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID) AND (dbo.Tests.TestResult = 1)) AS PassedTestCount, 
             Applications.ApplicationStatus  AS Status
FROM   dbo.LocalDrivingLicenseApplications INNER JOIN
             dbo.Applications ON dbo.LocalDrivingLicenseApplications.ApplicationID = dbo.Applications.ApplicationID INNER JOIN
             dbo.LicenseClasses ON dbo.LocalDrivingLicenseApplications.LicenseClassID = dbo.LicenseClasses.LicenseClassID INNER JOIN
             dbo.People ON dbo.Applications.ApplicantPersonID = dbo.People.PersonID) as c
			 where c.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    ClassName = (string)reader["ClassName"];
                    NationalNo = (string)reader["NationalNo"];
                    FullName = (string)reader["FullName"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    PassedTesctCount = (int)reader["PassedTestCount"];
                    Status = (int)reader["Status"];

                }
                else
                {
                    isFound = false;
                }

                reader.Close();

            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                con.Close();
            }
            return isFound;

        }



        public static bool GetLocalDrivingLApplicationByAppID(
     int LocalDrivingLicenseApplicationID,
     ref int ApplicationID,            // 🔥 مهم جدًا (مضاف)
     ref int LicenseClassID,
     ref string ClassName,
     ref string NationalNo,
     ref string FullName,
     ref DateTime ApplicationDate,
     ref int PassedTestCount,
     ref int Status)
        {
            bool isFound = false;

            using (SqlConnection con =
                new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
SELECT 
    L.LocalDrivingLicenseApplicationID,
    L.ApplicationID,   -- 🔥 هذا أهم إضافة
    L.LicenseClassID,
    LC.ClassName,
    P.NationalNo,
    P.FirstName + ' ' + P.SecondName + ' ' + 
    ISNULL(P.ThirdName, '') + ' ' + P.LastName AS FullName,
    A.ApplicationDate,

    (SELECT COUNT(*)
     FROM Tests T
     INNER JOIN TestAppointments TA
        ON T.TestAppointmentID = TA.TestAppointmentID
     WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID
       AND T.TestResult = 1) AS PassedTestCount,

    A.ApplicationStatus

FROM LocalDrivingLicenseApplications L
INNER JOIN Applications A
    ON L.ApplicationID = A.ApplicationID
INNER JOIN LicenseClasses LC
    ON L.LicenseClassID = LC.LicenseClassID
INNER JOIN People P
    ON A.ApplicantPersonID = P.PersonID
WHERE L.LocalDrivingLicenseApplicationID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                        LocalDrivingLicenseApplicationID;

                    try
                    {
                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                            ClassName = reader["ClassName"].ToString();
                            NationalNo = reader["NationalNo"].ToString();
                            FullName = reader["FullName"].ToString();
                            ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);

                            PassedTestCount = reader["PassedTestCount"] != DBNull.Value
                                ? Convert.ToInt32(reader["PassedTestCount"])
                                : 0;

                            Status = Convert.ToInt32(reader["ApplicationStatus"]);
                        }

                        reader.Close();
                    }
                    catch
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }
        public static bool GetLocalDrivingLApplicationByFullName(ref int LocalDrivingLicenseApplicationID, ref string ClassName, ref string NationalNo,
             string FullName, ref DateTime ApplicationDate, ref int PassedTesctCount, ref int Status)
        {

            bool isFound = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from(
SELECT dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, dbo.LicenseClasses.ClassName, dbo.People.NationalNo, dbo.People.FirstName + ' ' + dbo.People.SecondName + ' ' + ISNULL(dbo.People.ThirdName, '') + ' ' + dbo.People.LastName AS FullName, 
             dbo.Applications.ApplicationDate,
                 (SELECT COUNT(dbo.TestAppointments.TestTypeID) AS PassedTestCount
                 FROM    dbo.Tests INNER JOIN
                              dbo.TestAppointments ON dbo.Tests.TestAppointmentID = dbo.TestAppointments.TestAppointmentID
                 WHERE (dbo.TestAppointments.LocalDrivingLicenseApplicationID = dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID) AND (dbo.Tests.TestResult = 1)) AS PassedTestCount, 
             Applications.ApplicationStatus  AS Status
FROM   dbo.LocalDrivingLicenseApplications INNER JOIN
             dbo.Applications ON dbo.LocalDrivingLicenseApplications.ApplicationID = dbo.Applications.ApplicationID INNER JOIN
             dbo.LicenseClasses ON dbo.LocalDrivingLicenseApplications.LicenseClassID = dbo.LicenseClasses.LicenseClassID INNER JOIN
             dbo.People ON dbo.Applications.ApplicantPersonID = dbo.People.PersonID) as c
			 where c.FullName = @FullName
";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@FullName", FullName);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    ClassName = (string)reader["ClassName"];
                    NationalNo = (string)reader["NationalNo"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    PassedTesctCount = (int)reader["PassedTestCount"];
                    Status = (int)reader["Status"];

                }
                else
                {
                    isFound = false;
                }

                reader.Close();

            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                con.Close();
            }
            return isFound;
        }


        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT L.LocalDrivingLicenseApplicationID, LC.ClassName,\r\n    P.NationalNo,\r\n    P.FirstName + ' ' + P.SecondName + ' ' +\r\n    ISNULL(P.ThirdName, '') + ' ' + P.LastName AS FullName,\r\n    A.ApplicationDate, (\r\n        SELECT COUNT(*)\r\n        FROM Tests T\r\n        INNER JOIN TestAppointments TA\r\n            ON T.TestAppointmentID = TA.TestAppointmentID\r\n        WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID\r\n          AND T.TestResult = 1\r\n    ) AS PassedTestCount,\r\n\r\n    CASE A.ApplicationStatus\r\n        WHEN 1 THEN 'New'\r\n        WHEN 2 THEN 'In Progress'\r\n        WHEN 3 THEN 'Passed Tests'\r\n        WHEN 4 THEN 'Completed'\r\n        WHEN 5 THEN 'Cancelled'\r\n        ELSE 'Unknown'\r\n    END AS Status\r\n\r\nFROM LocalDrivingLicenseApplications L\r\nINNER JOIN Applications A\r\n    ON L.ApplicationID = A.ApplicationID\r\nINNER JOIN LicenseClasses LC\r\n    ON L.LicenseClassID = LC.LicenseClassID\r\nINNER JOIN People P\r\n    ON A.ApplicantPersonID = P.PersonID";

            SqlCommand cmd = new SqlCommand(query, con);


            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            catch (Exception) {
            }
            finally
            {
                con.Close();
            }
            return dt;

        }
        public static int AddNewLocalApplication(int applicationID, int licenseClassID)
        {
            int id = -1;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO LocalDrivingLicenseApplications
                     (ApplicationID, LicenseClassID)
                     VALUES (@AppID, @ClassID);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@AppID", applicationID);
            cmd.Parameters.AddWithValue("@ClassID", licenseClassID);

            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                id = Convert.ToInt32(result);
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }

            return id;
        }

        public static bool HasActiveApplication(int personID, int licenseClassID)
        {
            bool exists = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT 1
        FROM Applications A
        INNER JOIN LocalDrivingLicenseApplications L
            ON A.ApplicationID = L.ApplicationID
        WHERE A.ApplicantPersonID = @PersonID
        AND L.LicenseClassID = @LicenseClassID
        AND A.ApplicationStatus = 1";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                exists = result != null;
            }
            catch
            {
                exists = false;
            }
            finally
            {
                con.Close();
            }

            return exists;
        }


        public static int GetApplicationIDByLocalAppID(int LocalappID)
        {
            int appId = -1;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select LocalDrivingLicenseApplications.ApplicationID from Applications inner join 
           LocalDrivingLicenseApplications on Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID

            where LocalDrivingLicenseApplicationID = @LocalappID";

            SqlCommand cmd = new SqlCommand(@query, con);

            cmd.Parameters.AddWithValue("@LocalappID", LocalappID);

            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                appId = Convert.ToInt32(result);
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }

            return appId;
        }


        public static bool Delete(int localApp)
        {
            int rowsAffected = 0;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            DELETE FROM LocalDrivingLicenseApplications
            WHERE LocalDrivingLicenseApplicationID = @localApp";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@localApp", SqlDbType.Int).Value = localApp;

                    try
                    {
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception )
                    {
                        // log error if needed
                        return false;
                    }
                }
            }

            return rowsAffected > 0;
        }


        public static int GetLocalAppIDByApplicationID(int applicationID)
        {
            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT LocalDrivingLicenseApplicationID
            FROM LocalDrivingLicenseApplications
            WHERE ApplicationID = @AppID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@AppID", SqlDbType.Int).Value = applicationID;

                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();

                        return (result != null) ? Convert.ToInt32(result) : -1;
                    }
                    catch
                    {
                        return -1;
                    }
                }
            }
        }


        public static bool ExistsPassedTestsWithoutLicense(int personID, int licenseClassID)
        {
            bool exists = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT TOP 1 1
            FROM LocalDrivingLicenseApplications L
            INNER JOIN Applications A 
                ON L.ApplicationID = A.ApplicationID
            WHERE A.ApplicantPersonID = @PersonID
              AND L.LicenseClassID = @LicenseClassID
              AND A.ApplicationStatus = @PassedTestsStatus
              AND NOT EXISTS (
                    SELECT 1 
                    FROM Licenses Lic
                    WHERE Lic.ApplicationID = A.ApplicationID
              )";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonID", personID);
                    cmd.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
                    cmd.Parameters.AddWithValue("@PassedTestsStatus", (int)enApplicationStatus.PassedTests);

                    try
                    {
                        conn.Open();

                        object result = cmd.ExecuteScalar();

                        exists = (result != null);
                    }
                    catch (Exception ex)
                    {
                        // Optional: log error
                        // clsLogger.Log(ex);
                        exists = false;
                    }
                }
            }

            return exists;
        }
    } 


}
