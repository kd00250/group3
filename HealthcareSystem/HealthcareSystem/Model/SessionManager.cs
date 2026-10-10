namespace HealthcareSystem.Model;

public class SessionManager
{
    /// <summary>
    ///     Gets the current user.
    /// </summary>
    /// <value>
    ///     The current user.
    /// </value>
    public static UserAccount? CurrentUser { get; private set; }

    /// <summary>
    ///     Gets a value indicating whether this instance is logged in.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is logged in; otherwise, <c>false</c>.
    /// </value>
    public static bool IsLoggedIn => CurrentUser != null;

    /// <summary>
    ///     Gets a value indicating whether this instance is admin.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is admin; otherwise, <c>false</c>.
    /// </value>
    public static bool IsAdmin => CurrentUser?.AccountRole == AccountRole.Administrator;

    /// <summary>
    ///     Gets a value indicating whether this instance is nurse.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is nurse; otherwise, <c>false</c>.
    /// </value>
    public static bool IsNurse => CurrentUser?.AccountRole == AccountRole.Nurse;

    /// <summary>
    ///     Logins the specified user.
    /// </summary>
    /// <param name="user">The user.</param>
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