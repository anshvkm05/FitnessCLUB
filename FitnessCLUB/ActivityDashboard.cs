using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessCLUB
{
    public partial class ActivityDashboard: UserControl
    {
        public ActivityDashboard()
        {
            InitializeComponent();
        }

        private void ActivityDashboard_Load(object sender, EventArgs e)
        {

        }
        public ActivityDashboard(string activityName, string activityDate, string activityTime, string activityCalories) : this()
        {
            lblGoalName.Text = activityName;
            lblGoalDate.Text = activityDate;
            lblGoalTime.Text = activityTime;
            lblCalories.Text = activityCalories;
        }
    }
}
