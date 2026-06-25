using DVLDBusinessLayer;
using DVLDBussinessLayer;
using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLDPresentationLayer
{
    public partial class FrmManageUsers : Form
    {
        private DataTable _dtUsers;
        private string _lastFilter = "";

        private int _selectedUserId;
        public FrmManageUsers()
        {
            InitializeComponent();
        }
        public enum FilterInputType
        {
            TextBox,
            IsActiveCombo,
            None
        }
        public class FilterItem
        {
            public string Display { get; set; }
            public string Value { get; set; }
            public FilterInputType InputType { get; set; }
        }
        private void SetupUserFilters()
        {
            var filters = new List<FilterItem>()
    {
        new FilterItem { Display = "None", Value = "None", InputType = FilterInputType.None },

        new FilterItem { Display = "User ID", Value = "UserID", InputType = FilterInputType.TextBox },

        new FilterItem { Display = "Person ID", Value = "PersonID", InputType = FilterInputType.TextBox },

        new FilterItem { Display = "User Name", Value = "UserName", InputType = FilterInputType.TextBox },

        new FilterItem { Display = "Full Name", Value = "FullName", InputType = FilterInputType.TextBox },

        new FilterItem { Display = "Is Active", Value = "IsActive", InputType = FilterInputType.IsActiveCombo }
    };

            cbFilterBy.DataSource = filters;
            cbFilterBy.DisplayMember = "Display";
            cbFilterBy.ValueMember = "Value";
        }
        private void DgvPeople_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int personID = Convert.ToInt32(DGVUsers.Rows[e.RowIndex].Cells["UserID"].Value);
            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo(personID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
               // RefreshPeopleList();
            }
        }



        private void UpdateSearchVisibility()
        {
            txtSearch.Visible = cbFilterBy.SelectedValue.ToString() != "None";
        }
        private void FrmManageUsers_Load(object sender, EventArgs e)
        {

            DGVUsers.AutoGenerateColumns = true; 

            cbIsActive.Location = txtSearch.Location;
            cbIsActive.Size = txtSearch.Size;

            DGVUsers.CellMouseDown += DGVUsers_CellMouseDown_1;

            cbIsActive.Items.Clear();
            cbIsActive.Items.Add("All");
            cbIsActive.Items.Add("Yes");
            cbIsActive.Items.Add("No");

            cbIsActive.SelectedIndex = 0;
            cbIsActive.Visible = false;

            SetupUserFilters();
            RefreshUserseList();

            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            DGVUsers.CellDoubleClick += DGVUsers_CellDoubleClick_1;



            pbAddNewUser.Cursor = Cursors.Hand;
            toolTip1.SetToolTip(pbAddNewUser, "Add New User");

            UpdateSearchVisibility();
        }
        private void DGVUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void RefreshUserseList()
        {
            _dtUsers = clsUser.GetUsers();

            DGVUsers.DataSource = _dtUsers;

            DGVUsers.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            _dtUsers.DefaultView.RowFilter = "";
            txtSearch.Text = "";

            LbNumberOfRecords.Text = _dtUsers.DefaultView.Count.ToString();
        }
        private void DgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                if (_dtUsers == null)
                    return;

                if (cbFilterBy.SelectedItem is FilterItem selectedFilter)
                {
                    string currentFilter = selectedFilter.Value;

                    // 🔥 امسح فقط إذا تغير الفلتر
                    if (_lastFilter != currentFilter)
                    {
                        txtSearch.Text = "";
                        _lastFilter = currentFilter;
                    }

                    switch (selectedFilter.InputType)
                    {
                        case FilterInputType.TextBox:
                            txtSearch.Visible = true;
                            cbIsActive.Visible = false;
                            break;

                        case FilterInputType.IsActiveCombo:
                            txtSearch.Visible = false;
                            cbIsActive.Visible = true;
                            cbIsActive.SelectedIndex = 0;
                            break;

                        case FilterInputType.None:
                            txtSearch.Visible = false;
                            cbIsActive.Visible = false;
                            _dtUsers.DefaultView.RowFilter = "";
                            break;
                    }
                }
            
        }
        private void ApplyFilter()
        {
            if (_dtUsers == null || cbFilterBy.SelectedItem == null)
                return;

            if (!(cbFilterBy.SelectedItem is FilterItem selectedFilter))
                return;

            string column = selectedFilter.Value;

            // None
            if (selectedFilter.InputType == FilterInputType.None)
            {
                _dtUsers.DefaultView.RowFilter = "";
                LbNumberOfRecords.Text = _dtUsers.DefaultView.Count.ToString();
                return;
            }

            // IsActive
            if (selectedFilter.InputType == FilterInputType.IsActiveCombo)
            {
                string selected = cbIsActive.SelectedItem?.ToString();

                if (selected == "All")
                    _dtUsers.DefaultView.RowFilter = "";
                else if (selected == "Yes")
                    _dtUsers.DefaultView.RowFilter = "IsActive = 1";
                else if (selected == "No")
                    _dtUsers.DefaultView.RowFilter = "IsActive = 0";

                LbNumberOfRecords.Text = _dtUsers.DefaultView.Count.ToString();
                return;
            }

            // Text filters
            string value = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(value))
            {
                _dtUsers.DefaultView.RowFilter = "";
                return;
            }

            if (!_dtUsers.Columns.Contains(column))
                return;

            Type type = _dtUsers.Columns[column].DataType;

            if (type == typeof(int) || type == typeof(short) || type == typeof(long))
            {
                if (int.TryParse(value, out int num))
                    _dtUsers.DefaultView.RowFilter = $"{column} = {num}";
                else
                    _dtUsers.DefaultView.RowFilter = "0 = 1";
            }
            else
            {
                value = value.Replace("'", "''");
                _dtUsers.DefaultView.RowFilter = $"{column} LIKE '%{value}%'";
            }

            LbNumberOfRecords.Text = _dtUsers.DefaultView.Count.ToString();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {


          
                if (cbFilterBy.SelectedItem is FilterItem selectedFilter)
                {
                    switch (selectedFilter.InputType)
                    {
                        case FilterInputType.TextBox:
                            txtSearch.Visible = true;
                            cbIsActive.Visible = false;
                            break;

                        case FilterInputType.IsActiveCombo:
                            txtSearch.Visible = false;
                            cbIsActive.Visible = true;
                            cbIsActive.SelectedIndex = 0;
                            break;

                        case FilterInputType.None:
                            txtSearch.Visible = false;
                            cbIsActive.Visible = false;
                            _dtUsers.DefaultView.RowFilter = "";
                            break;
                    }
                }
            ApplyFilter();

          
        }
        private string GetFilterExpression(string column, string value)
        {
            Type columnType = _dtUsers.Columns[column].DataType;

            // 🔥 Special Cases أولاً

            string special = HandleSpecialCases(column, value);
            if (special != null)
                return special;

            // 🔢 Numeric
            if (IsNumericType(columnType))
                return HandleNumericFilter(column, value);

            // 🔤 String
            return HandleStringFilter(column, value);
        }

        private bool IsNumericType(Type type)
        {
            return type == typeof(int) ||
                   type == typeof(short) ||
                   type == typeof(long);
        }
        private string HandleNumericFilter(string column, string value)
        {
            if (int.TryParse(value, out int number))
                return $"{column} = {number}";

            return "0 = 1"; // 🔥 لا نتائج
        }
        private string HandleStringFilter(string column, string value)
        {
            value = value.Replace("'", "''");

            return $"{column} LIKE '%{value}%'";
        }

        private string HandleSpecialCases(string column, string value)
        {
            // ✅ IsActive (bool أو bit)
            if (column == "IsActive")
            {
                if (value.Equals("Active", StringComparison.OrdinalIgnoreCase))
                    return $"{column} = 1";

                if (value.Equals("Not Active", StringComparison.OrdinalIgnoreCase))
                    return $"{column} = 0";

                return "0 = 1";
            }

            return null;
        }

        private void BntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedValue == null)
                return;

            string column = cbFilterBy.SelectedValue.ToString();

            if (column == "PersonID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            if(column == "UserID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }

        private void pbAddNewUser_Click(object sender, EventArgs e)
        {
            FrmAddUser frm = new FrmAddUser(-1);
            frm.OnSavedCompleted += (UserID) =>
            {
                if (UserID > 0)
                {
                    RefreshUserseList();
                }
            };

            frm.Show();
        }
       
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedUserId <= 0)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            FrmChangePassword frm = new FrmChangePassword(_selectedUserId);
            frm.ShowDialog();
        }

        private void DGVUsers_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DGVUsers.ClearSelection();
                DGVUsers.Rows[e.RowIndex].Selected = true;

                _selectedUserId = Convert.ToInt32(DGVUsers.Rows[e.RowIndex].Cells["UserID"].Value);
            }
        }

        

        private void DGVUsers_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int userID = Convert.ToInt32(DGVUsers.Rows[e.RowIndex].Cells["UserID"].Value);

            FrmChangePassword frm = new FrmChangePassword(userID);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = (int)DGVUsers.CurrentRow.Cells["UserID"].Value;

            FrmUserDetails Frm = new FrmUserDetails(userID);

            Frm.OnPersonUpdated += (success) =>
            {
                RefreshUserseList();
                
            };
            Frm.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)

        {
            FrmAddUser frm = new FrmAddUser(-1);

            frm.OnSavedCompleted += (UserID) =>
            {
                if (UserID > 0)
                {
                    RefreshUserseList();
                }
            };

            frm.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGVUsers.CurrentRow == null)
                return;

            int userID = (int)DGVUsers.CurrentRow.Cells["UserID"].Value;

            // 🔴 1. حماية (Business Rules)

            // ❌ منع حذف نفسك
            if (clsGlobalSettings.CurrentUser != null &&
     userID == clsGlobalSettings.CurrentUser.UserID)
            {
                MessageBox.Show("You cannot deactivate your own account",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // ❌ منع حذف الأدمن
            if (userID == 1)
            {
                MessageBox.Show("Cannot deactivate system admin",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // 🔵 2. تأكيد
            if (MessageBox.Show("Are you sure you want to deactivate this user?",
                                "Confirm",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // 🟢 3. Soft Delete
            if (clsUser.DeleteUser(userID))
            {
                MessageBox.Show("User deactivated successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                RefreshUserseList();
            }
            else
            {
                MessageBox.Show("Operation failed.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int userID = (int)DGVUsers.CurrentRow.Cells["UserID"].Value;

            FrmAddUser frm = new FrmAddUser(userID);
            frm.OnSavedCompleted += (UserID) =>
            {
                if (UserID > 0)
                {
                    RefreshUserseList();
                }
            };
            frm.Show();
        }
    }
}
