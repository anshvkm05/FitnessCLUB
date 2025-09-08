using FitnessCLUB.Resources;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessCLUB
{
    public partial class Dashboard : Form
    {
        public Home1 homeControl;
        public Activity activityControl;
        Setting settingControl;
        Contactus contactusControl;
        public Progress ProgressControl;
        public Goal goalControl;
        public Dashboard()
        {
            InitializeComponent();

            homeControl = new Home1(this);
            goalControl = new Goal(this);
            activityControl = new Activity(this);
            settingControl = new Setting();
            contactusControl = new Contactus();
            ProgressControl = new Progress(this);



            panelContainer.Controls.Add(activityControl);
            panelContainer.Controls.Add(homeControl);
            panelContainer.Controls.Add(goalControl);
            panelContainer.Controls.Add(settingControl);
            panelContainer.Controls.Add(contactusControl);
            panelContainer.Controls.Add(ProgressControl);

            activityControl.Dock = DockStyle.Fill;
            homeControl.Dock = DockStyle.Fill;
            goalControl.Dock = DockStyle.Fill;
            settingControl.Dock = DockStyle.Fill;
            contactusControl.Dock = DockStyle.Fill;
            ProgressControl.Dock = DockStyle.Fill;

            // Show Home initially
            homeControl.BringToFront();
        }



        private void cuiLabel1_Load(object sender, EventArgs e)
        {

        }

        private void cuiLabel2_Load(object sender, EventArgs e)
        {

        }

        private void cuiLabel1_Click(object sender, EventArgs e)
        {
            homeControl.BringToFront();
        }

        private void cuiLabel2_Click(object sender, EventArgs e)
        {
            goalControl.BringToFront();
        }

        private void cuiLabel3_Click(object sender, EventArgs e)
        {
            ProgressControl.BringToFront();
        }

        private void cuiLabel4_Click(object sender, EventArgs e)
        {
            activityControl.BringToFront();
        }

        private void cuiLabel5_Click(object sender, EventArgs e)
        {
            settingControl.BringToFront();
        }

        private void cuiLabel6_Click(object sender, EventArgs e)
        {
            contactusControl.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cuiLabel1_MouseEnter(object sender, EventArgs e)
        {
            cuiLabel1.BackColor = Color.FromArgb(5, 45, 73);
            cuiLabel1.ForeColor = Color.FromArgb(128, 255, 255);
        }

        private void cuiLabel1_MouseLeave(object sender, EventArgs e)
        {
            cuiLabel1.BackColor = Color.FromArgb(4, 32, 53);
            cuiLabel1.ForeColor = Color.White;
        }

        private void cuiLabel2_MouseHover(object sender, EventArgs e)
        {

        }

        private void cuiLabel2_MouseLeave(object sender, EventArgs e)
        {
            cuiLabel2.BackColor = Color.FromArgb(4, 32, 53);
            cuiLabel2.ForeColor = Color.White;
        }

        private void cuiLabel2_MouseEnter(object sender, EventArgs e)
        {
            cuiLabel2.BackColor = Color.FromArgb(5, 45, 73);
            cuiLabel2.ForeColor = Color.FromArgb(128, 255, 255);
        }

        private void cuiLabel4_MouseEnter(object sender, EventArgs e)
        {
            cuiLabel4.BackColor = Color.FromArgb(5, 45, 73);
            cuiLabel4.ForeColor = Color.FromArgb(128, 255, 255);
        }

        private void cuiLabel4_MouseLeave(object sender, EventArgs e)
        {
            cuiLabel4.BackColor = Color.FromArgb(4, 32, 53);
            cuiLabel4.ForeColor = Color.White;
        }

        private void cuiLabel3_MouseEnter(object sender, EventArgs e)
        {
            cuiLabel3.BackColor = Color.FromArgb(5, 45, 73);
            cuiLabel3.ForeColor = Color.FromArgb(128, 255, 255);
        }

        private void cuiLabel3_MouseLeave(object sender, EventArgs e)
        {
            cuiLabel3.BackColor = Color.FromArgb(4, 32, 53);
            cuiLabel3.ForeColor = Color.White;
        }

        private void cuiLabel5_MouseEnter(object sender, EventArgs e)
        {
            cuiLabel5.BackColor = Color.FromArgb(5, 45, 73);
            cuiLabel5.ForeColor = Color.FromArgb(128, 255, 255);
        }

        private void cuiLabel5_MouseLeave(object sender, EventArgs e)
        {
            cuiLabel5.BackColor = Color.FromArgb(4, 32, 53);
            cuiLabel5.ForeColor = Color.White;
        }

        private void cuiLabel6_MouseEnter(object sender, EventArgs e)
        {
            cuiLabel6.BackColor = Color.FromArgb(5, 45, 73);
            cuiLabel6.ForeColor = Color.FromArgb(128, 255, 255);
        }

        private void cuiLabel6_MouseLeave(object sender, EventArgs e)
        {
            cuiLabel6.BackColor = Color.FromArgb(4, 32, 53);
            cuiLabel6.ForeColor = Color.White;
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
