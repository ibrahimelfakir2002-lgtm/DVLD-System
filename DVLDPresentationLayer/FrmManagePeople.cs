using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLDPresentationLayer
{
    public partial class FrmManagePeople : Form
    {
        private DataTable _dtPeople;

        public FrmManagePeople()
        {
            InitializeComponent();
        }



        // البحث في DataGridView
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtPeople == null || cbFilterBy.SelectedValue == null)
                return;

            string column = cbFilterBy.SelectedValue.ToString();
            string value = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(value))
            {
                _dtPeople.DefaultView.RowFilter = "";
                return;
            }

            if (!_dtPeople.Columns.Contains(column))
                return;

            Type columnType = _dtPeople.Columns[column].DataType;

            if (columnType == typeof(int) || columnType == typeof(short) || columnType == typeof(long))
            {
                if (int.TryParse(value, out int number))
                    _dtPeople.DefaultView.RowFilter = $"{column} = {number}";
                else
                    _dtPeople.DefaultView.RowFilter = "0 = 1";
            }
            else
            {
                value = value.Replace("'", "''");

                if (column == "GenderText")
                {
                    _dtPeople.DefaultView.RowFilter = $"{column} = '{value}'";
                }
                else
                {
                    _dtPeople.DefaultView.RowFilter = $"{column} LIKE '%{value}%'";
                }
            }
        }
        private void pbAddPerson_Click(object sender, EventArgs e)
        {
            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo(-1); // إضافة جديد

            // ربط الحدث لإعادة تحميل البيانات بعد كل حفظ
            frm.OnPersonSaved += (personID) =>
            {
                if (personID > 0) // 🔥 هذا هو الصح
                {
                    RefreshPeopleList();
                }
            };


            frm.Show(); // لا تستخدم ShowDialog حتى يمكن تعديل وحفظ متعدد

           
        }

        // فتح فورم التعديل عند الضغط المزدوج على صف
        private void DgvPeople_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        // زر إغلاق الفورم
        private void BntClose_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
        private void SetupFilters()
        {
            var filters = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("None", "None"),
        new KeyValuePair<string, string>("Person ID", "PersonID"),
        new KeyValuePair<string, string>("National No", "NationalNo"),
         new KeyValuePair<string, string>("First Name", "FirstName"),
          new KeyValuePair<string, string>("Second Name", "SecondName"),
           new KeyValuePair<string, string>("Third Name", "ThirdName"),
           new KeyValuePair<string, string>("Last Name", "LastName"),
         new KeyValuePair<string, string>("Nationality", "CountryName"),
          new KeyValuePair<string, string>("Gender", "GenderText"),
             new KeyValuePair<string, string>("Phone", "Phone"),
               new KeyValuePair<string, string>("Email", "Email"),



    };

            cbFilterBy.DataSource = filters;
            cbFilterBy.DisplayMember = "Key";
            cbFilterBy.ValueMember = "Value";
        }

        private void UpdateSearchVisibility()
        {
            txtSearch.Visible = cbFilterBy.SelectedValue.ToString() != "None";
        }
        private void FrmManagePeople_Load_1(object sender, EventArgs e)
        {
            RefreshPeopleList();


            LbNumberOfRecords.Text = _dtPeople.DefaultView.Count.ToString();

            SetupFilters();

            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            DgvPeople.CellDoubleClick += DgvPeople_CellDoubleClick;

            pbAddPerson.Cursor = Cursors.Hand;
            toolTip1.SetToolTip(pbAddPerson, "Add New Person");

            UpdateSearchVisibility();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedValue.ToString() == "None")
            {
                txtSearch.Visible = false;
            }
            else
            {
                txtSearch.Visible = true;
            }
        }

        private void DgvPeople_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = DgvPeople.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    DgvPeople.ClearSelection();
                    DgvPeople.Rows[hit.RowIndex].Selected = true;
                    DgvPeople.CurrentCell = DgvPeople.Rows[hit.RowIndex].Cells[0];
                }
            }
        }

        private void RefreshPeopleList()
        {
            _dtPeople = clsPerson.GetAllPersons();

            DgvPeople.DataSource = null;   // 🔥 مهم جدا
            DgvPeople.DataSource = _dtPeople;

            _dtPeople.DefaultView.RowFilter = "";
            txtSearch.Text = "";

            LbNumberOfRecords.Text = _dtPeople.DefaultView.Count.ToString();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo(-1);

            frm.OnPersonSaved += (ID) =>
            {
                if (ID > 0) // 🔥 هذا هو الصح
                {
                    RefreshPeopleList();
                }
            };

            frm.ShowDialog();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)DgvPeople.CurrentRow.Cells["PersonID"].Value;

            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo(personID);

            frm.OnPersonSaved += (ID) =>
            {
                if (ID > 0) // 🔥 هذا هو الصح
                {
                    RefreshPeopleList();
                }
            };
            frm.Show();

            //RefreshPeopleList();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)DgvPeople.CurrentRow.Cells["PersonID"].Value;

            FrmPersonDetails frm = new FrmPersonDetails(personID);

            frm.OnPersonUpdated += (success) =>
            {
                RefreshPeopleList(); // 🔥 تحديث الجدول مباشرة
            };

            frm.ShowDialog();
            RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvPeople.CurrentRow == null)
                return;

            int personID = (int)DgvPeople.CurrentRow.Cells["PersonID"].Value;

            // 🔴 1. تحقق من الأسباب
            var reasons = clsPerson.GetDeleteBlockingReasons(personID);

            if (reasons.Count > 0)
            {
                string message = "Cannot delete this person because:\n\n- "
                                 + string.Join("\n- ", reasons);

                MessageBox.Show(message,
                                "Delete Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // 🔵 2. تأكيد
            if (MessageBox.Show("Are you sure you want to delete this person?",
                                "Confirm Delete",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // 🟢 3. تنفيذ الحذف
            if (clsPerson.DeletePersonByID(personID))
            {
                MessageBox.Show("Person deactivated successfully.", "", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                RefreshPeopleList();
            }
            else
            {
                MessageBox.Show("Delete failed. Please try again.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
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
        }

        private void DgvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvPeople_CellContextMenuStripChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvPeople_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int personID = Convert.ToInt32(DgvPeople.Rows[e.RowIndex].Cells["PersonID"].Value);
            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo(personID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                RefreshPeopleList();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}