using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using WarehouseApp.BLL;

namespace WarehouseApp.DAL
{
    class ProductsDAL
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
                string sql = "SELECT tbl_products.*, tbl_categories.title, tbl_users.name FROM tbl_products,tbl_categories,tbl_users WHERE tbl_products.category = tbl_categories.id AND tbl_products.added_by = tbl_users.id";
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

        public bool Insert(ProductsBLL bll)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(connStringSql);

            string sql = "INSERT INTO tbl_products (name, category, description, rate, qty, added_date, added_by) VALUES (@name, @category, @description, @rate, @qty, @added_date, @added_by)";
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@category", bll.Category);
                cmd.Parameters.AddWithValue("@name", bll.Name);
                cmd.Parameters.AddWithValue("@description", bll.Description);
                cmd.Parameters.AddWithValue("@added_date", bll.AddedDate);
                cmd.Parameters.AddWithValue("@added_by", bll.AddedBy);
                cmd.Parameters.AddWithValue("@rate", bll.Rate);
                cmd.Parameters.AddWithValue("@qty", bll.Qty);

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

        public bool Update(ProductsBLL bll)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "UPDATE tbl_products SET name=@name, category=@category, description=@description, rate=@rate, qty=@qty, added_date=@added_date, added_by=@added_by WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", bll.Name);
                cmd.Parameters.AddWithValue("@category", bll.Category);
                cmd.Parameters.AddWithValue("@description", bll.Description);
                cmd.Parameters.AddWithValue("@rate", bll.Rate);
                cmd.Parameters.AddWithValue("@qty", bll.Qty);
                cmd.Parameters.AddWithValue("@added_date", bll.AddedDate);
                cmd.Parameters.AddWithValue("@added_by", bll.AddedBy);
                cmd.Parameters.AddWithValue("@id", bll.Id);
                
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

        public bool Delete(ProductsBLL bll)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "DELETE FROM tbl_products WHERE id=@id";
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
                string sql = "SELECT * FROM tbl_products WHERE id LIKE '%" + keyWord + "%' OR name LIKE '%" + keyWord + "%' OR description LIKE '%" + keyWord + "%' OR category LIKE '%"+ keyWord +"%'  ";
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

        #region search transaction

        public ProductsBLL SearchProductForTransaction(string keyWord)
        {
            ProductsBLL bll = new ProductsBLL();
            SqlConnection conn = new SqlConnection(connStringSql);
            //to hold data base data
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM tbl_products WHERE rate LIKE '%" + keyWord + "%' OR name LIKE '%" + keyWord + "%' OR qty LIKE '%" + keyWord + "%' ";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                conn.Open();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    bll.Name = dt.Rows[0]["name"].ToString();
                    bll.Rate = decimal.Parse(dt.Rows[0]["rate"].ToString());
                    bll.Qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
                    bll.Id = int.Parse(dt.Rows[0]["id"].ToString());

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

            return bll;
        }

        #endregion


        #region Update quantity

        public bool UpdateQuantity(int productId, decimal qty)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "UPDATE tbl_products SET qty=@qty WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                
                cmd.Parameters.AddWithValue("@qty", qty);
                
                cmd.Parameters.AddWithValue("@id", productId);

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

        #region Get Product quantity

        public decimal GetProductQty(int productId)
        {
            SqlConnection conn = new SqlConnection(connStringSql);

            decimal qty = 0;

            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT qty FROM tbl_products WHERE id=@id ";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("id",productId);
                conn.Open();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
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

            return qty;
        }

        #endregion


        #region Method to increase product

        public bool IncreaseProduct(int productId, decimal increaseQty)
        {
            bool success = false;

            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                decimal currentQty = this.GetProductQty(productId);

                decimal newQty = currentQty + increaseQty;

                success = UpdateQuantity(productId, newQty);
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

        #region Get data table

        public DataTable DisplayTransacitonsAsCategory(string title)
        {
            //Connect to dataBase
            SqlConnection conn = new SqlConnection(connStringSql);
            //create data table
            DataTable dt = new DataTable();
            try
            {
                //Sql query
                //string sql = "SELECT * FROM tbl_products";

                string sql = "SELECT tbl_products.*, tbl_categories.title, tbl_users.name FROM tbl_categories,tbl_users,tbl_products WHERE tbl_categories.title=@title AND tbl_products.added_by = tbl_users.id And tbl_products.category= tbl_categories.id";

                //string sql = "SELECT tbl_categories.*,tbl_users.name FROM tbl_categories,tbl_users WHERE tbl_categories.added_by=tbl_users.id";
                //for execution commands
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);

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

        #region Method to decrease product

        public bool DecreaseProduct(int productId, decimal decreaseQty)
        {
            bool success = false;

            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                decimal currentQty = this.GetProductQty(productId);

                decimal newQty = currentQty - decreaseQty;

                success = UpdateQuantity(productId, newQty);
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

        #region Get Id Form user

        public ProductsBLL GetIdFromName(string name)
        {
            ProductsBLL pBLL = new ProductsBLL();

            SqlConnection conn = new SqlConnection(connStringSql);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id FROM tbl_products WHERE name=@name";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@name",name);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                conn.Open();
                da.Fill(dt);

                if (dt.Rows.Count>0)
                {
                    pBLL.Id = int.Parse(dt.Rows[0]["id"].ToString());
                    //MessageBox.Show(pBLL.Id.ToString());
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

            return pBLL;
        }

        #endregion

        /////////////////////////////////////FormProductsList

        #region search By calancer

        public DataTable SearchProductsByCalander(string keyWord)
        {
            //ProductsBLL bll = new ProductsBLL();
            SqlConnection conn = new SqlConnection(connStringSql);
            //to hold data base data
            DataTable dt = new DataTable();

            try
            {
                string sql = string.Format("SELECT tbl_products.*,tbl_categories.title,tbl_users.name FROM tbl_products,tbl_categories,tbl_users WHERE CAST(tbl_products.added_date AS DATE) = '{0}' AND (tbl_products.added_by=tbl_users.id) AND (tbl_categories.id=tbl_products.category)", keyWord);
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



    }

}
