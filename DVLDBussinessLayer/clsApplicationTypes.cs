using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DVLDDataAccessLayer;
namespace DVLDBussinessLayer
{
    public class clsApplicationTypes
    {

        public int ApplicationTypeID { get; }

        public string ApplicationTypeTitle { get; set; }

        public Decimal ApplicationTypeFees { get; set; }


        private clsApplicationTypes(int AppTypeID, string Title, decimal Fees)
        {
            this.ApplicationTypeID = AppTypeID;
            this.ApplicationTypeTitle = Title;
            this.ApplicationTypeFees = Fees;
        }

        public static clsApplicationTypes FindByID(int id)
        {
            string title = "";
            decimal fees = 0;

            bool isFound = clsApplicationTypesData.FindApplicationTypeByID(id, ref title, ref fees);

            if (!isFound)
                return null;

           return new clsApplicationTypes(id, title, fees);

           


        }
        public static DataTable GetAllApplicationsTypes()
        {
            return clsApplicationTypesData.GetApplicationsTypes();
        }

        public static bool UpdateAppTypesInfo(int ID , string Title, decimal Fees)
        {

            return clsApplicationTypesData.UpdateApplicationsTypes(ID, Title, Fees);
        }

        public bool Save()
        {
            return clsApplicationTypesData.UpdateApplicationsTypes(
                this.ApplicationTypeID,
                this.ApplicationTypeTitle,
                this.ApplicationTypeFees
            );
        }
    }
}
