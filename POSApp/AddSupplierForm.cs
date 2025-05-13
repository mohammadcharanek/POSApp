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
    public partial class AddSupplierForm : Form
    {
        public event EventHandler SupplierAdded;

        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["POSDBConnectionString"].ConnectionString;
        public AddSupplierForm()
        {
            InitializeComponent();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            string supplierName = txtSupplierName.Text;
            string contactInfo = txtContactInfo.Text;

            // Validate the inputs
            if (string.IsNullOrWhiteSpace(supplierName) || string.IsNullOrWhiteSpace(contactInfo))
            {
                MessageBox.Show("Please enter valid data in all fields.");
                return;
            }

            // Insert supplier into the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SQL query to insert the new supplier
                    string query = "INSERT INTO Suppliers (SupplierName, ContactInfo) VALUES (@SupplierName, @ContactInfo)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                        cmd.Parameters.AddWithValue("@ContactInfo", contactInfo);

                        // Execute the insert query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Supplier added successfully!");
                            this.Close(); // Optionally close the form after adding
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the supplier.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            // Notify that a supplier was added
            SupplierAdded?.Invoke(this, EventArgs.Empty);

            // Optionally close the form
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
