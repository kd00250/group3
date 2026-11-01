namespace HealthcareSystem.Model;

/// <summary>
/// A visit that took place for an appointment, including the vitals and diagnoses recorded for it.
/// </summary>
public class Visit
{
    /// <summary>
    /// Gets or sets the visit identifier.
    /// </summary>
    public int VisitId { get; set; }

    /// <summary>
    /// Gets or sets the visit date and time.
    /// </summary>
    public DateTime VisitDateTime { get; set; }

    /// <summary>
    /// Gets or sets the appointment identifier.
    /// </summary>
    public int AppointmentId { get; set; }

    /// <summary>
    /// Gets or sets the patient identifier.
    /// </summary>
    public int PatientId { get; set; }

    /// <summary>
    /// Gets or sets the name of the doctor for the appointment.
    /// </summary>
    public string DoctorName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the reason given for the appointment.
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    public decimal? Height { get; set; }

    /// <summary>
    /// Gets or sets the weight.
    /// </summary>
    public decimal? Weight { get; set; }

    /// <summary>
    /// Gets or sets the systolic blood pressure.
    /// </summary>
    public int? Systolic { get; set; }

    /// <summary>
    /// Gets or sets the diastolic blood pressure.
    /// </summary>
    public int? Diastolic { get; set; }

    /// <summary>
    /// Gets or sets the body temperature.
    /// </summary>
    public decimal? BodyTemperature { get; set; }

    /// <summary>
    /// Gets or sets the pulse.
    /// </summary>
    public int? Pulse { get; set; }

    /// <summary>
    /// Gets or sets the symptoms.
    /// </summary>
    public string? Symptoms { get; set; }

    /// <summary>
    /// Gets or sets when the nurse checked the patient.
    /// </summary>
    public DateTime? CheckDateTime { get; set; }

    /// <summary>
    /// Gets or sets the initial diagnosis.
    /// </summary>
    public string? InitialDiagnosis { get; set; }

    /// <summary>
    /// Gets or sets the final diagnosis.
    /// </summary>
    public string? FinalDiagnosis { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the nurse who recorded the visit information.
    /// </summary>
    public int? NurseId { get; set; }

    /// <summary>
    /// Gets or sets the name of the nurse who recorded the visit information.
    /// </summary>
    public string? NurseName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the visit is finalized and can no longer be edited.
    /// </summary>
    public bool IsFinalized { get; set; }
}
