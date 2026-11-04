namespace HealthcareSystem.Model;

public class LabOrder
{
    /// <summary>
    /// Gets or sets the lab order identifier.
    /// </summary>
    /// <value>
    /// The lab order identifier.
    /// </value>
    public int LabOrderId { get; set; }
    /// <summary>
    /// Gets or sets the date time ordered.
    /// </summary>
    /// <value>
    /// The date time ordered.
    /// </value>
    public DateTime DateTimeOrdered { get; set; }
    /// <summary>
    /// Gets or sets the visit identifier.
    /// </summary>
    /// <value>
    /// The visit identifier.
    /// </value>
    public int visitId { get; set; }
}
