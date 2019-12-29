namespace WarehouseApp
{
    partial class FormAdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemUser = new System.Windows.Forms.ToolStripMenuItem();
            this.userListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categotyEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerAndDealerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerAndDealerListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerAndDealerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ledgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ledgerEditDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regualCustomerAndDealerTransactionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalCustomerTransactionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControlHome = new System.Windows.Forms.TabControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelLoggedInUser = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.labelLogout = new System.Windows.Forms.Label();
            this.menuStripTop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripTop
            // 
            this.menuStripTop.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUser,
            this.categoryToolStripMenuItem,
            this.productToolStripMenuItem,
            this.customerAndDealerToolStripMenuItem,
            this.transactionToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.ledgerToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(692, 24);
            this.menuStripTop.TabIndex = 14;
            this.menuStripTop.Tag = "";
            this.menuStripTop.Text = "menuStripTop";
            // 
            // toolStripMenuItemUser
            // 
            this.toolStripMenuItemUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userListToolStripMenuItem,
            this.userSettingsToolStripMenuItem});
            this.toolStripMenuItemUser.Name = "toolStripMenuItemUser";
            this.toolStripMenuItemUser.Size = new System.Drawing.Size(42, 20);
            this.toolStripMenuItemUser.Text = "&User";
            this.toolStripMenuItemUser.Click += new System.EventHandler(this.toolStripMenuItemUser_Click);
            // 
            // userListToolStripMenuItem
            // 
            this.userListToolStripMenuItem.Name = "userListToolStripMenuItem";
            this.userListToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.userListToolStripMenuItem.Text = "User List";
            this.userListToolStripMenuItem.Click += new System.EventHandler(this.userListToolStripMenuItem_Click);
            // 
            // userSettingsToolStripMenuItem
            // 
            this.userSettingsToolStripMenuItem.Name = "userSettingsToolStripMenuItem";
            this.userSettingsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.userSettingsToolStripMenuItem.Text = "User Settings";
            this.userSettingsToolStripMenuItem.Click += new System.EventHandler(this.userSettingsToolStripMenuItem_Click);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoryListToolStripMenuItem,
            this.categotyEditToolStripMenuItem});
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.categoryToolStripMenuItem.Text = "&Category";
            // 
            // categoryListToolStripMenuItem
            // 
            this.categoryListToolStripMenuItem.Name = "categoryListToolStripMenuItem";
            this.categoryListToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.categoryListToolStripMenuItem.Text = "Category List";
            this.categoryListToolStripMenuItem.Click += new System.EventHandler(this.categoryListToolStripMenuItem_Click);
            // 
            // categotyEditToolStripMenuItem
            // 
            this.categotyEditToolStripMenuItem.Name = "categotyEditToolStripMenuItem";
            this.categotyEditToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.categotyEditToolStripMenuItem.Text = "Categoty Edit";
            this.categotyEditToolStripMenuItem.Click += new System.EventHandler(this.categotyEditToolStripMenuItem_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productListToolStripMenuItem,
            this.editProductToolStripMenuItem});
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.productToolStripMenuItem.Text = "&Product";
            // 
            // productListToolStripMenuItem
            // 
            this.productListToolStripMenuItem.Name = "productListToolStripMenuItem";
            this.productListToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.productListToolStripMenuItem.Text = "Product List";
            this.productListToolStripMenuItem.Click += new System.EventHandler(this.productListToolStripMenuItem_Click);
            // 
            // editProductToolStripMenuItem
            // 
            this.editProductToolStripMenuItem.Name = "editProductToolStripMenuItem";
            this.editProductToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.editProductToolStripMenuItem.Text = "Edit Product";
            this.editProductToolStripMenuItem.Click += new System.EventHandler(this.editProductToolStripMenuItem_Click);
            // 
            // customerAndDealerToolStripMenuItem
            // 
            this.customerAndDealerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerAndDealerListToolStripMenuItem,
            this.customerAndDealerSettingsToolStripMenuItem});
            this.customerAndDealerToolStripMenuItem.Name = "customerAndDealerToolStripMenuItem";
            this.customerAndDealerToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.customerAndDealerToolStripMenuItem.Text = "&Customer and Dealer";
            // 
            // customerAndDealerListToolStripMenuItem
            // 
            this.customerAndDealerListToolStripMenuItem.Name = "customerAndDealerListToolStripMenuItem";
            this.customerAndDealerListToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.customerAndDealerListToolStripMenuItem.Text = "Customer and Dealer list";
            this.customerAndDealerListToolStripMenuItem.Click += new System.EventHandler(this.customerAndDealerListToolStripMenuItem_Click);
            // 
            // customerAndDealerSettingsToolStripMenuItem
            // 
            this.customerAndDealerSettingsToolStripMenuItem.Name = "customerAndDealerSettingsToolStripMenuItem";
            this.customerAndDealerSettingsToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.customerAndDealerSettingsToolStripMenuItem.Text = "Customer and Dealer settings";
            this.customerAndDealerSettingsToolStripMenuItem.Click += new System.EventHandler(this.customerAndDealerSettingsToolStripMenuItem_Click);
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseToolStripMenuItem,
            this.saleToolStripMenuItem,
            this.transactionListToolStripMenuItem});
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.transactionToolStripMenuItem.Text = "&Transaction";
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.purchaseToolStripMenuItem.Text = "Purchase";
            this.purchaseToolStripMenuItem.Click += new System.EventHandler(this.purchaseToolStripMenuItem_Click);
            // 
            // saleToolStripMenuItem
            // 
            this.saleToolStripMenuItem.Name = "saleToolStripMenuItem";
            this.saleToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saleToolStripMenuItem.Text = "Sale";
            this.saleToolStripMenuItem.Click += new System.EventHandler(this.saleToolStripMenuItem_Click);
            // 
            // transactionListToolStripMenuItem
            // 
            this.transactionListToolStripMenuItem.Name = "transactionListToolStripMenuItem";
            this.transactionListToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.transactionListToolStripMenuItem.Text = "Transaction List";
            this.transactionListToolStripMenuItem.Click += new System.EventHandler(this.transactionListToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryListToolStripMenuItem});
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.inventoryToolStripMenuItem.Text = "&Inventory";
            // 
            // inventoryListToolStripMenuItem
            // 
            this.inventoryListToolStripMenuItem.Name = "inventoryListToolStripMenuItem";
            this.inventoryListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.inventoryListToolStripMenuItem.Text = "Inventory List";
            this.inventoryListToolStripMenuItem.Click += new System.EventHandler(this.inventoryListToolStripMenuItem_Click);
            // 
            // ledgerToolStripMenuItem
            // 
            this.ledgerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ledgerEditDeleteToolStripMenuItem,
            this.addManualToolStripMenuItem,
            this.regualCustomerAndDealerTransactionHistoryToolStripMenuItem,
            this.normalCustomerTransactionHistoryToolStripMenuItem});
            this.ledgerToolStripMenuItem.Name = "ledgerToolStripMenuItem";
            this.ledgerToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.ledgerToolStripMenuItem.Text = "&Ledger";
            // 
            // ledgerEditDeleteToolStripMenuItem
            // 
            this.ledgerEditDeleteToolStripMenuItem.Name = "ledgerEditDeleteToolStripMenuItem";
            this.ledgerEditDeleteToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.ledgerEditDeleteToolStripMenuItem.Text = "Ledger Edit/Delete";
            this.ledgerEditDeleteToolStripMenuItem.Click += new System.EventHandler(this.ledgerEditDeleteToolStripMenuItem_Click);
            // 
            // addManualToolStripMenuItem
            // 
            this.addManualToolStripMenuItem.Name = "addManualToolStripMenuItem";
            this.addManualToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.addManualToolStripMenuItem.Text = "Add Manual Payment";
            this.addManualToolStripMenuItem.Click += new System.EventHandler(this.addManualToolStripMenuItem_Click);
            // 
            // regualCustomerAndDealerTransactionHistoryToolStripMenuItem
            // 
            this.regualCustomerAndDealerTransactionHistoryToolStripMenuItem.Name = "regualCustomerAndDealerTransactionHistoryToolStripMenuItem";
            this.regualCustomerAndDealerTransactionHistoryToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.regualCustomerAndDealerTransactionHistoryToolStripMenuItem.Text = "Regual Customer and Dealer transaction history";
            this.regualCustomerAndDealerTransactionHistoryToolStripMenuItem.Click += new System.EventHandler(this.regualCustomerAndDealerTransactionHistoryToolStripMenuItem_Click);
            // 
            // normalCustomerTransactionHistoryToolStripMenuItem
            // 
            this.normalCustomerTransactionHistoryToolStripMenuItem.Name = "normalCustomerTransactionHistoryToolStripMenuItem";
            this.normalCustomerTransactionHistoryToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.normalCustomerTransactionHistoryToolStripMenuItem.Text = "Normal Customer transaction history";
            this.normalCustomerTransactionHistoryToolStripMenuItem.Click += new System.EventHandler(this.normalCustomerTransactionHistoryToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(-125, -11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(173, 27);
            this.panel2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(48, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Hridoy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "User: ";
            // 
            // tabControlHome
            // 
            this.tabControlHome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlHome.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControlHome.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlHome.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControlHome.Location = new System.Drawing.Point(12, 60);
            this.tabControlHome.Name = "tabControlHome";
            this.tabControlHome.SelectedIndex = 0;
            this.tabControlHome.Size = new System.Drawing.Size(668, 340);
            this.tabControlHome.TabIndex = 16;
            this.tabControlHome.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlHome_DrawItem);
            this.tabControlHome.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControlHome_MouseClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelLoggedInUser);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(12, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(173, 27);
            this.panel3.TabIndex = 17;
            // 
            // labelLoggedInUser
            // 
            this.labelLoggedInUser.AutoSize = true;
            this.labelLoggedInUser.BackColor = System.Drawing.SystemColors.Control;
            this.labelLoggedInUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoggedInUser.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelLoggedInUser.Location = new System.Drawing.Point(48, 4);
            this.labelLoggedInUser.Name = "labelLoggedInUser";
            this.labelLoggedInUser.Size = new System.Drawing.Size(0, 17);
            this.labelLoggedInUser.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "User: ";
            // 
            // labelLogout
            // 
            this.labelLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLogout.AutoSize = true;
            this.labelLogout.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelLogout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogout.Location = new System.Drawing.Point(624, 35);
            this.labelLogout.Name = "labelLogout";
            this.labelLogout.Size = new System.Drawing.Size(52, 17);
            this.labelLogout.TabIndex = 18;
            this.labelLogout.Text = "Logout";
            this.labelLogout.Click += new System.EventHandler(this.labelLogout_Click);
            // 
            // FormAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(692, 412);
            this.Controls.Add(this.labelLogout);
            this.Controls.Add(this.menuStripTop);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControlHome);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormAdminDashboard";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdminDashboard_FormClosing);
            this.Load += new System.EventHandler(this.FormAdminDashboard_Load);
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControlHome;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelLoggedInUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem userListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userSettingsToolStripMenuItem;
        private System.Windows.Forms.Label labelLogout;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categotyEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerAndDealerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerAndDealerListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerAndDealerSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ledgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ledgerEditDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regualCustomerAndDealerTransactionHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalCustomerTransactionHistoryToolStripMenuItem;
    }
}

