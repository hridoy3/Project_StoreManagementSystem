using System;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormAuthenticationCheck : Form
    {
        
        public FormAuthenticationCheck()
        {
            InitializeComponent();
        }
        public bool success { get; set; }



        private void FormAuthenticationCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void FormAuthenticationCheck_Load(object sender, EventArgs e)
        {
            this.labelUsername.Text = FormLogin.loggedInUser;
            
        }

        private void buttonAuthenticate_Click(object sender, EventArgs e)
        {
            AuthenticationCheckBLL aCBLL = new AuthenticationCheckBLL();
            AuthenticationCheckDAL aCDAL = new AuthenticationCheckDAL();

            aCBLL.Username = this.labelUsername.Text;
            aCBLL.Password = this.textBoxPassword.Text;
            if (success = aCDAL.CheckLogin(aCBLL))
            {
                this.Hide();
            }
            //this.Hide();
            else
            {
                if (MessageBox.Show("Try Again", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    success = aCDAL.CheckLogin(aCBLL);
                    //this.Hide();
                }
                
            }

        }

        
    }
}
