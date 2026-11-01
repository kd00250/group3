
namespace HealthcareSystem.View
{
    /// <summary>
    /// The ways the appointment form can be used.
    /// </summary>
    public enum AppointmentFormMode
    {
        /// <summary>
        /// Booking a new appointment.
        /// </summary>
        Create,

        /// <summary>
        /// Changing and upcoming appointment.
        /// </summary>
        Edit,

        /// <summary>
        /// Viewing an appointments details without changing anything.
        /// </summary>
        View
    }
}
