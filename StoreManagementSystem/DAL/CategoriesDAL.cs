using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using WarehouseApp.BLL;

namespace WarehouseApp.DAL
{
    class CategoriesDAL
    {
        string connStringSql = ConfigurationManager.ConnectionStrings["WarehouseApp.Properties.Settings.StoreConnectionString"].ConnectionString;

        public DataTable Select()
        {
            //Connect to dataBase
            SqlConnection conn = new SqlConnection(connStringSql);
            //create data table
            DataTable dt = new DataTable();
            try
            {
                //Sql query
                //string sql = "SELECT * FROM tbl_categories";
                string sql = "SELECT tbl_categories.*,tbl_users.name FROM tbl_categories,tbl_users WHERE tbl_categories.added_by=tbl_users.id";

                //for execution commands
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                //
                conn.Open();
                da.Fill(dt);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }


        public bool Insert(CategoriesBLL bll)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(connStringSql);

            string sql = "INSERT INTO tbl_categories (title, description, added_date, added_by) VALUES (@title, @description, @added_date, @added_by)";
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", bll.Title);
                cmd.Parameters.AddWithValue("@description", bll.Description);
                cmd.Parameters.AddWithValue("@added_date", bll.AddedDate);
                cmd.Parameters.AddWithValue("@added_by", bll.AddedBy);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                    isSuccess = false;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        
        public bool Update(CategoriesBLL bll)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "UPDATE tbl_categories SET title=@title, description=@description, added_date=@added_date, added_by=@added_by WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title",bll.Title);
                cmd.Parameters.AddWithValue("@description",bll.Description);
                cmd.Parameters.AddWithValue("@added_date",bll.AddedDate);
                cmd.Parameters.AddWithValue("@added_by",bll.AddedBy);
                cmd.Parameters.AddWithValue("@id",bll.Id);

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

        public bool Delete(CategoriesBLL bll)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "DELETE FROM tbl_categories WHERE id=@id";
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

        #region search

        public DataTable Search(string keyWord)
        {
            SqlConnection conn = new SqlConnection(connStringSql);
            //to hold data base data
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM tbl_categories WHERE id LIKE '%" + keyWord + "%' OR title LIKE '%" + keyWord + "%' OR description LIKE '%"+keyWord+"%' ";
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
