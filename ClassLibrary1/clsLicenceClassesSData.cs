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
    public class clsLicenceClassesSData
    {
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select * From LicenseClasses";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open(); // 🔥 مهم جدًا

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception )
                    {
                    }
                }
            }

            return dt;
        }

        public static bool GetLicenseClassByID(
       int id,
       ref string name,
       ref string description,
       ref int minAge,
       ref int validity,
       ref decimal fees)
        {
            string query = @"
        SELECT ClassName, ClassDescription, MinimumAllowedAge,
               DefaultValidityLength, ClassFees
        FROM LicenseClasses
        WHERE LicenseClassID = @ID";

            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        // nvarchar (ممكن NULL)
                        name = reader["ClassName"] as string ?? string.Empty;
                        description = reader["ClassDescription"] as string ?? string.Empty;

                        // tinyint → byte → int
                        minAge = reader["MinimumAllowedAge"] != DBNull.Value
                            ? Convert.ToByte(reader["MinimumAllowedAge"])
                            : 0;

                        validity = reader["DefaultValidityLength"] != DBNull.Value
                            ? Convert.ToByte(reader["DefaultValidityLength"])
                            : 0;

                        // smallmoney → decimal
                        fees = reader["ClassFees"] != DBNull.Value
                            ? Convert.ToDecimal(reader["ClassFees"])
                            : 0;

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // مهم جدًا
                throw;
            }
        }
    }
}
