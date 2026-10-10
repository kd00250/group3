using HealthcareSystem.Controller;
using HealthcareSystem.Model.DAL;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            var userAccountDal = new UserAccountDal();

            var loginController = new LoginController(userAccountDal);

            while (true)
            {
                using var loginForm = new LoginForm(loginController);

                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    break;
                }

                using var mainForm = new MainForm(loginController);

                mainForm.ShowDialog();

                loginController.Logout();
            }
            //Application.Run(new Form1());
        }
    }
}