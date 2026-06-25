using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsLicenseClass
    {
        public int LicenseClassID { get; private set; }

        public string ClassName {  get;  set; }
        public string ClassDescription { get; set; }

        public int MinimumAllowedAge {  get; set; }

        public int DefaultValidityLength { get; set; }

       public  decimal ClassFees {  get; set; }


        private clsLicenseClass(int licenseClassID, string className, string classDescription, int minimumAllowedAge, int defaultValidityLength, decimal classFees)
        {
            LicenseClassID = licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }

        public static DataTable GetAllLicenseCasses()
        {
            return clsLicenceClassesSData.GetAllLicenseClasses();
        }

        public static clsLicenseClass Find(int licenseClassID)
        {
            string className = "", description = "";
            int minAge = 0, validity = 0;
            decimal fees = 0;

            if (clsLicenceClassesSData.GetLicenseClassByID(
                licenseClassID, ref className, ref description,
                ref minAge, ref validity, ref fees))
            {
                return new clsLicenseClass(
                    licenseClassID, className, description,
                    minAge, validity, fees
                );
            }

            return null;
        }
    }
}
