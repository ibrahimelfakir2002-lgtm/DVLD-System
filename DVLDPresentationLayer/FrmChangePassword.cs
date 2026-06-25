using DVLDBusinessLayer;
using DVLDBussinessLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class FrmChangePassword : Form
    {
        private clsUser _User;

        // 🔥 EventArgs (لو تريد تمرير الحدث للأعلى بشكل احترافي)
        public class PersonUpdatedEventArgs : EventArgs
        {
            public int PersonID { get; set; }
            public bool Success { get; set; }
        }

        public event EventHandler<PersonUpdatedEventArgs> PersonUpdated;

        public FrmChangePassword(int UserID)
        {
            InitializeComponent();

            _User = clsUser.Find(UserID);

            if (_User != null)
            {
                ctrlPersonInfoCard1.SetPerson(_User.PersonID);
            }

            // 🔥 ربط الحدث بشكل صحيح
            ctrlPersonInfoCard1.PersonUpdated += CtrlPersonInfoCard1_PersonUpdated;
        }

        // =========================
        // EVENT HANDLER
        // =========================
        private void CtrlPersonInfoCard1_PersonUpdated(object sender, ctrlPersonInfoCard.PersonUpdatedEventArgs e)
        {
            if (e.Success)
            {
                _User = clsUser.Find(_User.UserID); // 🔥 مهم

                ctrlPersonInfoCard1.SetPerson(_User.PersonID);

                LoadLoginInfo(); // 🔥 مهم

                RaisePersonUpdated(e.PersonID, true);
            }
        
    }
      

        // =========================
        // RAISE EVENT UP
        // =========================
        private void RaisePersonUpdated(int personId, bool success)
        {
            PersonUpdated?.Invoke(this, new PersonUpdatedEventArgs
            {
                PersonID = personId,
                Success = success
            });
        }

        // =========================
        // LOAD LOGIN INFO
        // =========================
        private void LoadLoginInfo()
        {
            LbUserID.Text = _User.UserID.ToString();
            LbUserName.Text = _User.UserName;
            LbIsActive.Text = _User.IsActive ? "Yes" : "No";
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            LoadLoginInfo();
        }

        // =========================
        // VALIDATION - CURRENT PASSWORD
        // =========================
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;

            if (string.IsNullOrWhiteSpace(currentPassword))
            {
                errorProvider1.SetError(txtCurrentPassword, "Password is required.");
                e.Cancel = true;
            }
            else if (currentPassword.Length < 4)
            {
                errorProvider1.SetError(txtNewPassword, "Password must be at least 4 characters.");
                e.Cancel = true;
            }
            else if (!clsUser.IsPasswordCorrect(_User.UserID, currentPassword))
            {
                errorProvider1.SetError(txtCurrentPassword, "Current password is incorrect.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, "");
            }
        }

        // =========================
        // VALIDATION - NEW PASSWORD
        // =========================
        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            string newPassword = txtNewPassword.Text;

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                errorProvider1.SetError(txtNewPassword, "New Password is required.");
                e.Cancel = true;
            }
            else if (newPassword.Length < 4)
            {
                errorProvider1.SetError(txtNewPassword, "Password must be at least 4 characters.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, "");
            }
        }

        // =========================
        // VALIDATION - CONFIRM PASSWORD
        // =========================
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password is required.");
                e.Cancel = true;
            }
            else if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        // =========================
        // SAVE BUTTON
        // =========================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            // Optional safety check
            if (!clsUser.IsPasswordCorrect(_User.UserID, txtCurrentPassword.Text))
            {
                MessageBox.Show("Current password is incorrect");
                return;
            }

            _User.Password = txtNewPassword.Text.Trim();

            if (_User.Save())
            {
                MessageBox.Show("Password changed successfully");

                RaisePersonUpdated(_User.PersonID, true);

                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to change password");
            }
        }

        private void BntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonInfoCard1_Load(object sender, EventArgs e)
        {

        }
    }
}