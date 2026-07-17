using DVLDBusinessLayer;
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
    public partial class FrmAddUser : Form
    {
        private enMode _Mode;
        public int UserID { get; set; } = -1;

        private clsUser _User;
        private int _SelectedPersonID = -1;

        public event Action<int> OnSavedCompleted;
        public event Action<bool> OnError;

        private bool _IsDirty = false;
        public FrmAddUser(int userId)
        {
            InitializeComponent();


            UserID = userId;

        }

        private void FrmAddUser_Load(object sender, EventArgs e)
        {
            InitializeValidation();
            InitializeUI();

            // 🔥 أهم ربط
            ctrlPersonSelector1.OnPersonSelected += HandlePersonSelected;

            if (UserID == -1)
                SetupAddMode();
            else
                SetupEditMode();

            ApplyMode();
        }


     
            public enum enMode
            {
                Add,
                Edit
            }

           

            


        private void InitializeUI()
        {
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

            txtUserName.Validating += txtUserName_Validating;
            txtPassword.Validating += txtPassword_Validating;
            txtConfirmdPassword.Validating += txtConfirmPassword_Validating;

            txtUserName.TextChanged += MarkDirty;
            checkBoxIsActive.CheckedChanged += MarkDirty;
        }

            private void InitializeValidation()
            {
                btnSave.Enabled = false;
            }

            // =========================
            // MODES
            // =========================
            private void SetupAddMode()
            {
                _Mode = enMode.Add;

                _User = new clsUser();

                LbMode.Text = "Add New User";

                ctrlPersonSelector1.SetPerson(-1);

                _SelectedPersonID = -1;
            }

            private void SetupEditMode()
            {
                _Mode = enMode.Edit;
               
                _User = clsUser.Find(UserID);

                if (_User == null)
                {
                    OnError?.Invoke(true);
                    return;
                }

                LbMode.Text = $"Edit User ID = {_User.UserID}";

                ctrlPersonSelector1.SetPerson(_User.PersonID);
                 ctrlPersonSelector1.EnableFilter = false;

                txtUserName.Text = _User.UserName;
                checkBoxIsActive.Checked = _User.IsActive;

                LbUserID.Text = _User.UserID.ToString();

                txtPassword.Visible = false;
             LbTitlePassword.Visible = false;
            lbTitleConfirmdPassword.Visible = false;
            pboxPassword.Visible = false;
            pboxConfirmdPassword.Visible = false;
                txtConfirmdPassword.Visible = false;
            }

            private void ApplyMode()
            {
                bool isAdd = (_Mode == enMode.Add);

                txtPassword.Visible = isAdd;
                txtConfirmdPassword.Visible = isAdd;

              //  LbUserID.Visible = !isAdd;

                btnNext.Enabled = isAdd ? (_SelectedPersonID > 0) : true;
            }

            // =========================
            // PERSON SELECTED
            // =========================
            private void HandlePersonSelected(int personID)
            {
                _SelectedPersonID = personID;

                if (_Mode == enMode.Add)
                    btnNext.Enabled = (_SelectedPersonID > 0);
            }

            // =========================
            // NEXT
            // =========================
            private void btnNext_Click(object sender, EventArgs e)
            {
                
            }

            private void MarkDirty(object sender, EventArgs e)
            {
                _IsDirty = true;
                UpdateSaveState();
            }

            private void UpdateSaveState()
            {
                if (_Mode == enMode.Add)
                    btnSave.Enabled = (_SelectedPersonID > 0);
                else
                    btnSave.Enabled = _IsDirty;
            }

            // =========================
            // SAVE
            // =========================
            private void btnSave_Click(object sender, EventArgs e)
            {
               
            }

            // =========================
            // VALIDATION
            // =========================
            private void txtUserName_Validating(object sender, CancelEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    errorProvider1.SetError(txtUserName, "Required");
                    e.Cancel = true;
                }
                else
                    errorProvider1.SetError(txtUserName, "");
            }

            private void txtPassword_Validating(object sender, CancelEventArgs e)
            {
                if (_Mode == enMode.Edit) return;

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    errorProvider1.SetError(txtPassword, "Required");
                    e.Cancel = true;
                }
                else
                    errorProvider1.SetError(txtPassword, "");
            }

            private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
            {
                if (_Mode == enMode.Edit) return;

                if (txtPassword.Text != txtConfirmdPassword.Text)
                {
                    errorProvider1.SetError(txtConfirmdPassword, "Not matching");
                    e.Cancel = true;
                }
                else
                    errorProvider1.SetError(txtConfirmdPassword, "");
            }

            private void BntClose_Click(object sender, EventArgs e)
            {
               
            }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (_Mode == enMode.Add && _SelectedPersonID <= 0)
            {
                MessageBox.Show("Select a person first");
                return;
            }

            TabAddUser.SelectedTab = tabLoginInfo;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            _SelectedPersonID = ctrlPersonSelector1.SelectedPersonID;

            if (_SelectedPersonID <= 0)
            {
                MessageBox.Show("Select a person first");
                return;
            }

            if (!ValidateChildren())
            {
                MessageBox.Show("Fix validation errors");
                return;
            }

            if (_Mode == enMode.Add)
            {
                if (clsUser.IsPersonUser(_SelectedPersonID))
                {
                    MessageBox.Show("User already exists for this person");
                    return;
                }

                _User = new clsUser(_SelectedPersonID);
                _User.UserName = txtUserName.Text;
                _User.Password = txtPassword.Text;
                _User.IsActive = checkBoxIsActive.Checked;
            }
            else
            {
                _User = clsUser.Find(UserID);

                _User.UserName = txtUserName.Text;
                _User.IsActive = checkBoxIsActive.Checked;
            }

            _User.PersonID = _SelectedPersonID;

            if (_User.Save())
            {
                MessageBox.Show($"Saved Successfully ID = {_User.UserID}");

                OnSavedCompleted?.Invoke(_User.UserID);

              
            }
            else
            {
                MessageBox.Show("Error saving user");
            }
        }

        private void BntClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }


