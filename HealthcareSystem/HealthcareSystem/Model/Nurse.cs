namespace HealthcareSystem.Model;

public class Nurse
{
    /// <summary>
    ///     Gets or sets the nurse identifier.
    /// </summary>
    /// <value>
    ///     The nurse identifier.
    /// </value>
    public int NurseId { get; set; }

    /// <summary>
    ///     Gets or sets the person identifier.
    /// </summary>
    /// <value>
    ///     The person identifier.
    /// </value>
    public int PersonId { get; set; }

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
    ///     Gets or sets the gender.
    /// </summary>
    /// <value>
    ///     The gender.
    /// </value>
    public string Gender { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the date of birth.
    /// </summary>
    /// <value>
    ///     The date of birth.
    /// </value>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    ///     Gets or sets the street address.
    /// </summary>
    /// <value>
    ///     The street address.
    /// </value>
    public string? StreetAddress { get; set; }

    /// <summary>
    ///     Gets or sets the city.
    /// </summary>
    /// <value>
    ///     The city.
    /// </value>
    public string? City { get; set; }

    /// <summary>
    ///     Gets or sets the state.
    /// </summary>
    /// <value>
    ///     The state.
    /// </value>
    public string? State { get; set; }

    /// <summary>
    ///     Gets or sets the zip code.
    /// </summary>
    /// <value>
    ///     The zip code.
    /// </value>
    public string? ZipCode { get; set; }

    /// <summary>
    ///     Gets or sets the phone number.
    /// </summary>
    /// <value>
    ///     The phone number.
    /// </value>
    public string? PhoneNumber { get; set; }

    /// <summary>
    ///     Gets the full name.
    /// </summary>
    /// <value>
    ///     The full name.
    /// </value>
    public string FullName => $"{FirstName} {LastName}";
}