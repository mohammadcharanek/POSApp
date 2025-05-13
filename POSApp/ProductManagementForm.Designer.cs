namespace POSApp
{
    partial class ProductManagementForm
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
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProductID = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBarcodeInput = new System.Windows.Forms.TextBox();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtReorderLevel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDeleteProduct.Location = new System.Drawing.Point(554, 547);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(146, 37);
            this.btnDeleteProduct.TabIndex = 23;
            this.btnDeleteProduct.Text = "Delete Product";
            this.btnDeleteProduct.UseVisualStyleBackColor = false;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUpdateProduct.Location = new System.Drawing.Point(405, 547);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(123, 37);
            this.btnUpdateProduct.TabIndex = 22;
            this.btnUpdateProduct.Text = "Update Product";
            this.btnUpdateProduct.UseVisualStyleBackColor = false;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddProduct.Location = new System.Drawing.Point(270, 547);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(105, 37);
            this.btnAddProduct.TabIndex = 21;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(294, 165);
            this.txtQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(147, 22);
            this.txtQuantity.TabIndex = 20;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(294, 123);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(147, 22);
            this.txtPrice.TabIndex = 19;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(294, 85);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(147, 22);
            this.txtProductName.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Product Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Product ID";
            // 
            // cmbProductID
            // 
            this.cmbProductID.FormattingEnabled = true;
            this.cmbProductID.Location = new System.Drawing.Point(294, 38);
            this.cmbProductID.Name = "cmbProductID";
            this.cmbProductID.Size = new System.Drawing.Size(147, 24);
            this.cmbProductID.Sorted = true;
            this.cmbProductID.TabIndex = 26;
            this.cmbProductID.SelectedIndexChanged += new System.EventHandler(this.cmbProductID_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 58);
            this.button1.TabIndex = 27;
            this.button1.Text = "MainForm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Barcode";
            // 
            // txtBarcodeInput
            // 
            this.txtBarcodeInput.Location = new System.Drawing.Point(294, 206);
            this.txtBarcodeInput.Name = "txtBarcodeInput";
            this.txtBarcodeInput.Size = new System.Drawing.Size(147, 22);
            this.txtBarcodeInput.TabIndex = 29;
            this.txtBarcodeInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcodeInput_KeyPress);
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(294, 258);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(147, 24);
            this.comboBoxCategories.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Category";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 32;
            this.label7.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(294, 316);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(192, 61);
            this.txtDescription.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(185, 409);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "Supplier";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(294, 409);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(147, 24);
            this.cmbSupplier.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(186, 470);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 16);
            this.label9.TabIndex = 36;
            this.label9.Text = "Cost Price";
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Location = new System.Drawing.Point(294, 470);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Size = new System.Drawing.Size(147, 22);
            this.txtCostPrice.TabIndex = 37;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.SystemColors.Info;
            this.btnAddCategory.Location = new System.Drawing.Point(448, 258);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(105, 23);
            this.btnAddCategory.TabIndex = 38;
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(655, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 16);
            this.label10.TabIndex = 39;
            this.label10.Text = "Reorder level";
            // 
            // txtReorderLevel
            // 
            this.txtReorderLevel.Location = new System.Drawing.Point(771, 41);
            this.txtReorderLevel.Name = "txtReorderLevel";
            this.txtReorderLevel.Size = new System.Drawing.Size(132, 22);
            this.txtReorderLevel.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(658, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 16);
            this.label11.TabIndex = 41;
            this.label11.Text = "Discount";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(771, 90);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(132, 22);
            this.txtDiscount.TabIndex = 42;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(658, 143);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 16);
            this.label12.TabIndex = 43;
            this.label12.Text = "Tax";
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(771, 140);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(132, 22);
            this.txtTax.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(660, 195);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 16);
            this.label13.TabIndex = 45;
            this.label13.Text = "Unit";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(771, 195);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(132, 22);
            this.txtUnit.TabIndex = 46;
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.BackColor = System.Drawing.SystemColors.Info;
            this.btnAddSupplier.Location = new System.Drawing.Point(448, 409);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(105, 23);
            this.btnAddSupplier.TabIndex = 47;
            this.btnAddSupplier.Text = "Add Supplier";
            this.btnAddSupplier.UseVisualStyleBackColor = false;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(434, 4);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(100, 16);
            this.labelUsername.TabIndex = 48;
            this.labelUsername.Text = "Welcome, User";
            // 
            // ProductManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 621);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.btnAddSupplier);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtReorderLevel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.txtCostPrice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.txtBarcodeInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbProductID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProductManagementForm";
            this.Text = "ProductManagementForm";
            this.Load += new System.EventHandler(this.ProductManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.NumericUpDown txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProductID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBarcodeInput;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCostPrice;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtReorderLevel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Label labelUsername;
    }
}