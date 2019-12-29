using System;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormCustomersDealers : Form
    {
        CustDeaBLL bll = new CustDeaBLL();
        CustDeaDAL dal = new CustDeaDAL();

        bool enableDelete = false;
        bool enableUpdate = false;

        bool CheckNameAndCombobox()
        {
            if (textBoxName.Text == "" || comboBoxType.Text == "")
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

        public FormCustomersDealers()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (CheckNameAndCombobox())
            {
                if (MessageBox.Show("Are you sure?", "Add Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bll.Name = this.textBoxName.Text;
                    bll.Type = this.comboBoxType.Text;
                    bll.Email = this.textBoxEmail.Text.ToString();
                    bll.Contact = this.textBoxEmail.Text.ToString();
                    bll.Address = this.textBoxAddress.Text;
                    bll.AddedDate = DateTime.Now;
                    bll.AddedBy = FormLogin.loggedInUserId;
                    //bll.Due = 0;
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
            else
            {
                MessageBox.Show("Please enter Name and Type of Customer");
            }
        }

        void Clear()
        {
            this.comboBoxType.Text = this.textBoxName.Text = this.textBoxEmail.Text = this.textBoxContact.Text = this.textBoxAddress.Text = this.labelCustDeaID.Text = string.Empty;
        }

        void refreshDataGridView()
        {
            DataTable dt = dal.Select();
            dataGridViewCustDea.DataSource = dt;
        }

        private void FormCustomersDealers_Load(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void dataGridViewCustDea_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            this.labelCustDeaID.Text = dataGridViewCustDea.Rows[rowIndex].Cells[0].Value.ToString();
            this.comboBoxType.Text = dataGridViewCustDea.Rows[rowIndex].Cells[1].Value.ToString();
            this.textBoxName.Text = dataGridViewCustDea.Rows[rowIndex].Cells[2].Value.ToString();
            this.textBoxEmail.Text = dataGridViewCustDea.Rows[rowIndex].Cells[3].Value.ToString();
            this.textBoxContact.Text = dataGridViewCustDea.Rows[rowIndex].Cells[4].Value.ToString();
            this.textBoxAddress.Text = dataGridViewCustDea.Rows[rowIndex].Cells[5].Value.ToString();
            this.textBoxBalance.Text = dataGridViewCustDea.Rows[rowIndex].Cells[6].Value.ToString();
            Enabledd();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (CheckNameAndCombobox() && enableUpdate)
            {
                if (MessageBox.Show("Are you sure?", "Edit Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bll.Id = int.Parse(this.labelCustDeaID.Text);
                    bll.Name = this.textBoxName.Text;
                    bll.Type = this.comboBoxType.Text;
                    bll.Email = this.textBoxEmail.Text.ToString();
                    bll.Contact = this.textBoxContact.Text.ToString();
                    bll.Address = this.textBoxAddress.Text;
                    bll.Due = decimal.Parse(this.textBoxBalance.Text);
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
                MessageBox.Show("Please select row or enter Name and Cutomer type");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (enableDelete)
            {
                if (MessageBox.Show("Delete Entry", "Delete Promt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bll.Id = int.Parse(this.labelCustDeaID.Text);
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
                MessageBox.Show("Please select Row to Delete");
            }

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyWord = this.textBoxSearch.Text;

            if (keyWord != null)
            {
                DataTable dt = dal.Search(keyWord);
                dataGridViewCustDea.DataSource = dt;
            }
            else
            {
                refreshDataGridView();
            }
        }

        private void textBoxContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }
    }
}
