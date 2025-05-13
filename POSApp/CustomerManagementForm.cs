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
    public partial class CustomerManagementForm : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["POSDBConnectionString"].ConnectionString;
        public event EventHandler CustomerAdded;
        public CustomerManagementForm()
        {
            InitializeComponent();
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Customer Name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone number is required.");
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert the new customer into the database
                    string insertQuery = "INSERT INTO Customers (CustomerName, Phone, Email) VALUES (@CustomerName, @Phone, @Email)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = txtCustomerName.Text.Trim();
                        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = txtPhone.Text.Trim();
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text.Trim();

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Customer created successfully!");

                    // Raise the CustomerAdded event
                    CustomerAdded?.Invoke(this, EventArgs.Empty);

                    this.Close(); // Close the form after customer creation
                }
            }
            catch (Exception ex)
            {
                // Log the error and show a user-friendly message
                MessageBox.Show($"An error occurred while saving the customer: {ex.Message}");
            }
        }

        // Helper method to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
