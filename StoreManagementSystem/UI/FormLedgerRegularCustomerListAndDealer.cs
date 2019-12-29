using System;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormLedgerRegularCustomerListAndDealer : Form
    {
        CustDeaDAL cdDAL = new CustDeaDAL();
        LedgerDAL lDAL = new LedgerDAL();

        public FormLedgerRegularCustomerListAndDealer()
        {
            InitializeComponent();
        }

        private void FormLedgerRegularCustomerList_Load(object sender, EventArgs e)
        {
            
            
        }

        void UpdateDGVRegularCustomer()
        {
            dataGridViewNormalCustomer.DataSource = lDAL.SelectAllRegularCustomerLegdgerEntries();
        }

        void UpdateDGVDealer()
        {
            dataGridViewNormalCustomer.DataSource = lDAL.SelectAllDealerLegdgerEntries();
        }

        

        private void comboBoxNormalCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBoxNormalCustomer.SelectedValue.ToString());
            //int dea_cust_id = int.Parse(labelId.Text);
            if (radioButtonRegularCustomer.Checked)
            {
                dataGridViewNormalCustomer.DataSource = lDAL.SelectRegularCustomerLegdgerEntriesUsingCustomerID(int.Parse(comboBoxNormalCustomer.SelectedValue.ToString()));
            }
            else if (radioButtonDealer.Checked)
            {
                dataGridViewNormalCustomer.DataSource = lDAL.SelectDealerLegdgerEntriesUsingCustomerID(int.Parse(comboBoxNormalCustomer.SelectedValue.ToString()));

            }
            
            else
            {

            }
            
        }

        

        private void radioButtonRegularCustomer_CheckedChanged(object sender, EventArgs e)
        {
            
            DataTable customerDT = new DataTable();
            //featching data table
            customerDT = cdDAL.SelectRegularCustomer();

            //Display
            comboBoxNormalCustomer.DisplayMember = "name";
            //value
            comboBoxNormalCustomer.ValueMember = "id";
            //insert into combobox
            comboBoxNormalCustomer.DataSource = customerDT;

            labelId.Text = comboBoxNormalCustomer.SelectedValue.ToString();
            //UpdateDGV();
            UpdateDGVRegularCustomer();
        }

        private void radioButtonDealer_CheckedChanged(object sender, EventArgs e)
        {
            

            DataTable customerDT = new DataTable();
            //featching data table
            customerDT = cdDAL.SearchDealerForTransaction();

            //Display
            comboBoxNormalCustomer.DisplayMember = "name";
            //value
            comboBoxNormalCustomer.ValueMember = "id";
            //insert into combobox
            comboBoxNormalCustomer.DataSource = customerDT;

            labelId.Text = comboBoxNormalCustomer.SelectedValue.ToString();
            //UpdateDGV();
            UpdateDGVDealer();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            dataGridViewNormalCustomer.DataSource = lDAL.Select();
        }
    }
}
