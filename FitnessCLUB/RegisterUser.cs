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
    public partial class RegisterUser: UserControl
    {
        string connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=D:\Project DDOOCP try 2\FitnessCLUB\FitnessCLUB\FItnessClub.mdb;";
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
            try
            {
                conn = new OleDbConnection(connString);
                conn.Open();
                string query = "INSERT INTO UserCred (UserID, email, Password) VALUES" + "(@userid, @email, @password)";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@userid", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Inserted Successfully");
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
    }
}
