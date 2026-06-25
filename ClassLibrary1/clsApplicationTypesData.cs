using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public  class clsApplicationTypesData
    {

       public static DataTable GetApplicationsTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from ApplicationTypes";

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

        public static bool UpdateApplicationsTypes(int ID, string Title,   decimal Fees)
        {
            int RowAffected = 0;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE ApplicationTypes 
                 SET ApplicationTypeTitle = @Title,
                     ApplicationFees = @Fees
                 WHERE ApplicationTypeID = @ID";

            SqlCommand cmd  = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Title", Title);
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

        public static bool FindApplicationTypeByID(int ID, ref string Title, ref Decimal Fees )
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from ApplicationTypes where ApplicationTypeID = @ID";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ID", ID);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    Title = (string)reader["ApplicationTypeTitle"];
                    Fees = Convert.ToDecimal(reader["ApplicationFees"]);
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

        
    }

}
