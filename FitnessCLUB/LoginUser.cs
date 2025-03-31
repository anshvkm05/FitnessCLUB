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
        string connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=D:\Project DDOOCP try 2\FitnessCLUB\FitnessCLUB\FItnessClub.mdb;";
        OleDbConnection conn;

        private Login_user mainForm;
        public LoginUser(Login_user form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void LoginUser_Load(object sender, EventArgs e)
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

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            mainForm.LoadUserControl(new RegisterUser(mainForm));
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new OleDbConnection(connString);
                conn.Open();
                string query = "SELECT * FROM UserCred WHERE UserID = @username AND Password = @password";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Login Successful");
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                    guna2HtmlLabel1.Visible = true;
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
