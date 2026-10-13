namespace HealthcareSystem.Model;

/// <summary>
/// A doctor who can be booked for appointments.
/// </summary>
public class Doctor
{
    /// <summary>
    /// Gets or sets the doctor identifier.
    /// </summary>
    public int DoctorId { get; set; }

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the specialties as a comma-separated string, or null if the doctor has no specialties.
    /// </summary>
    public string? Specialties { get; set; }

    /// <summary>
    /// Gets the full name.
    /// </summary>
    public string FullName => $"{this.FirstName} {this.LastName}";
}