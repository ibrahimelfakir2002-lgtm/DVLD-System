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
    public partial class ctrlLicenseInfo : UserControl
    {
        private int _LicenseID;

        private clsLicense _License;
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }

        private void LbClass_Click(object sender, EventArgs e)
        {

        }

        public void LoadData(int LicenseID)
        {

           


                var data = clsLicense.GetLicenseDetails(LicenseID);

                if (data == null)
                    return;

                LbName.Text = data.FullName;
                LbClass.Text = data.ClassName;
                LbIsActive.Text = data.IsActive;
            LbExperationDate.Text = data.ExpirationDate.ToString();
            LbIssueDate.Text = data.IssueDate.ToString();
            LbDateOfBirth.Text = data.DateOfBirth.ToString();
            LbLicenseID.Text = data.LicenseID.ToString();
            LbNationalNo.Text = data.NationalNo .ToString();

            LbGendor.Text = data.Gender.ToString();

            LbIssueReason.Text  = data.IssueReason.ToString();
           
                LbNotes.Text = data.Notes.ToString();

            LbDriverID.Text = data.DriverID.ToString(); 
            LbIsDetained.Text   = data.IsDetained;  
            



            }
        
    }
}
