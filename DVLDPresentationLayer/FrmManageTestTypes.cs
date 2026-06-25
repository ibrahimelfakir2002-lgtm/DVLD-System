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
    public partial class FrmManageTestTypes : Form
    {
        private DataTable _TestTypesDt;
        public FrmManageTestTypes()
        {
            InitializeComponent();
        }

        private void BntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RefreshApplicationTypesList()
        {
            _TestTypesDt = clsTestTypes.GetAllTestTypes();      

            DGVTestTypes.DataSource = null;   // 🔥 مهم
            DGVTestTypes.DataSource = _TestTypesDt;

            // ✅ هنا دير التعديلات على الأعمدة
            DGVTestTypes.Columns["TestTypeTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGVTestTypes.Columns["TestTypeTitle"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            DGVTestTypes.Columns["TestTypeDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGVTestTypes.Columns["TestTypeDescription"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            DGVTestTypes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // توزيع باقي الأعمدة
            DGVTestTypes.Columns["TestTypeID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGVTestTypes.Columns["TestTypeFees"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            _TestTypesDt.DefaultView.RowFilter = "";

            LbNumberOfRecords.Text = _TestTypesDt.DefaultView.Count.ToString();
        }
        private void FrmManageTestTypes_Load(object sender, EventArgs e)
        {
            RefreshApplicationTypesList();
        }

        private void editTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int TestType = (int)DGVTestTypes.CurrentRow.Cells["TestTypeID"].Value;

            FrmUpdateTestTypes frm = new FrmUpdateTestTypes(TestType);

            frm.OnPersonUpdated += (success) =>
            {
                RefreshApplicationTypesList();
            };

            frm.Show();
            RefreshApplicationTypesList();
        }
    }
}
