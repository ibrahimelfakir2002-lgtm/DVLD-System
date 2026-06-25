using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsCountry
    {

        public enum enMode{ Addnew = 0, Update =1};

        public enMode Mode = enMode.Addnew;

        public int CountryID {  get; set; } 
        public string CountryName { get; set; }

        public clsCountry()
        {
            this.CountryID = -1;
            this.CountryName = "";

            this.Mode = enMode.Addnew;
        }

        private clsCountry(int CountryID, string CountryName)
        {
            this.CountryID=CountryID;   
            this.CountryName = CountryName;

            this.Mode= enMode.Update;
        }

        public static clsCountry GetCountryByCountryID(int CountryID)
        {
            string CountryName = "";

            if (clsCountriesData.GetCountryByID(CountryID, ref  CountryName))
            {

                return new clsCountry(CountryID, CountryName);
            }
            else
            {
                return null;
            }
        }

        public static clsCountry GetCountryByCountryName(string CountryName)
        {
            int CountryID = -1; 

            if(clsCountriesData.GetCountryByCountryName(ref CountryID,CountryName))
            {
                return new clsCountry(CountryID,CountryName);
            }
            else
            {
                return null;
            }


        } 

        public static DataTable GetAllCountries()
        {
            return clsCountriesData.GetAllCountries();

        }
    }
}
