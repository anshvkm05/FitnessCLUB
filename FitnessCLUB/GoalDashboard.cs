using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessCLUB.Resources
{
    public partial class GoalDashboard: UserControl
    {
        public GoalDashboard()
        {
            InitializeComponent();
        }

        private void GoalDashboard_Load(object sender, EventArgs e)
        {

        }
        public GoalDashboard(string goalName, string goalDate, string goalTime) : this()
        {
            lblGoalName.Text = goalName;
            lblGoalDate.Text = goalDate;
            lblGoalTime.Text = goalTime;
        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {
            if (checkBoxComplete.Checked)
            {
                this.BackColor = Color.Gray; // Mark as completed
            }
            else
            {
                this.BackColor = Color.White; // Revert to normal
            }
        }
    }
}

