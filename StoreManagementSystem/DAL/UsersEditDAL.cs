using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WarehouseApp.BLL;

namespace WarehouseApp.DAL
{
    class UsersEditDAL
    {
        static string connStringSql = ConfigurationManager.ConnectionStrings["WarehouseApp.Properties.Settings.StoreConnectionString"].ConnectionString;

        public DataTable GetAllUsers()
        {
            SqlConnection conn = new SqlConnection(connStringSql);
            string query = string.Format("SELECT password, contact, email, address, modified_date FROM tbl_users WHERE id={0}", FormLogin.loggedInUserId);
            
            SqlCommand cmd = new SqlCommand(query, conn);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }


       
        public bool Update(UsersEditBLL u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "UPDATE tbl_users SET email=@email, password=@password, contact=@contact, address=@address, modified_date=@modified_date WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", u.Email);
                cmd.Parameters.AddWithValue("@id", FormLogin.loggedInUserId);
                cmd.Parameters.AddWithValue("@password", u.Password);
                cmd.Parameters.AddWithValue("@contact", u.Contact);
                //cmd.Parameters.AddWithValue("@area", u.Area);
                cmd.Parameters.AddWithValue("@address", u.Address);
                cmd.Parameters.AddWithValue("@modified_date", u.modified_date);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }



    }


}

