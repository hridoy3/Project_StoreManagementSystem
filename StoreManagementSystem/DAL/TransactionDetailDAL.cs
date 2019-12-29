using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using WarehouseApp.BLL;

namespace WarehouseApp.DAL
{
    class TransactionDetailDAL
    {
        string connStringSql = ConfigurationManager.ConnectionStrings["WarehouseApp.Properties.Settings.StoreConnectionString"].ConnectionString;
        #region insert into database

        public bool InsertTransacionDetail(TransactionDetailsBLL bll)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(connStringSql);

            string sql = "INSERT INTO tbl_transaction_details (product_id, rate, qty, total, dea_cust_id, transactions_id, added_date, added_by) VALUES (@product_id, @rate, @qty, @total, @dea_cust_id, @transactions_id, @added_date, @added_by)";
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@product_id", bll.ProductId);
                cmd.Parameters.AddWithValue("@total", bll.Total);
                cmd.Parameters.AddWithValue("@dea_cust_id", bll.Dea_Cust_Id);
                cmd.Parameters.AddWithValue("@added_date", bll.AddedDate);
                cmd.Parameters.AddWithValue("@added_by", bll.AddedBy);
                cmd.Parameters.AddWithValue("@rate", bll.Rate);
                cmd.Parameters.AddWithValue("@qty", bll.Qty);
                cmd.Parameters.AddWithValue("@transactions_id", bll.TransactionID);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
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
