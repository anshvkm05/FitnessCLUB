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
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices.ComTypes;
using FitnessCLUB.Resources;

namespace FitnessCLUB
{
    public partial class Goal: UserControl
    {
        string connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=D:\Project DDOOCP try 2\FitnessCLUB\FitnessCLUB\FItnessClub.mdb;";
        OleDbConnection conn;
        private int weight;

        private Dashboard mainForm;
        public Goal(Dashboard form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox2_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(4, 32, 53);
        }

        public void SetSelectedGoal(string goalName1, string goalExercise1)
        {
            txtGoalName1.Text = goalName1;
            select_Excercise.SelectedItem = goalExercise1;
        }

        private void select_Excercise_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (select_Excercise.SelectedItem.ToString())
            {
                case "Running":
                    lblMetric1.Text = "Type";
                    lblMetric2.Text = "Distance (in km)";
                    lblMetric3.Text = "Time (in min)";
                    break;
                case "Swimming":
                    lblMetric1.Text = "Laps";
                    lblMetric2.Text = "Time (in min)";
                    lblMetric3.Text = "avg Heart Rate (BPM)";
                    break;
                case "Cycling":
                    lblMetric1.Text = "Type";
                    lblMetric2.Text = "Distance (in km)";
                    lblMetric3.Text = "Time (in min)";
                    break;
                case "Walking":
                    lblMetric1.Text = "Steps";
                    lblMetric2.Text = "Distance (in km)";
                    lblMetric3.Text = "Time Taken (in min)";
                    break;
                case "Skipping":
                    lblMetric1.Text = "Type";
                    lblMetric2.Text = "No. of Jumps";
                    lblMetric3.Text = "Time (in min)";
                    break;
                case "Zumba":
                    lblMetric1.Text = "Type";
                    lblMetric2.Text = "Distance (in km)";
                    lblMetric3.Text = "Time (in min)";
                    break;
                default:
                    lblMetric1.Text = "Metric 1";
                    lblMetric2.Text = "Metric 2";
                    lblMetric3.Text = "Metric 3";
                    break;
            }
        }

        private void Addgoalbtn_Click(object sender, EventArgs e)
        {
            string SActivity = select_Excercise.SelectedItem.ToString();

            if (string.IsNullOrEmpty(txtGoalName1.Text) || string.IsNullOrEmpty(select_Excercise.Text) || string.IsNullOrEmpty(txtTime.Text) ||
                string.IsNullOrEmpty(txtMetric1.Text) || string.IsNullOrEmpty(txtMetric2.Text) || string.IsNullOrEmpty(txtMetric3.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            else if (SActivity == "walking")
            {
                if ((Int32.Parse(txtMetric2.Text) * 60 / Int32.Parse(txtMetric2.Text)) < 3.2)
                {
                    txtMetric1.Text = "light";
                }
                else if ((Int32.Parse(txtMetric2.Text) * 60 / Int32.Parse(txtMetric2.Text)) >= 3.2 && ((Int32.Parse(txtMetric2.Text) * 60 / Int32.Parse(txtMetric2.Text)) < 4.8))
                {
                    txtMetric1.Text = "moderate";
                }
                else if ((Int32.Parse(txtMetric2.Text) * 60 / Int32.Parse(txtMetric2.Text)) >= 4.8)
                {
                    txtMetric1.Text = "intense";
                }
            }
            else if (SActivity == "swimmng")
            {
                if (Int32.Parse(txtMetric3.Text) < 110)
                {
                    txtMetric1.Text = "light";
                }
                else if (Int32.Parse(txtMetric3.Text) >= 110 && (Int32.Parse(txtMetric3.Text) < 150))
                {
                    txtMetric1.Text = "moderate";
                }
                else if (Int32.Parse(txtMetric3.Text) > 150)
                {
                    txtMetric1.Text = "intense";
                }
            }

            // Replace with actual user weight
            double UserCalB = Activity.GetCaloriesBurned(weight, Activity.GetMETValue(SActivity.ToString(), txtMetric1.Text), Int32.Parse(txtMetric3.Text));

            try
            {
                using (conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string query = "INSERT INTO UserGoal (UserID, GName, GExercise, GDate, GTime, GMetric1, GMetric2, GMetric3) " +
                                   "VALUES (@UserID, @gName, @gExercise, @gDate, @gTime, @gMetric1, @gMetric2, @gMetric3)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString()); // Replace with actual UserID
                        cmd.Parameters.AddWithValue("@gName", txtGoalName1.Text);
                        cmd.Parameters.AddWithValue("@gExercise", select_Excercise.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@gDate", dateTimePicker.Value.Date);
                        cmd.Parameters.AddWithValue("@gTime", txtTime.Text);
                        cmd.Parameters.AddWithValue("@gMetric1", txtMetric1.Text);
                        cmd.Parameters.AddWithValue("@gMetric2", txtMetric2.Text.ToString());
                        cmd.Parameters.AddWithValue("@gMetric3", txtMetric3.Text.ToString());


                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Goal added successfully. The Calories Burned is " + UserCalB.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Failed to add goal.");
                        }
                    }
                    string query2 = "UPDATE UserData SET TotalCALDone = TotalCALDone + @calories WHERE UserID = @UserID";
                    using (OleDbCommand cmd = new OleDbCommand(query2, conn))
                    {
                        cmd.Parameters.AddWithValue("@calories", UserCalB);
                        cmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString()); // Replace with actual UserID
                        cmd.ExecuteNonQuery();
                    }
                }
                Home1 home = new Home1(mainForm);
                home.LoadGoalsFromDatabase();
                home.LoadActivityFromDatabase();
                home.UpdateTodayCalories(UserCalB);
                home.LoadProgressData();
                mainForm.homeControl.BringToFront();
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void txtMetric1_MouseEnter(object sender, EventArgs e)
        {
            if (select_Excercise.SelectedItem.ToString() == "Running" || select_Excercise.SelectedItem.ToString() == "Cycling" || select_Excercise.SelectedItem.ToString() == "Skipping" || select_Excercise.SelectedItem.ToString() == "Zumba")
            {
                panel1.Visible = true;
            }
        }

        private void txtMetric1_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void Goal_Load(object sender, EventArgs e)
        {
            try
            {
                using (conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT Weight FROM UserData WHERE UserID = @UserID";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString()); // Assuming you have CurrentUserID set in Dashboard
                    OleDbDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    string Tstweight = reader["Weight"].ToString();
                    weight = Int32.Parse(Tstweight);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading goals: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
    
}
