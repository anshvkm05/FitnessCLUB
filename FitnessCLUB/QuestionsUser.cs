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
    public partial class QuestionsUser: UserControl
    {
        string connString = $@"Provider=Microsoft.JET.OLEDB.4.0;Data Source={Application.LocalUserAppDataPath}\FItnessClub.mdb;";
        OleDbConnection conn;
        private Login_user mainForm;
        private string userId; // Store UserID
        public QuestionsUser(Login_user form, string userId)
        {
            InitializeComponent();
            mainForm = form;
            this.userId = userId;
        }

        private void QuestionsUser_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtGender.Text) || string.IsNullOrEmpty(txtAge.Text) ||
                string.IsNullOrEmpty(txtWeight.Text) || string.IsNullOrEmpty(txtHeight.Text) || string.IsNullOrEmpty(txtFromWeight.Text) ||
                string.IsNullOrEmpty(txtToWeight.Text) || string.IsNullOrEmpty(txtTarget.Text) || string.IsNullOrEmpty(txtBMI.Text) ||
                string.IsNullOrEmpty(txtTIME.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                // Convert input values to appropriate types
                int age = int.Parse(txtAge.Text);
                double weight = double.Parse(txtWeight.Text);
                double height = double.Parse(txtHeight.Text);
                double fromWeight = double.Parse(txtFromWeight.Text);
                double toWeight = double.Parse(txtToWeight.Text);
                int timeMonth = int.Parse(txtTIME.Text);
                double bmi = double.Parse(txtBMI.Text);

                double weightDifference = fromWeight - toWeight;
                double totalCaloriesChange = Math.Abs(weightDifference) * 7700;
                double dailyCalorieChange = weightDifference > 0 ? totalCaloriesChange / (timeMonth * 30) : 500;
                DateTime today = DateTime.Today;

                using (conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string query = "INSERT INTO UserData (UserID, Age, Gender, BMI, Target, FromWeight, ToWeight, Name, Height, TimeMonth, TotalCAL, TodayCAL, TodayCALDone, TotalCALDone, Streak, PreviousDayDate, PreviousDayDateCAL) " +
                                   "VALUES (@userid, @age, @gender, @bmi, @target, @fromWeight, @toWeight, @name, @height, @timemonth, @totalCal, @todayCal, @todayCalDone, @totalCalDone, @streak, @prevDayDate, @prevDayDateCAL)";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Add parameters with correct types
                        cmd.Parameters.AddWithValue("@userid", userId); // UserID is likely a string
                        cmd.Parameters.AddWithValue("@age", age); // Integer
                        cmd.Parameters.AddWithValue("@gender", txtGender.Text); // String
                        cmd.Parameters.AddWithValue("@bmi", bmi); // Double
                        cmd.Parameters.AddWithValue("@target", txtTarget.Text); // String
                        cmd.Parameters.AddWithValue("@fromWeight", fromWeight); // Double
                        cmd.Parameters.AddWithValue("@toWeight", toWeight); // Double
                        cmd.Parameters.AddWithValue("@name", txtName.Text); // String
                        cmd.Parameters.AddWithValue("@height", height); // Double
                        cmd.Parameters.AddWithValue("@timemonth", timeMonth); // Integer
                        cmd.Parameters.AddWithValue("@totalCal", totalCaloriesChange); // Double
                        cmd.Parameters.AddWithValue("@todayCal", dailyCalorieChange); // Double
                        cmd.Parameters.AddWithValue("@todayCalDone", 0); // Integer
                        cmd.Parameters.AddWithValue("@totalCalDone", 0); // Integer
                        cmd.Parameters.AddWithValue("@streak", 1); // Integer
                        cmd.Parameters.AddWithValue("@prevDayDate", today); // DateTime
                        cmd.Parameters.AddWithValue("@prevDayDateCAL", today); // DateTime

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Data Saved Successfully!");
                            mainForm.LoadUserControl(new LoginUser(mainForm)); // Redirect to login
                        }
                        else
                        {
                            MessageBox.Show("Failed to save data, because of some error :-( ");
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input format. Please check your entries.\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtHeight_Leave(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double height = Convert.ToDouble(txtHeight.Text);
                double weight = Convert.ToDouble(txtWeight.Text);
                double bmi = weight / ((height/100) * (height/100));
                txtBMI.Text = bmi.ToString("0.00"); // Ensures exactly 2 decimal places

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
