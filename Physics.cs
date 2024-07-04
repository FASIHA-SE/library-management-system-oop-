using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    internal class Physics : BookShelf
    {
        int id;
        string catagory;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;");
        public Physics(string name, string Auname, string bp, string price, string quantity, string bpdate)
        {
            this.id = bookId();
            bookName = name;
            AuthorName = Auname;
            Book_publication = bp;
            Book_price = price;
            Quantity = quantity;
            Book_purchase_date = bpdate;
            catagory = "Physics";
        }
        internal protected override void inserting()
        {
            int bookid = bookId();
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO NewBook(book_id, bname, bAuthor, bPublish, bDate, bPrice, bQuantity, bCatagory) VALUES (@bookId, @bookName, @AuthorName, @Book_publication, @Book_purchase_date, @Book_price, @Quantity, @Catagory)", con);
            cmd.Parameters.AddWithValue("@bookId", bookid);
            cmd.Parameters.AddWithValue("@bookName", bookName);
            cmd.Parameters.AddWithValue("@AuthorName", AuthorName);
            cmd.Parameters.AddWithValue("@Book_publication", Book_publication);
            cmd.Parameters.AddWithValue("@Book_purchase_date", Book_purchase_date);
            cmd.Parameters.AddWithValue("@Book_price", Book_price);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Catagory", catagory);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Saved ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
