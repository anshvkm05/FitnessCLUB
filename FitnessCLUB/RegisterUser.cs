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
using System.Text.RegularExpressions;

namespace FitnessCLUB
{
    public partial class RegisterUser: UserControl
    {
        string connString = $@"Provider=Microsoft.JET.OLEDB.4.0;Data Source={Application.LocalUserAppDataPath}\FItnessClub.mdb;";
        OleDbConnection conn;

        private Login_user mainForm;
        public RegisterUser(Login_user form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void RegisterUser_Load(object sender, EventArgs e)
        {

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

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            mainForm.LoadUserControl(new LoginUser(mainForm)); // Switch to Login UserControl
        }

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            if (!IsValidEmail(txtemail.Text))
            {
                Invalidemail.Visible = true;
                return;
            }

            // Validate Password
            if (!IsValidPassword(txtpassword.Text))
            {
                MessageBox.Show("Password must be at least 8 characters long, contain 1 uppercase letter, and 1 digit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string query = "INSERT INTO UserCred (UserID, email, UserPassword) VALUES (@userid, @email, @password)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", txtusername.Text);
                        cmd.Parameters.AddWithValue("@email", txtemail.Text);
                        cmd.Parameters.AddWithValue("@password", txtpassword.Text);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Registered Successfull");
                            string userId = txtusername.Text; // Assuming username is entered during registration
                            mainForm.OpenQuestionsUser(userId); // Pass UserID

                        }
                        else if (result == 0)
                        {
                            MessageBox.Show("Failed to insert record");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Validate Password (At least 8 chars, 1 uppercase, 1 number)
        private bool IsValidPassword(string password)
        {
            string passwordPattern = @"^(?=.*[A-Z])(?=.*\d).{8,}$";
            return Regex.IsMatch(password, passwordPattern);
        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
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

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtpassword.Text;

            // Check for at least one uppercase letter
            if (Regex.IsMatch(password, @"[A-Z]"))
                lblCapital.ForeColor = Color.Green;
            else
                lblCapital.ForeColor = Color.Red;

            // Check for at least 8 characters
            if (password.Length >= 8)
                lbl8char.ForeColor = Color.Green;
            else
                lbl8char.ForeColor = Color.Red;

            // Check for at least one digit
            if (Regex.IsMatch(password, @"\d"))
                lblDigit.ForeColor = Color.Green;
            else
                lblDigit.ForeColor = Color.Red;
        }
    }
}
