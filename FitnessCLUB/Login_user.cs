using System;
using System.Windows.Forms;

namespace FitnessCLUB
{
    public partial class Login_user : Form
    {
        RegisterUser registerControl;
        LoginUser loginControl;
        ForgotPassword forgotPasswordControl;
        QuestionsUser questionUserControl;


        public Login_user()
        {
            InitializeComponent();

            // Add the user controls to the panel
            registerControl = new RegisterUser(this);
            loginControl = new LoginUser(this);
            forgotPasswordControl = new ForgotPassword(this);
            questionUserControl = new QuestionsUser(this);

            //Load the default login control
            LoadUserControl(loginControl);
        }

        public void LoadUserControl(UserControl userControl)
        {
            panel1.Controls.Clear(); // Remove existing control
            userControl.Dock = DockStyle.Fill; // Make it fill the panel
            panel1.Controls.Add(userControl); // Add the new control
        }

        private void Login_user_Load(object sender, EventArgs e)
        {

        }

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            Register_user Register = new Register_user();
            Register.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
