using DVLDBussinessLayer;
using System;
using System.Windows.Forms;
using static DVLDPresentationLayer.FrmScheduleTest;

using SharedDvldClasses.Enums;
namespace DVLDPresentationLayer
{
    public partial class ctrlVisionTest : UserControl
    {
        private int _localAppID;
        private int _testTypeID;

        private decimal _RetakeFees;
        private clsAppointment _appointment;

        public ctrlVisionTest()
        {
            InitializeComponent();
            LbMessage.Visible = false;
        }

        // 🔒 Lock Behavior
        public bool IsLocked
        {
            set
            {
                datetimeAppointmentDate.Enabled = !value;
            }
        }


        private void SetFormTitle()
        {
            switch ((enTestType)_testTypeID)
            {
                case enTestType.Vision:
                    gBoxVisionTest .Text = "Vision Test ";
                    break;

                case enTestType.Written:
                    gBoxVisionTest.Text = "Writting Test ";
                    break;

                case enTestType.Street:
                    gBoxVisionTest.Text = "Street Test ";
                    break;
            }
        }
        // 🔹 Normal Mode
        public void SetNormalMode()
        {
            LbTitle.Text = "Schedule Test";

            LbMessage.Visible = false;

            //LbRetakeFees.Text = "0";

            //LbTotalFees.Text = LbFees.Text;
        }

        // 🔹 Retake Mode
        public void SetRetakeMode(decimal retakeFees)
        {
            LbTitle.Text = "Schedule Retake Test";

            LbMessage.Visible = false;

            decimal.TryParse(LbFees.Text, out decimal testFees);

            //LbRetakeFees.Text = retakeFees.ToString();

            //LbTotalFees.Text =
            //    (testFees + retakeFees).ToString();
        }

        public void SetMode(enMode mode)
        {
            decimal.TryParse(LbFees.Text, out decimal testFees);
            decimal retakeFees = _RetakeFees;

            if (mode == enMode.Retake)
            {
                LbTitle.Text = "Schedule Retake Test";
                LbMessage.Visible = false;

                // optional fees logic
                // LbRetakeFees.Text = retakeFees.ToString();
                // LbTotalFees.Text = (testFees + retakeFees).ToString();
            }
            else if (mode == enMode.Update)
            {
                LbTitle.Text = "Update Test Appointment";
                LbMessage.Visible = true;   // 🔥 هنا تظهر الرسالة

                // update-specific UI logic
            }
        }

        // 🔹 Load
        public void LoadVisionTest(int localAppID, int testTypeID, int appointmentID = -1)
        {
            _localAppID = localAppID;
            _testTypeID = testTypeID;

            SetFormTitle();

            _appointment = null;

            if (appointmentID != -1)
            {
                _appointment = clsAppointment.Find(appointmentID);
            }

            DateTime? date = _appointment?.AppointmentDate;

            LoadForDisplay(localAppID, date);
        }

        private void LoadForDisplay(int localAppID, DateTime? appointmentDate)
        {
            var localApp = clsLocalDrivingLicenseApplication.Find(localAppID);
            if (localApp == null) return;

            LbDLocalAppID.Text = localApp.LocalDrivingLicenseApplicationID.ToString();
            LbClass.Text = localApp.LicenseClassInfo.ClassName;
            LbTrial.Text = localApp.TestCount.ToString();

            int appID = clsLocalDrivingLicenseApplication.GetApplicationIDByLocalAppID(localAppID);
            var app = clsApplication.FindByApplicationID(appID);

            if (app != null)
            {
                var person = clsPerson.GetPersonByID(app.ApplicantPersonID);

                LbName.Text = person != null
                    ? $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}"
                    : "Unknown";
            }

            var testType = clsTestTypes.FindTestTypeByID(_testTypeID);

            if (testType != null)
                LbFees.Text = testType.TestTypeFees.ToString();

            if (appointmentDate.HasValue)
                datetimeAppointmentDate.Value = appointmentDate.Value;
        }

        // 🔹 Build Object
        public clsAppointment GetAppointment()
        {
            decimal.TryParse(LbFees.Text, out decimal totalFees);

            if (_appointment == null)
            {
                _appointment = new clsAppointment
                {
                    LocalDrivingLicenseApplicationID = _localAppID,
                    TestTypeID = _testTypeID
                };
            }

            _appointment.AppointmentDate = datetimeAppointmentDate.Value;
            _appointment.PaidFees = totalFees;
            _appointment.IsLocked = false;

            return _appointment;
        }


        public decimal TestFees
        {
            get
            {
                decimal.TryParse(LbFees.Text, out decimal result);
                return result;
            }
        }
    }
}