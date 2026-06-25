using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsCountriesData
    {

        public static bool GetCountryByID(int CountryId, ref string CountryName)
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Countries where CountryID  = @CountryID ";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@CountryID", CountryId);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    CountryName = (string)reader["CountryName"];
                }

                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception )
            {
                isFound = false;
            }
            finally
            {
                con.Close();
            }

            return isFound;
        }

        public static bool GetCountryByCountryName(ref int CountryID, string CountryName)
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection((string)clsDataAccessSettings.ConnectionString);

            string query = @"select * from Countries where CountryName  = @CountryName";
            
            SqlCommand command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound= true;

                    CountryID = (int)reader["CountryID"];
                }
                else
                {
                  isFound |= false;
                }
                reader.Close();
            }

            catch (Exception )
            {
                isFound = false;
            }
            finally
            {
                con.Close();
            }
            return isFound;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Countries";
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
            catch (Exception )
            {

            }
            finally
            {
                con.Close();
            }

            return dt;

        }

    }
}
