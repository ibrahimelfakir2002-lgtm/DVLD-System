using ClassLibrary1;
using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using SharedDvldClasses;
using SharedDvldClasses.Enums;
namespace DVLDBussinessLayer
{
    public class clsTest
    {

        public enum EnMode { AddNew = 1, Update =2};

        public EnMode Mode = EnMode.AddNew;

       
        public int TestID {  get; set; }

        public int TestAppointmentID { get; set; }

        public int TestResult {  get; set; }

        public string Notes  { get; set; }

        public int CreatedByUserID { get; set; }


        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = -1;
            this.Notes = "";
            this.CreatedByUserID = -1;

            this.Mode = EnMode.AddNew;
        }

        public clsTest( int testID, int testAppointmentID, int testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;

            Mode = EnMode.Update;
        }


        public bool Save()
        {
            if (Mode == EnMode.AddNew)
            {
                int newID = clsTestData.AddNewTest(TestAppointmentID,TestResult,Notes,CreatedByUserID);

                if (newID != -1)
                {
                    TestID = newID;
                    Mode = EnMode.Update;
                    return true;
                }

                return false;
            }
            else 
                {  return false; }

           
        }

        public static bool IsTestExistsByAppointmentID(int TestAppointmentID)
        {
            return clsTestData.IsTestExistsByAppointmentID(TestAppointmentID);
        }

        public static enTestResult GetLastTestResult(int localApplicationID, enTestType testType)
        {
            return (enTestResult)clsTestData.GetLastTestResult(localApplicationID, (int)testType);
        }

        public static int GetPassedTestsCountByLocalAppID(int LocaApp)
        {
            return clsTestData.GetPassedTestsCountByLocalAppID(LocaApp);
        }

        public static bool HasAnyTestResults(int localAppID)
        {
            return clsTestData.HasAnyTestResults(localAppID);
        }


    }
}
