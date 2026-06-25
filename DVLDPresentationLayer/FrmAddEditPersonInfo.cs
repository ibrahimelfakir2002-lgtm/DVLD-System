using DVLDBussinessLayer;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class FrmAddEditPersonInfo : Form
    {
        

        public event Action<int> OnPersonSaved; // حدث جديد للفورم الأب
        public int PersonID { get; set; }
        public FrmAddEditPersonInfo(int personID)
        {
            InitializeComponent();

            ctrlAddEditNewVersion1.PersonID = personID;

            // عند الحفظ
            ctrlAddEditNewVersion1.OnSaveCompleted += (savedPersonID) =>
            {
                if (savedPersonID > 0)
                {
                    this.PersonID = savedPersonID;

                    OnPersonSaved?.Invoke(savedPersonID);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };

            ctrlAddEditNewVersion1.OnCloseRequested += CtrlAddEditNewVersion1_OnCloseRequested;
        }

        // عند طلب الإغلاق من UserControl
        private void CtrlAddEditNewVersion1_OnCloseRequested()
        {
            // الطريقة الأسهل: غلق الـ Form بالكامل
            this.Close();

            // أو إذا أردت فقط إخفاء الـ UserControl:
            // ctrlAddEditNewVersion1.Visible = false;
        }
    }
}