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
using System.Diagnostics.Eventing.Reader;
using FitnessCLUB.Resources;

namespace FitnessCLUB
{
    public partial class Activity: UserControl
    {
        // Delegate for customizable message box display, defaults to MessageBox.Show
        public Func<string, string, MessageBoxButtons, MessageBoxIcon, DialogResult> ShowMessageCallback { get; set; } = MessageBox.Show;
        // Connection string for the Access database
        string connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=D:\Project DDOOCP try 2\FitnessCLUB\FitnessCLUB\FItnessClub.mdb;";
        OleDbConnection conn;
        private string SActivity;
        private string EN;
        private Dashboard mainForm;
        public int weight;
        public double UserCALB;
        public Activity(Dashboard form)
        {
            InitializeComponent();
            mainForm = form;
            
        }
        // Sets the selected activity and checks corresponding radio button
        public void SetSelectedActivity(string activity)
        {
            EN = activity;
            switch (activity)
            {
                case "Running":
                    rdoRunning.Checked = true;
                    break;
                case "Swimming":
                    rdoSwimming.Checked = true;
                    break;
                case "Walking":
                    rdoWalking.Checked = true;
                    break;
                case "Jump rope":
                    rdoSkipping.Checked = true;
                    break;
                case "Cycling":
                    rdoCycling.Checked = true;
                    break;
                case "Zumba":
                    rdoZumba.Checked = true;
                    break;
                default:
                    break;
            }
        }
        // Returns MET value based on exercise type and intensity
        public static double GetMETValue(string exerciseN, string exerciseT)
        {
            switch (exerciseN.ToLower())
            {
                case "running":
                    switch (exerciseT.ToLower())
                    {
                        case "light":
                            return 6.0;
                        case "moderate":
                            return 8.3;
                        case "intense":
                            return 9.8;
                        default:
                            return 3.9;
                    }
                case "swimming":
                    switch (exerciseT.ToLower())
                    {
                        case "light":
                            return 5.8;
                        case "moderate":
                            return 9.8;
                        case "intense":
                            return 13.8;
                        default:
                            return 9.8;
                    }
                case "walking":
                    switch (exerciseT.ToLower())
                    {
                        case "light":
                            return 2.9;
                        case "moderate":
                            return 3.9;
                        case "intense":
                            return 4.3;
                        default:
                            return 3.9;
                    }
                case "skipping":
                    switch (exerciseT.ToLower())
                    {
                        case "light":
                            return 8.8;
                        case "moderate":
                            return 12.3;
                        case "intense":
                            return 14.8;
                        default:
                            return 12.3;
                    }
                case "cycling":
                    switch (exerciseT.ToLower())
                    {
                        case "light":
                            return 4.0;
                        case "moderate":
                            return 8.0;
                        case "intense":
                            return 12.0;
                        default:
                            return 7.8;
                    }
                case "zumba":
                    switch (exerciseT.ToLower())
                    {
                        case "light":
                            return 5.5;
                        case "moderate":
                            return 6.8;
                        case "intense":
                            return 8.8;
                        default:
                            return 6.8;
                    }
                default:
                    return 5.0;
            }
        }
        // Calculates calories burned based on weight, MET value, and duration
        public static double GetCaloriesBurned(int weightU, double MET, double durationEx)
        {
            double CalBurned = ((MET*weightU*3.5)/ 200) * durationEx;
            return CalBurned;
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
        // Inserts activity data into the database and updates UI
        public void insertintodatabse()
        {
            // Inserts activity data into the database and updates UI
            if (rdoRunning.Checked) 
            {
                SActivity = "running";
            }
            else if (rdoSwimming.Checked)
            {
                SActivity = "swimming";
            }
            else if (rdoWalking.Checked)
            {
                SActivity = "walking";
            }
            else if (rdoSkipping.Checked)
            {
                SActivity = "skipping";
            }
            else if (rdoCycling.Checked)
            {
                SActivity = "cycling";
            }
            else if (rdoZumba.Checked)
            {
                SActivity = "zumba";
            }
            else
            {
                MessageBox.Show("Please select an activity.");
                return;
            }
            if (SActivity == "walking")
            {
                if ((Int32.Parse(txtMetric2.Text) * 60 / Int32.Parse(txtMetric3.Text)) < 3.2)
                {
                    txtMetric1.Text = "light";
                }
                else if ((Int32.Parse(txtMetric2.Text) * 60 / Int32.Parse(txtMetric3.Text)) >= 3.2 && ((Int32.Parse(txtMetric2.Text) * 60 / Int32.Parse(txtMetric3.Text)) < 4.8))
                {
                    txtMetric1.Text = "moderate";
                }
                else if ((Int32.Parse(txtMetric2.Text) * 60 / Int32.Parse(txtMetric3.Text)) >= 4.8)
                {
                    txtMetric1.Text = "intense";
                }
            }
            else if (SActivity == "swimming")
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
                else
                {
                    txtMetric1.Text = "moderate";
                }
            }
            UserCALB = GetCaloriesBurned(weight, GetMETValue(SActivity.ToString(), txtMetric1.Text), Int32.Parse(txtMetric3.Text));
            try
            {
                using (conn = new OleDbConnection(connString))
                {
                    conn.Open(); // Insert activity into UserActivity table
                    string query = "INSERT INTO UserActivity (UserID, AExercise, ADate, ATime, AMetric1, AMetric2, AMetric3, ACalories) " +
                                   "VALUES (@UserID, @aExercise, @aDate, @aTime, @aMetric1, @aMetric2, @aMetric3, @aCalories)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString()); // Replace with actual UserID
                        cmd.Parameters.AddWithValue("@aExercise", SActivity);
                        cmd.Parameters.AddWithValue("@aDate", dateTimePicker.Value.Date);
                        cmd.Parameters.AddWithValue("@aTime", txtTime.Text);
                        cmd.Parameters.AddWithValue("@aMetric1", txtMetric1.Text);
                        cmd.Parameters.AddWithValue("@aMetric2", txtMetric2.Text);
                        cmd.Parameters.AddWithValue("@aMetric3", txtMetric3.Text);
                        cmd.Parameters.AddWithValue("@aCalories", UserCALB);


                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Goal added successfully. The calorie burned is " + UserCALB.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Failed to add goal.");
                            return;
                        }
                    }
                    // Update total calories in UserData
                    string query2 = "UPDATE UserData SET TotalCALDone = TotalCALDone + @calories WHERE UserID = @UserID";
                    using (OleDbCommand cmd = new OleDbCommand(query2, conn))
                    {
                        cmd.Parameters.AddWithValue("@calories", UserCALB);
                        cmd.Parameters.AddWithValue("@UserID", (LoginUser.SessionManager.CurrentUserID).ToString()); // Replace with actual UserID
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            // Clear input fields and radio buttons
            txtTime.Text = "";
            txtMetric1.Text = "";
            txtMetric2.Text = "";
            txtMetric3.Text = "";
            rdoRunning.Checked = false;
            rdoSwimming.Checked = false;
            rdoWalking.Checked = false;
            rdoSkipping.Checked = false;
            rdoCycling.Checked = false;
            rdoZumba.Checked = false;
            // Refresh homepage data and navigate back
            Home1 home = new Home1(mainForm);
            home.LoadGoalsFromDatabase();
            home.LoadActivityFromDatabase();
            home.UpdateTodayCalories(UserCALB);
            home.LoadProgressData();
            mainForm.homeControl.BringToFront();


        }
        private void Addgoalbtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtTime.Text) || string.IsNullOrEmpty(txtMetric1.Text) || string.IsNullOrEmpty(txtMetric2.Text) || string.IsNullOrEmpty(txtMetric3.Text))
            {
                ShowMessageCallback("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validate the time format (expected format: HH:mm)
            string timePattern = @"^([01]\d|2[0-3]):[0-5]\d$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTime.Text, timePattern))
            {
            ShowMessageCallback("Please enter the time in the correct format (HH:mm).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            }
            insertintodatabse();
            
        }

        private void rdoRunning_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtMetric1_TextChanged(object sender, EventArgs e)
        {

        }
        // Updates metric labels based on selected activity
        private void txtTime_Click(object sender, EventArgs e)
        {
            if (rdoRunning.Checked)
            {
                lblMetric1.Text = "Type";
                lblMetric2.Text = "Distance (in km)";
                lblMetric3.Text = "Time (in min)";
            }
            else if (rdoSwimming.Checked)
            {
                lblMetric1.Text = "Laps";
                lblMetric2.Text = "Time (in min)";
                lblMetric3.Text = "avg Heart Rate (BPM)";
            }
            else if (rdoWalking.Checked)
            {
                lblMetric1.Text = "Steps";
                lblMetric2.Text = "Distance (in km)";
                lblMetric3.Text = "Time Taken (in min)";
            }
            else if (rdoSkipping.Checked)
            {
                lblMetric1.Text = "Type";
                lblMetric2.Text = "No. of Jumps";
                lblMetric3.Text = "Time (in min)";
            }
            else if (rdoCycling.Checked)
            {
                lblMetric1.Text = "Type";
                lblMetric2.Text = "Distance (in km)";
                lblMetric3.Text = "Time (in min)";
            }
            else if (rdoZumba.Checked)
            {
                lblMetric1.Text = "Type";
                lblMetric2.Text = "Distance (in km)";
                lblMetric3.Text = "Time (in min)";
            }
        }

        private void txtMetric1_MouseEnter(object sender, EventArgs e)
        {
            if (rdoCycling.Checked || rdoRunning.Checked || rdoSkipping.Checked || rdoZumba.Checked )
            {
                panel1.Visible = true;
            } 
        }

        private void txtMetric1_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
        // Loads user weight from database on control load
        private void Activity_Load(object sender, EventArgs e)
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
                    int Tstweight = Convert.ToInt32(reader["Weight"]);
                    weight = Tstweight;
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
