using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using WarehouseApp.BLL;

namespace WarehouseApp.DAL
{
    class LoginDAL
    {
        //Connection string stored in varilble
        static string connStirngSql = ConfigurationManager.ConnectionStrings["WarehouseApp.Properties.Settings.StoreConnectionString"].ConnectionString;
        

        public bool CheckLogin(LoginBLL lBLL)
        {
            bool success = false;

            SqlConnection conn = new SqlConnection(connStirngSql);
            DataTable dt = new DataTable();
            
            try
            {
                //Sql query to check credentials
                string sql = "SELECT username, password, user_type FROM tbl_users WHERE username='"+lBLL.Username+"' AND password='"+lBLL.Password+"'";

                //SqlCommand cmd = new SqlCommand(sql, conn);

                //cmd.Parameters.AddWithValue("@username", lBLL.Username);
                //cmd.Parameters.AddWithValue("@password", lBLL.Password);
                //cmd.Parameters.AddWithValue("@user_type", lBLL.UserType);
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                conn.Open();

                da.Fill(dt);

                //int rows = cmd.ExecuteNonQuery();
                if (dt.Rows.Count > 0)
                {
                    success = true;

                }
                else
                {
                    success = false;
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

            return success;

        }

        public DataTable Select(LoginBLL lBLL)
        {
            //To connect to database
            SqlConnection conn = new SqlConnection(connStirngSql);
            //To hold the data from database
            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "SELECT id, user_type FROM tbl_users WHERE username='" + lBLL.Username + "' AND password='" + lBLL.Password + "'";
                //for executing command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //getting data from database
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //database connection open
                conn.Open();
                //fill data in the data table
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                //throw message if any error occur
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //close database connection
                conn.Close();
            }
            //return value in data table
            return dt;

        }

    }
}
