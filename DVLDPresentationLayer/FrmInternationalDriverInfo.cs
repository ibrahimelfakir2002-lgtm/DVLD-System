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
    public partial class FrmInternationalDriverInfo : Form
    {
        private int _InternationalLicenseID;
        public FrmInternationalDriverInfo(int InternationalLicenseID)
        {
            InitializeComponent();

            _InternationalLicenseID = InternationalLicenseID;

            ctrlInternationalDriverLicense1.SetInterLicenseID(_InternationalLicenseID);
        }

        private void FrmInternationalDriverInfo_Load(object sender, EventArgs e)
        {
        }
    }
}
