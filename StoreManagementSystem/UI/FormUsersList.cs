using System;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormUsersList : Form
    {
        UsersDAL uDAL = new UsersDAL();
        public FormUsersList()
        {
            InitializeComponent();
            DataTable dt = uDAL.Select();
            dataGridViewUserList.DataSource = dt;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DataTable dt = uDAL.Select();
            dataGridViewUserList.DataSource = dt;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            // getting text real time
            string keyWord = textBoxSearch.Text.ToString();

            //
            if (keyWord != null)
            {
                //show user based on keyWord
                //uDAL.Search(keyWord);
                DataTable dt = uDAL.Search(keyWord);
                dataGridViewUserList.DataSource = dt;
            }
            else
            {
                //show all users
                DataTable dt = uDAL.Select();
                dataGridViewUserList.DataSource = dt;
            }
        }
    }
}
