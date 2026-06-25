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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLDPresentationLayer
{
    public partial class ctrlLicenseSelector : UserControl
    {
        public clsLicense SelectedLicense { get; private set; }
        public event Action<clsLicense> OnLicenseSelected;

        public ctrlLicenseSelector()
        {
            InitializeComponent();
        }

        private void ctrlLicenseSelector_Load(object sender, EventArgs e)
        {

            toolTip1.SetToolTip(picBoxNewInterational, "Search License");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
                
            }

        private void PerformSearch()
        {
            if (!int.TryParse(txtSearch.Text.Trim(), out int licenseID))
            {
                MessageBox.Show("Invalid License ID");
                return;
            }

            var license = clsLicense.FindByLicenseID(licenseID);

            if (license == null)
            {
                MessageBox.Show("License not found");
                return;
            }

           
            SelectedLicense = license;

            ctrlLicenseInfo1.LoadData(licenseID);

            OnLicenseSelected?.Invoke(license);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();
            }
        }
        
        private void picBoxNewInterational_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void picBoxNewInterational_MouseEnter(object sender, EventArgs e)
        {
            picBoxNewInterational.BackColor = Color.LightGray;

        }

        private void picBoxNewInterational_MouseLeave(object sender, EventArgs e)
        {
            picBoxNewInterational.BackColor = Color.Transparent;
        }

    }
}
