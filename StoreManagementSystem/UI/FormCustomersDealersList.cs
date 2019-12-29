using System;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormCustomersDealersList : Form
    {
        CustDeaDAL cdDAL = new CustDeaDAL();

        public FormCustomersDealersList()
        {
            InitializeComponent();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyWord = this.textBoxSearch.Text;

            if (keyWord != null)
            {
                DataTable dt = cdDAL.Search(keyWord);
                dataGridViewCustDea.DataSource = dt;
            }
            else
            {
                refreshDataGridView();
            }
        }

        void refreshDataGridView()
        {
            DataTable dt = cdDAL.Select();
            dataGridViewCustDea.DataSource = dt;
        }

        private void FormCustomersDealersList_Load(object sender, EventArgs e)
        {
            refreshDataGridView();
        }
    }
}
