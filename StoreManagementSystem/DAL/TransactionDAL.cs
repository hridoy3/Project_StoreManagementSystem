using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using WarehouseApp.BLL;

namespace WarehouseApp.DAL
{
    class TransactionDAL
    {
        string connStringSql = ConfigurationManager.ConnectionStrings["WarehouseApp.Properties.Settings.StoreConnectionString"].ConnectionString;

        #region insert into database

        public bool InsertTransaction(TransactionsBLL bll, out int transacitonId)
        {
            bool isSuccess = false;

            transacitonId = -1;

            SqlConnection conn = new SqlConnection(connStringSql);

            string sql = "INSERT INTO tbl_transactions (type, dea_cust_id, grandTotal, transaction_date, tax, discount, added_by) VALUES (@type, @dea_cust_id, @grandTotal, @transaction_date, @tax, @discount, @added_by); SELECT @@IDENTITY;" ;
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", bll.Type);
                cmd.Parameters.AddWithValue("@dea_cust_id", bll.Dea_Cus_tId);
                cmd.Parameters.AddWithValue("@grandTotal", bll.GrandTotal);
                cmd.Parameters.AddWithValue("@transaction_date", bll.TransactionDate);
                cmd.Parameters.AddWithValue("@added_by", bll.AddedBy);
                cmd.Parameters.AddWithValue("@discount", bll.Discount);
                cmd.Parameters.AddWithValue("@tax", bll.Tax);

                conn.Open();

                object o = cmd.ExecuteScalar();

                if (o != null)
                {
                    transacitonId = int.Parse(o.ToString());
                    //MessageBox.Show(transacitonId.ToString());
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


        #region Get data table

        public DataTable DisplayAllTransacitons()
        {
            //Connect to dataBase
            SqlConnection conn = new SqlConnection(connStringSql);
            //create data table
            DataTable dt = new DataTable();
            try
            {
                //Sql query
                //string sql = "SELECT * FROM tbl_products";
                string sql = "SELECT * FROM tbl_transactions";
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

        #region Get data table

        public DataTable DisplayTransacitonsAsType(string type)
        {
            //Connect to dataBase
            SqlConnection conn = new SqlConnection(connStringSql);
            //create data table
            DataTable dt = new DataTable();
            try
            {
                //Sql query
                //string sql = "SELECT * FROM tbl_products";
                string sql = string.Format("SELECT * FROM tbl_transactions where type=@type");
                //for execution commands
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type",type);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
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
    }
}
