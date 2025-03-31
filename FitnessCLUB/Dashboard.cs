using FitnessCLUB.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;

namespace FitnessCLUB
{
    public partial class Dashboard: Form
    {
        private Home1 homeControl;
        private Goal goalControl;
        private Activity activityControl;
        private Setting settingControl;
        private Contactus contactusControl;
        private Progress ProgressControl;
        public Dashboard()
        {
            InitializeComponent();
            homeControl = new Home1();
            goalControl = new Goal();
            activityControl = new Activity();
            settingControl = new Setting();
            contactusControl = new Contactus();
            ProgressControl = new Progress();

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

        private void LoadUserControl(UserControl userControl)
        {
            if (userControl == null)
            {
                MessageBox.Show("Error: The selected UserControl is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            panelContainer.Controls.Clear(); // Remove existing control
            userControl.Dock = DockStyle.Fill; // Make it fill the panel
            panelContainer.Controls.Add(userControl); // Add the new control
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
    }
}
