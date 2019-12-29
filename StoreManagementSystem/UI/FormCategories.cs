using System;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormCategories : Form
    {
        CategoriesBLL bll = new CategoriesBLL();
        CategoriesDAL dal = new CategoriesDAL();
        //UsersDAL dall = new UsersDAL();
        bool enableDelete = false;
       
        bool enableUpdate = false;



        public FormCategories()
        {
            InitializeComponent();
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxTitle.Text == "")
            {
                MessageBox.Show("Please add Title");
            }
            else
            {
                if (MessageBox.Show("Are you sure?", "Add Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bll.Title = this.textBoxTitle.Text;
                    bll.Description = this.textBoxDescription.Text;
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


        void Clear()
        {
            this.textBoxDescription.Text = this.textBoxTitle.Text = this.labelCategoryId.Text = string.Empty;
        }

        private void FormCategories_Load(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        void refreshDataGridView()
        {
            DataTable dt = dal.Select();
            dataGridViewCategories.DataSource = dt;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (enableUpdate && textBoxTitle.Text != "")
            {
                if (MessageBox.Show("Are you sure?", "Edit Categoty", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bll.Id = int.Parse(this.labelCategoryId.Text);
                    bll.Title = this.textBoxTitle.Text;
                    bll.Description = this.textBoxDescription.Text;
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

                    enableUpdate = false;
                    enableDelete = false;
                }
            }
            else
            {
                MessageBox.Show("Please select row to update Or Title field cannot be empty");
            }
            
        }

        private void dataGridViewCategories_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            this.labelCategoryId.Text = dataGridViewCategories.Rows[rowIndex].Cells[0].Value.ToString();
            this.textBoxTitle.Text = dataGridViewCategories.Rows[rowIndex].Cells[1].Value.ToString();
            this.textBoxDescription.Text = dataGridViewCategories.Rows[rowIndex].Cells[2].Value.ToString();


            enableUpdate = true;
            enableDelete = true;
        }

        private void buttonDetete_Click(object sender, EventArgs e)
        {
            if (enableDelete)
            {
                if (MessageBox.Show("Delete Entry", "Delete Promt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bll.Id = int.Parse(this.labelCategoryId.Text);
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


                    enableUpdate = false;
                    enableDelete = false;
                }
            }
            else
            {
                MessageBox.Show("Please select row to Delete");
            }
            
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
