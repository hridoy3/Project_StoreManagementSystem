using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WarehouseApp.BLL;

namespace WarehouseApp.DAL
{
    class UsersDAL
    {
        public UsersDAL()
        {

        }
        //featching connection string in App.config
        static string connStringSql = ConfigurationManager.ConnectionStrings["WarehouseApp.Properties.Settings.StoreConnectionString"].ConnectionString;

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
                string sql = "SELECT * FROM tbl_users";
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

        #region Insert data in database

        public bool Insert(UsersBLL u)
        {
            bool isSuccess = false;
            //To connect to database
            SqlConnection conn = new SqlConnection(connStringSql);

            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "INSERT INTO tbl_users (name, email, username, password, contact, address, note, gender, user_type, added_date, added_by) VALUES (@name, @email, @username, @password, @contact, @address, @note, @gender, @user_type, @added_date, @added_by)";

                //for executing command
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@name", u.Name);
                cmd.Parameters.AddWithValue("@email", u.Email);
                cmd.Parameters.AddWithValue("@username", u.Username);
                cmd.Parameters.AddWithValue("@password", u.Password);
                cmd.Parameters.AddWithValue("@contact", u.Contact);
                //cmd.Parameters.AddWithValue("@area", u.Area);
                cmd.Parameters.AddWithValue("@address", u.Adderss);
                cmd.Parameters.AddWithValue("@note", u.Note);
                cmd.Parameters.AddWithValue("@gender", u.Gender);
                cmd.Parameters.AddWithValue("@user_type", u.UserType);
                cmd.Parameters.AddWithValue("@added_by", u.AddedBy);
                cmd.Parameters.AddWithValue("@added_date", u.AddedDate);

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
                //throw message if any error occur
                MessageBox.Show(ex.Message);

            }
            finally
            {
                //close database connection
                conn.Close();
            }
            return isSuccess;
        }


        #endregion

        #region Update data in database

        public bool Update(UsersBLL u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "UPDATE tbl_users SET name=@name, email=@email, username=@username, password=@password, contact=@contact, address=@address, note=@note, gender = @gender, user_type = @user_type, modified_date = @modified_date, added_by = @added_by WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", u.Name);
                cmd.Parameters.AddWithValue("@email", u.Email);
                cmd.Parameters.AddWithValue("@username", u.Username);
                cmd.Parameters.AddWithValue("@password", u.Password);
                cmd.Parameters.AddWithValue("@contact", u.Contact);
                //cmd.Parameters.AddWithValue("@area", u.Area);
                cmd.Parameters.AddWithValue("@address", u.Adderss);
                cmd.Parameters.AddWithValue("@note", u.Note);
                cmd.Parameters.AddWithValue("@gender", u.Gender);
                cmd.Parameters.AddWithValue("@user_type", u.UserType);
                cmd.Parameters.AddWithValue("@added_by", u.AddedBy);
                cmd.Parameters.AddWithValue("@modified_date", u.modifiedDate);
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

        #region Update Status using id in database

        public bool UpdateStatus(UsersBLL u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "UPDATE tbl_users SET status=@status WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@status", u.status);
                
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

        #region Delete data form database

        public bool Delete(UsersBLL u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(connStringSql);

            try
            {
                string sql = "DELETE FROM tbl_users WHERE id=@id";
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

        #region Search user on dtabase

        public DataTable Search(string keyWord)
        {
            //To connect to database
            SqlConnection conn = new SqlConnection(connStringSql);
            //To hold the data from database
            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "SELECT * FROM tbl_users WHERE id LIKE '%" + keyWord + "%' OR name LIKE '%" + keyWord + "%' OR username LIKE '%" + keyWord + "%'";
                
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

        #region Getting User Id form User

        public UsersBLL GetIdFromUsername(string username)
        {
            UsersBLL user = new UsersBLL();
            SqlConnection conn = new SqlConnection(connStringSql);

            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT id FROM tbl_users WHERE username='"+username+"'";
                //SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                conn.Open();

                da.Fill(dt);

                
                if (dt.Rows.Count>0)
                {
                    user.Id = int.Parse(dt.Rows[0]["id"].ToString());
                    //MessageBox.Show("ADDEDBY");
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


            return user;
        }

        #endregion

        #region Get Username list

        

        public DataTable GetUsernameList()
        {
            //To connect to database
            SqlConnection conn = new SqlConnection(connStringSql);
            //To hold the data from database
            DataTable dt = new DataTable();
            try
            {
                //sql query to get data form database
                string sql = "SELECT username FROM tbl_users";
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
