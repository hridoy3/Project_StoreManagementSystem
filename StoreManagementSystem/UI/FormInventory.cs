using System;
using System.Windows.Forms;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormInventory : Form
    {
        public FormInventory()
        {
            InitializeComponent();
        }

        CategoriesDAL cDAL = new CategoriesDAL();
        ProductsDAL pDAL = new ProductsDAL();

        private void FormInventory_Load(object sender, EventArgs e)
        {
            this.comboBoxFilter.DataSource = cDAL.Select();

            this.comboBoxFilter.DisplayMember = "title";
            this.comboBoxFilter.ValueMember = "title";


            UpdateDataDridView();
        }

        void UpdateDataDridView()
        {
            dataGridViewInventory.DataSource = pDAL.Select();
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = comboBoxFilter.Text;

            dataGridViewInventory.DataSource = pDAL.DisplayTransacitonsAsCategory(category);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDataDridView();
        }
    }
}
