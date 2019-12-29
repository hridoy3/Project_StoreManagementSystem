using System;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormTransactions : Form
    {
        TransactionDAL tDAL = new TransactionDAL();
        public FormTransactions()
        {
            InitializeComponent();
        }

        private void FormTransactions_Load(object sender, EventArgs e)
        {
            UpdateDatagridview();
        }

        void UpdateDatagridview()
        {
            DataTable dt = tDAL.DisplayAllTransacitons();
            this.dataGridViewTransactions.DataSource = dt;
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = this.comboBoxFilter.Text;

            this.dataGridViewTransactions.DataSource = tDAL.DisplayTransacitonsAsType(type);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDatagridview();
        }
    }
}
