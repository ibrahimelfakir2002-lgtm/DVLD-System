using DVLDDataAccessLayer;
using SharedDvldClasses.Enums;
using System;
                                    using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
                                    using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDDataAccessLayer
{
    public class clsApplicationData
    {
        public static int AddNewApplication(

                                        int ApplicantPersonID,
                                      DateTime ApplicationDate,
                                       int ApplicationTypeID,
                                       int ApplicationStatus,
                                      DateTime LastStatusDate,
                                      decimal PaidFees,
                                      int CreatedByUserID)
        {
            int ApplicationID = -1;
            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"insert into Applications (
			 						   ApplicantPersonID,
									   ApplicationDate,
									   ApplicationTypeID,
									   ApplicationStatus,
									   LastStatusDate,
									   PaidFees,
									   CreatedByUserID)


   values (@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFees,@CreatedByUserID);

                         SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                con.Open();

                object result = cmd.ExecuteScalar();

                ApplicationID = (result == null || result == DBNull.Value)
                    ? -1
                    : Convert.ToInt32(result);

            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }

            return ApplicationID;


        }

        public static bool GetApplicationByApplicationID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID, ref int ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID) { bool isFound = false; SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString); string query = @" select * from Applications where ApplicationID = @ApplicationID"; SqlCommand cmd = new SqlCommand(query, con); cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID); try { con.Open(); SqlDataReader reader = cmd.ExecuteReader(); if (reader.Read()) { 
                    isFound = true; 
                    ApplicantPersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                    ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                    ApplicationTypeID = Convert.ToInt32(reader["ApplicationTypeID"]);
                    ApplicationStatus = Convert.ToInt32(reader["ApplicationStatus"]);
                    LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                    PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]); 
                    ; }
                else { 
                    isFound = false;
                } 
                reader.Close(); 
            } 
            catch (Exception) {
                isFound = false; 
            } finally {
                con.Close(); 
            } 
            return isFound; }



        public static bool UpdateApplicationStatus(int ApplicationID, int Status)
        {
            int rows = 0;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"update Applications set ApplicationStatus = @Status where ApplicationID = @ApplicationID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    cmd.Parameters.AddWithValue("@Status", Status);

                    con.Open();
                    rows = cmd.ExecuteNonQuery();
                }
            }

            return rows > 0;


        }

        public static string GetApplicationTypeTitle(int applicationTypeID)
        {
            string title = "";

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT ApplicationTypeTitle FROM ApplicationTypes WHERE ApplicationTypeID = @ID";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", applicationTypeID);

            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    title = result.ToString();
            }
            catch
            {
                title = "";
            }
            finally
            {
                con.Close();
            }

            return title;
        }

        public static bool UpdateApplication(
     int applicationID,
     int applicantPersonID,
     int applicationTypeID,
     int applicationStatus,
     DateTime lastStatusDate,   // 🔥 NEW
     decimal paidFees)
        {
            int rowsAffected = 0;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
        UPDATE Applications
        SET ApplicantPersonID = @ApplicantPersonID,
            ApplicationTypeID = @ApplicationTypeID,
            ApplicationStatus = @ApplicationStatus,
            LastStatusDate = @LastStatusDate,   -- 🔥 NEW
            PaidFees = @PaidFees
        WHERE ApplicationID = @ApplicationID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
                    cmd.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = applicantPersonID;
                    cmd.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = applicationTypeID;
                    cmd.Parameters.Add("@ApplicationStatus", SqlDbType.Int).Value = applicationStatus;
                    cmd.Parameters.Add("@LastStatusDate", SqlDbType.DateTime).Value = lastStatusDate;

                    // 🔥 Important for decimal
                    SqlParameter feesParam = new SqlParameter("@PaidFees", SqlDbType.Decimal);
                    feesParam.Precision = 10;
                    feesParam.Scale = 2;
                    feesParam.Value = paidFees;
                    cmd.Parameters.Add(feesParam);

                    try
                    {
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception )
                    {
                        // 🔥 DO NOT swallow errors silently
                        // Log or debug
                       // MessageBox.Show("DB Error: " + ex.Message);
                        return false;
                    }
                }
            }

            return rowsAffected > 0;
        }

        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT 
                ApplicationID,
                ApplicantPersonID,
                ApplicationDate,
                ApplicationTypeID,
                ApplicationStatus,
                LastStatusDate,
                PaidFees,
                CreatedByUserID
            FROM Applications";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception)
                    {
                        // optional logging
                    }
                }
            }

            return dt;
        }


        public static bool DeleteApplication(int applicationID)
        {
            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE FROM Applications
                         WHERE ApplicationID = @AppID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AppID", applicationID);

                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }


        public static enApplicationStatus? GetApplicationStatus(int personID, int licenseClassID)
        {
            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT TOP 1 A.ApplicationStatus
            FROM Applications A
            INNER JOIN LocalDrivingLicenseApplications L
                ON A.ApplicationID = L.ApplicationID
            WHERE A.ApplicantPersonID = @PersonID
              AND L.LicenseClassID = @LicenseClassID
              AND A.ApplicationStatus <> @CancelledStatus
            ORDER BY A.ApplicationID DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;
                    cmd.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;
                    cmd.Parameters.Add("@CancelledStatus", SqlDbType.Int).Value = (int)enApplicationStatus.Cancelled;

                    try
                    {
                        con.Open();

                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                            return null;

                        int statusValue = Convert.ToInt32(result);

                        if (Enum.IsDefined(typeof(enApplicationStatus), statusValue))
                            return (enApplicationStatus)statusValue;

                        return null;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
    }
}


