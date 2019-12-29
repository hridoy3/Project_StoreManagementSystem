using System;
using System.Drawing;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;
using WarehouseApp.UI;

namespace WarehouseApp
{
    public partial class FormAdminDashboard : Form
    {
        
        Image closeImage, closeImageAct;
        FormLogin formLogin;

        public FormAdminDashboard(FormLogin formLogin)
        {
            InitializeComponent();
            //formUsers = new FormUsers();
            this.formLogin = formLogin;
        }

        

        //FormUsers formUser = new FormUsers();




        private void toolStripMenuItemUser_Click(object sender, EventArgs e)
        {

            //CreateFormPage(new FromProducts());
            
            
        }
        //void CreateFormPage(FromProducts formUser)
        //{
        //    TabPage tabPage = new TabPage { Text = formUser.Text };
        //    //tabControlHome.TabPages.Add(userAdd);
        //    tabControlHome.TabPages.Add(tabPage);
        //    formUser.TopLevel = false;
        //    formUser.Parent = tabPage;
        //    //formUsers.ApplySettingsSize(this.tabControlHome.Height, this.tabControlHome.Width);
        //    formUser.Anchor = AnchorStyles.Bottom;
        //    formUser.Anchor = AnchorStyles.Left;
        //    formUser.Anchor = AnchorStyles.Right;
        //    formUser.Anchor= AnchorStyles.Top;
        //    formUser.Dock = DockStyle.Fill;
        //    formUser.Show();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            tabControlHome.TabPages.Remove(tabControlHome.SelectedTab);
        }

        private void FormAdminDashboard_Load(object sender, EventArgs e)
        {
            labelLoggedInUser.Text = FormLogin.loggedInUser;

            /////////////////
            Size mysize = new Size(20, 20); // size of cross icon
            //Bitmap bt = new Bitmap(Properties.Resources.close);
            //// 
            Bitmap btm = new Bitmap(Properties.Resources.close, mysize);
            closeImageAct = btm;
            ////
            ////
            //Bitmap bt2 = new Bitmap(Properties.Resources.closeBlack);
            //// anh nay ban dau minh da them vao
            Bitmap btm2 = new Bitmap(Properties.Resources.closeBlack, mysize);
            closeImage = btm2;
            tabControlHome.Padding = new Point(30);
            /////////////////

        }

        private void FormAdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Application.Exit();
            
        }

        

        

        

        ////////////////////////////////////////

        private void AddTabPage(Form frm)
        {
            int t = getTabCounts(frm);
            if (t >= 0) 
            {
                
                if (tabControlHome.SelectedTab == tabControlHome.TabPages[t])
                    MessageBox.Show("Tap '" + frm.Text.Trim() + "' is currently open!");
                else
                    tabControlHome.SelectedTab = tabControlHome.TabPages[t];
            }
            else 
            {
                TabPage newTab = new TabPage(frm.Text.Trim());
                tabControlHome.TabPages.Add(newTab);
                frm.TopLevel = false;
                frm.Parent = newTab;
                tabControlHome.SelectedTab = tabControlHome.TabPages[tabControlHome.TabCount - 1];
                
                frm.Show();
                frm.Dock = DockStyle.Fill;

            }
        }
        private int getTabCounts(Form frm)
        {
            for (int i = 0; i < tabControlHome.TabCount; i++)
            {
                if (tabControlHome.TabPages[i].Text == frm.Text.Trim())
                {
                    return i;
                }
            }
            return -1;
        }

        private void userSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAuthenticationCheck fAC = new FormAuthenticationCheck();
            

            if (CheckSettingsAuthentication(fAC))
            {
                //fAC.Hide();
                AddTabPage(new FormUsersAUD());
                fAC.success = false;
            }
                            
            //AddTabPage(new FormUsersAUD());
        }

        

        bool CheckSettingsAuthentication(FormAuthenticationCheck fAC)
        {
            fAC.ShowDialog();
            return fAC.success;
        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormUsersList());
        }

        private void tabControlHome_MouseClick(object sender, MouseEventArgs e)
        {

            for (int i = 0; i < tabControlHome.TabCount; i++)
            {

                Rectangle rect = tabControlHome.GetTabRect(i);
                Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width,
                    rect.Top + (rect.Height - closeImage.Height) / 2,
                    closeImage.Width, closeImage.Height);

                if (imageRec.Contains(e.Location))
                    tabControlHome.TabPages.Remove(tabControlHome.SelectedTab);
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

        private void categotyEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormCategories());
        }

        private void editProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormProducts());
        }

        private void customerAndDealerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
         {
            AddTabPage(new FormCustomersDealers());
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormPurchaseAndSales() { Text = "Purchase" });
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormPurchaseAndSales() { Text = "Sale" });
        }

        private void transactionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormTransactions());
        }

        private void inventoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormInventory());
        }

        private void categoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormCategoriesList());
        }

        private void customerAndDealerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormCustomersDealersList());
        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormProductsList());
        }

        private void ledgerEditDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new FormLedger());
        }

        private void addManualToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void tabControlHome_DrawItem(object sender, DrawItemEventArgs e)
        {
            // minh viet san, khoi mat thoi gian
            Rectangle rect = tabControlHome.GetTabRect(e.Index);
            Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width,
                rect.Top + (rect.Height - closeImage.Height) / 2,
                closeImage.Width, closeImage.Height);
            // tang size rect
            rect.Size = new Size(rect.Width + 20, 38);

            Font f;
            Brush br = Brushes.Black;
            StringFormat strF = new StringFormat(StringFormat.GenericDefault);
            // neu tab dang duoc chon
            if (tabControlHome.SelectedTab == tabControlHome.TabPages[e.Index])
            {
                // hinh mau do, hinh nay them tu properti
                e.Graphics.DrawImage(closeImageAct, imageRec);
                f = new Font("Segoe UI", 10, FontStyle.Bold);
                // Ten tabPage
                e.Graphics.DrawString(tabControlHome.TabPages[e.Index].Text,
                    f, br, rect, strF);
            }
            else
            {
                // Tap dang mo, nhung ko dc chon, hinh mau den
                e.Graphics.DrawImage(closeImage, imageRec);
                f = new Font("Segoe UI", 9, FontStyle.Regular);
                // Ten tabPage
                e.Graphics.DrawString(tabControlHome.TabPages[e.Index].Text,
                    f, br, rect, strF);
            }
        }

        ////////////////////////

    }
}
