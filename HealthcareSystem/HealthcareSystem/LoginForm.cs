using HealthcareSystem.Controller;
using MySql.Data.MySqlClient;

namespace HealthcareSystem
{
    public partial class LoginForm : Form
    {
        private readonly LoginController loginController;

        public LoginForm(LoginController loginController)
        {
            this.InitializeComponent();

            this.loginController = loginController;
            this.passwordTextBox.UseSystemPasswordChar = true;
            AcceptButton = this.loginButton;
            this.errorLabel.Visible = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var username = this.usernameTextBox.Text.Trim();
            var password = this.passwordTextBox.Text;
            this.errorLabel.Visible = false;

            try
            {
                bool success = this.loginController.Login(username, password);

                if (success)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    this.showError("invalid username or password");
                    this.passwordTextBox.Clear();
                }
            } 
            catch (MySqlException)
            {
                this.showError("Unable to connect to the database.");
            }
        }

        private void showError(string message)
        {
            this.errorLabel.Text = message;
            this.errorLabel.Visible = true;
        }
    }
}
