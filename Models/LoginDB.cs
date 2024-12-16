using Microsoft.Data.SqlClient;
using System.Data;

namespace BookStoreAPI.Models
{
    public class LoginDB
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-8PBBHUD\SQLEXPRESS;database=BookStoreDB;integrated security=true;TrustServerCertificate=True");

        public int CheckUser(string username,string password)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[sp_UserLogin]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usrnm", username);
                cmd.Parameters.AddWithValue("@pwd", password);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@status";
                sp.DbType = DbType.Int32;
                sp.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sp);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
                return (Convert.ToInt32(sp.Value));
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

        public int GetRegIDfromDB(string username, string password)
        {
            int regid = 0;
            SqlCommand cmd = new SqlCommand("[sp_GetUserID]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usrnm", username);
            cmd.Parameters.AddWithValue("@pwd", password);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                regid = Convert.ToInt32(dr["user_id"]);
            }
            con.Close();
            return regid;
        }

    }

    
}
