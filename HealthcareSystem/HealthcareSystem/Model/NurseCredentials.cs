namespace HealthcareSystem.Model;

/// <summary>
///     The nurse credentials class that contains the nurse username and password.
/// </summary>
public class NurseCredentials
{
    /// <summary>
    ///     Gets or sets the username.
    /// </summary>
    /// <value>
    ///     The username.
    /// </value>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the password.
    /// </summary>
    /// <value>
    ///     The password.
    /// </value>
    public string Password { get; set; } = string.Empty;
}