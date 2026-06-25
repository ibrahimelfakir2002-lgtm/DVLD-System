using DVLDBussinessLayer;
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
    public partial class FrmManageApplicationsTypes : Form
    {
        private DataTable _DtApplicationsTypes;
        public FrmManageApplicationsTypes()
        {
            InitializeComponent();
        }
        private void RefreshApplicationTypesList()
        {
            _DtApplicationsTypes = clsApplicationTypes.GetAllApplicationsTypes();

            DGVManageAppTypes.DataSource = null;   // 🔥 مهم
            DGVManageAppTypes.DataSource = _DtApplicationsTypes;

            // ✅ هنا دير التعديلات على الأعمدة
            DGVManageAppTypes.Columns["ApplicationTypeTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGVManageAppTypes.Columns["ApplicationTypeTitle"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            DGVManageAppTypes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // توزيع باقي الأعمدة
            DGVManageAppTypes.Columns["ApplicationTypeID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGVManageAppTypes.Columns["ApplicationFees"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            _DtApplicationsTypes.DefaultView.RowFilter = "";

            LbNumberOfRecord.Text = _DtApplicationsTypes.DefaultView.Count.ToString();
        }
        private void FrmManageApplicationsTypes_Load(object sender, EventArgs e)
        {
            RefreshApplicationTypesList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppTypeID = (int)DGVManageAppTypes.CurrentRow.Cells["ApplicationTypeID"].Value;

            FrmUpdateApplicationType frm = new FrmUpdateApplicationType(AppTypeID);

                 frm.OnPersonUpdated += (success) =>
                 {
                     RefreshApplicationTypesList();
                 };

            frm.Show();
            RefreshApplicationTypesList();

        }

        private void BntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
