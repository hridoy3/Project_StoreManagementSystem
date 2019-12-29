using System;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormUsersEdit : Form
    {

        UsersEditBLL uBLL = new UsersEditBLL();
        UsersEditDAL uDAL = new UsersEditDAL();

        public FormUsersEdit()
        {
            InitializeComponent();
            dataGridViewUser.DataSource = uBLL.GetAllUser();
        }

        private void FormUsersEdit_Load(object sender, EventArgs e)
        {
            labelUserUsername.Text = FormLogin.loggedInUser;
            textBoxPassword.Text = uBLL.GetAllUser()[0].Password;
            textBoxEmail.Text = uBLL.GetAllUser()[0].Email;
            textBoxContact.Text = uBLL.GetAllUser()[0].Contact;
            textBoxAddress.Text = uBLL.GetAllUser()[0].Address;

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Update User Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (CheckFields())
                {
                    UpdateUserInfo();
                }
                else
                {
                    MessageBox.Show("Please enter Address, Email, Contact, Password");
                }

                dataGridViewUser.DataSource = uBLL.GetAllUser();
            }
        }


        bool CheckFields()
        {
            if (textBoxAddress.Text == "" || textBoxPassword.Text == "" || textBoxEmail.Text == "" || textBoxContact.Text == "")
            {
                return false;
            }
            else
                return true;
        }

        void UpdateUserInfo()
        {
            uBLL.Email = textBoxEmail.Text;

            uBLL.Password = textBoxPassword.Text;
            uBLL.Contact = textBoxContact.Text;
            uBLL.Address = textBoxAddress.Text;
            uBLL.modified_date = DateTime.Now;

            //
            //uBLL.AddedBy = 1;
            //
            bool isUpdated = uDAL.Update(uBLL);

            if (isUpdated)
            {
                MessageBox.Show("Successfully Updated");
                //Clear();
            }
            else
                MessageBox.Show("Operation Failed");
        }
    }
}
