namespace POSApp
{
    partial class MainForm
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
            this.dataOfCart = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveFromCart = new System.Windows.Forms.Button();
            this.btnCompleteSale = new System.Windows.Forms.Button();
            this.btnProductManagement = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSupplierManagement = new System.Windows.Forms.Button();
            this.btnCategoryManagement = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnSalesAndTransactions = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.taxCollected = new System.Windows.Forms.TextBox();
            this.discountApplied = new System.Windows.Forms.TextBox();
            this.quantitySold = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.cmbProductSearch = new System.Windows.Forms.ComboBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancelSale = new System.Windows.Forms.Button();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataOfCart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataOfCart
            // 
            this.dataOfCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataOfCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOfCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.Quantity,
            this.Price,
            this.Discount,
            this.Tax,
            this.Total,
            this.AvailableStock});
            this.dataOfCart.Location = new System.Drawing.Point(3, 6);
            this.dataOfCart.Name = "dataOfCart";
            this.dataOfCart.RowHeadersWidth = 51;
            this.dataOfCart.RowTemplate.Height = 24;
            this.dataOfCart.Size = new System.Drawing.Size(1406, 150);
            this.dataOfCart.TabIndex = 1;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "Product ID";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount";
            this.Discount.MinimumWidth = 6;
            this.Discount.Name = "Discount";
            // 
            // Tax
            // 
            this.Tax.HeaderText = "Tax";
            this.Tax.MinimumWidth = 6;
            this.Tax.Name = "Tax";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            // 
            // AvailableStock
            // 
            this.AvailableStock.HeaderText = "Available Stock";
            this.AvailableStock.MinimumWidth = 6;
            this.AvailableStock.Name = "AvailableStock";
            // 
            // btnRemoveFromCart
            // 
            this.btnRemoveFromCart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRemoveFromCart.Location = new System.Drawing.Point(928, 169);
            this.btnRemoveFromCart.Name = "btnRemoveFromCart";
            this.btnRemoveFromCart.Size = new System.Drawing.Size(183, 45);
            this.btnRemoveFromCart.TabIndex = 3;
            this.btnRemoveFromCart.Text = "Remove From Cart";
            this.btnRemoveFromCart.UseVisualStyleBackColor = false;
            this.btnRemoveFromCart.Click += new System.EventHandler(this.btnRemoveFromCart_Click);
            // 
            // btnCompleteSale
            // 
            this.btnCompleteSale.BackColor = System.Drawing.Color.LawnGreen;
            this.btnCompleteSale.Location = new System.Drawing.Point(938, 14);
            this.btnCompleteSale.Name = "btnCompleteSale";
            this.btnCompleteSale.Size = new System.Drawing.Size(192, 46);
            this.btnCompleteSale.TabIndex = 4;
            this.btnCompleteSale.Text = "Complete Sale";
            this.btnCompleteSale.UseVisualStyleBackColor = false;
            this.btnCompleteSale.Click += new System.EventHandler(this.btnCompleteSale_Click);
            // 
            // btnProductManagement
            // 
            this.btnProductManagement.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnProductManagement.Location = new System.Drawing.Point(76, 29);
            this.btnProductManagement.Name = "btnProductManagement";
            this.btnProductManagement.Size = new System.Drawing.Size(170, 52);
            this.btnProductManagement.TabIndex = 5;
            this.btnProductManagement.Text = "Product Management";
            this.btnProductManagement.UseVisualStyleBackColor = false;
            this.btnProductManagement.Click += new System.EventHandler(this.btnProductManagement_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnSupplierManagement);
            this.panel1.Controls.Add(this.btnCategoryManagement);
            this.panel1.Controls.Add(this.btnProductManagement);
            this.panel1.Controls.Add(this.btnReports);
            this.panel1.Controls.Add(this.btnSalesAndTransactions);
            this.panel1.Location = new System.Drawing.Point(12, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 520);
            this.panel1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(76, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 49);
            this.button1.TabIndex = 11;
            this.button1.Text = "Customer Management";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnSupplierManagement
            // 
            this.btnSupplierManagement.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSupplierManagement.Location = new System.Drawing.Point(76, 202);
            this.btnSupplierManagement.Name = "btnSupplierManagement";
            this.btnSupplierManagement.Size = new System.Drawing.Size(170, 54);
            this.btnSupplierManagement.TabIndex = 10;
            this.btnSupplierManagement.Text = "Supplier Management";
            this.btnSupplierManagement.UseVisualStyleBackColor = false;
            this.btnSupplierManagement.Click += new System.EventHandler(this.btnSupplierManagement_Click);
            // 
            // btnCategoryManagement
            // 
            this.btnCategoryManagement.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCategoryManagement.Location = new System.Drawing.Point(76, 112);
            this.btnCategoryManagement.Name = "btnCategoryManagement";
            this.btnCategoryManagement.Size = new System.Drawing.Size(170, 59);
            this.btnCategoryManagement.TabIndex = 9;
            this.btnCategoryManagement.Text = "Category Management";
            this.btnCategoryManagement.UseVisualStyleBackColor = false;
            this.btnCategoryManagement.Click += new System.EventHandler(this.btnCategoryManagement_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReports.Location = new System.Drawing.Point(76, 454);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(170, 47);
            this.btnReports.TabIndex = 8;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            // 
            // btnSalesAndTransactions
            // 
            this.btnSalesAndTransactions.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSalesAndTransactions.Location = new System.Drawing.Point(76, 375);
            this.btnSalesAndTransactions.Name = "btnSalesAndTransactions";
            this.btnSalesAndTransactions.Size = new System.Drawing.Size(170, 49);
            this.btnSalesAndTransactions.TabIndex = 7;
            this.btnSalesAndTransactions.Text = "Sales And Transactions";
            this.btnSalesAndTransactions.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbPaymentMethod);
            this.panel2.Controls.Add(this.cmbProductSearch);
            this.panel2.Controls.Add(this.txtBarcode);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.btnNewCustomer);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.cmbCustomer);
            this.panel2.Controls.Add(this.btnRemoveFromCart);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dataOfCart);
            this.panel2.Location = new System.Drawing.Point(335, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1412, 486);
            this.panel2.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.taxCollected);
            this.panel4.Controls.Add(this.discountApplied);
            this.panel4.Controls.Add(this.quantitySold);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(928, 249);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(418, 175);
            this.panel4.TabIndex = 27;
            // 
            // taxCollected
            // 
            this.taxCollected.Location = new System.Drawing.Point(212, 107);
            this.taxCollected.Name = "taxCollected";
            this.taxCollected.ReadOnly = true;
            this.taxCollected.Size = new System.Drawing.Size(140, 22);
            this.taxCollected.TabIndex = 31;
            // 
            // discountApplied
            // 
            this.discountApplied.Location = new System.Drawing.Point(212, 64);
            this.discountApplied.Name = "discountApplied";
            this.discountApplied.ReadOnly = true;
            this.discountApplied.Size = new System.Drawing.Size(140, 22);
            this.discountApplied.TabIndex = 30;
            // 
            // quantitySold
            // 
            this.quantitySold.Location = new System.Drawing.Point(212, 20);
            this.quantitySold.Name = "quantitySold";
            this.quantitySold.ReadOnly = true;
            this.quantitySold.Size = new System.Drawing.Size(140, 22);
            this.quantitySold.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Tax Collected";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Total Discount Applied";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Total Quantity Sold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Payment Method";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(170, 319);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(221, 24);
            this.cmbPaymentMethod.TabIndex = 24;
            // 
            // cmbProductSearch
            // 
            this.cmbProductSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProductSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductSearch.FormattingEnabled = true;
            this.cmbProductSearch.Location = new System.Drawing.Point(170, 267);
            this.cmbProductSearch.Name = "cmbProductSearch";
            this.cmbProductSearch.Size = new System.Drawing.Size(221, 24);
            this.cmbProductSearch.Sorted = true;
            this.cmbProductSearch.TabIndex = 23;
            this.cmbProductSearch.SelectedIndexChanged += new System.EventHandler(this.cmbProductSearch_SelectedIndexChanged);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(170, 225);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(221, 22);
            this.txtBarcode.TabIndex = 22;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(76, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 16);
            this.label12.TabIndex = 21;
            this.label12.Text = "Barcode";
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.BackColor = System.Drawing.SystemColors.Info;
            this.btnNewCustomer.Location = new System.Drawing.Point(414, 181);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(120, 23);
            this.btnNewCustomer.TabIndex = 20;
            this.btnNewCustomer.Text = "New Customer";
            this.btnNewCustomer.UseVisualStyleBackColor = false;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(51, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Customer Name";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(170, 180);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(221, 24);
            this.cmbCustomer.Sorted = true;
            this.cmbCustomer.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Product Search";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.btnCancelSale);
            this.panel3.Controls.Add(this.txtChange);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtTotalPrice);
            this.panel3.Controls.Add(this.btnCompleteSale);
            this.panel3.Controls.Add(this.txtPaidAmount);
            this.panel3.Controls.Add(this.btnPrintReceipt);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(12, 575);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1735, 74);
            this.panel3.TabIndex = 9;
            // 
            // btnCancelSale
            // 
            this.btnCancelSale.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelSale.Location = new System.Drawing.Point(1147, 14);
            this.btnCancelSale.Name = "btnCancelSale";
            this.btnCancelSale.Size = new System.Drawing.Size(171, 44);
            this.btnCancelSale.TabIndex = 8;
            this.btnCancelSale.Text = "Cancel Sale";
            this.btnCancelSale.UseVisualStyleBackColor = false;
            this.btnCancelSale.Click += new System.EventHandler(this.btnCancelSale_Click);
            // 
            // txtChange
            // 
            this.txtChange.Location = new System.Drawing.Point(784, 31);
            this.txtChange.Name = "txtChange";
            this.txtChange.Size = new System.Drawing.Size(135, 22);
            this.txtChange.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(714, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Change";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(175, 26);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(159, 22);
            this.txtTotalPrice.TabIndex = 5;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Location = new System.Drawing.Point(510, 31);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(163, 22);
            this.txtPaidAmount.TabIndex = 3;
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPrintReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReceipt.Location = new System.Drawing.Point(1336, 14);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(159, 44);
            this.btnPrintReceipt.TabIndex = 4;
            this.btnPrintReceipt.Text = "Print Receipt";
            this.btnPrintReceipt.UseVisualStyleBackColor = false;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnPrintReceipt_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(367, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Payment Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(88, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Total Price";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.ForeColor = System.Drawing.Color.Black;
            this.lblRole.Location = new System.Drawing.Point(971, 15);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(42, 16);
            this.lblRole.TabIndex = 10;
            this.lblRole.Text = "Role: ";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 665);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1759, 22);
            this.statusBar1.TabIndex = 11;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "statusBarPanel1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.Location = new System.Drawing.Point(796, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 16);
            this.lblUsername.TabIndex = 12;
            this.lblUsername.Text = "Welcome, User";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(1159, 13);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 13;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1759, 687);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataOfCart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataOfCart;
        private System.Windows.Forms.Button btnRemoveFromCart;
        private System.Windows.Forms.Button btnCompleteSale;
        private System.Windows.Forms.Button btnProductManagement;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnSalesAndTransactions;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.TextBox txtChange;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.Button btnCancelSale;
        //private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.ComboBox cmbProductSearch;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnSupplierManagement;
        private System.Windows.Forms.Button btnCategoryManagement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableStock;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox taxCollected;
        private System.Windows.Forms.TextBox discountApplied;
        private System.Windows.Forms.TextBox quantitySold;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button button1;
    }
}

