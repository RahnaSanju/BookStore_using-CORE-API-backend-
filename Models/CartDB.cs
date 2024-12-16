using Azure.Core;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace BookStoreAPI.Models
{
    public class CartDB
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-8PBBHUD\SQLEXPRESS;database=BookStoreDB;integrated security=true;TrustServerCertificate=True");

        public string InsertCart(Cart objCart)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Insert_Cart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usrid", objCart.User_Id);
                cmd.Parameters.AddWithValue("@bkid", objCart.Book_Id);
                cmd.Parameters.AddWithValue("@qty", objCart.Qty);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Inserted Successfully");

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }

        public string UpdateCart(Cart objCart)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Update_Cart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usrid", objCart.User_Id);
                cmd.Parameters.AddWithValue("@bkid", objCart.Book_Id);
                cmd.Parameters.AddWithValue("@qty", objCart.Qty);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Updated Successfully");

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }

        public List<Cart> ViewCart()
        {
            var list = new List<Cart>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_view_Cart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var getdata = new Cart
                    {
                        User_Id= Convert.ToInt32(dr["User_Id"]),
                        Book_Id = Convert.ToInt32(dr["Book_Id"]),
                        Book_Name = dr["Book_Name"].ToString(),
                        Qty = Convert.ToInt32(dr["Qty"])
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


        public string DeleteCart(int userid,int bookid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_delete_Cart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usrid", userid);
                cmd.Parameters.AddWithValue("@bkid", bookid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Deleted Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }


        public List<Cart> ViewCartwithUserID(int userid)
        {
            try
            {
                var list = new List<Cart>();
                SqlCommand cmd = new SqlCommand("sp_view_Cart_WithId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usrid", userid);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var getdata = new Cart
                    {
                        User_Id = Convert.ToInt32(dr["User_Id"]),
                        Book_Id = Convert.ToInt32(dr["Book_Id"]),
                        Book_Name = dr["Book_Name"].ToString(),
                        Qty = Convert.ToInt32(dr["Qty"])
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


        //public List<Cart> ViewCartwithUserID(Cart objCart)
        //{
        //    try
        //    {
        //        var list = new List<Cart>();
        //        SqlCommand cmd = new SqlCommand("sp_view_Cart_WithId", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@usrid", objCart.User_Id);
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            var getdata = new Cart
        //            {
        //                Book_Id = Convert.ToInt32(dr["Book_Id"]),
        //                Book_Name = dr["Book_Name"].ToString(),
        //                Qty = Convert.ToInt32(dr["Qty"])
        //            };
        //            list.Add(getdata);
        //        }
        //        con.Close();
        //        return list;
        //    }
        //    catch (Exception)
        //    {
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //        throw;
        //    }
        //}


    }
}
