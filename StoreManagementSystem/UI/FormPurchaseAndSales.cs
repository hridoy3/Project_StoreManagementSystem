using System;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;

namespace WarehouseApp.UI
{
    public partial class FormPurchaseAndSales : Form
    {
        CustDeaDAL cdDAL = new CustDeaDAL();
        ProductsDAL pDAL = new ProductsDAL();
        DataTable transactionDT = new DataTable();
        TransactionDAL tDLA = new TransactionDAL();
        TransactionDetailDAL tdDAL = new TransactionDetailDAL();
        NormalCustomerDAL nDAL = new NormalCustomerDAL();
        LedgerDAL lDal = new LedgerDAL();

        public FormPurchaseAndSales()
        {
            InitializeComponent();
        }


        private void textBoxSearchDeaCust_TextChanged(object sender, EventArgs e)
        {
            string keyWords = textBoxSearchDeaCust.Text;
            CustDeaBLL cd = new CustDeaBLL();

            if (keyWords == "")
            {
                ClearDeaCust();
                return;
            }
            else if (this.Text == "Sale")
            {
                cd = cdDAL.SearchCustomerForTransaction(keyWords);
                cd.Type = "Customer";
            }
            else if (this.Text == "Purchase")
            {
                cd = cdDAL.SearchDealerForTransaction(keyWords);
                cd.Type = "Dealer";
            }
            //CustDeaBLL cd = cdDAL.SearchDealerForTransaction(keyWords);
            this.labelCustDeaID.Text = cd.Id.ToString();
            this.textBoxCDname.Text = cd.Name;
            this.textBoxCDemail.Text = cd.Email;
            this.textBoxCDcontact.Text = cd.Contact;
            this.textBoxCDaddress.Text = cd.Address;
            this.labelBalance.Text = cd.Due.ToString();
            this.textBoxCDType.Text = cd.Type.ToString();

        }

        

        void ClearDeaCust()
        {
            this.textBoxCDaddress.Text = this.textBoxCDname.Text = this.textBoxCDemail.Text
                = this.textBoxCDcontact.Text = this.labelBalance.Text = this.textBoxSearchDeaCust.Text
                = this.labelCustDeaID.Text = this.textBoxCDType.Text = string.Empty;
        }

        private void textBoxSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string keyWord = textBoxSearchProduct.Text;
            if (keyWord == "")
            {
                ClearProductFiends();
                return;
            }

            ProductsBLL pbll = pDAL.SearchProductForTransaction(keyWord);

            this.labelProductName.Text = pbll.Name;
            this.labelProductInventory.Text = pbll.Qty.ToString();
            this.labelProductRate.Text = pbll.Rate.ToString();
            this.labelProductId.Text = pbll.Id.ToString();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if ((labelCustDeaID.Text == "" || labelCustDeaID.Text == "0") && radioButtonDealerAndCustomer.Checked)
            {
                MessageBox.Show("Please Add Customer and Dealer");
            }
            else if (textBoxProductQty.Text != "" && this.Text == "Sale")
            {
                if ((decimal.Parse(textBoxProductQty.Text) > decimal.Parse(labelProductInventory.Text)))
                {
                    MessageBox.Show(labelProductName.Text + " is Out of stock");
                }

            }
            else if (labelProductId.Text == "" || labelProductId.Text == "0")
            {
                MessageBox.Show("Please enter required product");
            }
            else
            {
                if (this.textBoxProductQty.Text != "" && this.labelProductId.Text != "")
                {
                    //get product details
                    string productName = this.labelProductName.Text;
                    Decimal rate = decimal.Parse(this.labelProductRate.Text.ToString());
                    decimal qty = decimal.Parse(this.textBoxProductQty.Text);
                    decimal total = rate * qty;
                    decimal subTotal = 0;
                    if (this.textBoxSubTotal.Text == "")
                    {
                        this.textBoxSubTotal.Text = "0";
                        subTotal = decimal.Parse(this.textBoxSubTotal.Text);
                        subTotal = subTotal + total;
                    }
                    else
                    {
                        subTotal = decimal.Parse(this.textBoxSubTotal.Text);
                        subTotal = subTotal + total;
                    }


                    if (productName == "")
                    {
                        MessageBox.Show("Product was not selected");
                    }
                    else
                    {
                        transactionDT.Rows.Add(productName, rate, qty, total);

                        this.dataGridViewPandS.DataSource = transactionDT;

                        //Dispaly Subtotal in textbox
                        this.textBoxSubTotal.Text = subTotal.ToString();

                        //clear all product fields
                        ClearProductFiends();
                    }


                }
                else
                {
                    MessageBox.Show("Please Add Quantity And Enter Product");
                }

                CalcDetailsFieldsOn();
            }

        }

        void ClearProductFiends()
        {
            this.labelProductName.Text = this.labelProductInventory.Text = this.labelProductRate.Text
                = this.textBoxProductQty.Text = this.labelProductId.Text = this.textBoxSearchProduct.Text
                = string.Empty;
        }

        void ClearAllTransactions()
        {
            ClearDeaCust();
            ClearProductFiends();
            ClearCalculationList();
            ClearNormalCustomerDetails();

            this.checkBoxAddToBalance.Checked = false;
        }

        private void FormPurchaseAndSales_Load(object sender, EventArgs e)
        {
            //specify columns for transection data table
            transactionDT.Columns.Add("Product Name");
            transactionDT.Columns.Add("Rate");
            transactionDT.Columns.Add("Quantuty");
            //transactionDT.Columns.Add("Paid");
            transactionDT.Columns.Add("Total");
            
            //this.comboBoxPS.Text = "Normal Custormer";


            CalcDetailsFieldsOff();
        }

        void CalcDetailsFieldsOn()
        {
            this.textBoxDiscount.ReadOnly = this.textBoxVat.ReadOnly = this.textBoxPaidAmount.ReadOnly = false;
        }

        void CalcDetailsFieldsOff()
        {
            this.textBoxDiscount.ReadOnly = this.textBoxVat.ReadOnly = this.textBoxPaidAmount.ReadOnly = true;
        }

        private void textBoxDiscount_TextChanged(object sender, EventArgs e)
        {
            //get discount percentage
            string value = this.textBoxDiscount.Text;

            if (value == "")
            {
                //Display Error promt
                //MessageBox.Show("Please Enter discount amount");
                //this.textBoxDiscount.Text = "0.00";
                //MessageBox.Show("Please enter decimal value");
            }
            else
            {
                //get decimal values
                decimal subTotal = decimal.Parse(this.textBoxSubTotal.Text);
                decimal discount = decimal.Parse(this.textBoxDiscount.Text);

                //Grand total adjustment for discount
                decimal grandTotal = ((100 - discount) / 100) * subTotal;

                //dispaly grandTotal in textbox
                this.textBoxGrandTotal.Text = grandTotal.ToString();
            }
        }

        private void textBoxVat_TextChanged(object sender, EventArgs e)
        {
            //check id grand total has valur if has value calc discount
            string check = textBoxVat.Text;
            if (check == "")
            {
                //Display the error prompt
                //MessageBox.Show("Please enter decimal value");
                //textBoxVat.Text = "0.00";

            }
            else
            {
                //calculate vat
                //getting val % first
                decimal previousGT = decimal.Parse(this.textBoxGrandTotal.Text);
                decimal val = decimal.Parse(this.textBoxVat.Text);
                decimal grandTotalWithVat = ((100 + val) / 100) * previousGT;

                //Displaying new grandtotal with vat
                this.textBoxGrandTotal.Text = grandTotalWithVat.ToString();
            }
        }

        private void textBoxSubTotal_TextChanged(object sender, EventArgs e)
        {
            this.textBoxGrandTotal.Text = this.textBoxSubTotal.Text;
        }

        private void textBoxPaidAmount_TextChanged(object sender, EventArgs e)
        {
            
            
            if (this.textBoxPaidAmount.Text == "" || this.textBoxGrandTotal.Text == "")
            {
                this.textBoxReturnAmount.Text = null;
            }
            else
            {
                decimal grandTotal = Math.Round(decimal.Parse(this.textBoxGrandTotal.Text), 2);
                decimal paidAmount = Math.Round(decimal.Parse(this.textBoxPaidAmount.Text), 2);
                
                decimal returnAmount = paidAmount - grandTotal;
                this.textBoxReturnAmount.Text = returnAmount.ToString();
            }
            
            


            //this.textBoxReturnAmount.Text = returnAmount.ToString();
        }

        //Checking if discount and val values are added
        bool CheckDiscountAndVatFields()
        {
            bool isEmpty;
            if (this.textBoxVat.Text == "" && this.textBoxDiscount.Text == "" && this.textBoxPaidAmount.Text == "")
            {
                MessageBox.Show("Enter Discount and Vat And Paid Amount");
                isEmpty = true;
            }
            else if (this.textBoxDiscount.Text == "" && this.textBoxPaidAmount.Text == "")
            {
                isEmpty = true;
                MessageBox.Show("Enter Discount And Paid Amount");
            }
            else if (this.textBoxVat.Text == "" && this.textBoxPaidAmount.Text == "")
            {
                MessageBox.Show("Enter Vat and Paid Amount");
                isEmpty = true;
            }
            else if (this.textBoxVat.Text == "" && this.textBoxDiscount.Text == "")
            {
                MessageBox.Show("Enter Vat and Discount");
                isEmpty = true;
            }
            else if (this.textBoxVat.Text == "")
            {
                MessageBox.Show("Enter Vat Amount");
                isEmpty = true;
            }
            else if (this.textBoxDiscount.Text == "")
            {
                MessageBox.Show("Enter discount Amount");
                isEmpty = true;
            }
            else if (this.textBoxPaidAmount.Text == "")
            {
                MessageBox.Show("Enter Paid Amount");
                isEmpty = true;
            }

            else
            {
                isEmpty = false;
            }
            return isEmpty;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            if(transactionDT.Rows.Count > 0 && !CheckDiscountAndVatFields() && radioButtonDealerAndCustomer.Checked)
            {
                decimal returnAmount = 0;
                
                if (textBoxReturnAmount.Text == "")
                {
                    
                }
                else
                {
                    returnAmount = decimal.Parse(textBoxReturnAmount.Text);
                }
                
                if (returnAmount<0 && checkBoxAddToBalance.Checked == false)
                {
                    MessageBox.Show("Please check Add to balance OR adjust paid amount");
                }
                else
                {
                    AddExistingCustandDealerEntry(new TransactionsBLL(), new LedgerBLL());
                    
                }
            }
            else if (transactionDT.Rows.Count > 0 && radioButtonNormalCustomer.Checked && !CheckDiscountAndVatFields())
            {
                decimal returnAmount = 0;

                if (textBoxReturnAmount.Text == "")
                {

                }
                else
                {
                    returnAmount = decimal.Parse(textBoxReturnAmount.Text);
                }

                if (returnAmount < 0)
                {
                    MessageBox.Show("Please adjust paid amount");
                }
                else
                {
                    AddNonExistingCustandDealerEntry(new TransactionsBLL(), new LedgerBLL());
                }
            }

            //if (CheckCalculationFields())
            //{

            //}
            //else
            //{
            //    MessageBox.Show("Please enter Discount, Vat, Paid Amount and other Requirments");
            //}

            //AddExistingCustandDealerEntry(new TransactionsBLL());

            //CODE TO INSERT TRANSECTION AND TRANSACTION DETAILS


            if (dataGridViewPandS.DataSource == null)
            {
                CalcDetailsFieldsOff();
            }
            
        }

        void AddExistingCustandDealerEntry(TransactionsBLL tBLL, LedgerBLL ledgerBLL)
        {

            //Get value form purchase sales form
            //TransactionsBLL tBLL = new TransactionsBLL();
            tBLL.Type = this.Text;
            //MessageBox.Show(this.Text);
            tBLL.Dea_Cus_tId = int.Parse(this.labelCustDeaID.Text);
            tBLL.GrandTotal = decimal.Parse(this.textBoxGrandTotal.Text);
            tBLL.TransactionDate = DateTime.Now;
            tBLL.Tax = decimal.Parse(this.textBoxVat.Text);
            tBLL.Discount = decimal.Parse(this.textBoxDiscount.Text);
            tBLL.AddedBy = FormLogin.loggedInUserId;

            tBLL.TransactionDetails = transactionDT;

            
            //Add to ladger
            //ledgerBLL.Type = this.Text;
            //ledgerBLL.dea_cust_id = int.Parse(this.labelCustDeaID.Text);


            ///

            bool success = false;
            int transactionID = -1;

            bool w = tDLA.InsertTransaction(tBLL, out transactionID);

            for (int i = 0; i < transactionDT.Rows.Count; i++)
            {
                TransactionDetailsBLL transactionDetail = new TransactionDetailsBLL();
                
                //MessageBox.Show(transactionDT.Rows[i][0].ToString());
                ProductsBLL pBll = pDAL.GetIdFromName(transactionDT.Rows[i][0].ToString());

                transactionDetail.ProductId = int.Parse(pBll.Id.ToString());
                transactionDetail.Rate = Math.Round(decimal.Parse(transactionDT.Rows[i][1].ToString()), 2);
                transactionDetail.Qty = Math.Round(decimal.Parse(transactionDT.Rows[i][2].ToString()), 2);
                transactionDetail.Total = Math.Round(decimal.Parse(transactionDT.Rows[i][3].ToString()), 2);
                //////////
                transactionDetail.TransactionID = transactionID;
                //////////
                transactionDetail.Dea_Cust_Id = int.Parse(this.labelCustDeaID.Text);
                //Updating customer and dealers balance
                transactionDetail.AddedDate = DateTime.Now;
                transactionDetail.AddedBy = FormLogin.loggedInUserId;
                
                /////legder
                ledgerBLL.Product_id = int.Parse(pBll.Id.ToString());
                ledgerBLL.Rate = Math.Round(decimal.Parse(transactionDT.Rows[i][1].ToString()), 2);
                ledgerBLL.Qty = Math.Round(decimal.Parse(transactionDT.Rows[i][2].ToString()), 2);
                ledgerBLL.Total = Math.Round(decimal.Parse(transactionDT.Rows[i][3].ToString()), 2);
                ledgerBLL.dea_cust_id = int.Parse(this.labelCustDeaID.Text);
                ledgerBLL.transaction_date = DateTime.Now;
                ledgerBLL.AddedBy = FormLogin.loggedInUserId;
                ledgerBLL.Type = this.Text;
                ledgerBLL.Title = transactionDT.Rows[i][0].ToString();
                
                
                decimal due = cdDAL.GetDueAmount(int.Parse(this.labelCustDeaID.Text));
                ledgerBLL.Balance = due + ledgerBLL.Total;
                    //decimal returnAmount = Math.Round(decimal.Parse(textBoxReturnAmount.Text), 2);
                    //ledgerBLL.Balance = due + (-1 * returnAmount);
                
                //else
                //{
                //    ledgerBLL.Balance = cdDAL.GetDueAmount(int.Parse(this.labelCustDeaID.Text));
                //}
                
                



                //Transaciton type
                string transactionType = this.Text;
                //MessageBox.Show(transactionType);
                bool x = false;
                if (transactionType == "Purchase")
                {
                    x = pDAL.IncreaseProduct(transactionDetail.ProductId, transactionDetail.Qty);
                }
                else if (transactionType == "Sale")
                {
                    x = pDAL.DecreaseProduct(transactionDetail.ProductId, transactionDetail.Qty);
                }


                bool y = tdDAL.InsertTransacionDetail(transactionDetail);
                bool l = lDal.Insert(ledgerBLL);
                success = w && x && y && l;

            }

            success = success && AdjustPaidAmount();

            if (success)
            {
                //scope.Complete();
                MessageBox.Show("Transaction Completed Successfully");
                //ClearAllTransactions();
                ClearAllTransactions();

                dataGridViewPandS.DataSource = null;
                dataGridViewPandS.Rows.Clear();
                transactionDT.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Transaction oporation Failed");
            }
        }

        bool AdjustPaidAmount()
        {
            LedgerBLL ledgerBLL = new LedgerBLL();
            ledgerBLL.dea_cust_id = int.Parse(this.labelCustDeaID.Text);
            ledgerBLL.GrandTotal = decimal.Parse(this.textBoxGrandTotal.Text);
            ledgerBLL.transaction_date = DateTime.Now;
            ledgerBLL.Tax = decimal.Parse(this.textBoxVat.Text);
            ledgerBLL.Discount = decimal.Parse(this.textBoxDiscount.Text);
            ledgerBLL.AddedBy = FormLogin.loggedInUserId;
            if (this.Text == "Purchase")
            {
                ledgerBLL.Type = "Purchase Adjustment";
            }
            else if (this.Text == "Sale")
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

            if (checkBoxAddToBalance.Checked == true)
            {
                decimal due = cdDAL.GetDueAmount(int.Parse(this.labelCustDeaID.Text));
                decimal returnAmount = Math.Round(decimal.Parse(textBoxReturnAmount.Text), 2);
                ledgerBLL.Balance = due + (-1 * returnAmount);
                ledgerBLL.Bill = decimal.Parse(textBoxPaidAmount.Text);
                //else
                //{
                //    ledgerBLL.Balance = cdDAL.GetDueAmount(int.Parse(this.labelCustDeaID.Text));
                //}
            }
            else
            {
                decimal due = cdDAL.GetDueAmount(int.Parse(this.labelCustDeaID.Text));
                ledgerBLL.Bill = decimal.Parse(textBoxGrandTotal.Text);
                ledgerBLL.Balance = cdDAL.GetDueAmount(int.Parse(this.labelCustDeaID.Text));
            }
            bool ss = cdDAL.UpdateDue(ledgerBLL.dea_cust_id, ledgerBLL.Balance);
            if (!ss)
            {
                MessageBox.Show("Due Update Failed");
            }
            return lDal.Insert(ledgerBLL);
        }

        bool AddCustomerInfo(ref int nCustomer)
        {
            bool success = false;
            NormalCustomerBLL nBLL = new NormalCustomerBLL();
            nBLL.Name = this.textBoxNName.Text;
            nBLL.Email = this.textBoxNEmail.Text;
            nBLL.Contact = this.textBoxNContact.Text;
            nBLL.Address = this.textBoxNAddress.Text;
            nBLL.AddedDate = DateTime.Now;
            nBLL.AddedBy = FormLogin.loggedInUserId;
            //int nCustomer = -1;
            success = nDAL.Insert(nBLL, out nCustomer);
            return success;
        }

        void AddNonExistingCustandDealerEntry(TransactionsBLL tBLL, LedgerBLL ledgerBLL)
        {
            bool success = false;
            int nCustomer = -1;
            bool c = AddCustomerInfo(ref nCustomer);
            
            tBLL.Type = this.Text;
            
            //tBLL.Dea_Cus_tId = int.Parse(this.labelCustDeaID.Text);
            tBLL.GrandTotal = decimal.Parse(this.textBoxGrandTotal.Text);
            tBLL.TransactionDate = DateTime.Now;
            tBLL.Tax = decimal.Parse(this.textBoxVat.Text);
            tBLL.Discount = decimal.Parse(this.textBoxDiscount.Text);
            tBLL.AddedBy = FormLogin.loggedInUserId;

            tBLL.TransactionDetails = transactionDT;
            int transactionID = -1;
            bool w = tDLA.InsertTransaction(tBLL, out transactionID);

            for (int i = 0; i < transactionDT.Rows.Count; i++)
            {

                TransactionDetailsBLL transactionDetail = new TransactionDetailsBLL();

                
                ProductsBLL pBll = pDAL.GetIdFromName(transactionDT.Rows[i][0].ToString());

                transactionDetail.ProductId = int.Parse(pBll.Id.ToString());
                transactionDetail.Rate = Math.Round(decimal.Parse(transactionDT.Rows[i][1].ToString()), 2);
                transactionDetail.Qty = Math.Round(decimal.Parse(transactionDT.Rows[i][2].ToString()), 2);
                transactionDetail.Total = Math.Round(decimal.Parse(transactionDT.Rows[i][3].ToString()), 2);
                //////////
                transactionDetail.TransactionID = transactionID;
                //////////
                //transactionDetail.Dea_Cust_Id = int.Parse(this.labelCustDeaID.Text);

                //Updating customer and dealers balance
                transactionDetail.AddedDate = DateTime.Now;
                transactionDetail.AddedBy = FormLogin.loggedInUserId;

                /////legder
                ledgerBLL.Product_id = int.Parse(pBll.Id.ToString());
                ledgerBLL.Rate = Math.Round(decimal.Parse(transactionDT.Rows[i][1].ToString()), 2);
                ledgerBLL.Qty = Math.Round(decimal.Parse(transactionDT.Rows[i][2].ToString()), 2);
                ledgerBLL.Total = Math.Round(decimal.Parse(transactionDT.Rows[i][3].ToString()), 2);
                //ledgerBLL.dea_cust_id = int.Parse(this.labelCustDeaID.Text);
                ledgerBLL.transaction_date = DateTime.Now;
                ledgerBLL.AddedBy = FormLogin.loggedInUserId;
                ledgerBLL.Type = this.Text;
                ledgerBLL.Title = transactionDT.Rows[i][0].ToString();
                ledgerBLL.n_cust_id = nCustomer;


                //decimal due = cdDAL.GetDueAmount(int.Parse(this.labelCustDeaID.Text));
                //ledgerBLL.Balance = due + ledgerBLL.Total;
                
                //Transaciton type
                string transactionType = this.Text;
                //MessageBox.Show(transactionType);
                bool x = false;
                if (transactionType == "Purchase")
                {
                    x = pDAL.IncreaseProduct(transactionDetail.ProductId, transactionDetail.Qty);
                }
                else if (transactionType == "Sale")
                {
                    x = pDAL.DecreaseProduct(transactionDetail.ProductId, transactionDetail.Qty);
                }


                bool y = tdDAL.InsertTransacionDetail(transactionDetail);
                bool l = lDal.Insert(ledgerBLL);
                success = w && x && y && l && c;

            }

            //success = success && AdjustPaidAmount();

            if (success)
            {
                //scope.Complete();
                MessageBox.Show("Transaction Completed Successfully");
                //ClearAllTransactions();
                ClearAllTransactions();

                dataGridViewPandS.DataSource = null;
                dataGridViewPandS.Rows.Clear();
                transactionDT.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Transaction oporation Failed");
            }
        }

        void ClearCalculationList()
        {
            this.textBoxSubTotal.Text = "";
            this.textBoxDiscount.Text = "";
            this.textBoxGrandTotal.Text = "";
            this.textBoxPaidAmount.Text = "";
            this.textBoxReturnAmount.Text = "";
            this.textBoxVat.Text = "";
        }

        

        //Checking if calculation fields are empty due to exception
        bool CheckCalculationFields()
        {
            string discount = this.textBoxDiscount.Text;
            string vat = this.textBoxVat.Text;
            string paidAmount = this.textBoxPaidAmount.Text;

            if (discount == null || vat == null || paidAmount == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        




        // key Press events

        private void textBoxProductQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;


            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
            //(char)Keys.

        }

        private void textBoxSubTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;


            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
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

        private void textBoxVat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;


            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxGrandTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;


            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;


            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxReturnAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;


            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxReturnAmount_TextChanged(object sender, EventArgs e)
        {
            //if (textBoxReturnAmount.Text == "")
            //{
            //    this.buttonAddToBalance.Enabled = false;
            //}
            //else
            //{
            //    decimal returnAmount = Math.Round(decimal.Parse(this.textBoxReturnAmount.Text), 2);
            //    if (returnAmount < 0)
            //    {
            //        this.buttonAddToBalance.Enabled = true;
            //    }
            //    else
            //    {
            //        this.buttonAddToBalance.Enabled = false;
            //    }
            //}


        }

        

        

        private void textBoxNsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxAddToBalance_Click(object sender, EventArgs e)
        {

            if (this.textBoxReturnAmount.Text == "")
            {
                MessageBox.Show("Return amount is 0");
                this.checkBoxAddToBalance.Checked = false;
            }
            else if (decimal.Parse(this.textBoxReturnAmount.Text) >= 0)
            {
                MessageBox.Show("Amount paid more than cost of products. Please return " + this.textBoxReturnAmount.Text + "TK to cuntomer");
                this.checkBoxAddToBalance.Checked = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void comboBoxPS_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    comboBoxPS.Text = this.comboBoxPS.Text;
        //    ClearAllTransactions();

            
        //}



        private void radioButtonNormalCustomer_Click(object sender, EventArgs e)
        {

            //this.radioButtonDealerAndCustomer.Checked = false;
            //MessageBox.Show(this.radioButtonDealerAndCustomer.Checked.ToString());
        }

        private void radioButtonDealerAndCustomer_Click(object sender, EventArgs e)
        {
            //this.radioButtonDealerAndCustomer.Checked = false;
            //MessageBox.Show(this.radioButtonNormalCustomer.Checked.ToString());
        }

        private void radioButtonNormalCustomer_CheckedChanged(object sender, EventArgs e)
        {
            panelNormalCustomer.Visible = true;
            panelDeaAndCust.Visible = false;
            panelCalculations.Visible = true;
            panelProducts.Visible = true;
            buttonAdd.Visible = true;
            buttonSave.Visible = true;
            buttonRefresh.Visible = true;
            panelDatagridview.Visible = true;
            this.checkBoxAddToBalance.Enabled = false;

            ClearAllTransactions();
            dataGridViewPandS.DataSource = null;
            dataGridViewPandS.Rows.Clear();
            transactionDT.Rows.Clear();
        }
        /// <summary>
        /// /////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void comboBoxPS_TextChanged(object sender, EventArgs e)
        //{
        //    if (this.comboBoxPS.Text == "Normal Custormer")
        //    {
        //        this.panelNormalCustomer.Visible = true;
        //        this.panelDeaAndCust.Visible = false;
        //        this.checkBoxAddToBalance.Enabled = false;
        //    }
        //    else if (this.comboBoxPS.Text == "Dealar & Regular Customer")
        //    {
        //        this.panelDeaAndCust.Visible = true;
        //        this.panelNormalCustomer.Visible = false;
        //        this.checkBoxAddToBalance.Enabled = true;
        //    }
        //    else
        //    {
        //        this.checkBoxAddToBalance.Enabled = false;
        //    }
        //}

        private void radioButtonDealerAndCustomer_CheckedChanged(object sender, EventArgs e)
        {
            panelNormalCustomer.Visible = false;
            panelDeaAndCust.Visible = true;
            panelCalculations.Visible = true;
            panelProducts.Visible = true;
            buttonAdd.Visible = true;
            buttonSave.Visible = true;
            buttonRefresh.Visible = true;
            panelDatagridview.Visible = true;
            this.checkBoxAddToBalance.Enabled = true;

            ClearAllTransactions();
            dataGridViewPandS.DataSource = null;
            dataGridViewPandS.Rows.Clear();
            transactionDT.Rows.Clear();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            ClearAllTransactions();
            dataGridViewPandS.DataSource = null;
            dataGridViewPandS.Rows.Clear();
            transactionDT.Rows.Clear();
        }

        void ClearNormalCustomerDetails()
        {
            this.textBoxNAddress.Text = this.textBoxNContact.Text = this.textBoxNEmail.Text
                = this.textBoxNName.Text = string.Empty;
        }

        private void textBoxGrandTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
