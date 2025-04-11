using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SATAUiFramework.Controls;
using System.Data.OleDb;
using System.Drawing.Text;

namespace FitnessCLUB.Resources
{
    public partial class Setting: UserControl
    {
        string connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=D:\Project DDOOCP try 2\FitnessCLUB\FitnessCLUB\FItnessClub.mdb;";
        OleDbConnection conn; // Store UserID
        public Setting()
        {
            InitializeComponent();
            conn = new OleDbConnection(connString);

        }

        private void sataPictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void Load_UserData()
        {
            try
            {
                conn.Open();
                string query = "SELECT Name, UserID, Age, Height, Weight, Gender, BMI FROM UserData WHERE UserID = @UserID";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString());

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (txtName != null) txtName.Content = reader["Name"].ToString();
                    if (txtName != null) guna2HtmlLabel1.Text = reader["UserID"].ToString();
                    if (txtAge != null) txtAge.Content = reader["Age"].ToString();
                    if (txtHeight != null) txtHeight.Content = reader["Height"].ToString();
                    if (txtWeight != null) txtWeight.Content = reader["Weight"].ToString();
                    if (txtGender != null) txtGender.Content = reader["Gender"].ToString();
                    if (txtUserID != null) txtUserID.Content = reader["UserID"].ToString();
                    if (txtBMI != null) txtBMI.Content = reader["BMI"].ToString();

                }
                else
                {
                    MessageBox.Show("User data not found.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading progress: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void Update_UserData()
        {
            try
            {
                conn.Open();
                string query = "UPDATE UserData SET Name = @name, Age = @age, Height = @height, Weight = @weight, Gender = @gender, BMI = @bmi WHERE UserID = @userID";
                OleDbCommand cmd = new OleDbCommand(query, conn);

                // Add parameters with values from textboxes
                cmd.Parameters.AddWithValue("@name", txtName.Content.ToString());
                cmd.Parameters.AddWithValue("@age", txtAge.Content);
                cmd.Parameters.AddWithValue("@height", txtHeight.Content);
                cmd.Parameters.AddWithValue("@weight", txtWeight.Content);
                cmd.Parameters.AddWithValue("@gender", txtGender.Content);
                cmd.Parameters.AddWithValue("@bmi", txtBMI.Content);
                cmd.Parameters.AddWithValue("@userID", guna2HtmlLabel1.Text); // Assuming UserID is not editable
                

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User data updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update user data.");
                }

                if (txtUserID.Content != guna2HtmlLabel1.Text)
                {
                    MessageBox.Show("User ID cannot be changed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            // Reset session data
            LoginUser.SessionManager.CurrentUserID = null;

            // Get the parent form (Dashboard) and hide it
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close(); // Hide or close the Dashboard form
            }

            // Show the Login form
            Login_user login_User = new Login_user();
            login_User.Show();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            Load_UserData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update_UserData();
            Load_UserData();
        }

        private void Setting_DoubleClick(object sender, EventArgs e)
        {
            Load_UserData();
        }

        private void txtUserID_ContentChanged(object sender, EventArgs e)
        {
        }

        private void txtUserID_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
