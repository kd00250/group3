using HealthcareSystem.Controller;
using HealthcareSystem.Model.DAL;
using HealthcareSystem.View;

namespace HealthcareSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            var userAccountDal = new UserAccountDal();

            var loginController = new LoginController(userAccountDal);

            while (true)
            {
                using var loginForm = new View.LoginForm(loginController);

                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    break;
                }

                using var mainForm = new MainForm(loginController);
                mainForm.ShowDialog();
                loginController.Logout();

                if (!mainForm.IsLoggingOut)
                {
                    break;
                }
            }
        }
    }
}