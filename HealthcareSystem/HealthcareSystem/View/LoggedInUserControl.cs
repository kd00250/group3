using HealthcareSystem.Model;

namespace HealthcareSystem.View
{
    /// <summary>
    ///     The logged in user control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class LoggedInUserControl : UserControl
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LoggedInUserControl"/> class.
        /// </summary>
        public LoggedInUserControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     Refreshes the user.
        /// </summary>
        public void RefreshUser()
        {
            var user = SessionManager.CurrentUser;

            if (user == null)
            {
                this.currentUserLabel.Text = "Not logged in";
                return;
            }

            this.currentUserLabel.Text = $"Full Name: {user.FullName}{Environment.NewLine}" +
                                         $"Username: {user.Username}{Environment.NewLine}" +
                                         $"ID: {user.AccountId}";
        }
    }
}
