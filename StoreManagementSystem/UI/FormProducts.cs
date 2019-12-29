using System;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;

namespace WarehouseApp
{
    public partial class FormProducts : Form
    {
        CategoriesDAL cDAL = new CategoriesDAL();
        //int categoryId;
        ProductsDAL dal = new ProductsDAL();
        ProductsBLL bll = new ProductsBLL();

        bool enableDelete = false;
        bool enableUpdate = false;

        bool CheckNameAndCombobox()
        {
            if (textBoxName.Text == "" || comboBoxCategory.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        void Enabledd()
        {
            enableDelete = true;
            enableUpdate = true;
        }
        void Disabled()
        {
            enableDelete = false;
            enableUpdate = false;
        }

        public FormProducts()
        {
            InitializeComponent();
        }

        private void FromProducts_Load(object sender, EventArgs e)
        {
            refreshDataGridView();

            //creating datatable
            DataTable categoryDt = new DataTable();
            //featching data table
            categoryDt = cDAL.Select();

            //Display
            comboBoxCategory.DisplayMember = "title";
            //value
            comboBoxCategory.ValueMember = "id";

            

            //insert into combobox
            comboBoxCategory.DataSource = categoryDt;
        }

        

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || comboBoxCategory.Text == "")
            {
                MessageBox.Show("Please enter Name and catebory fields");
            }
            else
            {
                if (MessageBox.Show("Are you sure?", "Add Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bll.Name = this.textBoxName.Text;
                    bll.Description = this.textBoxDescription.Text;
                    if (textBoxRate.Text == "")
                    {
                        bll.Rate = 0;
                    }
                    else
                    {
                        bll.Rate = decimal.Parse(textBoxRate.Text.ToString());
                    }

                    bll.Category = int.Parse(this.labelCategoryID.Text);
                    bll.Qty = 0;
                    bll.AddedDate = DateTime.Now;
                    bll.AddedBy = FormLogin.loggedInUserId;
                    bool success = dal.Insert(bll);

                    if (success)
                    {
                        //New category inserted successfully
                        MessageBox.Show("Added successfullly");
                        Clear();
                    }
                    else
                    {
                        //Failed to insert new category
                        MessageBox.Show("Operation Failed");
                    }
                    refreshDataGridView();
                }
            }
        }

        void refreshDataGridView()
        {
            DataTable dt = dal.Select();
            dataGridViewProducts.DataSource = dt;
        }

        int GetCategoryID()
        {
            string cID = comboBoxCategory.Text;
            DataTable dt = cDAL.Select();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString() == cID)
                {
                    return int.Parse(dt.Rows[i][0].ToString());
                }
            }

            return -1;
        }

        void Clear()
        {
            this.textBoxDescription.Text = this.textBoxName.Text = this.labelProductId.Text = this.textBoxRate.Text  = string.Empty;
        }

        private void comboBoxCategory_TextChanged(object sender, EventArgs e)
        {
            this.labelCategoryID.Text = this.GetCategoryID().ToString();
           
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (enableUpdate && CheckNameAndCombobox())
            {
                if (MessageBox.Show("Are you sure?", "Edit Categoty", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bll.Id = int.Parse(this.labelProductId.Text);
                    bll.Name = this.textBoxName.Text;
                    bll.Description = this.textBoxDescription.Text;
                    bll.Rate = decimal.Parse(textBoxRate.Text.ToString());
                    bll.Category = int.Parse(this.labelCategoryID.Text.ToString());
                    //bll.Qty = 0;
                    bll.AddedDate = DateTime.Now;
                    bll.AddedBy = FormLogin.loggedInUserId;

                    bool isUpdated = dal.Update(bll);

                    if (isUpdated)
                    {
                        MessageBox.Show("Successfully Updated");
                        Clear();
                    }
                    else
                        MessageBox.Show("Operation Failed");

                    refreshDataGridView();
                    Disabled();
                }
                         
             }
             else
             {
                 MessageBox.Show("Please select row or enter name and product category");
             }
        }

        private void dataGridViewProducts_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            this.labelProductId.Text = dataGridViewProducts.Rows[rowIndex].Cells[0].Value.ToString();
            this.textBoxName.Text = dataGridViewProducts.Rows[rowIndex].Cells[1].Value.ToString();
            this.labelCategoryID.Text = dataGridViewProducts.Rows[rowIndex].Cells[2].Value.ToString();
            
            this.textBoxDescription.Text = dataGridViewProducts.Rows[rowIndex].Cells[3].Value.ToString();
            this.textBoxRate.Text = dataGridViewProducts.Rows[rowIndex].Cells[4].Value.ToString();
            //this.labelCategoryID.Text = GetCategoryID().ToString();
            Enabledd();
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (enableDelete)
            {
                if (MessageBox.Show("Delete Entry", "Delete Promt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bll.Id = int.Parse(this.labelProductId.Text);
                    bool isSuccess = dal.Delete(bll);

                    if (isSuccess)
                    {
                        MessageBox.Show("Operation successful");
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Operation failed");
                    }
                    refreshDataGridView();
                    Disabled();
                }
            }
            else
            {
                MessageBox.Show("Select row to Delete");
            }
        }

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

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;


            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }
    }
}
