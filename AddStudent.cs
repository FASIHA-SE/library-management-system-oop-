using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace project
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("confirm?","Alert",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Close();
            }

            
        }

        private void Refresh()
        {
            txtSname.Clear();
            txtEno.Clear();
            txtDept.Clear();
            txtSem.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }
        private void btnRef_Click(object sender, EventArgs e)
        {
            Refresh();
        }


        private void Save()
        {
            string name = txtSname.Text;
            string enroll = txtEno.Text;
            string dep = txtDept.Text;
            string sem = txtSem.Text;
            string mobile = txtContact.Text;
            string email = txtEmail.Text;


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd.CommandText = "insert into NewStudents(sname,enroll,dep,sem,contact,email)Values ('" + name + "','" + enroll + "','" + dep + "','" + sem + "','" + mobile + "','" + email + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data saved", "Sucsess", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        //Restriction
        
        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            TextBox txtContact = sender as TextBox;
            int maxValue = 14;
            if (txtContact != null && txtContact.Text.Length > maxValue)
            {
                MessageBox.Show("Value exceeds the limit of " + maxValue);
                txtContact.Text = txtContact.Text.Substring(0, maxValue);
                txtContact.SelectionStart = maxValue;
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }

            
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == '+' && textBox != null && textBox.Text.Contains("+"))
            {
                e.Handled = true;
            }
        }
    }
}
