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

namespace FitnessCLUB.Resources
{
    public partial class Home1: UserControl
    {
        // Connection string for the Access database
        string connString = $@"Provider=Microsoft.JET.OLEDB.4.0;Data Source={Application.LocalUserAppDataPath}\FItnessClub.mdb;";
        OleDbConnection conn;

        private Dashboard mainForm;
        private string goalNameHome;
        private string goalExercise;
        private string selectedActivity;

        // Constructor: Initializes the Home1 user control
        public Home1(Dashboard form)
        {
            InitializeComponent();
            mainForm = form;
            conn = new OleDbConnection(connString);
            GoalDashboard goalDashboard = new GoalDashboard(); // Unused instance, possibly for initialization
            LoadGoalsFromDatabase();
            LoadActivityFromDatabase();
        }

        // Loads and displays user goals from the UserGoal table
        public void LoadGoalsFromDatabase()
        {
            try
            {
                conn.Open();
                // Query to retrieve goal details for the current user
                string query = "SELECT GName, GCalories, GDate, GTime FROM UserGoal WHERE UserID = @UserID";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString());
                OleDbDataReader reader = cmd.ExecuteReader();
                flowLayoutPanelGoal.Controls.Clear(); // Clear existing goals

                while (reader.Read())
                {
                    string goalName = reader["GName"].ToString();
                    string goalCalories = reader["GCalories"].ToString();
                    DateTime goalDate = Convert.ToDateTime(reader["GDate"]);
                    string formattedDate = goalDate.ToString("dd-MM-yyyy");
                    DateTime goalTime = Convert.ToDateTime(reader["GTime"]);
                    string formattedTime = goalTime.ToString("HH:mm");
                    // Create and add GoalDashboard control to display goal
                    GoalDashboard goalControl = new GoalDashboard(goalName, formattedDate, formattedTime, goalCalories + " kcal");
                    flowLayoutPanelGoal.Controls.Add(goalControl);
                }

                reader.Close();
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

        // Updates the user's login streak based on consecutive days
        private void CheckAndUpdateStreak()
        {
            try
            {
                conn.Open();
                // Query to get current streak and last login date
                string query = "SELECT Streak, PreviousDayDate FROM UserData WHERE UserID = @UserID";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString());
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int currentStreak = Convert.ToInt32(reader["Streak"]);
                    DateTime previousDate = Convert.ToDateTime(reader["PreviousDayDate"]);
                    DateTime today = DateTime.Today;
                    int daysDifference = (today - previousDate).Days;

                    if (daysDifference == 1)
                    {
                        // Continue the streak
                        currentStreak++;
                    }
                    else if (daysDifference > 1)
                    {
                        // Missed a day, reset streak
                        currentStreak = 1;
                    }
                    // If daysDifference == 0, no change

                    reader.Close();
                    // Update streak and date in database
                    string updateQuery = "UPDATE UserData SET Streak = @Streak, PreviousDayDate = @PreviousDayDate WHERE UserID = @UserID";
                    OleDbCommand updateCmd = new OleDbCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@Streak", currentStreak);
                    updateCmd.Parameters.AddWithValue("@PreviousDayDate", today);
                    updateCmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString());
                    updateCmd.ExecuteNonQuery();
                    lblStreak.Text = currentStreak.ToString();
                }
                else
                {
                    MessageBox.Show("User data not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking streak: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Loads and displays calorie progress data
        public void LoadProgressData()
        {
            try
            {
                conn.Open();
                // Query to retrieve calorie progress data
                string query = "SELECT TodayCAL, TodayCALDone, TotalCAL, TotalCALDone FROM UserData WHERE UserID = @UserID";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString());
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    double todayCal = Convert.ToDouble(reader["TodayCAL"]);
                    double todayCalDone = Convert.ToDouble(reader["TodayCALDone"]);
                    double totalCal = Convert.ToDouble(reader["TotalCAL"]);
                    double totalCalDone = Convert.ToDouble(reader["TotalCALDone"]);
                    // Calculate progress percentages, avoiding division by zero
                    double todayProgress = (todayCal > 0) ? (todayCalDone / todayCal) * 100 : 0;
                    double totalProgress = (totalCal > 0) ? (totalCalDone / totalCal) * 100 : 0;
                    todayProgress = Math.Min(todayProgress, 100);
                    totalProgress = Math.Min(totalProgress, 100);
                    lblTodayProgress.Text = todayProgress.ToString("0") + "%";
                    sataCircularProgress1.Percentage = (int)totalProgress;
                    todayProgressBar.ProgressValue = (int)todayProgress;
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

        // Updates today's calories burned in the database
        public void UpdateTodayCalories(double caloriesToAdd)
        {
            try
            {
                conn.Open();
                // Query to get current calorie data
                string selectQuery = "SELECT TodayCALDone, PreviousDayDateCAL, TodayCAL FROM UserData WHERE UserID = @UserID";
                OleDbCommand selectCmd = new OleDbCommand(selectQuery, conn);
                selectCmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString());
                OleDbDataReader reader = selectCmd.ExecuteReader();
                if (reader.Read())
                {
                    double currentCalories = Convert.ToDouble(reader["TodayCALDone"]);
                    DateTime previousDate = Convert.ToDateTime(reader["PreviousDayDateCAL"]);
                    DateTime today = DateTime.Today;
                    double updatedCalories = 0;

                    if (previousDate.Date == today)
                    {
                        // Same day, add new calories
                        updatedCalories = currentCalories + caloriesToAdd;
                    }
                    else
                    {
                        // New day, reset to new calories
                        updatedCalories = caloriesToAdd;
                    }

                    reader.Close();
                    // Update calories and date
                    string updateQuery = "UPDATE UserData SET TodayCALDone = @Calories, PreviousDayDateCAL = @Today WHERE UserID = @UserID";
                    OleDbCommand updateCmd = new OleDbCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@Calories", updatedCalories);
                    updateCmd.Parameters.AddWithValue("@Today", today);
                    updateCmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString());
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("User data not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating today's calories: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Loads and displays user activities from UserActivity table
        public void LoadActivityFromDatabase()
        {
            try
            {
                conn.Open();
                // Query to retrieve activity details
                string query = "SELECT AExercise, ACalories, ADate, ATime FROM UserActivity WHERE UserID = @UserID";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString());
                OleDbDataReader reader = cmd.ExecuteReader();
                flowLayoutPanelActivity.Controls.Clear();

                while (reader.Read())
                {
                    string activityName = reader["AExercise"].ToString();
                    string activityCalories = reader["ACalories"].ToString();
                    DateTime activityDate = Convert.ToDateTime(reader["ADate"]);
                    string formattedDate = activityDate.ToString("dd-MM-yyyy");
                    DateTime activityTime = Convert.ToDateTime(reader["ATime"]);
                    string formattedTime = activityTime.ToString("HH:mm");
                    // Create and add ActivityDashboard control
                    ActivityDashboard activityControl = new ActivityDashboard(activityName, formattedDate, formattedTime, activityCalories + " kcal");
                    flowLayoutPanelActivity.Controls.Add(activityControl);
                }

                reader.Close();
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

        // Updates UI label with calories burned
        public void RecoredProgress(String caloriesBurned)
        {
            label4.Text = caloriesBurned;
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Navigates to progress control
        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.ProgressControl.BringToFront();
        }

        private void guna2CustomRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
        }

        // Initializes UI data on form load
        private void Home_Load(object sender, EventArgs e)
        {
            LoadGoalsFromDatabase();
            LoadActivityFromDatabase();
            CheckAndUpdateStreak();
            LoadProgressData();
        }

        // Exits the application
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

        private void Addgoalbtn_Click(object sender, EventArgs e)
        {
        }

        // Navigates to activity control with selected activity
        private void button2_Click(object sender, EventArgs e)
        {
            if (rdoRunning.Checked)
            {
                selectedActivity = "Running";
            }
            else if (rdoSwimming.Checked)
            {
                selectedActivity = "Swimming";
            }
            else if (rdoWalking.Checked)
            {
                selectedActivity = "Walking";
            }
            else if (rdoSkipping.Checked)
            {
                selectedActivity = "Jump rope";
            }
            else if (rdoCycling.Checked)
            {
                selectedActivity = "Cycling";
            }
            else if (rdoZumba.Checked)
            {
                selectedActivity = "Zumba";
            }

            if (!string.IsNullOrEmpty(selectedActivity))
            {
                mainForm.activityControl.SetSelectedActivity(selectedActivity);
                mainForm.activityControl.BringToFront();
                rdoRunning.Checked = false;
                rdoSwimming.Checked = false;
                rdoWalking.Checked = false;
                rdoSkipping.Checked = false;
                rdoCycling.Checked = false;
                rdoZumba.Checked = false;
            }
            else
            {
                MessageBox.Show("Please select an activity.");
            }
        }

        private void rdoRunning_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rdoSwimming_CheckedChanged(object sender, EventArgs e)
        {
        }

        // Navigates to goal control with selected goal details
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtGoalName.Text != "")
            {
                goalNameHome = txtGoalName.Text;
                goalExercise = selectExcercise.SelectedItem.ToString();
                mainForm.goalControl.SetSelectedGoal(goalNameHome, goalExercise);
                mainForm.goalControl.BringToFront();
                txtGoalName.Clear();
                selectExcercise.Text = "Select Exercise";
            }
            else
            {
                MessageBox.Show("Please enter a goal name and select an exercise.");
            }
        }

        // Refreshes all data on double-click
        private void Home1_DoubleClick(object sender, EventArgs e)
        {
            LoadGoalsFromDatabase();
            LoadActivityFromDatabase();
            CheckAndUpdateStreak();
            LoadProgressData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        // Shows label on mouse hover
        private void guna2CirclePictureBox1_MouseEnter(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        // Hides label when mouse leaves
        private void guna2CirclePictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }
    }
}