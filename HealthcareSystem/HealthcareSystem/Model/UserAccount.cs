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

    /// <summary>
    ///     Gets or sets the first name.
    /// </summary>
    /// <value>
    ///     The first name.
    /// </value>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the last name.
    /// </summary>
    /// <value>
    ///     The last name.
    /// </value>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    ///     Gets the full name.
    /// </summary>
    /// <value>
    ///     The full name.
    /// </value>
    public string FullName => $"{this.FirstName} {this.LastName}";
}