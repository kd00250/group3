using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.View
{
    /// <summary>
    ///     The main form of the healthcare application.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        private readonly LoginController loginController;

        /// <summary>
        ///     Gets a value indicating whether this instance is logging out.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is logging out; otherwise, <c>false</c>.
        /// </value>
        public bool IsLoggingOut { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        /// <param name="loginController">The login controller.</param>
        /// <exception cref="InvalidOperationException">User is not logged in.</exception>
        public MainForm(LoginController loginController)
        {
            this.InitializeComponent();

            this.loginController = loginController;
            this.loggedInUserControl1.RefreshUser();

            if (!SessionManager.IsLoggedIn)
            {
                throw new InvalidOperationException("User is not logged in.");
            }

            this.initializeUserInterface();
        }

        private void initializeUserInterface()
        {
            this.manageUsersButton.Visible = SessionManager.IsAdmin;

            this.findPatientButton.Visible = SessionManager.IsNurse;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.IsLoggingOut = true;
            this.loginController.Logout();
            Close();
        }

        private void findPatientButton_Click(object sender, EventArgs e)
        {
            using var searchForm = new PatientSearchForm(new PatientController(new PatientDal()));
            searchForm.ShowDialog();
        }
    }
}
