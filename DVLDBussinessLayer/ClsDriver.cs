using ClassLibrary1;
using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLDBussinessLayer.clsApplication;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDBussinessLayer
{
    public class ClsDriver
    {


        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }



        public ClsDriver()
        {

            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;

            this.Mode = enMode.AddNew;

        }

        private ClsDriver(int DriverID, int PersonID, int CreateByUserID, DateTime CreateDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreateByUserID;
            this.CreatedDate = CreateDate;

            this.Mode = enMode.Update;
        }


        private bool _AddNewDriver()
        {
            //call DataAccess Layer 

            this.DriverID = clsDriversData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);

            return (this.DriverID != -1);
        }


        public static ClsDriver FindDriverByID(int DriverID)
        {

            int personId = -1, CreatebyUserId = -1;

            DateTime createDate = DateTime.Now;


            bool Found = clsDriversData.GetDriverByID(DriverID, ref personId, ref CreatebyUserId, ref createDate);

            if (!Found)
            {
                return null;
            }

            return new ClsDriver(DriverID, personId, CreatebyUserId, createDate);
        }


        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

               

            }




            return false;
        }

        public static ClsDriver FindByPersonID(int PersonID)
        {
            int driverid = -1, CreatebyUserId = -1;

            DateTime createDate = DateTime.Now;


            bool Found = clsDriversData.FindByPersonID(ref driverid, PersonID, ref CreatebyUserId, ref createDate);

            if (!Found)
            {
                return null;
            }

            return new ClsDriver(driverid, PersonID, CreatebyUserId, createDate);

        }

        public static DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDrivers();
        }
    }
    }


