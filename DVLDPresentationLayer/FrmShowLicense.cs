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
    public partial class FrmShowLicense : Form
    {
        private int _LicenseID;
        public FrmShowLicense(int LicenseId)
        {
            InitializeComponent();

            _LicenseID = LicenseId;
        }

        private void BntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmShowLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfo1.LoadData(_LicenseID);
        }
    }
}
