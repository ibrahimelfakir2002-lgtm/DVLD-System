using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class clsAppointmentsData
    {

        public static bool GetAppointmentByID(int TestAppointmentID ,
ref int TestTypeID,
ref int LocalDrivingLicenseApplicationID,
ref DateTime    AppointmentDate,
ref Decimal PaidFees,
ref int CreatedByUserID,
ref bool IsLocked
)
        {


            bool isFound = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from TestAppointments where TestAppointments.TestAppointmentID = @TestAppointmentID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsLocked = (bool)reader["IsLocked"];

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


        public static bool HasActiveAppointment(int localAppID, int testTypeID)
        {
            bool exists = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 
                     FROM TestAppointments
                     WHERE LocalDrivingLicenseApplicationID = @LocalAppID
                     AND TestTypeID = @TestTypeID
                     AND IsLocked = 0";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@LocalAppID", localAppID);
            cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);

            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                exists = (result != null);
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

        public static int AddNewAppointment(int testTypeID, int localAppID,
    DateTime appointmentDate, decimal paidFees, int createdByUserID, bool isLocked)
        {
            int newID = -1;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO TestAppointments
                     (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked)
                     VALUES
                     (@TestTypeID, @LocalAppID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked);

                     SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
            cmd.Parameters.AddWithValue("@LocalAppID", localAppID);
            cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", paidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", isLocked);

            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    newID = Convert.ToInt32(result);
            }
            finally
            {
                con.Close();
            }

            return newID;
        }

        public static bool UpdateAppointment(int testAppointmentID, DateTime appointmentDate,
    decimal paidFees, bool isLocked)
        {
            bool isUpdated = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE TestAppointments
                     SET AppointmentDate = @AppointmentDate,
                         PaidFees = @PaidFees,
                         IsLocked = @IsLocked
                     WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
            cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", paidFees);
            cmd.Parameters.AddWithValue("@IsLocked", isLocked);

            try
            {
                con.Open();
                isUpdated = cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                con.Close();
            }

            return isUpdated;
        }


        public static DataTable GetAllAppointmentsByLocalID(int LocalAppID)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select  TestAppointmentID,AppointmentDate,PaidFees,IsLocked  from TestAppointments 
            where TestAppointments.LocalDrivingLicenseApplicationID = @LocalAppID ";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@LocalAppID", LocalAppID);


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

       public static DataTable GetAllAppointmentsByLocalIDAndTestType(int LocalAppID , int TestTypeID)
        {

            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select  TestAppointmentID,AppointmentDate,PaidFees,IsLocked  from TestAppointments 
            where TestAppointments.LocalDrivingLicenseApplicationID = @LocalAppID 
          and TestAppointments.TestTypeID = @TestTypeID
        order by AppointmentDate desc";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@LocalAppID", LocalAppID);

            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);


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

        //public static bool LockedTestAppointment(int TestAppointmentID)
        //{
        //    int RowAffected = 0;

        //    SqlConnection con = new SqlConnection( clsDataAccessSettings.ConnectionString);

        //    string query = @"update TestAppointments
        //        set TestAppointments.IsLocked = 1
        //        where TestAppointmentID = @TestAppointmentID";

        //    SqlCommand cmd = new SqlCommand(query,con);

        //    cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
        //    try
        //    {
        //        con.Open();

        //        RowAffected = cmd.ExecuteNonQuery();


        //    }
        //    catch (Exception)
        //    {
        //        RowAffected = 0;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //    return (RowAffected > 0);
        //}

        public static bool LockAppointment(int appointmentID)
        {
            int rowsAffected = 0;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
        UPDATE TestAppointments
        SET IsLocked = 1
        WHERE TestAppointmentID = @ID
        AND IsLocked = 0";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", appointmentID);

                    try
                    {
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return rowsAffected > 0;
        }

        public static bool HasLockedAppointment(int localAppID, int testTypeID)
        {
            bool isFound = false;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
        SELECT 1
        FROM TestAppointments
        WHERE LocalDrivingLicenseApplicationID = @LocalAppID
        AND TestTypeID = @TestTypeID
        AND IsLocked = 1";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@LocalAppID", localAppID);
                    cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);

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


        public static bool HasFailedAppointment(int localAppID, int testTypeID)
        {
            bool isFound = false;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
        SELECT TOP 1 1
        FROM TestAppointments A
        INNER JOIN Tests T
            ON A.TestAppointmentID = T.TestAppointmentID
        WHERE A.LocalDrivingLicenseApplicationID = @LocalAppID
        AND A.TestTypeID = @TestTypeID
        AND A.IsLocked = 1
        AND T.TestResult = 0  -- 0 = Fail
        ORDER BY A.TestAppointmentID DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@LocalAppID", localAppID);
                    cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);

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
        public static bool HasPassedAppointment(int localAppID, int testTypeID)
        {
            bool isFound = false;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
        SELECT TOP 1 1
        FROM TestAppointments A
        INNER JOIN Tests T
            ON A.TestAppointmentID = T.TestAppointmentID
        WHERE A.LocalDrivingLicenseApplicationID = @LocalAppID
        AND A.TestTypeID = @TestTypeID
        AND A.IsLocked = 1
        AND T.TestResult = 1  -- 1 = Pass
        ORDER BY A.TestAppointmentID DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@LocalAppID", localAppID);
                    cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);

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

        public static bool HasTestAppointments(int localAppID)
        {
            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT CASE WHEN EXISTS( SELECT 1 FROM TestAppointments  WHERE LocalDrivingLicenseApplicationID = @LocalAppID) THEN 1 ELSE 0 END";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@LocalAppID", SqlDbType.Int).Value = localAppID;

                    try
                    {
                        con.Open();
                        return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
                    }
                    catch (Exception )
                    {
                       
                        return false;
                    }
                }
            }
        }



    }
}
