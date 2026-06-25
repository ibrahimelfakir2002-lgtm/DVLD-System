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
    public partial class FrmUpdateTestTypes : Form
    {
        private clsTestTypes _TestTypes;
        private int _TestTypeID;
        public event Action<bool> OnPersonUpdated;
        public FrmUpdateTestTypes(int TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void _LoadData()
        {
            _TestTypes = clsTestTypes.FindTestTypeByID(_TestTypeID);

            if (_TestTypes == null)
            {
                MessageBox.Show("tests Type not found");
                this.Close();
                return;
            }

            txtTitle.Text = _TestTypes.TestTypeTitle;
            txtDescription.Text = _TestTypes.TestTypeDescription;
            txtFees.Text = _TestTypes.TestTypeFees.ToString("0.00");

            btnSave.Enabled = false; // 🔥 ما يكونش مفعل حتى يتبدل شي حاجة
        }
        private void FrmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
                if (!_ValidateInputs(out decimal fees))
                    return;

                // 🔥 Check إذا ما تبدل حتى شي حاجة
                if (txtTitle.Text == _TestTypes.TestTypeTitle && txtDescription.Text == _TestTypes.TestTypeDescription &&
                    fees == _TestTypes.TestTypeFees)
                {
                    MessageBox.Show("No changes detected");
                    return;
                }

            _TestTypes.TestTypeTitle = txtTitle.Text;
            _TestTypes.TestTypeDescription = txtDescription.Text;
            _TestTypes.TestTypeFees = fees;

                if (_TestTypes.Save())
                {
                    OnPersonUpdated?.Invoke(true);
                    MessageBox.Show("Application Type Updated Successfully");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update Failed");
                }
            }

            private bool _ValidateInputs(out decimal fees)
            {
                fees = 0;

                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Title cannot be empty");
                    txtTitle.Focus();
                    return false;
                }

                if (!decimal.TryParse(txtFees.Text, out fees))
                {
                    MessageBox.Show("Invalid Fees");
                    txtFees.Focus();
                    return false;
                }

                return true;
            }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtFees_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void BntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

