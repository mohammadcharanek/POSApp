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

namespace POSApp
{
    
    public partial class ProductManagementForm : Form
    {
        private string _username;
        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=POS_DB;Integrated Security=True";
        public event EventHandler ProductAdded;
        public ProductManagementForm(string username)
        {
            InitializeComponent();
            LoadProductIDs();
           
            LoadSuppliers();  // Load suppliers when the form is initialized
            _username = username;
        }

        // Load all Product IDs into the ComboBox
        private void LoadProductIDs()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ProductID FROM Products";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbProductID.Items.Add(reader["ProductID"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Event handler when ProductID is selected
        private void cmbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected ProductID from the ComboBox
            if (cmbProductID.SelectedItem != null)
            {
                int selectedProductID;
                if (int.TryParse(cmbProductID.SelectedItem.ToString(), out selectedProductID))
                {
                    // Fetch product details based on the selected ProductID
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            string query = "SELECT ProductName, Price, Stock FROM Products WHERE ProductID = @ProductID";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ProductID", selectedProductID);

                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                txtProductName.Text = reader["ProductName"]?.ToString();
                                txtPrice.Text = reader["Price"]?.ToString();
                                txtQuantity.Text = reader["Stock"]?.ToString();
                            }
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
        }
        private void LoadSuppliers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT SupplierID, SupplierName FROM Suppliers"; // Adjust your query if needed

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Clear existing items in the ComboBox
                        cmbSupplier.Items.Clear();

                        while (reader.Read())
                        {
                            cmbSupplier.Items.Add(new ComboBoxItem
                            {
                                Value = Convert.ToInt32(reader["SupplierID"]),
                                Text = reader["SupplierName"].ToString()
                            });

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading suppliers: " + ex.Message);
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Read inputs from textboxes and ComboBoxes
            string productName = txtProductName.Text;
            decimal price;
            int stock;
            string barcode = txtBarcodeInput.Text;
            int categoryID = (int)comboBoxCategories.SelectedValue; // Assuming you have a ComboBox for CategoryID
            string description = txtDescription.Text; // Assuming you have a TextBox for Description

            decimal costPrice;
            decimal discount;
            decimal tax;
            string unit = txtUnit.Text; // Assuming you have a TextBox for Unit
            int reorderLevel;

            // Validate the inputs
            if (string.IsNullOrWhiteSpace(productName) ||
                !decimal.TryParse(txtPrice.Text, out price) ||
                !int.TryParse(txtQuantity.Value.ToString(), out stock) || // Assuming you have a NumericUpDown for quantity
                string.IsNullOrWhiteSpace(barcode) ||
                !decimal.TryParse(txtCostPrice.Text, out costPrice) || // TextBox for CostPrice
                !int.TryParse(txtReorderLevel.Text, out reorderLevel) || // TextBox for ReorderLevel
                !decimal.TryParse(txtDiscount.Text, out discount) || // TextBox for Discount
                !decimal.TryParse(txtTax.Text, out tax) || // TextBox for Tax
                string.IsNullOrWhiteSpace(unit) ||
                cmbSupplier.SelectedItem == null)
            {
                MessageBox.Show("Please enter valid data in all fields, including the barcode.");
                return;
            }

            var selectedSupplier = (ComboBoxItem)cmbSupplier.SelectedItem;
            int supplierID = (int)selectedSupplier.Value; // Assuming you have a ComboBox for SupplierID

            // Insert product into the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SQL query to insert the new product with all necessary fields
                    string query = @"
            INSERT INTO Products (ProductName, Price, Stock, Barcode, CategoryID, Description, SupplierID, CostPrice, ReorderLevel, Discount, Tax, DateAdded, Unit) 
            VALUES (@ProductName, @Price, @Stock, @Barcode, @CategoryID, @Description, @SupplierID, @CostPrice, @ReorderLevel, @Discount, @Tax, @DateAdded, @Unit)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@Stock", stock);
                        cmd.Parameters.AddWithValue("@Barcode", barcode);
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                        cmd.Parameters.AddWithValue("@CostPrice", costPrice);
                        cmd.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
                        cmd.Parameters.AddWithValue("@Discount", discount);
                        cmd.Parameters.AddWithValue("@Tax", tax);
                        cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now); // Set current date and time
                        cmd.Parameters.AddWithValue("@Unit", unit);

                        // Execute the insert query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product added successfully with barcode!");

                            // Raise the ProductAdded event
                            ProductAdded?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the product.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void txtBarcodeInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Get the scanned barcode
                string barcode = txtBarcodeInput.Text.Trim();

                // You can also validate or check the barcode before inserting it into the database.

                MessageBox.Show("Barcode captured: " + barcode);
            }
        }
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            // Read inputs from textboxes
            int productId;
            string productName = txtProductName.Text;
            decimal price;
            int stock;

            // Validate the inputs
            if (!int.TryParse(cmbProductID.Text, out productId) ||
                string.IsNullOrWhiteSpace(productName) ||
                !decimal.TryParse(txtPrice.Text, out price) ||
                !int.TryParse(txtQuantity.Text, out stock))
            {
                MessageBox.Show("Please enter valid data in all fields.");
                return;
            }

            // Update product in the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SQL query to update the product
                    string query = "UPDATE Products SET ProductName = @ProductName, Price = @Price, Stock = @Stock WHERE ProductID = @ProductID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@Stock", stock);

                        // Execute the update query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Product not found or update failed.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ProductManagementForm_Load(object sender, EventArgs e)
        {
            txtBarcodeInput.Focus();
            PopulateCategoryComboBox();
            RefreshCategoryComboBox();
            // Set the label or any UI component to display the username
            labelUsername.Text = $"Welcome, {_username}"; // Assuming labelUsername exists on the form

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (cmbProductID.SelectedItem != null)
            {
                // Get the selected ProductID from the ComboBox
                int selectedProductID;
                if (int.TryParse(cmbProductID.SelectedItem.ToString(), out selectedProductID))
                {
                    // Confirm before deletion
                    var confirmResult = MessageBox.Show("Are you sure to delete this product?",
                                                         "Confirm Delete",
                                                         MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Delete the product from the database
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            try
                            {
                                conn.Open();
                                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                                SqlCommand cmd = new SqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@ProductID", selectedProductID);

                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Product deleted successfully!");

                                    // Optionally: Refresh the ComboBox by reloading the Product IDs
                                    cmbProductID.Items.Clear();
                                    LoadProductIDs();

                                    // Clear the text fields
                                    txtProductName.Clear();
                                    txtPrice.Clear();
                                    txtQuantity.Value = 0;

                                }
                                else
                                {
                                    MessageBox.Show("Error: No product found to delete.");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Product ID selected.");
                }
            }
            else
            {
                MessageBox.Show("Please select a Product ID to delete.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string username = SessionInfo.Username;  // Assuming you store the username in SessionInfo

            // Pass the username to MainForm's constructor
            //MainForm mf = new MainForm(username);  // Pass the username when creating MainForm
            //mf.Show();
            this.Close();


        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            // Instantiate the AddCategoryForm
            AddCategoryForm addCategoryForm = new AddCategoryForm();

            // Show the AddCategoryForm as a modal dialog
            addCategoryForm.ShowDialog();
            RefreshCategoryComboBox();
        }
        // Method to populate ComboBox with categories
        private void PopulateCategoryComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL query to retrieve category names and IDs from the Categories table
                    string query = "SELECT CategoryID, CategoryName FROM Categories";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable categoriesTable = new DataTable();

                        // Fill the DataTable with category data
                        adapter.Fill(categoriesTable);

                        // Bind the ComboBox to the DataTable
                        comboBoxCategories.DisplayMember = "CategoryName";  // What will be displayed in the ComboBox
                        comboBoxCategories.ValueMember = "CategoryID";      // What will be the actual value (useful for database operations)
                        comboBoxCategories.DataSource = categoriesTable;    // Set the DataSource to the retrieved data
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshCategoryComboBox()
        {
            // Clear the current items in the ComboBox
            comboBoxCategories.DataSource = null;

            // Repopulate the ComboBox with updated data
            PopulateCategoryComboBox();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            // Open AddSupplierForm
            AddSupplierForm addSupplierForm = new AddSupplierForm();

            // Subscribe to the SupplierAdded event
            addSupplierForm.SupplierAdded += AddSupplierForm_SupplierAdded;

            addSupplierForm.ShowDialog(); // Show as a dialog to block the current form
        }
        private void AddSupplierForm_SupplierAdded(object sender, EventArgs e)
        {
            // Refresh the cmbSupplier when a new supplier is added
            LoadSuppliers();
        }
    }
}
