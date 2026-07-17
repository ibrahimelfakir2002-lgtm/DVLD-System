using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DVLDBusinessLayer;
using DVLDDataAccessLayer;
namespace DVLDBussinessLayer
{
    public class clsPerson
    {

        public enum enMode { AddNew= 0,Update = 1};

        public enMode Mode = enMode.AddNew;
        
        public int PersonID {  get; private set; }
        public string NationalNo {  get; set; }

        public string FirstName { get; set; }
        public string SecondName {  get; set; }
        public string ThirdName {  get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Gendor {  get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }       
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }

        public string ImagePath {  get; set; }
        
        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth    = DateTime.Now;
            this.Gendor = -1;
            this.Address = "";
            this.Phone =  "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            this.Mode = enMode.AddNew;
        }

        private clsPerson(int personID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
            DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = personID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            this.Mode = enMode.Update;
        }

        public static clsPerson GetPersonByID(int personID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "",
                ImagePath = "";
            int Gendor = -1, NationalityCountryID = -1 ;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPeopleData.GetPersonByID(personID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                
                return new clsPerson(personID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {

                return null;
            }

            }

       
        public static clsPerson FindPersonByNationalNo(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            int PersonID = -1, Gendor = -1, NationalityCountryID = -1;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPeopleData.GetPersonByNationalNo(ref PersonID, NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address,
               ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {

                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor,
                  Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }

        }
        public static clsPerson GetPersonByFirstName(string FirstName)
        {
            string NationalNo = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "",
               ImagePath = "";
            int Gendor = -1, NationalityCountryID = -1, PersonId = -1;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPeopleData.GetPersonByFirstName(ref PersonId, ref NationalNo, FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonId, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static clsPerson GetPersonBySecondName(string SecondName)
        {
            string NationalNo = "", FirstName = "",  ThirdName = "", Address = "", LastName = "", Phone = "", Email = "",
               ImagePath = "";
            int Gendor = -1, NationalityCountryID = -1, PersonId = -1;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPeopleData.GetPersonBySecondName(ref PersonId, ref NationalNo, ref FirstName,  SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonId, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static clsPerson GetPersonByThirdName(string ThirdName)
        {
            string NationalNo = "", FirstName = "", SecondName = "", Address = "", LastName = "", Phone = "", Email = "",
               ImagePath = "";
            int Gendor = -1, NationalityCountryID = -1, PersonId = -1;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPeopleData.GetPrsonByThirdName(ref PersonId, ref NationalNo, ref FirstName, ref SecondName,  ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonId, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static clsPerson GetPersonByLastName(string  LastName)
        {
            string NationalNo = "", FirstName = "",SecondName = "", ThirdName = "",  Address = "", Phone = "", Email = "",
               ImagePath = "";
            int Gendor = -1, NationalityCountryID = -1, PersonId = -1;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPeopleData.GetPersonByLastName(ref PersonId, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName,  LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonId, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static List<clsPerson> GetPeopleByNationality(string nationality)
        {
            List<clsPerson> people = new List<clsPerson>();

            DataTable dt = clsPeopleData.GetPeopleByNationality(nationality);

            foreach (DataRow row in dt.Rows)
            {
                people.Add(new clsPerson(
                    (int)row["PersonID"],
                    (string)row["NationalNo"],
                    (string)row["FirstName"],
                    (string)row["SecondName"],
                    row["ThirdName"] as string,
                    (string)row["LastName"],
                    (DateTime)row["DateOfBirth"],
                    Convert.ToInt32(row["Gendor"]),
                    (string)row["Address"],
                    (string)row["Phone"],
                    row["Email"] as string,
                    (int)row["NationalityCountryID"],
                    row["ImagePath"] as string
                ));
            }

            return people;
        }
        public static clsPerson GetPersonByGendor(int Gendor)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "",Phone = "", Email = "",
              ImagePath = "";
            int  NationalityCountryID = -1, PersonId = -1;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPeopleData.GetPersonByGendor( ref PersonId, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,  Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonId, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static clsPerson GetPersonByPhone(string Phone)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "",Email = "",
             ImagePath = "";
            int Gendor = -1,NationalityCountryID = -1, PersonId = -1;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPeopleData.GetPersonByPhone(ref PersonId, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address,  Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonId, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static clsPerson GetPersonByEmail(string Email)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "",Phone = "",
            ImagePath = "";
            int Gendor = -1, NationalityCountryID = -1, PersonId = -1;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPeopleData.GetPersonByEmail(ref PersonId, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address,ref Phone,  Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonId, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = clsPeopleData.AddnewPerson(this.NationalNo,this.FirstName,this.SecondName, this.ThirdName,this.LastName,this.DateOfBirth ,this.Gendor,this.Address,this.Phone,this.Email
                ,this.NationalityCountryID,this.ImagePath);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPeopleData.UpdatePersonInfo(this.PersonID,this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email
                , this.NationalityCountryID, this.ImagePath);

        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }




            return false;
        }
       

        public static List<string> GetDeleteBlockingReasons(int personID)
        {
            List<string> reasons = new List<string>();

            if (clsUser.IsPersonUser(personID))
                reasons.Add("This person has a user account.");

            if (ClsDriver.IsPersonDriver(personID))
                reasons.Add("This person has a driver profile.");

         

            return reasons;
        }
        public static bool DeletePersonByID(int PersonID)
        {
            return clsPeopleData.DeactivatePerson(PersonID);
        }
        public static bool IsNationalNumberExists(string NationalNumber)
        {
            return clsPeopleData.IsNationalNumberExists(NationalNumber);
        }

        public static bool IsNationalNumberExists(string NationalNumber, int PersonID)
        {
            return clsPeopleData.IsNationalNumberExists(NationalNumber, PersonID);
        }

        public static DataTable GetAllPersons()
        {
            return clsPeopleData.GetAllPersons();
        }
       
    }


    }

