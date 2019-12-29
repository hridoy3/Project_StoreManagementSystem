using System;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;

namespace WarehouseApp
{
    public partial class FormLogin : Form
    {
        LoginBLL lBLL = new LoginBLL();
        LoginDAL lDAL = new LoginDAL();
        UsersDAL uDAL = new UsersDAL();
        internal static string loggedInUser;
        internal static int loggedInUserId;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            lBLL.Username = textBoxUsername.Text;
            lBLL.Password = textBoxPassword.Text;
            //lBLL.UserType = comboBoxUserType.Text;

            bool success = lDAL.CheckLogin(lBLL);

            if (success)
            {
                //MessageBox.Show("Login Successful...");



                loggedInUser = lBLL.Username;
                
                DataTable dt = lDAL.Select(lBLL);
                lBLL.UserType = dt.Rows[0][1].ToString();
                loggedInUserId = int.Parse(dt.Rows[0][0].ToString());
                //MessageBox.Show(loggedInUserId.ToString());
                //Open user form based on user type
                switch(lBLL.UserType)
                {
                    case "Admin":
                        {
                            //Open admin dashboard
                            FormAdminDashboard fAD = new FormAdminDashboard(this);
                            fAD.Show();
                            this.Hide();
                        }
                        break;
                    case "User":
                        {
                            //open user dashboard
                            FormUserDashboard fUD = new FormUserDashboard();
                            fUD.Show();
                            this.Hide();
                        }
                        break;
                    default:
                        {
                            MessageBox.Show("Failed");
                            break;
                        }

                }

                UsersBLL uBLL = new UsersBLL();
                uBLL.status = "Online";
                uBLL.Id = loggedInUserId;
                bool s = uDAL.UpdateStatus(uBLL);
                if (!s)
                {
                    MessageBox.Show("Status Update failed");
                }
                
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password");
            }

        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
