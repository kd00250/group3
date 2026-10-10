using HealthcareSystem.Controller;
using HealthcareSystem.Model;

namespace HealthcareSystem
{
    /// <summary>
    ///     The main form of the healthcare application.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        private readonly LoginController loginController;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        /// <param name="loginController">The login controller.</param>
        /// <exception cref="InvalidOperationException">User is not logged in.</exception>
        public MainForm(LoginController loginController)
        {
            this.InitializeComponent();

            this.loginController = loginController;

            if (!SessionManager.IsLoggedIn)
            {
                throw new InvalidOperationException("User is not logged in.");
            }

            this.initializeUserInterface();
        }

        private void initializeUserInterface()
        {
            this.manageUsersButton.Visible = SessionManager.IsAdmin;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.loginController.Logout();
            Close();
        }
    }
}
