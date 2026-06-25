using DVLDBusinessLayer;
using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class ctrlDrivingLicenseAppAndAppInfo : UserControl
    {
      public int LocalAppID { get; set; }

        

       private clsLocalDrivingLicenseApplication _LocalApp;

        private clsApplication _Application;

        public ctrlDrivingLicenseAppAndAppInfo()
        {
            InitializeComponent();


        }

        private void gboxAppBasicInfo_Enter(object sender, EventArgs e)
        {
           
        }

        public void LoadData(int localAppID)
        {
            _LocalApp = clsLocalDrivingLicenseApplication.Find(localAppID);

            if (_LocalApp == null)
                return;

            LbDLocalAppID.Text = _LocalApp.LocalDrivingLicenseApplicationID.ToString();
            LbLicenseClass.Text = _LocalApp.LicenseClassInfo.ClassName;

            // تأكد أن هذه موجودة عندك
            LbPassedTest.Text = _LocalApp.TestCount.ToString();

            int appID = clsLocalDrivingLicenseApplication.GetApplicationIDByLocalAppID(localAppID);

            _Application = clsApplication.FindByApplicationID(appID);

            if (_Application != null)
            {
                LbAppID.Text = _Application.ApplicationID.ToString();

                LbType.Text = _Application.ApplicationTypeTitle;
            }

            clsPerson person = clsPerson.GetPersonByID(_Application.ApplicantPersonID);

            if (person != null)
            {
                LbApplicationPerson.Text =
                    person.FirstName + " " +
                    person.SecondName + " " +
                    person.ThirdName + " " +
                    person.LastName;
            }
            else
            {
                LbApplicationPerson.Text = "Unknown Person";
            }


            LbCreateBy.Text = _LocalApp.CreatedByUserID.ToString();
            LbAppDate.Text = _Application.ApplicationDate.ToString();   

            LbStatusDate.Text = _Application.LastStatusDate.ToString(); 

            LbStatus.Text = _Application.ApplicationStatus.ToString();

            clsUser _User = clsUser.Find(_Application.CreatedByUserID);
          

            LbCreateBy.Text = _User.UserName.ToString();    


        }

        private void ctrlDrivingLicenseAppAndAppInfo_Load(object sender, EventArgs e)
        {

          
        }

        private void ctrlDrivingLicenseAppAndAppInfo_Load_1(object sender, EventArgs e)
        {
           // clsLicenseClass License = clsLicenseClass.Find(_LocalApp.LicenseClassID);
        }

        private void LbShowLicenseInfo_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLbviewPersonDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            FrmPersonDetails frm = new  FrmPersonDetails(_Application.ApplicantPersonID);
            frm.Show();
        }

    }
}
