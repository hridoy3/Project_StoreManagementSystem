using System;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormCategoriesList : Form
    {
        CategoriesBLL bll = new CategoriesBLL();
        CategoriesDAL dal = new CategoriesDAL();

        public FormCategoriesList()
        {
            InitializeComponent();
        }

        private void FormCategoriesList_Load(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        void refreshDataGridView()
        {
            DataTable dt = dal.Select();
            dataGridViewCategories.DataSource = dt;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //getting text real time
            string keyWord = this.textBoxSearch.Text.ToString();

            //
            if (keyWord != null)
            {
                //show user based on keyWord
                //dal.Search(keyWord);
                DataTable dt = dal.Search(keyWord);
                dataGridViewCategories.DataSource = dt;
            }
            else
            {
                //show all users
                DataTable dt = dal.Select();
                dataGridViewCategories.DataSource = dt;
            }
        }
    }
}
