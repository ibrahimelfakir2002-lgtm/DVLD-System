using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class FrmManageDrivers : Form
    {
        private DataTable _dtDrivers;

        public FrmManageDrivers()
        {
            InitializeComponent();
        }

        // =========================
        // FORM LOAD
        // =========================
        private void FrmManageDrivers_Load(object sender, EventArgs e)
        {
           
        }

        // =========================
        // LOAD DATA
        // =========================
        private void RefreshDriversList()
        {
            _dtDrivers = ClsDriver.GetAllDrivers();

            DGVDrivers.DataSource = _dtDrivers;

            ResetSearch();

            UpdateRecordsCount();
        }

        // =========================
        // FILTER SETUP
        // =========================
        private void SetupFilters()
        {
            var filters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("None", "None"),
                new KeyValuePair<string, string>("Driver ID", "DriverID"),
                new KeyValuePair<string, string>("Person ID", "PersonID"),
                new KeyValuePair<string, string>("Full Name", "FullName"),
                new KeyValuePair<string, string>("Created Date", "CreatedDate")
            };

            cbFilterBy.DataSource = filters;
            cbFilterBy.DisplayMember = "Key";
            cbFilterBy.ValueMember = "Value";
        }

        // =========================
        // SEARCH LOGIC
        // =========================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        // =========================
        // COMBO CHANGE
        // =========================
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSearchVisibility();
            txtSearch.Text = "";
        }

        private void UpdateSearchVisibility()
        {
            string filter = cbFilterBy.SelectedValue?.ToString();

            txtSearch.Visible = false;
            dtpFrom.Visible = false;
            dtpTo.Visible = false;

            if (filter == "None")
                return;

            if (filter == "CreatedDate")
            {
                dtpFrom.Visible = true;
                dtpTo.Visible = true;
            }
            else
            {
                txtSearch.Visible = true;
            }
        }

        // =========================
        // RESET SEARCH
        // =========================
        private void ResetSearch()
        {
            _dtDrivers.DefaultView.RowFilter = "";
            txtSearch.Text = "";
        }

        // =========================
        // COUNT
        // =========================
        private void UpdateRecordsCount()
        {
            LbNumberOfRecords.Text = _dtDrivers.DefaultView.Count.ToString();
        }

        // =========================
        // DOUBLE CLICK (future use)
        // =========================
        private void DGVDrivers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // open driver details here later
        }

        private void FrmManageDrivers_Load_1(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (_dtDrivers == null || cbFilterBy.SelectedValue == null)
                return;

            string column = cbFilterBy.SelectedValue.ToString();
            string value = txtSearch.Text.Trim();

            if (column == "None")
            {
                _dtDrivers.DefaultView.RowFilter = "";
                UpdateRecordsCount();
                return;
            }

            if (!_dtDrivers.Columns.Contains(column))
                return;

            if (string.IsNullOrEmpty(value))
            {
                _dtDrivers.DefaultView.RowFilter = "";
                UpdateRecordsCount();
                return;
            }

            Type type = _dtDrivers.Columns[column].DataType;

            try
            {
                // =========================
                // NUMBER FILTER
                // =========================
                if (type == typeof(int) || type == typeof(short) || type == typeof(long))
                {
                    if (int.TryParse(value, out int number))
                        _dtDrivers.DefaultView.RowFilter = $"{column} = {number}";
                    else
                        _dtDrivers.DefaultView.RowFilter = "0 = 1";
                }

                // =========================
                // DATE FILTER
                // =========================
                else if (type == typeof(DateTime))
                {
                    if (DateTime.TryParse(value, out DateTime date))
                        _dtDrivers.DefaultView.RowFilter = $"Convert({column}, 'System.String') LIKE '%{date:yyyy-MM-dd}%'";
                    else
                        _dtDrivers.DefaultView.RowFilter = "0 = 1";
                }

                // =========================
                // STRING FILTER
                // =========================
                else
                {
                    _dtDrivers.DefaultView.RowFilter =
                        $"{column} LIKE '%{value.Replace("'", "''")}%' ";
                }

                UpdateRecordsCount();
            }
            catch
            {
                _dtDrivers.DefaultView.RowFilter = "";
            }
        }
        private void DateFilterChanged(object sender, EventArgs e)
        {
            if (_dtDrivers == null || cbFilterBy.SelectedValue == null)
                return;

            string column = cbFilterBy.SelectedValue.ToString();

            if (column != "CreatedDate")
                return;

            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;

            // مهم: include full day
            to = to.AddDays(1).AddSeconds(-1);

            try
            {
                _dtDrivers.DefaultView.RowFilter =
                    $"{column} >= #{from:MM/dd/yyyy}# AND {column} <= #{to:MM/dd/yyyy}#";

                UpdateRecordsCount();
            }
            catch
            {
                _dtDrivers.DefaultView.RowFilter = "";
            }
        }

        private void FrmManageDrivers_Load_2(object sender, EventArgs e)
        {
            SetupFilters();
            RefreshDriversList();

            dtpFrom.ValueChanged += DateFilterChanged;
            dtpTo.ValueChanged += DateFilterChanged;

            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;

            UpdateSearchVisibility();
        }
    }
}