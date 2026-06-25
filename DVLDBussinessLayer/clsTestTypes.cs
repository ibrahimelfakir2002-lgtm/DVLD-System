using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsTestTypes
    {

        public int TestTypeID {  get; set; }
        public string TestTypeTitle {  get; set; }
        public string TestTypeDescription { get; set;}

        public decimal TestTypeFees {  get; set; }

        private clsTestTypes(int TestTypeID, string TestTypeTitle, string TestTypeDescription , Decimal TestTypeFees)
        {

            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }


        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }

        public static clsTestTypes FindTestTypeByID(int TestTypeID)
        {
            string Title = "", Description = "";
            Decimal Fees = 0;

            bool isFound = clsTestTypesData.FindTestTypeByID(TestTypeID, ref Title, ref Description, ref Fees);

            if (!isFound)
                return null;

            return new clsTestTypes(TestTypeID, Title, Description, Fees);
        }

        public static bool UpdateTestTypesInfo(int ID, string Title,string Description, decimal Fees)
        {

            return clsTestTypesData.UpdateTestTypes(ID, Title, Description, Fees);
        }

        public bool Save()
        {
            return clsTestTypesData.UpdateTestTypes(
                this.TestTypeID,
                this.TestTypeTitle,
                this.TestTypeDescription,
                this.TestTypeFees
            );
        }


    }
}
