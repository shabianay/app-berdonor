using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donor
{
    public partial class FormDonor : Form
    {
        private readonly FormDonorList _parent;
        public string id, name, birth, gender, email, phone, address, bloodgroup, occupation;

        public FormDonor(FormDonorList parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            lbltext.Text = "Update Donors";
            btnSave.Text = "Update";
            txtName.Text = name;
            txtBirth.Text = birth;
            txtGender.Text = gender;
            txtEmail.Text = email;
            txtPhone.Text = phone;
            txtAddress.Text = address;
            txtBlood.Text = bloodgroup;
            txtOccupation.Text = occupation;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Donors name is Empty ( > 3).");
                return;
            }
            if (txtBirth.Text.Trim().Length < 1)
            {
                MessageBox.Show("Donors date of birth is Empty ( > 1).");
                return;
            }
            if (txtGender.Text.Trim().Length < 3)
            {
                MessageBox.Show("Donors gender is Empty ( > 3).");
                return;
            }
            if (txtEmail.Text.Trim().Length < 1)
            {
                MessageBox.Show("Donors email is Empty ( > 1).");
                return;
            }
            if (txtPhone.Text.Trim().Length < 1)
            {
                MessageBox.Show("Donors phone is Empty ( > 1).");
                return;
            }
            if (txtAddress.Text.Trim().Length < 3)
            {
                MessageBox.Show("Donors address is Empty ( > 1).");
                return;
            }
            if (txtBlood.Text.Trim().Length < 0)
            {
                MessageBox.Show("Donors blood group is Empty ( > 1).");
                return;
            }
            if (txtOccupation.Text.Trim().Length < 3)
            {
                MessageBox.Show("Donors occupation is Empty ( > 1).");
                return;
            }
            if (btnSave.Text == "Save")
            {
                Donor std = new Donor(txtName.Text.Trim(), txtBirth.Text.Trim(), txtGender.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtAddress.Text.Trim(), txtBlood.Text.Trim(), txtOccupation.Text.Trim());
                DbDonor.AddIdentity(std);
                Clear();
            }
            if (btnSave.Text == "Update")
            {
                Donor std = new Donor(txtName.Text.Trim(), txtBirth.Text.Trim(), txtGender.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtAddress.Text.Trim(), txtBlood.Text.Trim(), txtOccupation.Text.Trim());
                DbDonor.UpdateDonors(std, id);
            }

            _parent.Display();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        public void SaveInfo()
        {
            lbltext.Text = "Add Donors";
            btnSave.Text = "Save";
        }

        public void Clear()
        {
            txtName.Text = txtBirth.Text = txtGender.Text = txtEmail.Text = txtPhone.Text = txtAddress.Text = txtBlood.Text = txtOccupation.Text = String.Empty;
        }

        private void FormDonor_Load(object sender, EventArgs e)
        {

        }
    }
}
