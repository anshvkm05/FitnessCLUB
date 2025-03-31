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
    public partial class ForgotPassword: UserControl
    {
        private Login_user mainForm;
        public ForgotPassword(Login_user form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.LoadUserControl(new LoginUser(mainForm)); // Switch to Login UserControl
        }
    }
}
