namespace HealthcareSystem.Model;

/// <summary>
/// The Patient class represents a patient in the healthcare system.
/// </summary>
public class Patient
{
    /// <summary>
    /// Gets or sets the patient identifier.
    /// </summary>
    public int PatientId { get; set; }

    /// <summary>
    /// Gets or sets the person identifier.
    /// </summary>
    public int PersonId { get; set; }

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date of birth.
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the street address.
    /// </summary>
    public string? StreetAddress { get; set; }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets the state.
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Gets or sets the zip code.
    /// </summary>
    public string? ZipCode { get; set; }

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this patient is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets the full name.
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";



}