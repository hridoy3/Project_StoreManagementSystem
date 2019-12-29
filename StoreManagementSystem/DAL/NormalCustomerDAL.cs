using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using WarehouseApp.BLL;

namespace WarehouseApp.DAL
{
    class NormalCustomerDAL
    {

        string connStringSql = ConfigurationManager.ConnectionStrings["WarehouseApp.Properties.Settings.StoreConnectionString"].ConnectionString;

        #region Get data table

        public DataTable Select()
        {
            //Connect to dataBase
            SqlConnection conn = new SqlConnection(connStringSql);
            //create data table
            DataTable dt = new DataTable();
            try
            {
                //Sql query
                //string sql = "SELECT * FROM tbl_products";
                string sql = "SELECT * FROM tbl_n_customer";
                //for execution commands
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                //
                conn.Open();
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        #endregion


        #region insert into database

        public bool Insert(NormalCustomerBLL bll, out int nCustomerId)
        {
            bool isSuccess = false;

            nCustomerId = -1;

            SqlConnection conn = new SqlConnection(connStringSql);

            string sql = "INSERT INTO tbl_n_customer (name, email, contact, address, added_date, added_by) VALUES (@name, @email, @contact, @address, @added_date, @added_by); SELECT @@IDENTITY;";
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                
                cmd.Parameters.AddWithValue("@name", bll.Name);
                cmd.Parameters.AddWithValue("@email", bll.Email);
                cmd.Parameters.AddWithValue("@added_date", bll.AddedDate);
                cmd.Parameters.AddWithValue("@added_by", bll.AddedBy);
                cmd.Parameters.AddWithValue("@contact", bll.Contact);
                cmd.Parameters.AddWithValue("@address", bll.Address);


                conn.Open();
                object o = cmd.ExecuteScalar();

                if (o != null)
                {
                    nCustomerId = int.Parse(o.ToString());
                    isSuccess = true;
                }
                else
                    isSuccess = false;

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

        #endregion



    }
}
