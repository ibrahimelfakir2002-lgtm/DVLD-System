using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public   class clsTestData
    {

        public static bool GetTestByTestID(int TestID,
int TestAppointmentID,
int TestResult,
string Notes,
int CreatedByUserID
 )
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Tests where Tests.TestID = @TestID";

            SqlCommand cmd  = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (int)reader["TestResult"];

                    if (reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)reader["Notes"];
                    }
                    else
                    {
                        Notes = "";
                    }

                    CreatedByUserID = (int)reader["CreatedByUserID"];
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


        public static DataTable GetAllTests()
        {

            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Tests";

            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }

            return dt;
        }


        public static int AddNewTest(int TestAppointmentID, int TestResult, string Notes, int CreatedByUserID)
        {
            int TestId = -1;

            SqlConnection con = new SqlConnection( clsDataAccessSettings.ConnectionString);

            string query = @"insert into Tests ( TestAppointmentID,  TestResult,  Notes,  CreatedByUserID)
            values 
            (@TestAppointmentID ,@TestResult,@Notes,@CreatedByUserID)  ;SELECT CAST(SCOPE_IDENTITY() AS INT)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);

            if (string.IsNullOrEmpty(Notes))
            {
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);

            }
            else
            {
                cmd.Parameters.AddWithValue("@Notes", Notes);
            }

            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                con.Open();


                object result = cmd.ExecuteScalar();

                TestId = (result == null || result == DBNull.Value)
                    ? -1
                    : Convert.ToInt32(result);
            }
            catch (Exception)
            {
                TestId = -1;
            }
            finally
            {
                con.Close();
            }
            return TestId;

        }
        public static bool IsTestExistsByAppointmentID(int appointmentID)
        {
            bool isFound = false;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
        SELECT 1
        FROM Tests
        WHERE TestAppointmentID = @AppointmentID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);

                    try
                    {
                        con.Open();

                        var result = cmd.ExecuteScalar();

                        isFound = (result != null);
                    }
                    catch
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static int GetLastTestResult(int localAppID, int testTypeID)
        {
            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
        SELECT TOP 1 T.TestResult
        FROM TestAppointments A
        INNER JOIN Tests T
            ON A.TestAppointmentID = T.TestAppointmentID
        WHERE A.LocalDrivingLicenseApplicationID = @LocalAppID
        AND A.TestTypeID = @TestTypeID
        ORDER BY A.TestAppointmentID DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@LocalAppID", localAppID);
                    cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);

                    con.Open();

                    object result = cmd.ExecuteScalar();

                    if (result == null)
                        return -1; // no test yet

                    return Convert.ToInt32(result);
                }
            }
        }


        


        public static int GetPassedTestsCountByLocalAppID(int localAppID)
        {
            int count = 0;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT COUNT(*)
            FROM TestAppointments TA
            INNER JOIN Tests T 
                ON TA.TestAppointmentID = T.TestAppointmentID
            WHERE TA.LocalDrivingLicenseApplicationID = @LocalAppID
              AND T.TestResult = 1";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@LocalAppID", SqlDbType.Int).Value = localAppID;

                    con.Open();
                    object result = cmd.ExecuteScalar();

                    count = (result != null) ? Convert.ToInt32(result) : 0;
                }
            }

            return count;
        }

        public static bool HasAnyTestResults(int localAppID)
        {
            bool exists = false;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT 1
            FROM Tests T
            INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID
            WHERE TA.LocalDrivingLicenseApplicationID = @LocalAppID
            AND T.TestResult IS NOT NULL";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@LocalAppID", localAppID);

                    try
                    {
                        con.Open();

                        object result = cmd.ExecuteScalar();

                        exists = result != null;
                    }
                    catch (Exception)
                    {
                        exists = false;
                    }
                }
            }

            return exists;
        }

    }
}
