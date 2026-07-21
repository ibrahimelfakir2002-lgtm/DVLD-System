using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DVLDDataAccessLayer
{
    public class clsPeopleData
    {
        private static object ToDbValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return DBNull.Value;

            return value;
        }
        public static bool GetPersonByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,ref DateTime DateOfBirth, ref int Gendor , ref string Address ,ref string Phone,  ref string Email, ref int  NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

         

             string query = @"select * from People where PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, con);

          cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                con.Open();
               
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    {

                    isFound = true;

                    NationalNo = reader["NationalNo"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = reader["LastName"].ToString();

                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);

                    Gendor = Convert.ToInt32(reader["Gendor"]);

                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();

                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }


                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                  
                   

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

        public static bool GetPersonByNationalNo(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName,
           ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from People where NationalNo  = @NationalNo";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;


                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = Convert.ToInt32(reader["Gendor"]);
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }


                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

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
                connection.Close();
            }
            return isFound;
        }

        public static bool GetPersonByFirstName(ref int PersonID, ref string NationalNo,  string FirstName, ref string SecondName,
           ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection con  = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from People where FirstName = @FirstName";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@FirstName", FirstName);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    NationalNo = (string)reader["NationalNo"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = Convert.ToInt32(reader["Gendor"]);
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }


                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

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

        public static bool GetPersonBySecondName(ref int PersonID, ref string NationalNo, ref string FirstName,  string SecondName,
           ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from People where SecondName = @SecondName";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@SecondName", SecondName);


            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];

                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = Convert.ToInt32(reader["Gendor"]);
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }


                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

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


        public static bool GetPrsonByThirdName(ref int PersonID, ref string NationalNo, ref string FirstName,ref  string SecondName,
           string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from People where ThirdName = @ThirdName";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ThirdName", ThirdName);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];

                    SecondName = (string)reader["SecondName"];

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = Convert.ToInt32(reader["Gendor"]);
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }


                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

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


        public static bool GetPersonByLastName(ref int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,
           ref string ThirdName,  string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from People where LastName = @LastName";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@LastName", LastName);
            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = Convert.ToInt32(reader["Gendor"]);
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }


                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

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
        public static DataTable GetPeopleByNationality(string nationality)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM People 
                         INNER JOIN Countries 
                         ON People.NationalityCountryID = Countries.CountryID
                         WHERE Countries.CountryName = @Nationality";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nationality", nationality);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }

            return dt;
        }
        public static bool GetPersonByGendor( ref int PersonID,ref  string NationalNo, ref string FirstName, ref string SecondName,
           ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,  int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from People where Gendor = @Gendor";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Gendor", Gendor);

            try { 
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                isFound = true;

                PersonID = (int)reader["PersonID"];
                NationalNo = (string)reader["NationalNo"];
                FirstName = (string)reader["FirstName"];
                SecondName = (string)reader["SecondName"];
                if (reader["ThirdName"] != DBNull.Value)
                {
                    ThirdName = (string)reader["ThirdName"];
                }
                else
                {
                    ThirdName = "";
                }

                LastName = (string)reader["LastName"];

                DateOfBirth = (DateTime)reader["DateOfBirth"];
                Address = (string)reader["Address"];
                Phone = (string)reader["Phone"];

                if (reader["Email"] != DBNull.Value)
                {
                    Email = (string)reader["Email"];
                }
                else
                {
                    Email = "";
                }


                NationalityCountryID = (int)reader["NationalityCountryID"];

                if (reader["ImagePath"] != DBNull.Value)
                {
                    ImagePath = (string)reader["ImagePath"];
                }
                else
                {
                    ImagePath = "";
                }

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


        public static bool GetPersonByPhone( ref int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,
           ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address,  string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {

            bool isFound = false;
            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from People where Phone = @Phone";

            SqlCommand cmd =new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Phone", Phone);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = Convert.ToInt32(reader["Gendor"]);
                    Address = (string)reader["Address"];

                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }


                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

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

        public static bool GetPersonByEmail( ref int PersonID,ref string NationalNo, ref string FirstName, ref string SecondName,
           ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone,  string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from People where Email = @Email";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Email", Email);
            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    Gendor = (int)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    


                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

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

       
        public static int AddnewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName , DateTime DateOfBirth ,
            int Gendor , string Address,string Phone , string Email,int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;
           SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People (NationalNo,FirstName,SecondName,ThirdName, LastName,DateOfBirth,Gendor,Address, Phone,Email,   NationalityCountryID,ImagePath)
                             VALUES (@NationalNo,@FirstName,@SecondName, @ThirdName,@LastName,@DateOfBirth,@Gendor, @Address, @Phone, @Email, @NationalityCountryID,@ImagePath);
                             SELECT SCOPE_IDENTITY();";


            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@SecondName", SecondName);


            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", Gendor);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);

           


            cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);


            cmd.Parameters.AddWithValue("@Email", ToDbValue(Email));
            cmd.Parameters.AddWithValue("@ThirdName", ToDbValue(ThirdName));
            cmd.Parameters.AddWithValue("@ImagePath", ToDbValue(ImagePath));

            
           try
            {
                con.Open();

                object result = cmd.ExecuteScalar();

                PersonID = (result == null || result == DBNull.Value)
                    ? -1
                    : Convert.ToInt32(result);
            }
            catch (Exception )
            {
               
            }
            finally
            {
                con.Close();
            }
            return PersonID;
            }

            public static bool UpdatePersonInfo(
      int PersonID,
      string NationalNo,
      string FirstName,
      string SecondName,
      string ThirdName,
      string LastName,
      DateTime DateOfBirth,
      int Gendor,
      string Address,
      string Phone,
      string Email,
      int NationalityCountryID,
      string ImagePath)
        {
            int rowAffected = 0;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            UPDATE People
            SET NationalNo = @NationalNo,
                FirstName = @FirstName, 
                SecondName = @SecondName,
                ThirdName = @ThirdName,
                LastName = @LastName, 
                DateOfBirth = @DateOfBirth,
                Gendor = @Gendor,
                Address = @Address,     
                Phone = @Phone, 
                Email = @Email, 
                NationalityCountryID = @NationalityCountryID,
                ImagePath = @ImagePath,
                LastModifiedAt = GETDATE()
            WHERE PersonID = @PersonID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", SecondName);
                    cmd.Parameters.AddWithValue("@ThirdName", ToDbValue(ThirdName));
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gendor", Gendor);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@Email", ToDbValue(Email));
                    cmd.Parameters.AddWithValue("@ImagePath", ToDbValue(ImagePath));
                    cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        con.Open();
                        rowAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        // Logging later
                    }
                }
            }

            return (rowAffected > 0);
        }

        public static DataTable GetAllPersons()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString);

                                        string query = @"
                                SELECT 
                                    P.PersonID,
                                    P.NationalNo,
                                    P.FirstName,
                                    P.SecondName,
                                    P.ThirdName,
                                    P.LastName,
                                     CASE 
                                        WHEN P.Gendor = 0 THEN 'Male'
                                        ELSE 'Female'
                                    END AS GenderText,
                                    P.DateOfBirth,
                                     C.CountryName as Nationality ,
                                    

                                    P.Phone,
                                    P.Email,
                                  
                                    P.ImagePath

                                FROM People P
                                INNER JOIN Countries C
                                    ON P.NationalityCountryID = C.CountryID

order by  P.FirstName"; 
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

        public static bool DeactivatePerson(int PersonID)
        {
            int rowAffected = 0;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            UPDATE People 
            SET IsActive = 0,
                DeletedAt = GETDATE(),
                LastModifiedAt = GETDATE()
            WHERE PersonID = @PersonID 
              AND IsActive = 1";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        con.Open();
                        rowAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        // لاحقًا Logging
                    }
                }
            }

            return (rowAffected > 0);
        }

        public static bool IsNationalNumberExists(string NationalNumber)
        {
            bool isFound = false;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT TOP 1 1 FROM People WHERE NationalNo = @NationalNumber";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NationalNumber", NationalNumber);

                    try
                    {
                        con.Open();

                        object result = cmd.ExecuteScalar();

                        isFound = (result != null);
                    }
                    catch
                    {
                        isFound = false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return isFound;
        }

        public static bool IsNationalNumberExists(string NationalNumber, int PersonID)
        {
            bool isFound = false;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT TOP 1 1 
                         FROM People 
                         WHERE NationalNo = @NationalNumber 
                         AND PersonID <> @PersonID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NationalNumber", NationalNumber);
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
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

        
    }
}
