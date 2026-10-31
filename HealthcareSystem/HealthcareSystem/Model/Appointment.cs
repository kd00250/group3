namespace HealthcareSystem.Model;

/// <summary>
/// An appointment class that represents a scheduled appointment in the healthcare system between
/// a patient and a doctor at a specific date and time.
/// </summary>
public class Appointment
{
    /// <summary>
    /// Gets or sets the appointment identifier.
    /// </summary>
    public int AppointmentId { get; set; }

    /// <summary>
    /// Gets or sets the patient identifier.
    /// </summary>
    public int PatientId { get; set; }

    /// <summary>
    /// Gets or sets the doctor identifier.
    /// </summary>
    public int DoctorId { get; set; }

    /// <summary>
    ///     Gets or sets the name of the doctor.
    /// </summary>
    /// <value>
    ///     The name of the doctor.
    /// </value>
    public string DoctorName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the appointment date, only the date part is used.
    /// </summary>
    public DateTime AppointmentDate { get; set; }

    /// <summary>
    /// Gets or sets the appointment time of day.
    /// </summary>
    public TimeSpan AppointmentTime { get; set; }

    /// <summary>
    /// Gets or sets the reason for the appointment.
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// Gets the appointment date and time combined.
    /// </summary>
    public DateTime AppointmentDateTime => this.AppointmentDate.Date + this.AppointmentTime;

}