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
    public partial class Progress: UserControl
    {
        string connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=D:\Project DDOOCP try 2\FitnessCLUB\FitnessCLUB\FItnessClub.mdb;";
        OleDbConnection conn;
        private Dashboard mainForm;
        public Progress(Dashboard form)
        {
            InitializeComponent();
            mainForm = form;
            conn = new OleDbConnection(connString);
            pictureBox2.MouseEnter += pictureBox2_MouseEnter;
            pictureBox2.MouseLeave += pictureBox2_MouseLeave;
        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void LoadProgressData()
        {
            try
            {
                conn.Open();

                string query = "SELECT TodayCAL, TodayCALDone, TotalCAL, TotalCALDone, Height, Weight, Streak FROM UserData WHERE UserID = @UserID";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString());

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Fetch calorie data
                    double todayCal = Convert.ToDouble(reader["TodayCAL"]);
                    double todayCalDone = Convert.ToDouble(reader["TodayCALDone"]);
                    double totalCal = Convert.ToDouble(reader["TotalCAL"]);
                    double totalCalDone = Convert.ToDouble(reader["TotalCALDone"]);

                    // Fetch height, weight, and streak
                    double height = Convert.ToDouble(reader["Height"]); // Height in cm
                    double weight = Convert.ToDouble(reader["Weight"]); // Weight in kg
                    int streak = Convert.ToInt32(reader["Streak"]);

                    // Calculate BMI
                    double heightInMeters = height / 100; // Convert height to meters
                    double bmi = weight / (heightInMeters * heightInMeters);

                    // Avoid division by zero
                    double todayProgress = (todayCal > 0) ? (todayCalDone / todayCal) * 100 : 0;
                    double totalProgress = (totalCal > 0) ? (totalCalDone / totalCal) * 100 : 0;

                    // Clamp to max 100%
                    todayProgress = Math.Min(todayProgress, 100);
                    totalProgress = Math.Min(totalProgress, 100);

                    // Update UI elements
                    lblTodayProgress.Text = todayProgress.ToString("0") + "%";
                    sataCircularProgress1.Percentage = (int)totalProgress;
                    todayProgressBar.ProgressValue = (int)todayProgress;

                    lblHeight.Text = height.ToString("0");
                    lblWeight.Text = weight.ToString("0");
                    lblStreak.Text = streak.ToString();

                    lblBMI.Text = bmi.ToString("0.0");
                    lblBMICategory.Text = GetBMICategory(bmi); // Get BMI category (e.g., Normal, Overweight)
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

        // Helper method to determine BMI category
        private string GetBMICategory(double bmi)
        {
            if (bmi < 18.5)
                return "Underweight";
            else if (bmi >= 18.5 && bmi < 24.9)
                return "Normal";
            else if (bmi >= 25 && bmi < 29.9)
                return "Overweight";
            else
                return "Obese";
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(4, 32, 53);
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            LoadProgressData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
