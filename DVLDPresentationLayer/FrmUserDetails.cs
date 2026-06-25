using DVLDBusinessLayer;
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
    public partial class FrmUserDetails : Form
    {
        private int _UserID;
        private clsUser _User;

        public event Action<bool> OnPersonUpdated;

        public FrmUserDetails(int UserID)
        {
            InitializeComponent();
            
            _User = clsUser.Find(UserID);
            if (_User != null)
            {
                ctrlPersonInfoCard1.SetPerson(_User.PersonID);

                ctrlPersonInfoCard1.PersonUpdated += CtrlPersonInfoCard1_PersonUpdated;
            }

        }

        private void CtrlPersonInfoCard1_PersonUpdated(object sender, ctrlPersonInfoCard.PersonUpdatedEventArgs e)
        {
            if (e.Success)
            {
                ctrlPersonInfoCard1.RefreshData();

                OnPersonUpdated?.Invoke(true);
            }
        }
        // =========================
        // LOAD LOGIN INFO
        // =========================
        private void LoadLoginInfo()
        {
            LbUserID.Text = _User.UserID.ToString();
            LbUserName.Text = _User.UserName;
            LbIsActive.Text = _User.IsActive ? "Yes" : "No";
        }
        private void FrmUserDetails_Load(object sender, EventArgs e)
        {
            LoadLoginInfo();
        }

        private void BntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
