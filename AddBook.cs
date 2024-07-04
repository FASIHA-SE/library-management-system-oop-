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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace project
{
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void Save()
        {
            if (bnametxt.Text != "" && bauthortxt.Text != "" && bpubtxt.Text != "" && bdatetxt.Text != "" && bpricetxt.Text != "" && bquantitytxt.Text != "")
            {
                string bookName = bnametxt.Text;
                string bookAuthorName = bauthortxt.Text;
                string bookPublication = bpubtxt.Text;
                string bookPurchaseDate = bdatetxt.Text;
                string bookPrice = bpricetxt.Text;
                string bookQuantity = bquantitytxt.Text;
                switch (dropdown.Text)
                {
                    case "Database":
                        {
                            Database obj = new Database(bookName, bookAuthorName, bookPublication, bookPrice, bookQuantity, bookPurchaseDate);
                            obj.inserting();

                            break;
                        }
                    case "Object-Orinted Programming":
                        {
                            OOP obj = new OOP(bookName, bookAuthorName, bookPublication, bookPrice, bookQuantity, bookPurchaseDate);
                            obj.inserting();
                            break;
                        }
                    case "Mathematics":
                        {
                            Mathematics obj = new Mathematics(bookName, bookAuthorName, bookPublication, bookPrice, bookQuantity, bookPurchaseDate);
                            obj.inserting();
                            break;
                        }
                    case "Physics":
                        {
                            Physics obj = new Physics(bookName, bookAuthorName, bookPublication, bookPrice, bookQuantity, bookPurchaseDate);
                            obj.inserting();
                            break;
                        }
                    case "Marketing":
                        {
                            Marketing obj = new Marketing(bookName, bookAuthorName, bookPublication, bookPrice, bookQuantity, bookPurchaseDate);
                            obj.inserting();
                            break;
                        }
                    default:
                        {
                            OtherBooks obj = new OtherBooks(bookName, bookAuthorName, bookPublication, bookPrice, bookQuantity, bookPurchaseDate);
                            obj.inserting();
                            break;
                        }
                }

                MessageBox.Show("Data Saved ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bnametxt.Clear();
                bauthortxt.Clear();
                bpubtxt.Clear();
                bpricetxt.Clear();
                bquantitytxt.Clear();
            }
            else
            {
                MessageBox.Show("Empty Field Not Allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            Save();
        }


        private void Cancel()
        {
            this.Close();
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure? This Will Delete your Unsave Data", "ARE YOU SURE?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Cancel();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
