using DVLDBusinessLayer;
using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLDPresentationLayer
{
    public partial class ctrlPersonSelector : UserControl
    {
        private int _SelectedPersonID = -1;

        // 🔥 Event مهم
        public event Action<int> OnPersonSelected;

        // 🔥 Property

        public int SelectedPersonID => _SelectedPersonID;

        public bool EnableFilter
        {
            set
            {
                gboxFilter.Enabled = value;
            }
        }
        public ctrlPersonSelector()
        {
            InitializeComponent();
            ctrlPersonInfoCard1.AllowEdit = true;
           



        }

        private void ctrlPersonSelector_Load(object sender, EventArgs e)
        {
           



        }

        private void SetupFilters()
        {
            var filters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("None", "None"),
                new KeyValuePair<string, string>("Person ID", "PersonID"),
                new KeyValuePair<string, string>("National No", "NationalNo"),
            };

            cbFilterBy.DataSource = filters;
            cbFilterBy.DisplayMember = "Key";
            cbFilterBy.ValueMember = "Value";
        }

        // =========================
        // SEARCH
        // =========================
        private void SearchPerson()
        {
            string filter = cbFilterBy.SelectedValue?.ToString();

            if (filter == "None")
                return;

            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Enter value first");
                return;
            }

            if (filter == "PersonID")
                SearchByPersonID();
            else if (filter == "NationalNo")
                SearchByNationalNo();
        }

        private void SearchByPersonID()
        {
            if (!int.TryParse(txtSearch.Text, out int personID))
            {
                MessageBox.Show("Invalid Person ID");
                return;
            }

            LoadPerson(personID);
        }

        private void SearchByNationalNo()
        {
            var person = clsPerson.FindPersonByNationalNo(txtSearch.Text);

            if (person == null)
            {
                MessageBox.Show("Person Not Found");
                ResetPerson();
                return;
            }

            LoadPerson(person.PersonID);
        }

        // =========================
        // LOAD PERSON
        // =========================
        private void LoadPerson(int personID)
        {
            var person = clsPerson.GetPersonByID(personID);

            if (person == null)
            {
                MessageBox.Show("Person Not Found");
                ResetPerson();
                return;
            }

            _SelectedPersonID = personID;

            ctrlPersonInfoCard1.SetPerson(personID);

            cbFilterBy.SelectedIndex = 1;
            txtSearch.Text = personID.ToString();

            // 🔥 Notify form
            OnPersonSelected?.Invoke(personID);
        }

        private void ResetPerson()
        {
            _SelectedPersonID = -1;
            ctrlPersonInfoCard1.SetPerson(-1);
            OnPersonSelected?.Invoke(-1);
        }

        // =========================
        // PUBLIC METHOD
        // =========================
        public void SetPerson(int personID)
        {
            if (personID <= 0)
            {
                ResetPerson();
                return;
            }

            LoadPerson(personID);
        }

        // =========================
        // EVENTS
        // =========================
        private void pboxSearch_Click(object sender, EventArgs e)
        {
            SearchPerson();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchPerson();
                e.SuppressKeyPress = true;
            }
        }

        private void pboxAddPerson_Click(object sender, EventArgs e)
        {
          
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedValue == null)
                return;

            bool showSearch = cbFilterBy.SelectedValue.ToString() != "None";

            txtSearch.Visible = showSearch;
            pboxSearch.Visible = showSearch;

            if (!showSearch)
                txtSearch.Text = "";
        }

        private void pboxAddPerson_Click_1(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtSearch.Text = "";

            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo(-1);

            frm.OnPersonSaved += LoadPerson;

            frm.ShowDialog();
        }
       
       
        private void ctrlPersonInfoCard1_Load(object sender, EventArgs e)
        {
            SetupFilters();

            cbFilterBy.SelectedIndex = 0;

            pboxSearch.Cursor = Cursors.Hand;
            SearchToolTip.SetToolTip(pboxSearch, "Search Person");
            pboxAddPerson.Cursor = Cursors.Hand;
            AddNewToolTip.SetToolTip(pboxAddPerson, "Add New Person");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}