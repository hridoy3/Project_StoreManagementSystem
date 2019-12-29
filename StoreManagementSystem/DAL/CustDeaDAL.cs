using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using WarehouseApp.BLL;

namespace WarehouseApp.DAL
{
    class CustDeaDAL
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
                string sql = "SELECT * FROM tbl_dea_cust";
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

        public bool Insert(CustDeaBLL bll)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(connStringSql);

            string sql = "INSERT INTO tbl_dea_cust (name, type, email, contact, address, due, added_date, added_by) VALUES (@name, @type, @email, @contact, @address, @due, @added_date, @added_by)";
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", bll.Type);
                cmd.Parameters.AddWithValue("@name", bll.Name);
                cmd.Parameters.AddWithValue("@email", bll.Email);
                cmd.Parameters.AddWithValue("@added_date", bll.AddedDate);
                cmd.Parameters.AddWithValue("@added_by", bll.AddedBy);
                cmd.Parameters.AddWithValue("@contact", bll.Contact);
                cmd.Parameters.AddWithValue("@address", bll.Address);
                cmd.Parameters.AddWithValue("@due", bll.DueAtCreation);
                

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
        #region Update data in database

        public bool Update(CustDeaBLL bll)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "UPDATE tbl_dea_cust SET name=@name, type=@type, email=@email, contact=@contact, address=@address, due=@due, added_date=@added_date, added_by=@added_by WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", bll.Type);
                cmd.Parameters.AddWithValue("@name", bll.Name);
                cmd.Parameters.AddWithValue("@email", bll.Email);
                cmd.Parameters.AddWithValue("@added_date", bll.AddedDate);
                cmd.Parameters.AddWithValue("@added_by", bll.AddedBy);
                cmd.Parameters.AddWithValue("@contact", bll.Contact);
                cmd.Parameters.AddWithValue("@address", bll.Address);
                cmd.Parameters.AddWithValue("@id", bll.Id);
                cmd.Parameters.AddWithValue("@due",bll.Due);

                conn.Open();

                if (cmd.ExecuteNonQuery() > 0)
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
        #region Delete row

        public bool Delete(CustDeaBLL bll)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "DELETE FROM tbl_dea_cust WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", bll.Id);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
                else
                    success = false;
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

        #endregion
        #region search

        public DataTable Search(string keyWord)
        {
            SqlConnection conn = new SqlConnection(connStringSql);
            //to hold data base data
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM tbl_dea_cust WHERE id LIKE '%" + keyWord + "%' OR name LIKE '%" + keyWord + "%' OR email LIKE '%" + keyWord + "%' OR type LIKE '%" + keyWord + "%'  ";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

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
        #region search dea and cust for transertion

        public CustDeaBLL SearchDealerCustomerForTransaction(string keyWord)
        {
            CustDeaBLL dc = new CustDeaBLL();

            SqlConnection conn = new SqlConnection(connStringSql);
            //to hold data base data
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT id, name, email, contact, address, due FROM tbl_dea_cust WHERE id LIKE '%" + keyWord + "%' OR name LIKE '%" + keyWord + "%' ";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                conn.Open();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dc.Id = int.Parse(dt.Rows[0]["id"].ToString());
                    dc.Name = dt.Rows[0]["name"].ToString();
                    dc.Email = dt.Rows[0]["email"].ToString();
                    dc.Contact = dt.Rows[0]["contact"].ToString();
                    dc.Address = dt.Rows[0]["address"].ToString();
                    //decimal balance = decimal.Parse(dt.Rows[0]["balance"].ToString());
                    dc.Due = decimal.Parse(dt.Rows[0]["due"].ToString());
                    
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

            return dc;
        }

        #endregion

        //#region Update Balance

        //public bool UpdateBalance(int cust_dea_id, string due)
        //{
        //    bool isSuccess = false;
        //    SqlConnection conn = new SqlConnection(connStringSql);

        //    try
        //    {
        //        string sql = "UPDATE tbl_dea_cust SET due=@due WHERE id=@id";
        //        SqlCommand cmd = new SqlCommand(sql, conn);

        //        cmd.Parameters.AddWithValue("@due", due);

        //        cmd.Parameters.AddWithValue("@id", cust_dea_id);

        //        conn.Open();

        //        if (cmd.ExecuteNonQuery() > 0)
        //        {
        //            isSuccess = true;
        //        }
        //        else
        //            isSuccess = false;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }



        //    return isSuccess;
        //}


        //#endregion

        #region Update due of cust and dea

        public bool UpdateDue(int custAndDeaID, decimal due)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "UPDATE tbl_dea_cust SET due=@due WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@due", due);

                cmd.Parameters.AddWithValue("@id", custAndDeaID);

                conn.Open();

                if (cmd.ExecuteNonQuery() > 0)
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

        #region Get Due from of Cust and Dealer

        public decimal GetDueAmount(int custAndDealerID)
        {
            SqlConnection conn = new SqlConnection(connStringSql);

            decimal due = 0;

            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT due FROM tbl_dea_cust WHERE id=@id ";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("id", custAndDealerID);
                conn.Open();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    due = decimal.Parse(dt.Rows[0][0].ToString());
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

            return due;
        }

        #endregion

        #region search dea(purchase)

        public CustDeaBLL SearchDealerForTransaction(string keyWord)
        {
            CustDeaBLL dc = new CustDeaBLL();

            SqlConnection conn = new SqlConnection(connStringSql);
            //to hold data base data
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT id, name, email, contact, address, due FROM tbl_dea_cust WHERE (id LIKE '%" + keyWord + "%' OR name LIKE '%" + keyWord + "%') and (type = @type) ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", "Dealer");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                conn.Open();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dc.Id = int.Parse(dt.Rows[0]["id"].ToString());
                    dc.Name = dt.Rows[0]["name"].ToString();
                    dc.Email = dt.Rows[0]["email"].ToString();
                    dc.Contact = dt.Rows[0]["contact"].ToString();
                    dc.Address = dt.Rows[0]["address"].ToString();
                    //decimal balance = decimal.Parse(dt.Rows[0]["balance"].ToString());
                    dc.Due = decimal.Parse(dt.Rows[0]["due"].ToString());
                    //dc.Type = dt.Rows[0]["type"].ToString();

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

            return dc;
        }

        #endregion

        #region search customer(Sale)

        public CustDeaBLL SearchCustomerForTransaction(string keyWord)
        {
            CustDeaBLL dc = new CustDeaBLL();

            SqlConnection conn = new SqlConnection(connStringSql);
            //to hold data base data
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT id, name, email, contact, address, due FROM tbl_dea_cust WHERE (id LIKE '%" + keyWord + "%' OR name LIKE '%" + keyWord + "%') and (type = @type) ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", "Customer");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                conn.Open();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dc.Id = int.Parse(dt.Rows[0]["id"].ToString());
                    dc.Name = dt.Rows[0]["name"].ToString();
                    dc.Email = dt.Rows[0]["email"].ToString();
                    dc.Contact = dt.Rows[0]["contact"].ToString();
                    dc.Address = dt.Rows[0]["address"].ToString();
                    //decimal balance = decimal.Parse(dt.Rows[0]["balance"].ToString());
                    dc.Due = decimal.Parse(dt.Rows[0]["due"].ToString());
                    //dc.Type = dt.Rows[0]["type"].ToString();
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

            return dc;
        }

        #endregion


        #region Select customer name and id only filter

        public DataTable SelectRegularCustomer()
        {
            

            SqlConnection conn = new SqlConnection(connStringSql);
            //to hold data base data
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT id, name, email, contact, address, due FROM tbl_dea_cust WHERE type = @type ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", "Customer");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

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

        #region Delect for Leager filter

        public DataTable SearchDealerForTransaction()
        {
            

            SqlConnection conn = new SqlConnection(connStringSql);
            //to hold data base data
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT id, name, email, contact, address, due FROM tbl_dea_cust WHERE type = @type ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", "Dealer");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

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
