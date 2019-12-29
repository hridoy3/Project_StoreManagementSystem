using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using WarehouseApp.BLL;

namespace WarehouseApp.DAL
{
    class AuthenticationCheckDAL
    {
        static string connStirngSql = ConfigurationManager.ConnectionStrings["WarehouseApp.Properties.Settings.StoreConnectionString"].ConnectionString;


        public bool CheckLogin(AuthenticationCheckBLL aCBLL)
        {
            bool success = false;

            SqlConnection conn = new SqlConnection(connStirngSql);
            DataTable dt = new DataTable();

            try
            {
                //Sql query to check credentials
                string sql = "SELECT username, password FROM tbl_users WHERE username='" + aCBLL.Username + "' AND password='" + aCBLL.Password + "'";

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
    }
}
