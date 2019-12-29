namespace WarehouseApp.UI
{
    partial class FormLedgerRegularCustomerListAndDealer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelId = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxNormalCustomer = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewNormalCustomer = new System.Windows.Forms.DataGridView();
            this.radioButtonRegularCustomer = new System.Windows.Forms.RadioButton();
            this.radioButtonDealer = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNormalCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.labelId);
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 84);
            this.panel1.TabIndex = 0;
            // 
            // labelId
            // 
            this.labelId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.Location = new System.Drawing.Point(147, 60);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(0, 17);
            this.labelId.TabIndex = 20;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonRefresh.Location = new System.Drawing.Point(8, 54);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(122, 23);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "Show all transaciotns";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Work Field";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.75248F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.24753F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxNormalCustomer, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(505, 28);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 28);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cust or Dealer List";
            // 
            // comboBoxNormalCustomer
            // 
            this.comboBoxNormalCustomer.FormattingEnabled = true;
            this.comboBoxNormalCustomer.Location = new System.Drawing.Point(128, 3);
            this.comboBoxNormalCustomer.Name = "comboBoxNormalCustomer";
            this.comboBoxNormalCustomer.Size = new System.Drawing.Size(374, 21);
            this.comboBoxNormalCustomer.TabIndex = 0;
            this.comboBoxNormalCustomer.SelectedIndexChanged += new System.EventHandler(this.comboBoxNormalCustomer_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.dataGridViewNormalCustomer);
            this.panel2.Location = new System.Drawing.Point(12, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 263);
            this.panel2.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Caegory List";
            // 
            // dataGridViewNormalCustomer
            // 
            this.dataGridViewNormalCustomer.AllowUserToAddRows = false;
            this.dataGridViewNormalCustomer.AllowUserToDeleteRows = false;
            this.dataGridViewNormalCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewNormalCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNormalCustomer.Location = new System.Drawing.Point(3, 20);
            this.dataGridViewNormalCustomer.Name = "dataGridViewNormalCustomer";
            this.dataGridViewNormalCustomer.ReadOnly = true;
            this.dataGridViewNormalCustomer.Size = new System.Drawing.Size(731, 240);
            this.dataGridViewNormalCustomer.TabIndex = 15;
            this.dataGridViewNormalCustomer.TabStop = false;
            // 
            // radioButtonRegularCustomer
            // 
            this.radioButtonRegularCustomer.AutoSize = true;
            this.radioButtonRegularCustomer.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.radioButtonRegularCustomer.Location = new System.Drawing.Point(12, 12);
            this.radioButtonRegularCustomer.Name = "radioButtonRegularCustomer";
            this.radioButtonRegularCustomer.Size = new System.Drawing.Size(109, 17);
            this.radioButtonRegularCustomer.TabIndex = 4;
            this.radioButtonRegularCustomer.TabStop = true;
            this.radioButtonRegularCustomer.Text = "Regular Customer";
            this.radioButtonRegularCustomer.UseVisualStyleBackColor = false;
            this.radioButtonRegularCustomer.CheckedChanged += new System.EventHandler(this.radioButtonRegularCustomer_CheckedChanged);
            // 
            // radioButtonDealer
            // 
            this.radioButtonDealer.AutoSize = true;
            this.radioButtonDealer.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.radioButtonDealer.Location = new System.Drawing.Point(127, 12);
            this.radioButtonDealer.Name = "radioButtonDealer";
            this.radioButtonDealer.Size = new System.Drawing.Size(56, 17);
            this.radioButtonDealer.TabIndex = 5;
            this.radioButtonDealer.TabStop = true;
            this.radioButtonDealer.Text = "Dealer";
            this.radioButtonDealer.UseVisualStyleBackColor = false;
            this.radioButtonDealer.CheckedChanged += new System.EventHandler(this.radioButtonDealer_CheckedChanged);
            // 
            // FormLedgerRegularCustomerListAndDealer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 406);
            this.Controls.Add(this.radioButtonDealer);
            this.Controls.Add(this.radioButtonRegularCustomer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLedgerRegularCustomerListAndDealer";
            this.Text = "Regular Customer and Dealer history";
            this.Load += new System.EventHandler(this.FormLedgerRegularCustomerList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNormalCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewNormalCustomer;
        private System.Windows.Forms.ComboBox comboBoxNormalCustomer;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.RadioButton radioButtonRegularCustomer;
        private System.Windows.Forms.RadioButton radioButtonDealer;
    }
}