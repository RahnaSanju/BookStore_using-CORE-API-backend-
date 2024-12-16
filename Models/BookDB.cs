using Microsoft.Data.SqlClient;
using System.Data;

namespace BookStoreAPI.Models
{
    public class BookDB
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-8PBBHUD\SQLEXPRESS;database=BookStoreDB;integrated security=true;TrustServerCertificate=True");

        public List<Book> ViewAllBooks()
        {
            var list= new List<Book>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Books",con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr=cmd.ExecuteReader();
                while(dr.Read())
                {
                    var getdata = new Book
                    {
                        Book_Id = Convert.ToInt32(dr["Book_Id"]),
                        Book_Name = dr["Book_Name"].ToString(),
                        Book_Author = dr["Book_Author"].ToString(),
                        Book_Price = Convert.ToDouble(dr["Book_Price"])
                    };
                    list.Add(getdata);
                }
                con.Close();
                return list;
               
            }
            catch(Exception)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }


        //public List<Book> SearchBooks(Book objBook)
        public List<Book> SearchBooks(string title,string auth, double price)
        {
            string qry = "";
            var list = new List<Book>();
            try
            {
                if (title != null)
                {
                    qry = " and book_name like '%"+title+"%'";
                }
                if (auth != null)
                {
                    qry = " and book_author like '%" + auth + "%'";
                }
                if (price > 0)
                {
                    qry = " and book_price < " + price;
                }

                SqlCommand cmd = new SqlCommand("sp_BookSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var getdata = new Book
                    {
                        Book_Id = Convert.ToInt32(dr["Book_Id"]),
                        Book_Name = dr["Book_Name"].ToString(),
                        Book_Author = dr["Book_Author"].ToString(),
                        Book_Price = Convert.ToDouble(dr["Book_Price"])
                    };
                    list.Add(getdata);
                }
                con.Close();
                return list;

            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }

    }
}
