using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
namespace BookStoreAPI.Models
{
    public class ConnectionCls
    {
        SqlConnection con;
        SqlCommand cmd;

        public ConnectionCls()
        {
            con = new SqlConnection(@"server=DESKTOP-8PBBHUD\SQLEXPRESS;database=BookStoreDB;integrated security=true");
        }

        public int Fn_ExecNonQuery(String SqlQuery) //insert , delete, update
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(SqlQuery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public string Fn_ExecScalar(String SqlQuery) //scalar/aggregate functions
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(SqlQuery, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;
        }

        public SqlDataReader Fn_ExecReader(String SqlQuery) //Select
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(SqlQuery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public DataSet Fn_ExecAdapter(String SqlQuery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(SqlQuery, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataTable Fn_ExecDataTable(String SqlQuery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(SqlQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
