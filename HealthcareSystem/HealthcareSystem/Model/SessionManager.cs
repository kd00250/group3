namespace HealthcareSystem.Model;

public class SessionManager
{
    public static UserAccount? CurrentUser { get; private set; }

    public static bool IsLoggedIn => CurrentUser != null;

    public static bool isAdmin => CurrentUser?.AccountRole == AccountRole.Admin;

    public static bool isNurse => CurrentUser?.AccountRole == AccountRole.Nurse;

    public static void Login(UserAccount user)
    {
        ///TODO CHECK FOR NULL????

        CurrentUser = user;
    }

    public static void Logout()
    {
        CurrentUser = null;
    }
}