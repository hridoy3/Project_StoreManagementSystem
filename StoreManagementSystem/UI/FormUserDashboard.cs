using System;
using System.Drawing;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;
using WarehouseApp.UI;

namespace WarehouseApp
{
    public partial class FormUserDashboard : Form
    {
        public FormUserDashboard()
        {
            InitializeComponent();
        }

        Image closeImage, closeImageAct;
        //FormLogin formLogin;
        private void button1_Click(object sender, EventArgs e)
        {

            tabControlUserDashboard.TabPages.Remove(tabControlUserDashboard.SelectedTab);
        }

        private void FormUserDashboard_Load(object sender, EventArgs e)
        {
            labelLoggedInUser.Text = FormLogin.loggedInUser;

            /////////////////
            Size mysize = new System.Drawing.Size(20, 20); 
            Bitmap bt = new Bitmap(Properties.Resources.close);
            
            Bitmap btm = new Bitmap(bt, mysize);
            closeImageAct = btm;
            ////
            ////
            Bitmap bt2 = new Bitmap(Properties.Resources.closeBlack);
            
            Bitmap btm2 = new Bitmap(bt2, mysize);
            closeImage = btm2;
            tabControlUserDashboard.Padding = new Point(30);
            /////////////////
        }

        private void FormUserDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        ////////////////////////////////////////

        private void AddTabPage(Form frm)
        {
            
            int t = getTabCounts(frm);
            if (t >= 0)
            {

                if (tabControlUserDashboard.SelectedTab == tabControlUserDashboard.TabPages[t])
                    MessageBox.Show("Tap \"" + frm.Text.Trim() + "\" is currently open!");
                else
                    tabControlUserDashboard.SelectedTab = tabControlUserDashboard.TabPages[t];
            }
            else
            {
                TabPage newTab = new TabPage(frm.Text.Trim());
                tabControlUserDashboard.TabPages.Add(newTab);
                frm.TopLevel = false;
                frm.Parent = newTab;
                tabControlUserDashboard.SelectedTab = tabControlUserDashboard.TabPages[tabControlUserDashboard.TabCount - 1];

                frm.Show();
                frm.Dock = DockStyle.Fill;

            }
        }
        private int getTabCounts(Form frm)
        {
            for (int i = 0; i < tabControlUserDashboard.TabCount; i++)
                if (tabControlUserDashboard.TabPages[i].Text == frm.Text.Trim())
                    return i;
            return -1;
        }

        private void tabControlUserDashboard_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControlUserDashboard.TabCount; i++)
            {

                Rectangle rect = tabControlUserDashboard.GetTabRect(i);
                Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width,
                    rect.Top + (rect.Height - closeImage.Height) / 2,
                    closeImage.Width, closeImage.Height);

                if (imageRec.Contains(e.Location))
                    tabControlUserDashboard.TabPages.Remove(tabControlUserDashboard.SelectedTab);
            }
        }

        private void tabControlUserDashboard_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            Rectangle rect = tabControlUserDashboard.GetTabRect(e.Index);
            Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width,
                rect.Top + (rect.Height - closeImage.Height) / 2,
                closeImage.Width, closeImage.Height);
            
            rect.Size = new Size(rect.Width + 20, 38);

            Font f;
            Brush br = Brushes.Black;
            StringFormat strF = new StringFormat(StringFormat.GenericDefault);
            
            if (tabControlUserDashboard.SelectedTab == tabControlUserDashboard.TabPages[e.Index])
            {
               
                e.Graphics.DrawImage(closeImageAct, imageRec);
                f = new Font("Segoe UI", 10, FontStyle.Bold);
                
                e.Graphics.DrawString(tabControlUserDashboard.TabPages[e.Index].Text,
                    f, br, rect, strF);
            }
            else
            {
                
                e.Graphics.DrawImage(closeImage, imageRec);
                f = new Font("Segoe UI", 9, FontStyle.Regular);
                
                e.Graphics.DrawString(tabControlUserDashboard.TabPages[e.Index].Text,
                    f, br, rect, strF);
            }
        }

        

        bool CheckSettingsAuthentication(FormAuthenticationCheck fAC)
        {
            fAC.ShowDialog();
            return fAC.success;
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormPurchaseAndSales() { Text = "Purchase" });
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormPurchaseAndSales() { Text = "Sale" });
        }

        private void editDealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormCustomersDealers());
        }

        private void inventoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormInventory());
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAuthenticationCheck fAC = new FormAuthenticationCheck();
            if (CheckSettingsAuthentication(fAC))
            {
                //fAC.Hide();
                AddTabPage(new FormUsersEdit());
                fAC.success = false;
            }
        }

        

        private void labelLogout_Click(object sender, EventArgs e)
        {
            UsersDAL uDAL = new UsersDAL();
            UsersBLL uBLL = new UsersBLL();

            uBLL.status = "Offline";
            uBLL.Id = FormLogin.loggedInUserId;
            uDAL.UpdateStatus(uBLL);
            FormLogin fl = new FormLogin();
            

            this.Hide();
            fl.Show();
        }

        private void deaAndCustListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormCustomersDealersList());
        }

        private void deaAndCustListToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddTabPage(new FormCustomersDealersList());
        }

        private void transactionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormTransactions());
        }

        private void addManualPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormAddManualPayment());
        }

        private void regualCustomerAndDealerTransactionHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormLedgerRegularCustomerListAndDealer());
        }

        private void normalCustomerTransactionHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormLedgerNormalCustomer());
        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormUsersList());
        }


    }
}
