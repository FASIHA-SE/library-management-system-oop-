using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;

namespace project
{
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void StudentView()
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudents";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }


        private void ViewStudent_Load(object sender, EventArgs e)
        {
           
           StudentView();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //Encapsulation
        private void Delete()
        {
            if (MessageBox.Show("Data will be Delete.confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewStudents where stdid=" + rowid + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }


        //Encapsulation

        private void Update()
        {
            if (MessageBox.Show("Data will be Update.confirm?", "Sucess", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string ConnectionString = "Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;";
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();

                string sname = txtSname.Text;
                string enroll = txtSEno.Text;
                string dep = txtSdept.Text;
                string sem = txtSem.Text;
                string contact = txtContact.Text;
                string email = txtEmail.Text;
                string Query = "update NewStudents set Sname = '" + sname + "' ,enroll = '" + enroll + "',dep ='" + dep + "',sem='" + sem + "',Contact='" + contact + "',email='" + email + "' where stdid=" + rowid + "";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                con.Close();


            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }
        private void txtPDate_ValueChanged(object sender, EventArgs e)
        {
        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtPublication_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //Encapsulation
        private void Search()
        {
            if (txtSearch.Text != "")
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudents where enroll Like '" + txtSearch.Text + "%'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }


            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select* from NewStudents";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            Search();

        }


       

        int book_id;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                book_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select* from NewStudents where stdid="+book_id+"";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            rowid = Int64.Parse(DS.Tables[0].Rows[0][0].ToString());

            txtSname.Text = DS.Tables[0].Rows[0][1].ToString();
            txtSEno.Text = DS.Tables[0].Rows[0][2].ToString();
            txtSdept.Text = DS.Tables[0].Rows[0][3].ToString();
            txtSem.Text = DS.Tables[0].Rows[0][4].ToString();
            txtContact.Text = DS.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = DS.Tables[0].Rows[0][6].ToString();
        }

        //Encapsulation
        private void Refresh()
        {
            txtSearch.Clear();
            panel2.Visible = false;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();

        }


    }
}
