using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

public class LoginController
{
    private readonly UserAccountDal userAccountDal;

    /// <summary>
    ///     Initializes a new instance of the <see cref="LoginController"/> class.
    /// </summary>
    /// <param name="userAccountDal">The user account dal.</param>
    public LoginController(UserAccountDal userAccountDal)
    {
        this.userAccountDal = userAccountDal;
    }

    /// <summary>
    ///     Logins the specified username.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <returns></returns>
    public bool Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            return false;
        }

        if (SessionManager.IsLoggedIn)
        {
            return false;
        }

        var user = this.userAccountDal.Authenticate(username.Trim(), password);

        if (user == null)
        {
            return false;
        }

        SessionManager.Login(user);
        return true;
    }

    /// <summary>
    ///     Logouts this instance.
    /// </summary>
    public void Logout()
    {
        SessionManager.Logout();
    }
}