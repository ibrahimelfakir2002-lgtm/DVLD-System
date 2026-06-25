using DVLDBusinessLayer;
using DVLDBussinessLayer;
using DVLDDataAccessLayer;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class FrmLogin : Form
    {
        private clsUser _User;

        public FrmLogin()
        {
            InitializeComponent();
        }

        // 🔥 حفظ Remember Me
        private void SaveRememberMe()
        {
            Properties.Settings.Default.RememberMe = chkRememberMe.Checked;

            if (chkRememberMe.Checked)
                Properties.Settings.Default.Username = txtUserName.Text;
            else
                Properties.Settings.Default.Username = "";

            Properties.Settings.Default.Save();
        }

        // 🔥 تحميل البيانات عند فتح الفورم
        private void LoadRememberMe()
        {
            if (Properties.Settings.Default.RememberMe)
            {
                txtUserName.Text = Properties.Settings.Default.Username;
                chkRememberMe.Checked = true;
            }
            else
            {
                txtUserName.Text = "";
                chkRememberMe.Checked = false;
            }

            txtPassword.Text = ""; // دائما فارغة
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _User = clsUser.GetUserByUserNameAndPassword(
                txtUserName.Text,
                txtPassword.Text
            );

            if (_User == null)
            {
                MessageBox.Show("Wrong Try again");
                return;
            }

            clsGlobalSettings.CurrentUser = _User;

           

            // 🔥 حفظ Remember Me بعد نجاح الدخول
            SaveRememberMe();

            FrmMainMenu frm = new FrmMainMenu();
            frm.Show();

            // 🔥 بعد الرجوع من الفورم الثاني
            txtPassword.Text = "";

            this.Hide();

          
            frm.FormClosed += (s, args) => this.Show();

            frm.Show();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            LoadRememberMe();
        }

        // 🔥 مهم جدًا: عند الرجوع للفورم
        private void FrmLogin_Activated(object sender, EventArgs e)
        {
            LoadRememberMe();
        }
    }
}