using DVLDBussinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class FrmManageInternationalLicenseApplications : Form
    {

        private DataTable _dtInternationalLicenses;

        public FrmManageInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
     
        private void DGVLocalLicenses_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var grid = DgvInternationalLicenseApps;

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (grid.Columns.Contains("IsActive"))
            {
                grid.Columns["IsActive"].HeaderText = "Active";
                grid.Columns["IsActive"].Width = 60;
            }
        }

        private void RefreshInternationalLicenses()
        {
            _dtInternationalLicenses = clsInternationalLicense.GeinternationalLicensesApps();
            DgvInternationalLicenseApps.DataSource = null;   // 🔥 مهم جدا
            DgvInternationalLicenseApps.DataSource = _dtInternationalLicenses;

            _dtInternationalLicenses.DefaultView.RowFilter = "";
            txtSearch.Text = "";

            LbNumberOfRecords.Text = _dtInternationalLicenses.DefaultView.Count.ToString();
        }
        private void FrmInternationalLicenseApplications_Load(object sender, EventArgs e)


        {

            DgvInternationalLicenseApps.DataBindingComplete += DGVLocalLicenses_DataBindingComplete;


            RefreshInternationalLicenses();

            LbNumberOfRecords.Text = _dtInternationalLicenses.DefaultView.Count.ToString();

           // SetupFilters();

            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;


            pbAddPerson.Cursor = Cursors.Hand;
            toolTip1.SetToolTip(pbAddPerson, "Add New International License");

           // UpdateSearchVisibility();
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

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppId =  (int)DgvInternationalLicenseApps.CurrentRow.Cells["ApplicationID"].Value;

            clsApplication app = clsApplication.FindByApplicationID(AppId);

            if (app != null)
            {
                clsPerson Person= clsPerson.GetPersonByID(app.ApplicantPersonID);
                if (Person != null)
                {

                    FrmPersonDetails frm = new FrmPersonDetails(Person.PersonID);
                    frm.Show();
                }

            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InterLicenseiD = (int)DgvInternationalLicenseApps.CurrentRow.Cells["InternationalLicenseID"].Value;

            clsInternationalLicense interLicense = clsInternationalLicense.FindByID(InterLicenseiD);

            if(interLicense != null)
            {
                FrmInternationalDriverInfo Frm = new FrmInternationalDriverInfo(InterLicenseiD);
                Frm.Show();
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)DgvInternationalLicenseApps.CurrentRow.Cells["DriverID"].Value;

            ClsDriver Driver = ClsDriver.FindDriverByID(DriverID);

            if (Driver != null)
            {
                FrmShowPersonLicenseHistory frm = new FrmShowPersonLicenseHistory(DriverID);
                frm.Show();
            }

        }

        private void pbAddPerson_Click(object sender, EventArgs e)
        {
            FrmNewInternationalLicense frm = new FrmNewInternationalLicense();
            frm.Show();

        }
    }
}
