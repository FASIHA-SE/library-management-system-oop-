using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    internal abstract class BookShelf
    {
        protected string bookName { get; set; }
        protected string AuthorName { get; set; }
        protected string Book_publication { get; set; }
        protected string Book_purchase_date { get; set; }
        protected string Book_price { get; set; }
        protected string Quantity { get; set; }
        SqlConnection con;
        public BookShelf()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-13O7JS7;Initial Catalog=project_library;Integrated Security=True;");
        }
        internal protected int bookId()
        {
            SqlCommand cmd = new SqlCommand($"select max(book_id) from NewBook", con);
            con.Open();
            object result = cmd.ExecuteScalar();
            con.Close();
            return int.Parse(result.ToString()) + 1;
        }
        internal protected abstract void inserting();



    }
}
