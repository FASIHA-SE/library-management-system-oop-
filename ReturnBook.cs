using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;

namespace project
{
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void BookREturn()
        {
            txtEnterEnrollment.Clear();
        }
        private void ReturnBook_Load(object sender, EventArgs e)
        {
            BookREturn();
        }


        private void SSearch()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from IRBook where std_enroll = ' " + txtEnterEnrollment.Text + " ' and book_return_date IS NULL";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid id OR No Book Issued ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            SSearch();
        }


        private void Exit()
        {
            if (MessageBox.Show("Are you sure ", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();

            }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
           Exit();
        }

        string bname;
        string bdate;
        Int64 rowid;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            }
            txtBookName.Text = bname;
            txtBookIssueDate.Text = bdate;
        }


        private void Return()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd.CommandText = "update IRBook set book_return_date  = ' " + dateTimePicker1.Text + " ' where std_enroll = ' " + txtEnterEnrollment.Text + " ' and id = " + rowid + " ";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Return SuccessFull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReturnBook_Load(this, null);
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Return();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
