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

namespace project
{
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }

        private void BookIssue()
        {
            string ConnectionString = "Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;";
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand("select bname from NewBook", con);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    comboBoxBooks.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
        }
        private void IssueBook_Load(object sender, EventArgs e)
        {
            BookIssue();
        }

       
        private void SearchEn()
        {
            if (txtEnrollment.Text != "")
            {
                string eid = txtEnrollment.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudents where enroll = '" + eid + "'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                if (DS.Tables[0].Rows.Count != 0)

                {
                    txtName.Text = DS.Tables[0].Rows[0][1].ToString();
                    txtDepartment.Text = DS.Tables[0].Rows[0][3].ToString();
                    txtSemester.Text = DS.Tables[0].Rows[0][4].ToString();
                    txtContact.Text = DS.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = DS.Tables[0].Rows[0][6].ToString();

                }
                else
                {
                    txtName.Clear();
                    txtDepartment.Clear();
                    txtSemester.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    MessageBox.Show("Invalid Enrollment No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEn();
        }

        int count;
        private void issue()
        {
            if (txtName.Text != "")
            {
                if (comboBoxBooks.SelectedIndex != -1 && count <= 2)
                {
                    string enroll = txtEnrollment.Text;
                    string sname = txtName.Text;
                    string dept = txtDepartment.Text;
                    string sem = txtSemester.Text;
                    string contact = txtContact.Text;
                    string email = txtEmail.Text;
                    string bookname = comboBoxBooks.Text;
                    string bookIssueDate = dateTimePicker.Text;


                    string eid = txtEnrollment.Text;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = cmd.CommandText = "insert into IRBook (std_enroll ,std_name,std_dep,std_sem,std_contact,std_email,book_name, book_issue_date ) values (' " + enroll + " ', ' " + sname + " ',' " + dept + " '" +
                        " , ' " + sem + " ', ' " + contact + " ', ' " + email + " ' ,' " + bookname + " ' , ' " + bookIssueDate + " ')";

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                
            }
            else
            {
                MessageBox.Show("Enter Valid Enrollment NO.", "ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            issue();
        }


        private void Entext()
        {
            if (txtEnrollment.Text == "")
            {
                txtName.Clear();
                txtDepartment.Clear();
                txtSemester.Clear();
                txtEmail.Clear();
                txtContact.Clear();
            }
        }
        private void txtEnrollment_TextChanged(object sender, EventArgs e)
        {
            Entext();
        }


        private void refresh()
        {
            txtEnrollment.Clear();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void exit()
        {
            this.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                exit();
            }
        }
    }
}

