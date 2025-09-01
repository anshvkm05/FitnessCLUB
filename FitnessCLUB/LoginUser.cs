using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FitnessCLUB
{
    public partial class LoginUser: UserControl
    {
        string connString = $@"Provider=Microsoft.JET.OLEDB.4.0;Data Source={Application.StartupPath}\FItnessClub.mdb;";
        OleDbConnection conn;
        private int lockaccount = 0;
        private static Dictionary<string, int> failedAttempts = new Dictionary<string, int>();
        private static Dictionary<string, bool> accountLocked = new Dictionary<string, bool>();
        private Login_user mainForm;
        public LoginUser(Login_user form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void LoginUser_Load(object sender, EventArgs e)
        {

        }
        public static class SessionManager
        {
            public static string CurrentUserID { get; set; }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(4, 32, 53);
        }

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            mainForm.LoadUserControl(new RegisterUser(mainForm));
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;

            // Check if the account is locked
            if (accountLocked.ContainsKey(username) && accountLocked[username])
            {
                MessageBox.Show("Your account is locked due to too many failed login attempts.");
                return;
            }
            try
            {
                conn = new OleDbConnection(connString);
                conn.Open();
                string query = "SELECT * FROM UserCred WHERE UserID = @username AND UserPassword = @password";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    ResetFailedAttempts(username);  // Reset failed attempts on successful login
                    SessionManager.CurrentUserID = (txtusername.Text).ToString(); // Store the current user ID
                    MessageBox.Show("Login Successful");
                    Form parentForm = this.FindForm();
                    if (parentForm != null)
                    {
                        parentForm.Hide(); // Hide or close the Dashboard form
                    }
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                    guna2HtmlLabel1.Visible = true;
                    IncrementFailedAttempts(username);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void IncrementFailedAttempts(string username)
        {
            if (!failedAttempts.ContainsKey(username))
            {
                failedAttempts[username] = 0;
            }

            failedAttempts[username]++;

            if (failedAttempts[username] >= 3)
            {
                LockAccount(username);
            }
        }

        private void ResetFailedAttempts(string username)
        {
            if (failedAttempts.ContainsKey(username))
            {
                failedAttempts[username] = 0;
            }
        }

        private void LockAccount(string username)
        {
            MessageBox.Show($"Account for user '{username}' has been locked due to too many failed login attempts.");
            accountLocked[username] = true;
        }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            mainForm.LoadUserControl(new ForgotPassword(mainForm));  
        }

        private void guna2HtmlLabel1_MouseEnter(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Cursor = Cursors.Hand;
        }

        private void guna2HtmlLabel1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void showpass_Click(object sender, EventArgs e)
        {
            if (showpass.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }
    }
}
