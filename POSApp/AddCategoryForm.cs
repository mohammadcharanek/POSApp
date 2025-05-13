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
    public partial class AddCategoryForm : Form
    {
        public AddCategoryForm()
        {
            InitializeComponent();
        }
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["POSDBConnectionString"].ConnectionString;
        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Category Name cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL query to insert a new category
                    string query = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCategoryName.Clear();  // Clear the textbox after a successful insertion
                        }
                        else
                        {
                            MessageBox.Show("Failed to add category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
