using DVLDBussinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class FrmShowPersonLicenseHistory : Form
    {
        private int _DriverID;
        private ClsDriver _Driver;

        private DataTable _LocalLicenses;
        private DataTable _InternationalLicenses;

        public FrmShowPersonLicenseHistory(int driverID)
        {
            InitializeComponent();
            _DriverID = driverID;
        }

        // -----------------------------
        // LOAD FORM
        // -----------------------------
        private void FrmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            DGVLocalLicenses.DataBindingComplete += DGVLocalLicenses_DataBindingComplete;
           DGVInternationalLicenses.DataBindingComplete += DGVInternationalLicenses_DataBindingComplete;

            LoadDriver();
            LoadPersonInfo();
            LoadLicenses();
            SetupUI();
        }
        private void DGVLocalLicenses_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var grid = DGVLocalLicenses;

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (grid.Columns.Contains("IsActive"))
            {
                grid.Columns["IsActive"].HeaderText = "Active";
                grid.Columns["IsActive"].Width = 60;
            }
        }

        private void DGVInternationalLicenses_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var grid = DGVInternationalLicenses;

            if (grid == null || grid.Columns == null)
                return;

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            DGVInternationalLicenses.AutoGenerateColumns = false;
            new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                DataPropertyName = "IsActive",
                HeaderText = "Active"
            };


           
        }

        // -----------------------------
        // DRIVER
        // -----------------------------
        private void LoadDriver()
        {
            _Driver = ClsDriver.FindDriverByID(_DriverID);

            if (_Driver == null)
            {
                MessageBox.Show("Driver not found!");
                this.Close();
            }
        }

        // -----------------------------
        // PERSON INFO
        // -----------------------------
        private void LoadPersonInfo()
        {
            ctrlPersonInfoCard1.SetPerson(_Driver.PersonID);
        }

        // -----------------------------
        // LICENSES DATA
        // -----------------------------
        private void LoadLicenses()
        {
            _LocalLicenses = clsLicense.GetLocalLicensesByDriverID(_DriverID);
            _InternationalLicenses = clsInternationalLicense.GetInternationalLicensesByDriverID(_DriverID);

            DGVLocalLicenses.DataSource = _LocalLicenses;

            //  🔥 مهم: افحص قبل الربط
            if (_InternationalLicenses != null && _InternationalLicenses.Rows.Count > 0)
                DGVInternationalLicenses.DataSource = _InternationalLicenses;
            else
                DGVInternationalLicenses.DataSource = null;
        }

        // -----------------------------
        // GRID UI FORMAT
        // -----------------------------
        private void FormatGrids()
        {
            FormatLocalGrid();
            FormatInternationalGrid();
        }

        private void FormatLocalGrid()
        {
            if (DGVLocalLicenses.Columns.Count == 0) return;

            DGVLocalLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVLocalLicenses.ReadOnly = true;
            DGVLocalLicenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (DGVLocalLicenses.Columns["IsActive"] != null)
            {
                DGVLocalLicenses.Columns["IsActive"].HeaderText = "Active";
                DGVLocalLicenses.Columns["IsActive"].Width = 60;
            }
        }

        private void FormatInternationalGrid()
        {
            if (DGVInternationalLicenses == null || DGVInternationalLicenses.DataSource == null)
                return;

            DGVInternationalLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVInternationalLicenses.ReadOnly = true;
            DGVInternationalLicenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (DGVInternationalLicenses.Columns.Contains("IsActive"))
            {
                DGVInternationalLicenses.Columns["IsActive"].HeaderText = "Active";
                DGVInternationalLicenses.Columns["IsActive"].Width = 60;
            }
        }

        // -----------------------------
        // UI SETUP
        // -----------------------------
        private void SetupUI()
        {
            txtSearch.Text = _Driver.PersonID.ToString();
            cbFilterBy.Text = "Person ID";

            pboxAddPerson.Enabled = false;
            pboxSearch.Enabled = false;
            gboxFilter.Enabled = false;
        }
    }
}