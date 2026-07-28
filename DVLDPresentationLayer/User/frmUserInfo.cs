using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer.User
{
    public partial class frmUserInfo : Form
    {
        private int _UseriD;
        public frmUserInfo(int UserId)
        {
            InitializeComponent();

            _UseriD = UserId; 
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_UseriD);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
