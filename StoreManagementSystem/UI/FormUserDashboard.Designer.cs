namespace WarehouseApp
{
    partial class FormUserDashboard
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
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealerAndCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deaAndCustListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDealerAndCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControlUserDashboard = new System.Windows.Forms.TabControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelLoggedInUser = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.labelLogout = new System.Windows.Forms.Label();
            this.transactionListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ledgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addManualPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regualCustomerAndDealerTransactionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalCustomerTransactionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.userToolStripMenuItem,
            this.dealerAndCustomerToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.ledgerToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(827, 24);
            this.menuStripTop.TabIndex = 9;
            this.menuStripTop.Text = "menuStripTop";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountSettingsToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "&User";
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.accountSettingsToolStripMenuItem.Text = "Account Settings";
            this.accountSettingsToolStripMenuItem.Click += new System.EventHandler(this.accountSettingsToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseToolStripMenuItem,
            this.saleToolStripMenuItem,
            this.transactionListToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.transactionsToolStripMenuItem.Text = "&Transactions";
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.purchaseToolStripMenuItem.Text = "Purchase";
            this.purchaseToolStripMenuItem.Click += new System.EventHandler(this.purchaseToolStripMenuItem_Click);
            // 
            // saleToolStripMenuItem
            // 
            this.saleToolStripMenuItem.Name = "saleToolStripMenuItem";
            this.saleToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.saleToolStripMenuItem.Text = "Sale";
            this.saleToolStripMenuItem.Click += new System.EventHandler(this.saleToolStripMenuItem_Click);
            // 
            // dealerAndCustomerToolStripMenuItem
            // 
            this.dealerAndCustomerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deaAndCustListToolStripMenuItem,
            this.editDealerAndCustomerToolStripMenuItem});
            this.dealerAndCustomerToolStripMenuItem.Name = "dealerAndCustomerToolStripMenuItem";
            this.dealerAndCustomerToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.dealerAndCustomerToolStripMenuItem.Text = "&Dealer and Customer";
            // 
            // deaAndCustListToolStripMenuItem
            // 
            this.deaAndCustListToolStripMenuItem.Name = "deaAndCustListToolStripMenuItem";
            this.deaAndCustListToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.deaAndCustListToolStripMenuItem.Text = "Dea and Cust List";
            this.deaAndCustListToolStripMenuItem.Click += new System.EventHandler(this.deaAndCustListToolStripMenuItem_Click_1);
            // 
            // editDealerAndCustomerToolStripMenuItem
            // 
            this.editDealerAndCustomerToolStripMenuItem.Name = "editDealerAndCustomerToolStripMenuItem";
            this.editDealerAndCustomerToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.editDealerAndCustomerToolStripMenuItem.Text = "Edit Dealer and Customer";
            this.editDealerAndCustomerToolStripMenuItem.Click += new System.EventHandler(this.editDealerAndCustomerToolStripMenuItem_Click);
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
            this.inventoryListToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.inventoryListToolStripMenuItem.Text = "Inventory List";
            this.inventoryListToolStripMenuItem.Click += new System.EventHandler(this.inventoryListToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(-149, -22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(173, 27);
            this.panel2.TabIndex = 10;
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
            // tabControlUserDashboard
            // 
            this.tabControlUserDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlUserDashboard.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlUserDashboard.Location = new System.Drawing.Point(12, 60);
            this.tabControlUserDashboard.Name = "tabControlUserDashboard";
            this.tabControlUserDashboard.SelectedIndex = 0;
            this.tabControlUserDashboard.Size = new System.Drawing.Size(803, 367);
            this.tabControlUserDashboard.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlUserDashboard.TabIndex = 11;
            this.tabControlUserDashboard.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlUserDashboard_DrawItem);
            this.tabControlUserDashboard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControlUserDashboard_MouseClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelLoggedInUser);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(12, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(173, 27);
            this.panel3.TabIndex = 12;
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
            this.labelLogout.Location = new System.Drawing.Point(763, 31);
            this.labelLogout.Name = "labelLogout";
            this.labelLogout.Size = new System.Drawing.Size(52, 17);
            this.labelLogout.TabIndex = 19;
            this.labelLogout.Text = "Logout";
            this.labelLogout.Click += new System.EventHandler(this.labelLogout_Click);
            // 
            // transactionListToolStripMenuItem
            // 
            this.transactionListToolStripMenuItem.Name = "transactionListToolStripMenuItem";
            this.transactionListToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.transactionListToolStripMenuItem.Text = "Transaction List";
            this.transactionListToolStripMenuItem.Click += new System.EventHandler(this.transactionListToolStripMenuItem_Click);
            // 
            // ledgerToolStripMenuItem
            // 
            this.ledgerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addManualPaymentToolStripMenuItem,
            this.regualCustomerAndDealerTransactionHistoryToolStripMenuItem,
            this.normalCustomerTransactionHistoryToolStripMenuItem});
            this.ledgerToolStripMenuItem.Name = "ledgerToolStripMenuItem";
            this.ledgerToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.ledgerToolStripMenuItem.Text = "&Ledger";
            // 
            // addManualPaymentToolStripMenuItem
            // 
            this.addManualPaymentToolStripMenuItem.Name = "addManualPaymentToolStripMenuItem";
            this.addManualPaymentToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.addManualPaymentToolStripMenuItem.Text = "Add Manual Payment";
            this.addManualPaymentToolStripMenuItem.Click += new System.EventHandler(this.addManualPaymentToolStripMenuItem_Click);
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
            // FormUserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(827, 439);
            this.Controls.Add(this.labelLogout);
            this.Controls.Add(this.tabControlUserDashboard);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStripTop);
            this.Controls.Add(this.panel2);
            this.Name = "FormUserDashboard";
            this.ShowIcon = false;
            this.Text = "FormUserDashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUserDashboard_FormClosing);
            this.Load += new System.EventHandler(this.FormUserDashboard_Load);
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControlUserDashboard;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelLoggedInUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dealerAndCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deaAndCustListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDealerAndCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.Label labelLogout;
        private System.Windows.Forms.ToolStripMenuItem transactionListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ledgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addManualPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regualCustomerAndDealerTransactionHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalCustomerTransactionHistoryToolStripMenuItem;
    }
}