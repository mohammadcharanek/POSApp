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
    public partial class LoginForm : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["POSDBConnectionString"].ConnectionString;
        private bool isLoggingIn = false;

        public LoginForm()
        {
            InitializeComponent();
            LoadUsernames();
            txtPassword.KeyDown += new KeyEventHandler(txtPassword_KeyDown);  // Enable Enter key login
        }

        private void loginForm_Load(object sender, EventArgs e) { }

        // Load usernames from the database into the ComboBox
        private void LoadUsernames()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Username FROM Users";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxUsernames.Items.Add(reader["Username"].ToString());
                        }
                    }
                }
            }

            if (comboBoxUsernames.Items.Count > 0)
            {
                comboBoxUsernames.SelectedIndex = 0;  // Select the first username by default
            }
        }

        // Authenticate user
        private bool AuthenticateUser(string username, string password, out int userID, out string role)
        {
            userID = 0;
            role = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UserID, Role FROM Users WHERE Username = @Username AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userID = reader.GetInt32(0); // Get UserID
                            role = reader.GetString(1); // Get Role
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        // Handle Enter key press in the password field
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;  // Suppress Enter key beep

                btnLogin_Click_1(sender, e);  // Trigger the login logic
            }
        }

        // Handle login button click
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (isLoggingIn) return;  // Prevent multiple logins
            isLoggingIn = true;  // Set flag to indicate login in progress
            btnLogin.Enabled = false;  // Disable login button

            try
            {
                string username = comboBoxUsernames.SelectedItem.ToString();
                string password = txtPassword.Text;

                int userID;
                string role;

                if (AuthenticateUser(username, password, out userID, out role))
                {
                    // Set session information
                    SessionInfo.UserID = userID;
                    SessionInfo.Role = role;
                    SessionInfo.Username = username;

                    // Create and show MainForm
                    MainForm mainForm = new MainForm(SessionInfo.Username);

                    // Hide the LoginForm before showing MainForm
                    this.Hide();  // Ensure this is only called once

                    // Show the MainForm (modal or non-modal)
                    mainForm.ShowDialog();  // ShowDialog ensures MainForm runs as modal

                    // Optional: Close the LoginForm after MainForm is closed
                    this.Close();  // Close the LoginForm to prevent returning to login
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                    btnLogin.Enabled = true;  // Re-enable the button on failure
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                btnLogin.Enabled = true;  // Re-enable the button on error
            }
            finally
            {
                isLoggingIn = false;  // Reset the flag
            }
        }

    }
}