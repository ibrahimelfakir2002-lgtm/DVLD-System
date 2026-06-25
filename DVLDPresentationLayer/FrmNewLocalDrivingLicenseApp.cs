using DVLDBussinessLayer;
using DVLDDataAccessLayer;
using SharedDvldClasses.Enums;
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

    // select top 1 1 from Applications where (
    //select count(*) from Applications where(ApplicantPersonID = 1 and ApplicationTypeID = 1 and
    // ApplicationStatus = 1) )  > 1

    public partial class FrmNewLocalDrivingLicenseApp : Form
    {
        public event Action<bool> OnLocalAppSaved;
        public FrmNewLocalDrivingLicenseApp()
        {
            InitializeComponent();
        }

        private void _FillLicenseClassesInComboBox()
        {
            cboxLicenseClasses.Items.Clear();
            DataTable dt = clsLicenseClass.GetAllLicenseCasses();

            if (dt == null || dt.Rows.Count == 0)
                return;

            ComboBoxItem<int> defaultItem = null;

            foreach (DataRow row in dt.Rows)
            {
                int classID = Convert.ToInt32(row["LicenseClassID"]);
                string className = row["ClassName"].ToString();

                var item = new ComboBoxItem<int>(classID, className); // ✅ الصحيح
                cboxLicenseClasses.Items.Add(item);

                if (className == "Class 1 - Small Motorcycle")
                    defaultItem = item;
            }

            cboxLicenseClasses.SelectedItem = defaultItem ?? cboxLicenseClasses.Items[0];
        }
        private void FrmNewLocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            LoadPersonData();
        }

        public void LoadPersonData()
        {
            _FillLicenseClassesInComboBox();


            DateTime now = DateTime.Now;

            LbDLDate.Text = now.ToString();
            LbUserCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabNewLocalDrivingLicApp.SelectedTab = tabApplicationInfo;
        }

        public class ComboBoxItem<T>
        {
            public T Value { get; set; }
            public string Text { get; set; }

            public ComboBoxItem(T value, string text)
            {
                Value = value;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

                clsLocalDrivingLicenseApplication localApp =
                    new clsLocalDrivingLicenseApplication();

                localApp.ApplicantPersonID = ctrlPersonSelector2.SelectedPersonID;

                var selectedItem = (ComboBoxItem<int>)cboxLicenseClasses.SelectedItem;
                localApp.LicenseClassID = selectedItem.Value;

                localApp.PaidFees = Convert.ToDecimal(LbDLApplicationFees.Text);

                localApp.CreatedByUserID = clsGlobalSettings.CurrentUserID;



            var result = localApp.Save(enApplicationType.NewLocalDrivingLicense);

            switch (result)
            {
                case enSaveResult.Success:
                    OnLocalAppSaved?.Invoke(true);
                    MessageBox.Show("Saved successfully.");
                    break;

                case enSaveResult.HasLicense:
                    MessageBox.Show("This person already has a license.");
                    break;

                case enSaveResult.HasActiveApplication:
                    MessageBox.Show("This person already has an active application.");
                    break;

                case enSaveResult.InvalidData:
                    MessageBox.Show("Invalid data.");
                    break;

                default:
                    MessageBox.Show("Something went wrong.");
                    break;
            }

        }

        private void BntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonSelector2_Load(object sender, EventArgs e)
        {

        }
    }

   
}
