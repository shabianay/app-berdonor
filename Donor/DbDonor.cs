using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Donor
{
    internal class DbDonor
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=list";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySql Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }

        public static void AddIdentity(Donor std)
        {
            string sql = "INSERT INTO list_table VALUES (NULL, @ListName, @ListBirth, @ListGender, @ListEmail, @ListPhone, @ListAddress, @ListBloodGroup, @ListOccupation, NULL)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@ListName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@ListBirth", MySqlDbType.VarChar).Value = std.Birth;
            cmd.Parameters.Add("@ListGender", MySqlDbType.VarChar).Value = std.Gender;
            cmd.Parameters.Add("@ListEmail", MySqlDbType.VarChar).Value = std.Email;
            cmd.Parameters.Add("@ListPhone", MySqlDbType.VarChar).Value = std.Phone;
            cmd.Parameters.Add("@ListAddress", MySqlDbType.VarChar).Value = std.Address;
            cmd.Parameters.Add("@ListBloodGroup", MySqlDbType.VarChar).Value = std.BloodGroup;
            cmd.Parameters.Add("@ListOccupation", MySqlDbType.VarChar).Value = std.Occupation;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Donors not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void UpdateDonors(Donor std, string id)
        {
            string sql = "UPDATE list_table SET Name = @ListName, Birth = @ListBirth, Gender = @ListGender, Email = @ListEmail, Phone = @ListPhone, Address = @ListAddress, BloodGroup = @ListBloodGroup, Occupation = @ListOccupation WHERE ID = @ListID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@ListID", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@ListName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@ListBirth", MySqlDbType.VarChar).Value = std.Birth;
            cmd.Parameters.Add("@ListGender", MySqlDbType.VarChar).Value = std.Gender;
            cmd.Parameters.Add("@ListEmail", MySqlDbType.VarChar).Value = std.Email;
            cmd.Parameters.Add("@ListPhone", MySqlDbType.VarChar).Value = std.Phone;
            cmd.Parameters.Add("@ListAddress", MySqlDbType.VarChar).Value = std.Address;
            cmd.Parameters.Add("@ListBloodGroup", MySqlDbType.VarChar).Value = std.BloodGroup;
            cmd.Parameters.Add("@ListOccupation", MySqlDbType.VarChar).Value = std.Occupation;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Donors not update. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void DeleteDonors(string id)
        {
            string sql = "DELETE FROM list_table WHERE ID = @ListID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@ListID", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Donors not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgv.DataSource = dt;
            con.Close();
        }
    }
}
