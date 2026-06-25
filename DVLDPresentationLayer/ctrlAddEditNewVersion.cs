using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLDBussinessLayer; // مكان clsPerson و clsCountry

namespace DVLDPresentationLayer
{
    public partial class ctrlAddEditNewVersion : UserControl
    {
        private clsPerson _Person;
        private bool _IsImageManuallySet = false;

        private string _oldImagePathToDelete = null;
        private bool _isImageRemoved = false;

        // خاصية لتحديد الشخص عند التعديل
        public int PersonID { get; set; } = -1; // -1 يعني إضافة جديد

        // حدث خارجي بعد الحفظ
        public event Action<int> OnSaveCompleted;
        public event Action<bool> OnError;

        public event Action OnCloseRequested;
        private ErrorProvider _errorProvider = new ErrorProvider();
        public ctrlAddEditNewVersion()
        {
            InitializeComponent();


            LinkLbRemoveImage.Visible = false;

            // ربط الأحداث
            rdbtnMale.CheckedChanged += rdbtnGender_CheckedChanged;
            rdbtnFemale.CheckedChanged += rdbtnGender_CheckedChanged;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            this.Load += ctrlAddEditNewVersion_Load;

            txtFirstName.Validating += TxtFirstName_Validating;
            txtSecondName.Validating += TxtSecondName_Validating;
            txtLastName.Validating += TxtLastName_Validating;
            txtNationalNumber.Validating += TxtNationalNumber_Validating;
            PersonBirthDate.Validating += PersonBirthDate_Validating;

            txtPhone.Validating += TxtPhone_Validating;
            txtEmail.Validating += TxtEmail_Validating;

        }

        private string SaveImageToProjectFolder(string sourceImagePath)
        {
            if (string.IsNullOrEmpty(sourceImagePath))
                return "";

            string folderPath = @"C:\DVLD-People-Images\";

            // إنشاء الفولدر إذا لم يوجد
            if (!System.IO.Directory.Exists(folderPath))
                System.IO.Directory.CreateDirectory(folderPath);

            // الحصول على الامتداد
            string extension = System.IO.Path.GetExtension(sourceImagePath);

            // إنشاء اسم GUID
            string newFileName = Guid.NewGuid().ToString() + extension;

            string destinationPath = System.IO.Path.Combine(folderPath, newFileName);

            // نسخ الصورة
            System.IO.File.Copy(sourceImagePath, destinationPath, true);

            return destinationPath;
        }
        private void TxtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                _errorProvider.SetError(txtFirstName, "First Name is required.");
                e.Cancel = true; // يمنع الانتقال إلى الحقل التالي
            }
            else
            {
                _errorProvider.SetError(txtFirstName, "");
            }
        }

      

        private void TxtSecondName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSecondName.Text)) // صححت هنا
            {
                _errorProvider.SetError(txtSecondName, "Second Name is required.");
                e.Cancel = true;
            }
            else
            {
                _errorProvider.SetError(txtSecondName, "");
            }
        }

        private void TxtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text)) // صححت هنا
            {
                _errorProvider.SetError(txtLastName, "Last Name is required.");
                e.Cancel = true;
            }
            else
            {
                _errorProvider.SetError(txtLastName, "");
            }
        }


        private void TxtNationalNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string nationalNo = txtNationalNumber.Text.Trim();
            int personID = _Person?.PersonID ?? -1;

            if (string.IsNullOrWhiteSpace(nationalNo))
            {
                _errorProvider.SetError(txtNationalNumber, "National Number is required.");
                e.Cancel = true;
            }
            else if (clsPerson.IsNationalNumberExists(nationalNo, personID))
            {
                _errorProvider.SetError(txtNationalNumber, "National Number already exists.");
                e.Cancel = true;
            }
            else
            {
                _errorProvider.SetError(txtNationalNumber, "");
            }
        }
        private void PersonBirthDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
        private void TxtPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(phone))
            {
                _errorProvider.SetError(txtPhone, ""); // فارغ مقبول
            }
            else
            {
                // تحقق من كون الرقم فقط أرقام
                if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d+$"))
                {
                    _errorProvider.SetError(txtPhone, "Phone must contain only numbers.");
                    e.Cancel = true;
                }
                else
                {
                    _errorProvider.SetError(txtPhone, "");
                }
            }
        }
        private void TxtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                // فارغ مقبول
                _errorProvider.SetError(txtEmail, "");
            }
            else
            {
                // تحقق من النمط العام للبريد الإلكتروني
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    _errorProvider.SetError(txtEmail, "Invalid email format.");
                    e.Cancel = true;
                }
                else
                {
                    _errorProvider.SetError(txtEmail, "");
                }
            }
        }
        // --- تحميل البيانات عند إضافة أو تعديل ---
        private void ctrlAddEditNewVersion_Load(object sender, EventArgs e)
        {
            LoadPersonData(PersonID);
        }

        public void LoadPersonData(int personID)
        {
            _FillCountriesInComboBox();

            if (personID == -1) // إضافة جديد
            {
                _Person = new clsPerson();
                _Person.Mode = clsPerson.enMode.AddNew;

                LblMode.Text = "Add New Contact";
                ClearFields(); // الآن ClearFields يضبط الصورة الافتراضية
            }
            else // تعديل
            {
                _Person = clsPerson.GetPersonByID(personID);
                if (_Person == null)
                {
                    OnError?.Invoke(true);
                    return;
                }
                _Person.Mode = clsPerson.enMode.Update;
                LblMode.Text = $"Edit Contact ID = {_Person.PersonID}";
                FillPersonFields(); // عند التعديل يتم تحميل الصورة المخزنة أو الافتراضية
            }
        }

        // --- مسح الحقول ---
        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNumber.Text = "";
            PersonBirthDate.Value = DateTime.Today;

            rdbtnMale.Checked = true;
            rdbtnFemale.Checked = false;

            txtAddress.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";

            _IsImageManuallySet = false;
            UpdateGenderIcon(); // الصورة الافتراضية حسب الجنس

           // _FillCountriesInComboBox(); // ملء ComboBox وتعيين الدولة الافتراضية
        }

        // --- تعبئة الحقول عند التعديل ---
        private void FillPersonFields()
        {


            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName ?? "";
            txtLastName.Text = _Person.LastName;
            txtNationalNumber.Text = _Person.NationalNo;
            PersonBirthDate.Value = _Person.DateOfBirth;

            rdbtnMale.Checked = _Person.Gendor == 0;
            rdbtnFemale.Checked = _Person.Gendor == 1;

            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email ?? "";

            

            // تحديد الدولة
            foreach (ComboBoxItem<int> item in CboxCountries.Items)
            {
                if (item.Value == _Person.NationalityCountryID)
                {
                    CboxCountries.SelectedItem = item;
                    break;
                }
            }

            // تحميل الصورة
            if (!string.IsNullOrWhiteSpace(_Person.ImagePath) &&
                System.IO.File.Exists(_Person.ImagePath))
            {
                picBoxImage.ImageLocation = null; // 🔥 مهم
                using (var img = Image.FromFile(_Person.ImagePath))
                {
                    picBoxImage.Image = new Bitmap(img);
                }
                _IsImageManuallySet = true;
            }
            else
            {
                _IsImageManuallySet = false;
                picBoxImage.ImageLocation = null; // 🔥 مهم جدًا
                picBoxImage.Image = null;
                UpdateGenderIcon();
            }
        }

        // --- تحديث أيقونة الجنس ---
        private void UpdateGenderIcon()
        {


            if (_IsImageManuallySet) return;

            picBoxImage.ImageLocation = null; // 🔥 مهم

            picBoxImage.Image = rdbtnMale.Checked
                ? Properties.Resources.icons8_add_user_male_16_1_
                : Properties.Resources.icons8_female_user_30;
        }
        // --- رفع صورة عبر PictureBox ---


        // --- رفع صورة عبر LinkLabel ---
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChooseImage();

            LinkLbRemoveImage.Visible = true;

        }

        // --- تغيير الجنس ---
        private void rdbtnGender_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGenderIcon();
        }

        // --- زر الحفظ ---
        

        // --- تعبئة الدول ---
        private void _FillCountriesInComboBox()
        {
            CboxCountries.Items.Clear();
            DataTable countries = clsCountry.GetAllCountries();

            if (countries != null && countries.Rows.Count > 0)
            {
                foreach (DataRow row in countries.Rows)
                {
                    string countryName = row["CountryName"].ToString();
                    int countryID = Convert.ToInt32(row["CountryID"]);
                    CboxCountries.Items.Add(new ComboBoxItem<int>(countryName, countryID));
                }

                // --- تعيين الدولة الافتراضية ---
                ComboBoxItem<int> defaultCountry = null;

                foreach (ComboBoxItem<int> item in CboxCountries.Items)
                {
                    if (item.Text == "Morocco") // ضع اسم الدولة الافتراضية
                    {
                        defaultCountry = item;
                        break;
                    }
                }

                if (defaultCountry != null)
                    CboxCountries.SelectedItem = defaultCountry;
                else
                    CboxCountries.SelectedIndex = 0; // إذا لم نجد الدولة الافتراضية، اختر أول عنصر
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNumber.Text.Trim();
            _Person.DateOfBirth = PersonBirthDate.Value;
            _Person.Gendor = rdbtnMale.Checked ? 0 : 1;
            _Person.Address = txtAddress.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();

            if (CboxCountries.SelectedItem != null)
                _Person.NationalityCountryID = ((ComboBoxItem<int>)CboxCountries.SelectedItem).Value;

            string folderPath = @"C:\DVLD-People-Images\";

            // ================================
            // 1️⃣ حالة الحذف (Remove Image)
            // ================================
            if (_isImageRemoved)
            {
                // نحذف الصورة القديمة عند الحفظ
                if (!string.IsNullOrEmpty(_oldImagePathToDelete) &&
                    _oldImagePathToDelete.StartsWith(folderPath) &&
                    System.IO.File.Exists(_oldImagePathToDelete))
                {
                    try
                    {
                        System.IO.File.Delete(_oldImagePathToDelete);
                    }
                    catch { }
                }

                _Person.ImagePath = null;
            }

            // ================================
            // 2️⃣ حالة تغيير صورة جديدة
            // ================================
            else if (_IsImageManuallySet &&
                !string.IsNullOrEmpty(picBoxImage.ImageLocation) &&
                _Person.ImagePath != picBoxImage.ImageLocation)
            {
                // حذف القديمة
                if (!string.IsNullOrEmpty(_Person.ImagePath) &&
                    _Person.ImagePath.StartsWith(folderPath) &&
                    System.IO.File.Exists(_Person.ImagePath))
                {
                    try
                    {
                        System.IO.File.Delete(_Person.ImagePath);
                    }
                    catch { }
                }

                // حفظ الجديدة
                _Person.ImagePath = SaveImageToProjectFolder(picBoxImage.ImageLocation);
            }

            // ================================
            // Save Person
            // ================================
            if (_Person.Save())
            {
                _Person.Mode = clsPerson.enMode.Update;
                LblMode.Text = $"Edit Contact ID = {_Person.PersonID}";
                LbPersonID.Text = _Person.PersonID.ToString();

                // reset flags بعد الحفظ
                _isImageRemoved = false;
                _oldImagePathToDelete = null;

                MessageBox.Show("Saved successfully! You can continue editing.",
                   "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                PersonID = _Person.PersonID;

                OnSaveCompleted?.Invoke(PersonID);




            }
            else

            {
                OnSaveCompleted?.Invoke(-1);
                MessageBox.Show("Error saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OnError?.Invoke(true);
               
            }
        }


        private void BntClose_Click(object sender, EventArgs e)
        {
            OnCloseRequested?.Invoke(); // يرسل إشارة للـ Form الذي يحتويه
        }
        private void ChooseImage()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picBoxImage.ImageLocation = ofd.FileName;
                    _IsImageManuallySet = true;
                }
            }
        }
        private void LinkLbRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // نحفظ الصورة القديمة فقط
            _oldImagePathToDelete = _Person.ImagePath;

            // نعلم أنها محذوفة
            _isImageRemoved = true;

            // تنظيف UI فقط
            _Person.ImagePath = null;
            picBoxImage.ImageLocation = null;
            _IsImageManuallySet = false;



            UpdateGenderIcon();

            LinkLbRemoveImage.Visible = false;
        }

        private void picBoxImage_Click_1(object sender, EventArgs e)
        {
            ChooseImage();

           

        }

        private void PersonBirthDate_Validating_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int age = DateTime.Today.Year - PersonBirthDate.Value.Year;
            if (PersonBirthDate.Value > DateTime.Today.AddYears(-age)) age--;
            if (age < 18)
            {
                _errorProvider.SetError(PersonBirthDate, "Age must be 18 or older.");
                e.Cancel = true;
            }
            else
            {
                _errorProvider.SetError(PersonBirthDate, "");
            }
        }
        // يحرر الموارد

    }

    // --- صنف مساعد لعرض النص والقيمة في ComboBox ---
    public class ComboBoxItem<T>
    {
        public string Text { get; set; }
        public T Value { get; set; }

        public ComboBoxItem(string text, T value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString() => Text;
    }
}