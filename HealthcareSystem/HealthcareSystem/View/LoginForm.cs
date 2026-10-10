using HealthcareSystem.Controller;
using MySql.Data.MySqlClient;

namespace HealthcareSystem.View
{
    public partial class LoginForm : Form
    {
        private readonly LoginController loginController;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        /// <param name="loginController">The login controller.</param>
        public LoginForm(LoginController loginController)
        {
            this.InitializeComponent();

            this.loginController = loginController;
            this.passwordTextBox.UseSystemPasswordChar = true;
            AcceptButton = this.loginButton;
            this.errorLabel.Visible = false;

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var username = this.usernameTextBox.Text.Trim();
            var password = this.passwordTextBox.Text;
            this.errorLabel.Visible = false;

            if (string.IsNullOrWhiteSpace(username))
            {
                this.showError("Username cannot be empty.");
                this.usernameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                this.showError("Password cannot be empty.");
                this.passwordTextBox.Focus();
                return;
            }

            try
            {
                var success = this.loginController.Login(username, password);

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
