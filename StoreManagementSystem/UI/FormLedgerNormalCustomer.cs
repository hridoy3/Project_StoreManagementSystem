using System;
using System.Windows.Forms;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormLedgerNormalCustomer : Form
    {
        LedgerDAL lDAL = new LedgerDAL();

        public FormLedgerNormalCustomer() 
        {
            InitializeComponent();
        }

        private void FormLedgerNormalCustomer_Load(object sender, EventArgs e)
        {
            comboBoxNormalCustomer.Items.Add("Show All");
            comboBoxNormalCustomer.Items.Add("Sale");
            comboBoxNormalCustomer.Items.Add("Purchase");
            

            dataGridViewNormalCustomer.DataSource = lDAL.SelectAllNormalLegdgerEntries();
            
        }

        void UpdateDGVNormalCustomer()
        {
            dataGridViewNormalCustomer.DataSource = lDAL.SelectAllNormalLegdgerEntries();
        }

        private void comboBoxNormalCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNormalCustomer.Text == "Sale")
            {
                dataGridViewNormalCustomer.DataSource = lDAL.SelectAllNormalLegdgerSaleEntries();
            }
            else if (comboBoxNormalCustomer.Text == "Purchase")
            {
                dataGridViewNormalCustomer.DataSource = lDAL.SelectAllNormalLegdgerPurchaseEntries();
            }
            else
            {
                dataGridViewNormalCustomer.DataSource = lDAL.SelectAllNormalLegdgerEntries();
            }
        }

        private void buttonShowAllTransactions_Click(object sender, EventArgs e)
        {


            dataGridViewNormalCustomer.DataSource = lDAL.Select();
        }
    }
}
