using DVLDBussinessLayer;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class FrmUpdateApplicationType : Form
    {
        private int _AppTypeID;
        private clsApplicationTypes _appTypes;

        public event Action<bool> OnPersonUpdated;
        public FrmUpdateApplicationType(int AppTypeID)
        {
            InitializeComponent();

            _AppTypeID = AppTypeID;

        }

        private void FrmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            
        }
      

        private void _LoadData()
        {
            _appTypes = clsApplicationTypes.FindByID(_AppTypeID);

            if (_appTypes == null)
            {
                MessageBox.Show("Application Type not found");
                this.Close();
                return;
            }

            txtTitle.Text = _appTypes.ApplicationTypeTitle;
            txtFees.Text = _appTypes.ApplicationTypeFees.ToString("0.00");

            btnSave.Enabled = false; // 🔥 ما يكونش مفعل حتى يتبدل شي حاجة
        }

      
        private void BntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateInputs(out decimal fees))
                return;

            // 🔥 Check إذا ما تبدل حتى شي حاجة
            if (txtTitle.Text == _appTypes.ApplicationTypeTitle &&
                fees == _appTypes.ApplicationTypeFees)
            {
                MessageBox.Show("No changes detected");
                return;
            }

            _appTypes.ApplicationTypeTitle = txtTitle.Text;
            _appTypes.ApplicationTypeFees = fees;

            if (_appTypes.Save())
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

        // 🔥 Enable Save إذا تغير شي حاجة
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtFees_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmUpdateApplicationType_Load_1(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void txtFees_TextChanged_1(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtTitle_TextChanged_1(object sender, EventArgs e)
        {

            btnSave.Enabled = true;
        }
    }
}