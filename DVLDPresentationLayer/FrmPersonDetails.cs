using DVLDBussinessLayer;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class FrmPersonDetails : Form
    {
        public event Action<bool> OnPersonUpdated;

        public FrmPersonDetails(int PersonID)
        {
            InitializeComponent();


            ctrlPersonInfoCard1.AllowEdit = true;
            ctrlPersonInfoCard1.SetPerson(PersonID);

            ctrlPersonInfoCard1.PersonUpdated += CtrlPersonInfoCard1_PersonUpdated;

        }

        private void CtrlPersonInfoCard1_PersonUpdated(object sender, ctrlPersonInfoCard.PersonUpdatedEventArgs e)
        {
            if (e.Success)
            {
                ctrlPersonInfoCard1.RefreshData();

                OnPersonUpdated?.Invoke(true);
            }
        }

        private void BntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}