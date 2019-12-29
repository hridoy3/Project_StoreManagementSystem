using System;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormProductsList : Form
    {
        public FormProductsList()
        {
            InitializeComponent();
        }

        ProductsDAL dal = new ProductsDAL();
        ProductsBLL bll = new ProductsBLL();

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyWord = this.textBoxSearch.Text;

            if (keyWord != null)
            {
                DataTable dt = dal.Search(keyWord);
                dataGridViewProducts.DataSource = dt;
            }
            else
            {
                refreshDataGridView();
            }
        }
        void refreshDataGridView()
        {
            DataTable dt = dal.Select();
            dataGridViewProducts.DataSource = dt;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string keyWord = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            //string keyWord = dateTimePicker1.Value.Date.ToString();

            //MessageBox.Show(keyWord);
            dataGridViewProducts.DataSource = dal.SearchProductsByCalander(keyWord);
        }

        private void FormProductsList_Load(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refreshDataGridView();
        }
    }
}
