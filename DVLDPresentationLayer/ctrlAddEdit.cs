using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLDPresentationLayer
{
    public partial class ctrlAddEdit : UserControl
    {
        public enum enMode
        {
            Add =0,
            Update = 1
        }
        private enMode _Mode;
        private int _PersonID ;

        private clsPerson _Person;
        private clsCountry _Country;
        public ctrlAddEdit(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            if(PersonID == -1)
            {
                _Mode = enMode.Add;
            }
            else
            {
                _Mode = enMode.Update; 
            }
           
        }


        //private void _LoadPersonData()
        //{
        //    var person = clsPerson.GetPersonByID(_PersonID);

        //    if (person == null)
        //        return;
        //    LbPersonID.Text = (_Mode == enMode. Add) ? "N/A" : _PersonID.ToString();
        //    txtFirstName.Text = person.FirstName;
        //    txtLastName.Text = person.LastName;
        //    txtNationalNumber.Text = person.NationalNo;
        //}
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {

                CboxCountries.Items.Add(row["CountryName"]);

            }

        }
        private void _LoadData()
        {

            _FillCountriesInComoboBox();
            CboxCountries.SelectedIndex = 0;

            if (_Mode == enMode.Add)
            {
                LblMode.Text = "Add New Contact";
                _Person = new clsPerson();
                return;
            }

            _Person = clsPerson.GetPersonByID(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Contact with ID = " + _PersonID);

                return;
            }

            LblMode.Text = "Edit Contact ID = " + _PersonID;
            LbPersonID.Text = _Person.PersonID.ToString();
          

       


        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            
                if (string.IsNullOrWhiteSpace(txtNationalNumber.Text))
                {
                    errorProvider1.SetError(txtNationalNumber, "Required");
                    e.Cancel = true;
                    return;
                }

                bool exists;

                if (_Mode == enMode.Add)
                    exists = clsPerson.IsNationalNumberExists(txtNationalNumber.Text);
                else
                    exists = clsPerson.IsNationalNumberExists(txtNationalNumber.Text, _PersonID);

                if (exists)
                {
                    errorProvider1.SetError(txtNationalNumber, "Already exists");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtNationalNumber, "");
                }
            }

        private void ctrlAddEdit_Load(object sender, EventArgs e)
        {
            _LoadData();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
