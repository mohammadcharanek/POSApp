using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Drawing.Printing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace POSApp
{
    public partial class MainForm : Form
    {
        private int _userID;
        private string role;
        private string username;
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["POSDBConnectionString"].ConnectionString;
        private Timer textChangedTimer;
        private int debounceDelay = 300; // Adjust this delay as needed
        private PrintDocument printDocument = new PrintDocument();
        private string receiptToPrint;
        private List<SaleItem> saleItems = new List<SaleItem>(); // List to store sale items
        private decimal totalAmount;
        private decimal totalTax;
        private decimal totalDiscount;
        public MainForm(string username)
        {
            int userId = SessionInfo.UserID;
            string role = SessionInfo.Role;
            InitializeComponent();
            //TestConnection();
            this.username = username;
            this.role= role;

            textChangedTimer = new Timer();
            textChangedTimer.Interval = debounceDelay;
            textChangedTimer.Tick += new EventHandler(OnTextChangedTimerTick);

           
            txtPaidAmount.TextChanged += new EventHandler(txtPaidAmount_TextChanged);
            
            // Attach event handler
            dataOfCart.CellValueChanged += dataOfCart_CellValueChanged;
            this.Size = new Size(1366, 648);  // Size of the form should be (1366, 768)
            this.MinimumSize = new Size(1366, 648);  // Prevents resizing smaller than this size
            dataOfCart.RowsAdded += dataOfCart_RowsAdded;
            dataOfCart.RowsRemoved += dataOfCart_RowsRemoved;
            dataOfCart.CellValueChanged += dataOfCart_CellValueChanged;
        }
        private void MainForm_Shown(object sender, EventArgs e)
{
    // Refresh the product ComboBox when the form is shown
    PopulateProductSearchComboBox();
}
        
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scannedBarcode = txtBarcode.Text;

                // Search for product by barcode
                AddProductToCartByBarcode(scannedBarcode);

                // Clear the textbox for the next scan
                txtBarcode.Clear();
            }
        }

        private void AddProductToCartByBarcode(string barcode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Query to get product details including Discount and Tax
                string query = "SELECT ProductID, ProductName, Price, Stock, Discount, Tax FROM Products WHERE Barcode = @Barcode";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Barcode", barcode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int productID = (int)reader["ProductID"];
                        string productName = reader["ProductName"].ToString();
                        decimal price = (decimal)reader["Price"];
                        int stockLevel = (int)reader["Stock"]; // Available stock
                        decimal discount = (decimal)reader["Discount"];
                        decimal tax = (decimal)reader["Tax"];

                        // Check if the product is already in the cart
                        foreach (DataGridViewRow row in dataOfCart.Rows)
                        {
                            if (!row.IsNewRow && (int)row.Cells["ProductID"].Value == productID)
                            {
                                int currentQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                                if (currentQuantity + 1 <= stockLevel)
                                {
                                    row.Cells["Quantity"].Value = currentQuantity + 1;
                                    UpdateCartRow(row, price, discount, tax);
                                    UpdateTotalPrice();
                                    return; // Exit after updating the existing row
                                }
                                else
                                {
                                    MessageBox.Show("Insufficient stock for this product.");
                                    return; // Exit if not enough stock
                                }
                            }
                        }

                        // If the product is not in the cart, validate stock before adding
                        if (stockLevel > 0)
                        {
                            dataOfCart.Rows.Add(productID, productName, 1, price.ToString("F2"),
                                (price * discount / 100).ToString("F2"), (price * tax / 100).ToString("F2"),
                                price.ToString("F2"), stockLevel); // Include available stock
                            UpdateTotalPrice();
                        }
                        else
                        {
                            MessageBox.Show("Product is out of stock.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product not found.");
                    }
                }
            }
        }






        private void UpdateProductStock(int productID, int quantitySold, SqlConnection conn)
        {
            string updateQuery = "UPDATE Products SET Stock = Stock - @QuantitySold WHERE ProductID = @ProductID";

            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@QuantitySold", quantitySold);
                cmd.Parameters.AddWithValue("@ProductID", productID);

                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateTotalPrice()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataOfCart.Rows)
            {
                if (!row.IsNewRow)
                {
                    total += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }
            txtTotalPrice.Text = total.ToString("F2");
        }




        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            // Reset the timer every time the text changes
            textChangedTimer.Stop();
            textChangedTimer.Start();
        }

        private void OnTextChangedTimerTick(object sender, EventArgs e)
        {
            // Stop the timer
            textChangedTimer.Stop();

            // Now that the user has stopped typing, fetch product details
            FillProductDetails();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            PopulateProductSearchComboBox();  // Refresh the ComboBox when the form is shown
        }
        private void PopulateProductSearchComboBox()
        {
            cmbProductSearch.Items.Clear(); // Clear existing items first

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT ProductID, ProductName FROM Products";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int productID = (int)reader["ProductID"];
                        string productName = reader["ProductName"].ToString();

                        // Add items to ComboBox, storing the ProductID in an anonymous object
                        cmbProductSearch.Items.Add(new { Text = productName, Value = productID });
                    }
                }
            }

            // Set ComboBox properties for display and value
            cmbProductSearch.DisplayMember = "Text"; // Show product names
            cmbProductSearch.ValueMember = "Value";   // Use ProductID as value

            // Set ComboBox properties for autocomplete
            cmbProductSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProductSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cmbProductSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductSearch.SelectedItem != null)
            {
                var selectedProduct = (dynamic)cmbProductSearch.SelectedItem; // Get the selected item
                int selectedProductID = selectedProduct.Value;  // Extract ProductID

                // Now add the product to the cart using its ProductID
                AddProductToCartByID(selectedProductID);
                cmbProductSearch.SelectedIndex = -1;
            }
        }
        // Attach this event handler to the DataGridView (dataOfCart)
        private void dataOfCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataOfCart.Columns["Quantity"].Index && e.RowIndex >= 0)
            {
                // Get the updated quantity value
                DataGridViewRow row = dataOfCart.Rows[e.RowIndex];
                int newQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                decimal discount = Convert.ToDecimal(row.Cells["Discount"].Value) / newQuantity;
                decimal tax = Convert.ToDecimal(row.Cells["Tax"].Value) / newQuantity;

                // Check stock level from the row or database
                int stockLevel = GetStockLevelFromDatabase((int)row.Cells["ProductID"].Value);

                if (newQuantity > stockLevel)
                {
                    MessageBox.Show("Insufficient stock for this product.");
                    row.Cells["Quantity"].Value = stockLevel; // Set to maximum stock level
                    return;
                }

                // Recalculate total price for this row
                decimal totalPrice = (price - discount) * newQuantity + tax * newQuantity;
                row.Cells["Total"].Value = totalPrice.ToString("F2");

                // Update the overall total price
                UpdateTotalPrice();
            }
            UpdateSummary();
        }
        private void AddProductToCartByID(int productID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Fetch product details including Discount and Tax
                string query = "SELECT ProductID, ProductName, Price, Stock, Discount, Tax FROM Products WHERE ProductID = @ProductID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string productName = reader["ProductName"].ToString();
                        decimal price = (decimal)reader["Price"];
                        int stockLevel = (int)reader["Stock"]; // Available stock
                        decimal discount = (decimal)reader["Discount"];
                        decimal tax = (decimal)reader["Tax"];

                        // Default quantity to 1
                        int quantityInput = 1;

                        // Check if the product is already in the cart
                        foreach (DataGridViewRow row in dataOfCart.Rows)
                        {
                            if (!row.IsNewRow && (int)row.Cells["ProductID"].Value == productID)
                            {
                                // Update existing quantity if stock allows
                                int currentQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                                if (currentQuantity + quantityInput <= stockLevel)
                                {
                                    row.Cells["Quantity"].Value = currentQuantity + quantityInput;
                                    UpdateCartRow(row, price, discount, tax);
                                    UpdateTotalPrice();
                                    return; // Exit after updating the existing row
                                }
                                else
                                {
                                    MessageBox.Show("Insufficient stock for this product.");
                                    return; // Exit if not enough stock
                                }
                            }
                        }

                        // If the product is not in the cart, validate stock before adding
                        if (stockLevel > 0)
                        {
                            // Add a new row to the cart including available stock
                            dataOfCart.Rows.Add(productID, productName, quantityInput, price.ToString("F2"),
                                (price * discount / 100).ToString("F2"), (price * tax / 100).ToString("F2"),
                                price.ToString("F2"), stockLevel); // Include available stock
                            UpdateTotalPrice();
                        }
                        else
                        {
                            MessageBox.Show("Product is out of stock.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product not found.");
                    }
                }
            }
        }




        private void UpdateCartRow(DataGridViewRow row, decimal price, decimal discount, decimal tax)
        {
            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
            decimal discountAmount = Math.Round(price * discount / 100 * quantity, 2);
            decimal taxAmount = Math.Round((price - discountAmount) * tax / 100 * quantity, 2);
            decimal totalPrice = Math.Round((price - discountAmount + taxAmount) * quantity, 2);

            row.Cells["Discount"].Value = discountAmount.ToString("F2");
            row.Cells["Tax"].Value = taxAmount.ToString("F2");
            row.Cells["Total"].Value = totalPrice.ToString("F2");
        }





        private void UpdateProductStock(int productID, int quantitySold)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Update the stock level in the Products table
                string updateQuery = "UPDATE Products SET Stock = Stock - @QuantitySold WHERE ProductID = @ProductID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@QuantitySold", quantitySold);
                    cmd.Parameters.AddWithValue("@ProductID", productID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Failed to update stock.");
                    }
                }
            }
        }





        private int GetStockLevelFromDatabase(int productID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Stock FROM Products WHERE ProductID = @ProductID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }


        private void FillProductDetails()
        {
            if (cmbProductSearch.SelectedItem != null)  // Ensure a product is selected
            {
                string selectedProduct = cmbProductSearch.Text.Trim();  // Get the selected product name

                if (!string.IsNullOrEmpty(selectedProduct))
                {
                    string query = "SELECT Price, Stock FROM Products WHERE ProductName = @ProductName";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", selectedProduct);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                
                            }
                            else
                            {
                               
                            }
                        }
                    }
                }
            }
            else
            {
                
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUsername.Text = $"Welcome, {username}"; // Update label with the username
            lblRole.Text = $"Role: {role}";
            PopulateCustomerComboBox();
            string query = "SELECT * FROM Products";

            // Create a new DataTable
            DataTable dataTable = new DataTable();

            // Use SqlConnection and SqlDataAdapter to fill the DataTable
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.Fill(dataTable);
            }


            PopulateProductSearchComboBox();
            PopulatePaymentMethods();

        }
        //private void TestConnection()
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            MessageBox.Show("Connection successful!");
        //        }
        //        catch (SqlException ex)
        //        {
        //            MessageBox.Show("SQL Error: " + ex.Message);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error: " + ex.Message);
        //        }
        //    }
        //}

        private void btnProductManagement_Click(object sender, EventArgs e)
        {
            // Pass the username from SessionInfo to ProductManagementForm
            ProductManagementForm productForm = new ProductManagementForm(SessionInfo.Username);

            // Subscribe to the ProductAdded event to refresh cmbProductSearch when a product is added
            productForm.ProductAdded += (s, eArgs) => PopulateProductSearchComboBox();

            // Show the ProductManagementForm without hiding the MainForm
            productForm.Show();

            // Optionally disable the current button or form to prevent further actions on MainForm
            this.Enabled = false;  // Disable MainForm while the ProductManagementForm is open

            // Subscribe to the FormClosed event of ProductManagementForm to re-enable MainForm after closing
            productForm.FormClosed += (s, args) => { this.Enabled = true; };  // Re-enable MainForm when ProductManagementForm is closed


        }

        
        /*
        private void PopulateProductSearchAutoComplete()
        {
            // Create the AutoCompleteStringCollection for the text box
            AutoCompleteStringCollection productCollection = new AutoCompleteStringCollection();

            // Fetch product names from the database
            using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=POS_DB;Integrated Security=True"))
            {
                conn.Open();
                string query = "SELECT ProductName FROM Products"; // Assuming you have a table named 'Products'

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Add product names to the AutoComplete collection
                            productCollection.Add(reader["ProductName"].ToString());
                        }
                    }
                }
            }

            // Assign the AutoComplete collection to the Product Search TextBox
            txtProductSearch.AutoCompleteCustomSource = productCollection;
            txtProductSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProductSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        */
        // When a product is selected, auto-fill price and other related fields
        
        
        
        private decimal CalculateTax(decimal amount)
        {
            const decimal taxRate = 0.10M; // 10% tax
            return amount * taxRate;
        }
        
        

        

       

       

        // Implement the GetProductIDByName method to fetch ProductID from the database
        private int GetProductIDByName(string productName)
        {
            int productID = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductID FROM Products WHERE ProductName = @ProductName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", productName);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        productID = Convert.ToInt32(result);
                    }
                }
            }
            return productID;
        }

        // Update stock in the database after the sale
        private void UpdateStock(string productName, int quantitySold)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET Stock = Stock - @QuantitySold WHERE ProductName = @ProductName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@QuantitySold", quantitySold);
                    cmd.Parameters.AddWithValue("@ProductName", productName);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Clear input fields after adding to cart
        private void ClearProductInputFields()
        {
            cmbProductSearch.SelectedIndex = -1;
            
        }
        private void UpdateCartTotals()
        {
            decimal total = 0;
            decimal totalTax = 0;

            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in dataOfCart.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Calculate row total and add it to the grand total
                    if (row.Cells["Total"] != null && row.Cells["Total"].Value != DBNull.Value)
                    {
                        decimal rowTotal;
                        if (decimal.TryParse(row.Cells["Total"].Value.ToString(), out rowTotal))
                        {
                            total += rowTotal;
                        }
                    }

                    // Add row tax to total tax
                    if (row.Cells["Tax"] != null && row.Cells["Tax"].Value != DBNull.Value)
                    {
                        decimal rowTax;
                        if (decimal.TryParse(row.Cells["Tax"].Value.ToString(), out rowTax))
                        {
                            totalTax += rowTax;
                        }
                    }
                }
            }

           
            // Update the total price TextBox
            txtTotalPrice.Text = total.ToString("0.00");
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
           
                // Ensure that a row is selected
                if (dataOfCart.SelectedRows.Count > 0)
                {
                    // Get the selected row index
                    int selectedIndex = dataOfCart.SelectedRows[0].Index;

                    // Optionally: Retrieve the product name from the selected row (if needed for database removal)
                    string productName = dataOfCart.Rows[selectedIndex].Cells["ProductName"].Value.ToString();

                    // Remove the selected row from the DataGridView
                    dataOfCart.Rows.RemoveAt(selectedIndex);

                    // Optionally: Remove the item from the database
                    RemoveFromDatabase(productName);

                    // Update cart totals after removal
                    UpdateCartTotals();
                }
                else
                {
                    MessageBox.Show("Please select an item to remove.");
                }
         }
        private void RemoveFromDatabase(string productName)
        {
            // Define the SQL query to delete the cart item from the database based on the product name
            string query = "DELETE FROM Cart WHERE ProductName = @ProductName";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Add the ProductName parameter
                cmd.Parameters.AddWithValue("@ProductName", productName);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void UpdateSummary()
        {
            // Initialize totals
            int totalQuantitySold = 0;
            decimal totalDiscountApplied = 0;
            decimal totalTaxCollected = 0;

            // Iterate through DataGridView rows to calculate totals
            foreach (DataGridViewRow row in dataOfCart.Rows)
            {
                if (row.Cells["Quantity"]?.Value != null)
                {
                    totalQuantitySold += Convert.ToInt32(row.Cells["Quantity"].Value);
                }

                if (row.Cells["Discount"]?.Value != null)
                {
                    totalDiscountApplied += Convert.ToDecimal(row.Cells["Discount"].Value);
                }

                if (row.Cells["Tax"]?.Value != null)
                {
                    totalTaxCollected += Convert.ToDecimal(row.Cells["Tax"].Value);
                }
            }

            // Update TextBoxes
            quantitySold.Text = totalQuantitySold.ToString();
            discountApplied.Text = totalDiscountApplied.ToString("F2"); // Format as decimal with 2 decimal places
            taxCollected.Text = totalTaxCollected.ToString("F2");
        }

        // Attach this method to relevant DataGridView events
        private void dataOfCart_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateSummary();
        }

        private void dataOfCart_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateSummary();
        }

        private void PopulatePaymentMethods()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=POS_DB;Integrated Security=True"; // Replace with your actual connection string
            string query = "SELECT PaymentMethodID, PaymentMethodName FROM PaymentMethods";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear existing items
                    cmbPaymentMethod.Items.Clear();

                    // Add items to the ComboBox
                    while (reader.Read())
                    {
                        cmbPaymentMethod.Items.Add(new KeyValuePair<int, string>(
                            reader.GetInt32(0), // PaymentMethodID
                            reader.GetString(1) // PaymentMethodName
                        ));
                    }

                    cmbPaymentMethod.DisplayMember = "Value"; // Display the name
                    cmbPaymentMethod.ValueMember = "Key";    // Use ID as the value
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading payment methods: " + ex.Message);
                }
            }
        }

        private void UpdateChange()
        {
            decimal totalPrice = string.IsNullOrEmpty(txtTotalPrice.Text) ? 0 : decimal.Parse(txtTotalPrice.Text);
            decimal paidAmount = string.IsNullOrEmpty(txtPaidAmount.Text) ? 0 : decimal.Parse(txtPaidAmount.Text);

            if (paidAmount >= totalPrice)
            {
                decimal change = paidAmount - totalPrice;
                txtChange.Text = change.ToString("0.00");
            }
            else
            {
                txtChange.Text = "0.00";  // No change if the paid amount is less than the total
            }
        }
        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            UpdateChange();
        }

        private void btnCompleteSale_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPaymentMethod.SelectedItem == null)
                {
                    MessageBox.Show("Please select a payment method before completing the sale.");
                    return;
                }

                // Retrieve selected payment method
                KeyValuePair<int, string> selectedPaymentMethod = (KeyValuePair<int, string>)cmbPaymentMethod.SelectedItem;
                int paymentMethodID = selectedPaymentMethod.Key; // Get PaymentMethodID
                string paymentMethodName = selectedPaymentMethod.Value;

                totalAmount = decimal.Parse(txtTotalPrice.Text);
                int userID = GetCurrentUserID();  // Get the current user ID
                int customerID = GetSelectedCustomerID(cmbCustomer);  // Get the customer ID

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Calculate total tax and total discount from cart
                    totalTax = 0;
                    totalDiscount = 0;

                    foreach (DataGridViewRow row in dataOfCart.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            totalTax += decimal.Parse(row.Cells["Tax"].Value.ToString());
                            totalDiscount += decimal.Parse(row.Cells["Discount"].Value.ToString());
                        }
                    }

                    // Insert the sale into the Sales table
                    string insertSaleQuery = @"
INSERT INTO Sales (SaleDate, TotalAmount, UserID, CustomerID, PaymentMethodID, TotalDiscount, TotalTax) 
VALUES (@SaleDate, @TotalAmount, @UserID, @CustomerID, @PaymentMethodID, @TotalDiscount, @TotalTax);
SELECT SCOPE_IDENTITY();";  // Get the last inserted SaleID

                    using (SqlCommand cmd = new SqlCommand(insertSaleQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@CustomerID", customerID);
                        cmd.Parameters.AddWithValue("@PaymentMethodID", paymentMethodID);
                        cmd.Parameters.AddWithValue("@TotalDiscount", totalDiscount); // Add TotalDiscount
                        cmd.Parameters.AddWithValue("@TotalTax", totalTax);           // Add TotalTax

                        // Execute the query and get the newly inserted SaleID
                        int saleID = Convert.ToInt32(cmd.ExecuteScalar());

                        // Clear previous sale items in case of multiple transactions
                        saleItems.Clear();

                        // Insert each item from the cart into the SalesDetails table
                        foreach (DataGridViewRow row in dataOfCart.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                int productID = int.Parse(row.Cells["ProductID"].Value.ToString());
                                int quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                                decimal priceAtSale = decimal.Parse(row.Cells["Price"].Value.ToString());
                                decimal discountApplied = decimal.Parse(row.Cells["Discount"].Value.ToString());
                                decimal taxApplied = decimal.Parse(row.Cells["Tax"].Value.ToString());
                                decimal totalPrice = decimal.Parse(row.Cells["Total"].Value.ToString());

                                string insertItemQuery = @"
INSERT INTO SalesDetails (SaleID, ProductID, Quantity, PriceAtSale, DiscountApplied, TaxApplied, TotalPrice) 
VALUES (@SaleID, @ProductID, @Quantity, @PriceAtSale, @DiscountApplied, @TaxApplied, @TotalPrice)";

                                using (SqlCommand itemCmd = new SqlCommand(insertItemQuery, conn))
                                {
                                    itemCmd.Parameters.AddWithValue("@SaleID", saleID);
                                    itemCmd.Parameters.AddWithValue("@ProductID", productID);
                                    itemCmd.Parameters.AddWithValue("@Quantity", quantity);
                                    itemCmd.Parameters.AddWithValue("@PriceAtSale", priceAtSale);
                                    itemCmd.Parameters.AddWithValue("@DiscountApplied", discountApplied);
                                    itemCmd.Parameters.AddWithValue("@TaxApplied", taxApplied);
                                    itemCmd.Parameters.AddWithValue("@TotalPrice", totalPrice);

                                    itemCmd.ExecuteNonQuery();
                                }

                                // Store sale item data for printing
                                SaleItem item = new SaleItem
                                {
                                    ProductName = row.Cells["ProductName"].Value.ToString(),
                                    Quantity = quantity,
                                    Price = priceAtSale,
                                    Discount = discountApplied,
                                    Tax = taxApplied,
                                    Total = totalPrice
                                };
                                saleItems.Add(item);
                            }
                        }

                        // Update stock in the database after completing the sale
                        foreach (DataGridViewRow row in dataOfCart.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                int productID = (int)row.Cells["ProductID"].Value;
                                int quantitySold = Convert.ToInt32(row.Cells["Quantity"].Value);
                                UpdateProductStock(productID, quantitySold, conn);
                            }
                        }

                        // Clear the cart and reset fields
                        dataOfCart.Rows.Clear();  // Clear the DataGridView after completing the sale
                        txtTotalPrice.Text = "0"; // Reset total price
                        cmbCustomer.SelectedIndex = -1; // Clear customer selection
                        cmbPaymentMethod.SelectedIndex = -1; // Clear payment method selection

                        MessageBox.Show($"Sale completed successfully with payment method: {paymentMethodName}!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error completing sale: " + ex.Message);
            }
        }




        private int GetCurrentUserID()
        {
            return SessionInfo.UserID;
        }
        private int GetSelectedCustomerID(System.Windows.Forms.ComboBox comboBox)
        {
            try
            {
                // Check if the comboBox or SelectedItem is null
                if (comboBox == null)
                {
                    throw new NullReferenceException("The ComboBox is null.");
                }

                // Safely handle null SelectedItem by assigning an empty string if null
                string customerName = comboBox.SelectedItem != null ? comboBox.SelectedItem.ToString() : string.Empty;

                // If customerName is empty, no item was selected
                if (string.IsNullOrEmpty(customerName))
                {
                    MessageBox.Show("Please select a customer.");
                    return -1;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT CustomerID FROM Customers WHERE CustomerName = @CustomerName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", customerName);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            throw new Exception("Customer not found.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL-specific exceptions
                MessageBox.Show("Database error: " + ex.Message);
                return -1;
            }
            catch (NullReferenceException ex)
            {
                // Handle the case where the comboBox or SelectedItem is null
                MessageBox.Show(ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
                return -1;
            }
        }




        // Calculate total tax for all items in the cart
        private decimal CalculateTotalTax()
        {
            decimal totalTax = 0;

            foreach (DataGridViewRow row in dataOfCart.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal taxApplied = decimal.Parse(row.Cells["Tax"].Value.ToString());
                    totalTax += taxApplied; // Add the tax for each item to the total
                }
            }

            return totalTax;
        }

        // Calculate total discount for all items in the cart
        private decimal CalculateTotalDiscount()
        {
            decimal totalDiscount = 0;

            foreach (DataGridViewRow row in dataOfCart.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal discountApplied = decimal.Parse(row.Cells["Discount"].Value.ToString());
                    totalDiscount += discountApplied; // Add the discount for each item to the total
                }
            }

            return totalDiscount;
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();

            // Show the print dialog to let the user select the printer
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Use the printer selected by the user
                printDocument.PrinterSettings = printDialog.PrinterSettings;

                // Attach the event handler for printing
                printDocument.PrintPage += new PrintPageEventHandler(PrintReceiptPage);

                try
                {
                    // Start printing
                    printDocument.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while printing: " + ex.Message);
                }
            }
        }
        private void PrintReceiptPage(object sender, PrintPageEventArgs e)
        {
            // Define fonts and layout for printing
            Font font = new Font("Arial", 10, FontStyle.Regular);
            Font boldFont = new Font("Arial", 12, FontStyle.Bold);
            int lineHeight = (int)font.GetHeight(e.Graphics);
            int x = 10;  // Starting x-coordinate (left margin)
            int y = 10;  // Starting y-coordinate (top margin)

            // Print the header (store name, etc.)
            e.Graphics.DrawString("FastTrackPOS", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, x, y);
            y += lineHeight + 5;

            // Print store details (Address and Phone)
            e.Graphics.DrawString("1234 Main Street, City Name", font, Brushes.Black, x, y);
            y += lineHeight;
            e.Graphics.DrawString("Phone: (123) 456-7890", font, Brushes.Black, x, y);
            y += lineHeight + 10;

            // Print a dotted line separator
            e.Graphics.DrawString("----------------------------------------", font, Brushes.Black, x, y);
            y += lineHeight + 5;

            // Print sale details (e.g., Receipt, Date, etc.)
            e.Graphics.DrawString("Receipt", boldFont, Brushes.Black, x, y);
            y += lineHeight + 5;
            e.Graphics.DrawString("Date: " + DateTime.Now.ToString("MM/dd/yyyy"), font, Brushes.Black, x, y);
            y += lineHeight + 10;

            // Print each sale item (Product, Quantity, Price, etc.)
            foreach (var item in saleItems)  // Assuming saleItems contains the current sale data
            {
                e.Graphics.DrawString($"Product: {item.ProductName}", font, Brushes.Black, x, y);
                y += lineHeight;

                e.Graphics.DrawString($"Quantity: {item.Quantity}", font, Brushes.Black, x, y);
                y += lineHeight;

                e.Graphics.DrawString($"Price: {item.Price:C2}", font, Brushes.Black, x, y);
                y += lineHeight;

                e.Graphics.DrawString($"Total: {item.Total:C2}", font, Brushes.Black, x, y);
                y += lineHeight + 10;
            }

            // Print totals (Tax, Discount, and Total Amount)
            e.Graphics.DrawString("Tax: " + totalTax.ToString("C2"), font, Brushes.Black, x, y);  // totalTax stored during sale
            y += lineHeight;

            e.Graphics.DrawString("Discount: " + totalDiscount.ToString("C2"), font, Brushes.Black, x, y);  // totalDiscount stored during sale
            y += lineHeight;

            e.Graphics.DrawString("Total Amount: " + totalAmount.ToString("C2"), boldFont, Brushes.Black, x, y);
            y += lineHeight + 10;

            // Print a dotted line separator for the end
            e.Graphics.DrawString("----------------------------------------", font, Brushes.Black, x, y);
        }



        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            // Set up basic fonts and formatting
            Font font = new Font("Arial", 10);
            Font boldFont = new Font("Arial", 12, FontStyle.Bold);
            float lineHeight = font.GetHeight(e.Graphics);
            float x = 10; // X position
            float y = 10; // Starting Y position

            // Print the header (Store Information)
            e.Graphics.DrawString("FastTrackPOS", boldFont, Brushes.Black, x, y);
            y += lineHeight;
            e.Graphics.DrawString("Address: 123 Store St.", font, Brushes.Black, x, y);
            y += lineHeight;
            e.Graphics.DrawString("Phone: (123) 456-7890", font, Brushes.Black, x, y);
            y += lineHeight * 2;

            // Print the date and time of the sale
            e.Graphics.DrawString("Date: " + DateTime.Now.ToString(), font, Brushes.Black, x, y);
            y += lineHeight;

            // Print a line to separate header
            e.Graphics.DrawString("---------------------------------", font, Brushes.Black, x, y);
            y += lineHeight;

            // Print the sale details header
            e.Graphics.DrawString("Product    Qty   Price   Total", boldFont, Brushes.Black, x, y);
            y += lineHeight;

            // Print a line to separate the table headers
            e.Graphics.DrawString("---------------------------------", font, Brushes.Black, x, y);
            y += lineHeight;

            // Print each stored item from the sale
            foreach (var item in saleItems)
            {
                string line = string.Format("{0,-10} {1,5} {2,8} {3,10}",
                    item.ProductName, item.Quantity, item.Price, item.Total);
                e.Graphics.DrawString(line, font, Brushes.Black, x, y);
                y += lineHeight;
            }

            // Print a line to separate the items from totals
            e.Graphics.DrawString("---------------------------------", font, Brushes.Black, x, y);
            y += lineHeight;

            // Print the total amount
            e.Graphics.DrawString("Total Amount: " + totalAmount.ToString("F2"), boldFont, Brushes.Black, x, y);
            y += lineHeight;

            // Print total tax
            e.Graphics.DrawString("Tax: " + totalTax.ToString("F2"), font, Brushes.Black, x, y);
            y += lineHeight;

            // Print total discount
            e.Graphics.DrawString("Discount: " + totalDiscount.ToString("F2"), font, Brushes.Black, x, y);
            y += lineHeight;

            // Print a thank you message
            y += lineHeight * 2;
            e.Graphics.DrawString("Thank you for shopping!", boldFont, Brushes.Black, x, y);
        }







        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            // Open the CustomerManagementForm
            CustomerManagementForm customerForm = new CustomerManagementForm();

            // Subscribe to the CustomerAdded event
            customerForm.CustomerAdded += (s, eArgs) => PopulateCustomerComboBox();

            // Show the form as a dialog
            customerForm.ShowDialog();
        }
        private void PopulateCustomerComboBox()
        {
            cmbCustomer.Items.Clear();  // Clear previous items

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT CustomerName FROM Customers"; // Fetch customer names
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbCustomer.Items.Add(reader["CustomerName"].ToString());
                        }
                    }
                }
            }

            // Set ComboBox properties for autocomplete
            cmbCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusBar1.Panels[0].Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void btnCategoryManagement_Click(object sender, EventArgs e)
        {
            // Instantiate the AddCategoryForm
            AddCategoryForm addCategoryForm = new AddCategoryForm();

            // Show the AddCategoryForm as a modal dialog
            addCategoryForm.ShowDialog();
        }

        private void btnSupplierManagement_Click(object sender, EventArgs e)
        {
            // Open AddSupplierForm
            AddSupplierForm addSupplierForm = new AddSupplierForm();

            // Subscribe to the SupplierAdded event
            

            addSupplierForm.ShowDialog(); // Show as a dialog to block the current form
        }

        private void btnCancelSale_Click(object sender, EventArgs e)
        {
            try
            {
                // Confirm if the user wants to cancel the sale
                DialogResult result = MessageBox.Show("Are you sure you want to cancel the sale?", "Cancel Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Clear the cart (DataGridView)
                    dataOfCart.Rows.Clear();

                    // Reset total price and any other relevant fields
                    txtTotalPrice.Text = "0"; // Reset total price to 0
                    cmbCustomer.SelectedIndex = -1; // Clear customer selection
                                                    // If you have additional fields like txtDiscount or txtTax, reset them here as well
                                                    // Example: txtDiscount.Text = "0"; txtTax.Text = "0";

                    MessageBox.Show("Sale has been canceled.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error canceling sale: " + ex.Message);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close the current form
                this.Hide();

                // Show the login form
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                // Optional: Clear any session data or reset states
                SessionInfo.Clear(); // Assuming you have a static SessionInfo class for managing session data
            }
        }
    }

}

