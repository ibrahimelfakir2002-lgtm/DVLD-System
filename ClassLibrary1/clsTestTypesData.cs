using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsTestTypesData
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection con =  new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from TestTypes";

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
        public static bool FindTestTypeByID(int ID, ref string Title, ref string Description, ref Decimal Fees)
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from TestTypes where TestTypeID= @ID";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ID", ID);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    Title = (string)reader["TestTypeTitle"];
                    Description = (string)reader["TestTypeDescription"];
                    Fees = Convert.ToDecimal(reader["TestTypeFees"]);
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

        public static bool UpdateTestTypes(int ID, string Title, string Description ,decimal Fees)
        {
            int RowAffected = 0;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE TestTypes 
                 SET TestTypeTitle = @Title,
                     TestTypeDescription = @Description,
                     TestTypeFees = @Fees
                 WHERE TestTypeID = @ID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Description", Description);

            cmd.Parameters.AddWithValue("@Fees", Fees);
            cmd.Parameters.AddWithValue("@ID", ID);

            try
            {
                con.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // Logging later


            }
            finally
            {
                con.Close();
            }
            return (RowAffected > 0);
        }
    }
}
