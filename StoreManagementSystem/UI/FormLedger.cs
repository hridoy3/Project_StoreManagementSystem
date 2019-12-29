using System;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormLedger : Form
    {
        LedgerDAL dal = new LedgerDAL();
        LedgerBLL bll = new LedgerBLL();
        bool editable = false;
        public FormLedger()
        {
            InitializeComponent();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //getting text real time
            string keyWord = textBoxSearch.Text.ToString();

            //
            if (keyWord != null)
            {
                //show user based on keyWord
                dal.Search(keyWord);
                DataTable dt = dal.Search(keyWord);
                dataGridViewLedger.DataSource = dt;
            }
            else
            {
                //show all users
                DataTable dt = dal.Select();
                dataGridViewLedger.DataSource = dt;
            }
        }

        void ClearAllFields()
        {
            this.textBoxLedgerID.Text = this.textBoxtTitle.Text = this.textBoxRate.Text
               = this.textBoxQty.Text = this.textBoxTotal.Text = this.textBoxDealerOrCustomerID.Text
               = this.textBoxNormalCustomerID.Text = this.textBoxProductID.Text = this.textBoxType.Text
               = this.textBoxTax.Text = this.textBoxDiscount.Text = this.textBoxGrandTotal.Text
               = this.textBoxBill.Text = this.textBoxBalance.Text = textBoxSearch.Text = string.Empty;
            editable = false;
        }

        void AllFieldsEnable()
        {
            this.textBoxtTitle.Enabled = this.textBoxRate.Enabled
               = this.textBoxQty.Enabled = this.textBoxTotal.Enabled = this.textBoxDealerOrCustomerID.Enabled
               = this.textBoxNormalCustomerID.Enabled = this.textBoxProductID.Enabled = this.textBoxType.Enabled
               = this.textBoxTax.Enabled = this.textBoxDiscount.Enabled = this.textBoxGrandTotal.Enabled
               = this.textBoxBill.Enabled = this.textBoxBalance.Enabled = true;

            
        }

        void AllFieldsDisable()
        {
            this.textBoxtTitle.Enabled = this.textBoxRate.Enabled
               = this.textBoxQty.Enabled = this.textBoxTotal.Enabled = this.textBoxDealerOrCustomerID.Enabled
               = this.textBoxNormalCustomerID.Enabled = this.textBoxProductID.Enabled = this.textBoxType.Enabled
               = this.textBoxTax.Enabled = this.textBoxDiscount.Enabled = this.textBoxGrandTotal.Enabled
               = this.textBoxBill.Enabled = this.textBoxBalance.Enabled = false;
        }

        private void FormLedger_Load(object sender, EventArgs e)
        {
            UpdateDGT();
        }

        void UpdateDGT()
        {
            dataGridViewLedger.DataSource = dal.Select();
            editable = false;
        }
        
        private void dataGridViewLedger_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int r = e.RowIndex;
            this.textBoxLedgerID.Text = dataGridViewLedger.Rows[r].Cells[0].Value.ToString();
            this.textBoxtTitle.Text = dataGridViewLedger.Rows[r].Cells[1].Value.ToString();
            this.textBoxRate.Text = dataGridViewLedger.Rows[r].Cells[2].Value.ToString();
            this.textBoxQty.Text = dataGridViewLedger.Rows[r].Cells[3].Value.ToString();
            this.textBoxGrandTotal.Text = dataGridViewLedger.Rows[r].Cells[4].Value.ToString();
            this.textBoxType.Text = dataGridViewLedger.Rows[r].Cells[5].Value.ToString();
            this.textBoxTax.Text = dataGridViewLedger.Rows[r].Cells[6].Value.ToString();
            this.textBoxDiscount.Text = dataGridViewLedger.Rows[r].Cells[7].Value.ToString();
            this.textBoxGrandTotal.Text = dataGridViewLedger.Rows[r].Cells[8].Value.ToString();
            this.textBoxBill.Text = dataGridViewLedger.Rows[r].Cells[9].Value.ToString();
            this.textBoxBalance.Text = dataGridViewLedger.Rows[r].Cells[10].Value.ToString();
            this.textBoxDealerOrCustomerID.Text = dataGridViewLedger.Rows[r].Cells[15].Value.ToString();
            this.textBoxNormalCustomerID.Text = dataGridViewLedger.Rows[r].Cells[16].Value.ToString();
            this.textBoxProductID.Text = dataGridViewLedger.Rows[r].Cells[17].Value.ToString();

            AllFieldsEnable();
            editable = true;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(editable)
            {
                if (MessageBox.Show("Are you sure?", "Update User Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bll.Id = int.Parse(textBoxLedgerID.Text);
                    bll.Title = textBoxtTitle.Text;


                    bll.Type = textBoxType.Text;

                    bll.ModifiedDate = DateTime.Now;
                    bll.ModifiedBy = FormLogin.loggedInUserId;
                    bll.dea_cust_id = int.Parse(textBoxDealerOrCustomerID.Text);
                    bll.n_cust_id = int.Parse(textBoxNormalCustomerID.Text);
                    bll.Product_id = int.Parse(textBoxProductID.Text);
                    //

                    if ((textBoxRate.Text = textBoxQty.Text = textBoxGrandTotal.Text = textBoxTotal.Text = textBoxTax.Text
                            = textBoxDiscount.Text = textBoxBill.Text = textBoxBalance.Text) == "")
                    {

                    }
                    else
                    {
                        bll.Rate = decimal.Parse(textBoxRate.Text);
                        bll.Qty = decimal.Parse(textBoxQty.Text);
                        bll.Total = decimal.Parse(textBoxTotal.Text);
                        bll.Tax = decimal.Parse(textBoxTax.Text);
                        bll.Discount = decimal.Parse(textBoxDiscount.Text);
                        bll.GrandTotal = decimal.Parse(textBoxGrandTotal.Text);
                        bll.Bill = decimal.Parse(textBoxBill.Text);
                        bll.Balance = decimal.Parse(textBoxBalance.Text);
                    }
                    bool isUpdated = dal.Update(bll);

                    if (isUpdated)
                    {
                        MessageBox.Show("Successfully Updated");
                        ClearAllFields();
                        AllFieldsDisable();
                    }
                    else
                        MessageBox.Show("Operation Failed");

                    UpdateDGT();

                }
                
            }
            else
            {
                MessageBox.Show("Please select row");
            }
            editable = false;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (editable)
            {
                if (MessageBox.Show("Are you sure?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bll.Id = int.Parse(textBoxLedgerID.Text);

                    bool isDeleted = dal.Delete(bll);
                    ClearAllFields();
                    UpdateDGT();
                    AllFieldsDisable();
                }
            }
            else
            {
                MessageBox.Show("Please select row to be edited");
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            UpdateDGT();
            ClearAllFields();
            AllFieldsDisable();
        }

        private void FormLedger_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;


            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }

        
    }
}
