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
    public partial class FormDonorList : Form
    {
        FormDonor form;

        public FormDonorList()
        {
            InitializeComponent();
            form = new FormDonor(this);
        }

        public void Display()
        {
            DbDonor.DisplayAndSearch("Select ID, Name, Birth, Gender, Email, Phone, Address, BloodGroup, Occupation FROM list_table", dataGridView);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.SaveInfo();
            form.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbDonor.DisplayAndSearch("Select ID, Name, Birth, Gender, Email, Phone, Address, BloodGroup, Occupation FROM list_table WHERE Name LIKE'%" + txtSearch.Text +"%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                //Edit
                form.Clear();
                form.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.name = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.birth = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.gender = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.email = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.phone = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.address = dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.bloodgroup = dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.occupation = dataGridView.Rows[e.RowIndex].Cells[10].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            if(e.ColumnIndex == 1)
            {
                //Delete
                if(MessageBox.Show("Are you want to delete donor record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbDonor.DeleteDonors(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormDonorList_Shown_1(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

