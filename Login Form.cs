using MySql.Data.MySqlClient;
using sims.Admin_Side;
using sims.Admin_Side.Items;
using sims.Messages_Boxes;
using sims.Staff_Side;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
            ConfirmPasswordTextBox();
            showPasswordChk.OnChange += new EventHandler(showPasswordChk_OnChange);
        }

        private void ConfirmPasswordTextBox()
        {
            passwordTxt.PlaceholderText = "Password";
            passwordTxt.PasswordChar = '\0';
            passwordTxt.TextChanged += (sender, e) =>
            {
                string enteredPassword = passwordTxt.Text;
                if (string.IsNullOrEmpty(enteredPassword))
                {
                    passwordTxt.PlaceholderText = "Password";
                    passwordTxt.PasswordChar = '\0';
                }
                else
                {
                    passwordTxt.PlaceholderText = "";
                    passwordTxt.PasswordChar = '●';
                }
            };
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            dbModule db = new dbModule();
            string username = usernameTxt.Text.Trim();
            string password = passwordTxt.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                usernameTxt.Focus();
                new Field_Required().Show();
                usernameTxt.Clear();
                passwordTxt.Clear();
                return;
            }

            string userQuery = "SELECT Staff_Name FROM users WHERE BINARY username = @Username AND BINARY password = @Password";
            string staffQuery = "SELECT Staff_Name FROM staff WHERE BINARY username = @Username AND BINARY password = @Password";

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(userQuery, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // Check if the user is an owner
                        string ownerName = cmd.ExecuteScalar()?.ToString();

                        if (!string.IsNullOrEmpty(ownerName))
                        {
                            // Log owner activity
                            AddLoginActivity(ownerName, "Owner");
                            new ownerLogin().Show();
                            this.Hide();
                        }
                        else
                        {
                            // Check if the user is staff
                            cmd.CommandText = staffQuery;
                            string staffName = cmd.ExecuteScalar()?.ToString();

                            if (!string.IsNullOrEmpty(staffName))
                            {
                                // Log staff activity
                                AddLoginActivity(staffName, "Staff");
                                new Staff_Login().Show();
                                this.Hide();
                            }
                            else
                            {
                                usernameTxt.Focus();
                                new Invalid_Account().Show();
                                usernameTxt.Clear();
                                passwordTxt.Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddLoginActivity(string staffName, string role)
        {
            dbModule db = new dbModule();

            string query = "INSERT INTO activitylogs (Staff_Name, Role, Activity, Date_Logged_In) VALUES (@StaffName, @Role, @Activity, @DateLoggedIn)";

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StaffName", staffName);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@Activity", "Logged In");
                        cmd.Parameters.AddWithValue("@DateLoggedIn", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPasswordChk_OnChange(object sender, EventArgs e)
        {
            if (showPasswordChk.Checked)
            {
                passwordTxt.PasswordChar = '\0';
            }
            else
            {
                passwordTxt.PasswordChar = '●';
            }
        }

        private void forgotPasswordLnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Forgot_Password.Forgot_Password().Show();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
