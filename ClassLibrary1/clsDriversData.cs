using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class clsDriversData
    {

        public static bool GetDriverByID(int DriverID, ref 
int PersonID,
ref int CreatedByUserID,
ref DateTime CreatedDate
 )
        {
            bool isFound=false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" select * from Drivers where DriverID = @DriverID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) 
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];

                }

                else{
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


        public static int AddNewDriver(
int PersonID,
 int CreatedByUserID,
 DateTime CreatedDate)
        {
            int DriverID = -1;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Drivers(
PersonID,
CreatedByUserID,
CreatedDate
)
                         VALUES (@PersonID,@CreatedByUserID,@CreatedDate);

                         SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);

                    con.Open();

                    object result = cmd.ExecuteScalar();

                    DriverID = (result == null || result == DBNull.Value)
                        ? -1
                        : Convert.ToInt32(result);
                }
            }

            return DriverID;

        }

        public static bool FindByPersonID(ref int DriverID, 
int PersonID,
ref int CreatedByUserID,
ref DateTime CreatedDate)
        {


            bool isFound = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Drivers where PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query ,con    );

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];

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


        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
         
          SELECT 
    DriverID,
    PersonID,
    NationalNo,
    FullName,
    NumberOfActiveLicenses,
    CreatedDate
FROM Drivers_View";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error while retrieving drivers data: " + ex.Message);
                    }
                }
            }

            return dt;
        }


        public static bool IsPersonDriver(int personId)
        {
            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT TOP 1 1
                         FROM Drivers
                         WHERE PersonID = @PersonId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PersonId", personId);

                    con.Open();
                    return cmd.ExecuteScalar() != null;
                }
            }
        }


    }
}
