using DVLDBussinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class ctrlPersonInfoCard : UserControl
    {
        private clsPerson _Person;
        private clsCountry _Country;

        private int _personID = -1;
        private bool _IsImageManuallySet = false;

        public event Action<int> OnPersonSelected;

        private bool _allowEdit = false;

        public bool AllowEdit
        {
            get { return _allowEdit; }
            set
            {
                _allowEdit = value;
                linkLbEditPerson.Visible = value;
            }
        }
        // 🔥 EventArgs version (Best Practice)
        public class PersonUpdatedEventArgs : EventArgs
        {
            public int PersonID { get; set; }
            public bool Success { get; set; }
        }

        public event EventHandler<PersonUpdatedEventArgs> PersonUpdated;

        public int PersonID => _personID;

        public void SetPerson(int personID)
        {
            if (_personID == personID)
                return;

            _personID = personID;

            LoadPerson(); // 👈 خلي LoadPerson تتكفل بالباقي
        }

        public ctrlPersonInfoCard()
        {
            InitializeComponent();
        }

        // =========================
        // LOAD PERSON
        // =========================
        public void LoadPerson()
        {
            if (_personID <= 0)
            {
                ClearUI();
                return;
            }

            _Person = clsPerson.GetPersonByID(_personID);

            if (_Person == null)
            {
                ClearUI();
                return;
            }

            _Country = clsCountry.GetCountryByCountryID(_Person.NationalityCountryID);

            BindDataToUI();

            OnPersonSelected?.Invoke(_Person.PersonID);
        }

        // =========================
        // BIND UI ONLY
        // =========================
        private void BindDataToUI()
        {
            LbPersonID.Text = _Person.PersonID.ToString();
            LbPersonName.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
            LbPersonNationalNo.Text = _Person.NationalNo;
            LbPersonGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            LbPersonEmail.Text = _Person.Email;
            LbPersonAddress.Text = _Person.Address;
            LbPesonDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            LbPersonPhone.Text = _Person.Phone;

            LbPersonCountry.Text = _Country?.CountryName ?? "N/A";

            LoadImage();
        }

        // =========================
        // IMAGE HANDLING
        // =========================
        private void LoadImage()
        {
            if (!string.IsNullOrWhiteSpace(_Person.ImagePath) &&
                System.IO.File.Exists(_Person.ImagePath))
            {
                using (var img = Image.FromFile(_Person.ImagePath))
                {
                    pboxPersonImage.Image = new Bitmap(img);
                }

                _IsImageManuallySet = true;
            }
            else
            {
                _IsImageManuallySet = false;
                UpdateGenderIcon();
            }
        }

        private void UpdateGenderIcon()
        {
            if (_IsImageManuallySet) return;

            pboxPersonImage.Image = _Person.Gendor == 0
                ? Properties.Resources.icons8_add_user_male_16_1_
                : Properties.Resources.icons8_female_user_30;
        }

        // =========================
        // CLEAR UI
        // =========================
       
        private void ClearUI()
        {
            LbPersonID.Text = "N/A";
            LbPersonName.Text = "No Person Found";
            LbPersonNationalNo.Text = "";
            LbPersonGendor.Text = "";
            LbPersonEmail.Text = "";
            LbPersonAddress.Text = "";
            LbPesonDateOfBirth.Text = "";
            LbPersonPhone.Text = "";
            LbPersonCountry.Text = "";

            pboxPersonImage.Image = null;
        }
        // =========================
        // REFRESH
        // =========================
        public void RefreshData()
        {
            if (_personID > 0)
                LoadPerson();
        }

        // =========================
        // EDIT PERSON
        // =========================
        private void linkLbEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo(PersonID);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                RefreshData();

                RaisePersonUpdated(true);
            }
        }

        // 🔥 Clean Event Raising
        private void RaisePersonUpdated(bool success)
        {
            PersonUpdated?.Invoke(this, new PersonUpdatedEventArgs
            {
                PersonID = this.PersonID,
                Success = success
            });
        }

        private void ctrlPersonInfoCard_Load(object sender, EventArgs e)
        {
        }
    }
}