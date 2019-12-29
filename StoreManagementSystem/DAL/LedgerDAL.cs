using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using WarehouseApp.BLL;

namespace WarehouseApp.DAL
{
    class LedgerDAL
    {

        
        string connStringSql = ConfigurationManager.ConnectionStrings["WarehouseApp.Properties.Settings.StoreConnectionString"].ConnectionString;


        #region Insert While Transaction

        public bool Insert(LedgerBLL bll)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(connStringSql);

            string sql = "INSERT INTO tbl_ledger (title, rate, qty, type, total, tax, discount, grandTotal, dea_cust_id, bill, balance, transaction_date, added_by, product_id, n_cust_id) VALUES (@title, @rate, @qty, @type, @total, @tax, @discount, @grandTotal, @dea_cust_id, @bill, @balance, @transaction_date, @added_by, @product_id, @n_cust_id)";
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@product_id", bll.Product_id);
                cmd.Parameters.AddWithValue("@total", bll.Total);
                cmd.Parameters.AddWithValue("@dea_cust_id", bll.dea_cust_id);
                cmd.Parameters.AddWithValue("@transaction_date", bll.transaction_date);
                cmd.Parameters.AddWithValue("@added_by", bll.AddedBy);
                cmd.Parameters.AddWithValue("@rate", bll.Rate);
                cmd.Parameters.AddWithValue("@qty", bll.Qty);
                cmd.Parameters.AddWithValue("@n_cust_id", bll.n_cust_id);
                cmd.Parameters.AddWithValue("@type",bll.Type);
                cmd.Parameters.AddWithValue("@tax",bll.Tax);
                cmd.Parameters.AddWithValue("@discount",bll.Discount);
                cmd.Parameters.AddWithValue("@grandTotal",bll.GrandTotal);
                cmd.Parameters.AddWithValue("@balance",bll.Balance);
                cmd.Parameters.AddWithValue("@title",bll.Title);
                cmd.Parameters.AddWithValue("@bill",bll.Bill);



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

        #region Select Data from Database

        public DataTable Select()
        {
            //To connect to database
            SqlConnection conn = new SqlConnection(connStringSql);
            //To hold the data from database
            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "select tbl_ledger.id, tbl_ledger.title, tbl_ledger.rate, tbl_ledger.qty, total, tbl_ledger.type, tax,discount,grandTotal,bill,balance,transaction_date, modified_by, tbl_ledger.modified_date, dea_cust_id, n_cust_id, tbl_ledger.added_by, tbl_users.name from tbl_ledger, tbl_users where(tbl_users.id = tbl_ledger.added_by)";
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


        #endregion

        #region Search user on dtabase

        public DataTable Search(string keyWord)
        {
            SqlConnection conn = new SqlConnection(connStringSql);
            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "SELECT * FROM tbl_Ledger WHERE id LIKE '%" + keyWord + "%' OR title LIKE '%" + keyWord + "%' OR type LIKE '%" + keyWord + "%'";

                //for executing command
                SqlCommand cmd = new SqlCommand(sql, conn);

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

        #endregion

        #region Update data in database

        public bool Update(LedgerBLL bll)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "UPDATE tbl_Ledger SET title=@title, rate=@rate, qty=@qty, total=@total, type=@type, tax=@tax, discount=@discount, grandTotal=@grandTotal, bill=@bill, balance=@balance, modified_date=@modified_date, modified_by=@modified_by, dea_cust_id=@dea_cust_id, n_cust_id=@n_cust_id, product_id=@product_id WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", bll.Title);
                cmd.Parameters.AddWithValue("@rate", bll.Rate);
                cmd.Parameters.AddWithValue("@qty", bll.Qty);
                cmd.Parameters.AddWithValue("@total", bll.Total);
                cmd.Parameters.AddWithValue("@type", bll.Type);
                //cmd.Parameters.AddWithValue("@area", u.Area);
                cmd.Parameters.AddWithValue("@tax", bll.Tax);
                cmd.Parameters.AddWithValue("@discount", bll.Discount);
                cmd.Parameters.AddWithValue("@grandTotal", bll.GrandTotal);
                cmd.Parameters.AddWithValue("@bill", bll.Bill);
                cmd.Parameters.AddWithValue("@balance", bll.Balance);
                cmd.Parameters.AddWithValue("@modified_date", bll.ModifiedDate);
                cmd.Parameters.AddWithValue("@modified_by", bll.ModifiedBy);
                cmd.Parameters.AddWithValue("@dea_cust_id", bll.dea_cust_id);
                cmd.Parameters.AddWithValue("@n_cust_id", bll.n_cust_id);
                cmd.Parameters.AddWithValue("@Product_id", bll.Product_id);


                cmd.Parameters.AddWithValue("@id", bll.Id);

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

        #endregion

        #region Delete data form database

        public bool Delete(LedgerBLL u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "DELETE FROM tbl_ledger WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", u.Id);

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


        #endregion

        #region Select All regular customer transactions

        public DataTable SelectAllRegularCustomerTransactions()
        {
            //To connect to database
            SqlConnection conn = new SqlConnection(connStringSql);
            //To hold the data from database
            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "SELECT * FROM tbl_ledger";
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


        #endregion
         
        // Regular Customer
        #region Select All Regular Customer Legdger Entries history

        public DataTable SelectAllRegularCustomerLegdgerEntries()
        {
            //To connect to database
            SqlConnection conn = new SqlConnection(connStringSql);
            //To hold the data from database
            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "select tbl_ledger.id, tbl_dea_cust.name, dea_cust_id, tbl_ledger.title, tbl_ledger.rate, tbl_ledger.qty, total, tbl_ledger.type, tax,discount,grandTotal,bill,balance,transaction_date, tbl_ledger.modified_date, tbl_users.name      FROM      tbl_ledger, tbl_dea_cust, tbl_users      WHERE     (tbl_ledger.dea_cust_id = tbl_dea_cust.id) and  (tbl_ledger.type Like '%Sale%' or tbl_ledger.type Like 'Sale Adjustment')     and     (tbl_users.id = tbl_ledger.added_by)";
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


        #endregion

        #region Select Regular Customer Legdger Entries history using regular customer ID

        public DataTable SelectRegularCustomerLegdgerEntriesUsingCustomerID(int dea_cust_id)
        {
            //To connect to database
            SqlConnection conn = new SqlConnection(connStringSql);
            //To hold the data from database
            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "SELECT tbl_ledger.id, tbl_dea_cust.name, dea_cust_id, tbl_ledger.title, tbl_ledger.rate, tbl_ledger.qty, total, tbl_ledger.type, tax,discount,grandTotal,bill,balance,transaction_date, tbl_ledger.modified_date, tbl_users.name      FROM      tbl_ledger, tbl_dea_cust, tbl_users      WHERE     (tbl_ledger.dea_cust_id = tbl_dea_cust.id) and  (tbl_ledger.type Like '%Sal%' or tbl_ledger.type Like 'Adjustment')     and     (tbl_users.id = tbl_ledger.added_by)     and    dea_cust_id=@dea_cust_id";
                //for executing command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@dea_cust_id", dea_cust_id);
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


        #endregion

        // Dealer
        #region Select Dealer Legdger Entries history using regular dealar ID

        public DataTable SelectDealerLegdgerEntriesUsingCustomerID(int dea_cust_id)
        {
            //To connect to database
            SqlConnection conn = new SqlConnection(connStringSql);
            //To hold the data from database
            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "SELECT tbl_ledger.id, tbl_dea_cust.name, dea_cust_id, tbl_ledger.title, tbl_ledger.rate, tbl_ledger.qty, total, tbl_ledger.type, tax,discount,grandTotal,bill,balance,transaction_date, tbl_ledger.modified_date, tbl_users.name      FROM      tbl_ledger, tbl_dea_cust, tbl_users      WHERE     (tbl_ledger.dea_cust_id = tbl_dea_cust.id) and  (tbl_ledger.type Like '%Purchase%' or tbl_ledger.type Like 'Adjustment')     and     (tbl_users.id = tbl_ledger.added_by)     and    dea_cust_id=@dea_cust_id";
                //for executing command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@dea_cust_id", dea_cust_id);
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


        #endregion

        #region Select All Dealer Legdger Entries history

        public DataTable SelectAllDealerLegdgerEntries()
        {
            //To connect to database
            SqlConnection conn = new SqlConnection(connStringSql);
            //To hold the data from database
            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "select tbl_ledger.id, tbl_dea_cust.name, dea_cust_id, tbl_ledger.title, tbl_ledger.rate, tbl_ledger.qty, total, tbl_ledger.type, tax,discount,grandTotal,bill,balance,transaction_date, tbl_ledger.modified_date, tbl_users.name      FROM      tbl_ledger, tbl_dea_cust, tbl_users      WHERE     (tbl_ledger.dea_cust_id = tbl_dea_cust.id) and  (tbl_ledger.type Like '%Purchase%' or tbl_ledger.type Like 'Purchase Adjustment')     and     (tbl_users.id = tbl_ledger.added_by)";
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


        #endregion

        // Normal Customer

        #region Select All normal Legdger Entries history

        public DataTable SelectAllNormalLegdgerEntries()
        {
            //To connect to database
            SqlConnection conn = new SqlConnection(connStringSql);
            //To hold the data from database
            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "select tbl_ledger.id, tbl_n_customer.name, n_cust_id, tbl_ledger.title, tbl_ledger.rate, tbl_ledger.qty, total, tbl_ledger.type, tax,discount,grandTotal,bill,balance,transaction_date, tbl_ledger.modified_date, tbl_users.name from tbl_ledger, tbl_n_customer, tbl_users where(tbl_ledger.n_cust_id = tbl_n_customer.id) and(tbl_users.id = tbl_ledger.added_by)";
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


        #endregion

        #region Select All normal Legdger Sale Entries history

        public DataTable SelectAllNormalLegdgerSaleEntries()
        {
            //To connect to database
            SqlConnection conn = new SqlConnection(connStringSql);
            //To hold the data from database
            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "select tbl_ledger.id, tbl_n_customer.name, dea_cust_id, tbl_ledger.title, tbl_ledger.rate, tbl_ledger.qty, total, tbl_ledger.type, tax,discount,grandTotal,bill,balance,transaction_date, tbl_ledger.modified_date, tbl_users.name from tbl_ledger, tbl_n_customer, tbl_users where(tbl_ledger.n_cust_id = tbl_n_customer.id) and(tbl_ledger.type Like '%Sale%' or tbl_ledger.type Like 'Adjustment Sale') and(tbl_users.id = tbl_ledger.added_by)";
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


        #endregion

        #region Select All normal Legdger Purchase Entries history

        public DataTable SelectAllNormalLegdgerPurchaseEntries()
        {
            //To connect to database
            SqlConnection conn = new SqlConnection(connStringSql);
            //To hold the data from database
            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "select tbl_ledger.id, tbl_n_customer.name, dea_cust_id, tbl_ledger.title, tbl_ledger.rate, tbl_ledger.qty, total, tbl_ledger.type, tax,discount,grandTotal,bill,balance,transaction_date, tbl_ledger.modified_date, tbl_users.name from tbl_ledger, tbl_n_customer, tbl_users where(tbl_ledger.n_cust_id = tbl_n_customer.id) and(tbl_ledger.type Like '%Purchase%' or tbl_ledger.type Like 'Adjustment Purchase') and(tbl_users.id = tbl_ledger.added_by)";
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


        #endregion

    }
}
