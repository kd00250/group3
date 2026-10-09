namespace HealthcareSystem.Model;

/// <summary>
///     The UserAccount class.
/// </summary>
public class UserAccount
{
    /// <summary>
    /// Gets the account identifier.
    /// </summary>
    /// <value>
    /// The account identifier.
    /// </value>
    public int AccountId { get; init; }

    /// <summary>
    ///     Gets the username.
    /// </summary>
    /// <value>
    ///     The username.
    /// </value>
    public string Username { get; init; } = string.Empty;

    /// <summary>
    ///     Gets the account role.
    /// </summary>
    /// <value>
    ///     The account role.
    /// </value>
    public AccountRole AccountRole { get; init; }
    
    /// <summary>
    ///     Gets the person identifier.
    /// </summary>
    /// <value>
    ///     The person identifier.
    /// </value>
    public int PersonId { get; init; }
}