using System;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormAddManualPayment : Form
    {
        CustDeaDAL cdDAL = new CustDeaDAL();
        LedgerDAL lDAL = new LedgerDAL();

        public FormAddManualPayment()
        {
            InitializeComponent();
        }



        void ClearDeaAndCust()
        {
            this.textBoxtName.Text = this.textBoxEmail.Text = this.textBoxContact.Text
                = this.textBoxAddress.Text = this.labelDealerOrCustomerID.Text = this.textBoxDue.Text
                = this.textBoxSearchDealerAndCustomer.Text = string.Empty;
            this.textBoxDueRemaining.Text = string.Empty;
            this.textBoxDiscount.Text = this.textBoxGrandTotal.Text = this.textBoxPaidAmount.Text = this.textBoxReturnAmount.Text = string.Empty;
        }

        void ClearCalculations()
        {
            this.textBoxDiscount.Text = this.textBoxGrandTotal.Text
                = this.textBoxReturnAmount.Text = this.textBoxDueRemaining.Text = string.Empty;
        }

        void ClearAllTransactions()
        {
            ClearCalculations();
            ClearDeaAndCust();

            this.textBoxType.Text = string.Empty;
        }

        private void radioButtonlCustomer_CheckedChanged(object sender, EventArgs e)
        {
            panelLedgerList.Visible = true;
            panelManualPaymentEntries.Visible = true;

            this.textBoxType.Text = "Sale Adjustment";
            //ClearAllTransactions();
            ClearDeaAndCust();
            CalculationFieldsOff();
        }

        private void radioButtonDealerAndCustomer_CheckedChanged(object sender, EventArgs e)
        {
            panelLedgerList.Visible = true;
            panelManualPaymentEntries.Visible = true;

            this.textBoxType.Text = "Purchase Adjustment";
            //ClearAllTransactions();
            ClearDeaAndCust();
            CalculationFieldsOff();
            
        }

        private void textBoxSearchDealerAndCustomer_TextChanged(object sender, EventArgs e)
        {
            string keyWords = textBoxSearchDealerAndCustomer.Text;
            CustDeaBLL cd = new CustDeaBLL();

            if (keyWords == "")
            {

                //ClearAllTransactions();
                //CalculationFieldsOff();
                ClearDeaAndCust();

                return;
            }
            else if (this.textBoxType.Text == "Sale Adjustment")
            {
                cd = cdDAL.SearchCustomerForTransaction(keyWords);
                cd.Type = "Customer";
            }
            else if (this.textBoxType.Text == "Purchase Adjustment")
            {
                cd = cdDAL.SearchDealerForTransaction(keyWords);
                cd.Type = "Dealer";
            }

            this.textBoxtName.Text = cd.Name;
            this.textBoxEmail.Text = cd.Email;
            this.textBoxContact.Text = cd.Contact;
            this.textBoxAddress.Text = cd.Address;
            this.labelDealerOrCustomerID.Text = cd.Id.ToString();
            this.textBoxDue.Text = cd.Due.ToString();
            this.textBoxDueRemaining.Text = cd.Due.ToString();

        }

        void UpdateDGV()
        {
            dataGridViewLedger.DataSource = lDAL.Select();
        }

        private void FormAddManualPayment_Load(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void textBoxDiscount_TextChanged(object sender, EventArgs e)
        {
            //get discount percentage
            string value = this.textBoxDiscount.Text;

            if (value == "")
            {
                textBoxGrandTotal.Text = "";

            }
            else
            {
                textBoxPaidAmount.Text = "";
                decimal remainingDue = decimal.Parse(this.textBoxDueRemaining.Text);
                decimal discount = decimal.Parse(this.textBoxDiscount.Text);

                if (discount >= 100)
                {
                    discount = 100;
                    textBoxDiscount.Text = "100";

                }


                //Grand total adjustment for discount
                decimal grandTotal = ((100 - discount) / 100) * remainingDue;

                //dispaly grandTotal in textbox
                this.textBoxGrandTotal.Text = grandTotal.ToString();
            }
        }



        void CalculationFieldsOn()
        {
            this.textBoxDiscount.Enabled = this.textBoxPaidAmount.Enabled = true;
            this.buttonAdd.Enabled = true;
        }
        void CalculationFieldsOff()
        {
            this.textBoxDiscount.Enabled = this.textBoxPaidAmount.Enabled = false;
            buttonAdd.Enabled = false;
        }

        private void textBoxPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxPaidAmount.Text == "" || this.textBoxGrandTotal.Text == "")
            {
                this.textBoxReturnAmount.Text = null;
            }
            else
            {
                decimal grandTotal = Math.Round(decimal.Parse(this.textBoxGrandTotal.Text));
                decimal paidAmount = Math.Round(decimal.Parse(this.textBoxPaidAmount.Text));
                if (paidAmount >= grandTotal)
                {
                    this.textBoxPaidAmount.Text = grandTotal.ToString();
                    paidAmount = grandTotal;
                }

                decimal returnAmount = paidAmount - grandTotal;
                this.textBoxReturnAmount.Text = returnAmount.ToString();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (this.textBoxSearchDealerAndCustomer.Text == "" || this.textBoxDiscount.Text == "" || this.textBoxPaidAmount.Text == "")
            {
                MessageBox.Show("Please enter Discount and Paid Account fields");
            }
            else
            {
                if (MessageBox.Show("Are you sure?", "Add User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    LedgerBLL ledgerBLL = new LedgerBLL();
                    ledgerBLL.dea_cust_id = int.Parse(this.labelDealerOrCustomerID.Text);
                    ledgerBLL.GrandTotal = decimal.Parse(this.textBoxGrandTotal.Text);
                    ledgerBLL.transaction_date = DateTime.Now;
                    ledgerBLL.Tax = 0;
                    ledgerBLL.Discount = decimal.Parse(this.textBoxDiscount.Text);
                    ledgerBLL.AddedBy = FormLogin.loggedInUserId;
                    if (this.textBoxType.Text == "Purchase Adjustment")
                    {
                        ledgerBLL.Type = "Purchase Adjustment";
                    }
                    else if (this.textBoxType.Text == "Sale Adjustment")
                    {
                        ledgerBLL.Type = "Sale Adjustment";
                    }
                    else
                    {
                        MessageBox.Show("Adjustment entry error");
                    }


                    //ledgerBLL.Product_id = 1;

                    ledgerBLL.Product_id = 0;
                    ledgerBLL.Rate = 0;
                    ledgerBLL.Qty = 0;
                    ledgerBLL.Total = 0;
                    //ledgerBLL.dea_cust_id = int.Parse(this.labelCustDeaID.Text);
                    //ledgerBLL.transaction_date = DateTime.Now;
                    //ledgerBLL.AddedBy = FormLogin.loggedInUserId;
                    //ledgerBLL.Type = this.Text;
                    ledgerBLL.Title = "";

                    decimal due = cdDAL.GetDueAmount(int.Parse(this.labelDealerOrCustomerID.Text));
                    //decimal returnAmount = Math.Round(decimal.Parse(textBoxReturnAmount.Text), 2);
                    decimal paidAmount = Math.Round(decimal.Parse(textBoxPaidAmount.Text), 2);

                    ledgerBLL.Bill = decimal.Parse(textBoxPaidAmount.Text);

                    ledgerBLL.Balance = due - paidAmount;

                    bool ss = cdDAL.UpdateDue(ledgerBLL.dea_cust_id, ledgerBLL.Balance);
                    if (!ss)
                    {
                        MessageBox.Show("Due Update Failed");
                    }
                    bool success = lDAL.Insert(ledgerBLL);
                    if (!success)
                    {
                        MessageBox.Show("Ledger Insert failed");
                    }
                    UpdateDGV();
                    textBoxSearch.Text = textBoxSearchDealerAndCustomer.Text =  string.Empty;
                }

            }

        }

        private void labelDealerOrCustomerID_TextChanged(object sender, EventArgs e)
        {
            if (this.labelDealerOrCustomerID.Text == "" || this.labelDealerOrCustomerID.Text == "0")
            {
                CalculationFieldsOff();
            }
            else
            {
                CalculationFieldsOn();
            }

        }

        private void textBoxDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;


            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            UpdateDGV();
            ClearAllTransactions();
            CalculationFieldsOff();
        }
    }
}
