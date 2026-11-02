using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

namespace HealthcareSystem.Controller;

/// <summary>
/// Busniess rules for booking appointments.
/// </summary>
public class AppointmentController
{
    private const int MaxReasonsLength = 255;
    private const int SlotMinutes = 15;
    private static readonly TimeSpan FirstSlot = new(8, 0, 0);
    private static readonly TimeSpan LastSlot = new(16, 45, 0);
    private readonly AppointmentDal appointmentDal;
    private readonly DoctorDal doctorDal;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppointmentController"/> class.
    /// </summary>
    /// <param name="appointmentDal">The appointment dal.</param>
    /// <param name="doctorDal">The doctor dal.</param>
    public AppointmentController(AppointmentDal appointmentDal, DoctorDal doctorDal)
    {
        this.appointmentDal = appointmentDal;
        this.doctorDal = doctorDal;
    }

    /// <summary>
    /// Gets all doctors.
    /// </summary>
    /// <returns>A list of all doctors.</returns>
    public List<Doctor> GetAllDoctors()
    {
        return this.doctorDal.GetAllDoctors();
    }

    /// <summary>
    /// Gets the available time slots for a doctor on a specific date.
    /// This includes every 15 minute slot between 8:00 AM and 4:45 PM, excluding any slots that are already booked or have passed.
    /// </summary>
    /// <param name="doctorId">The doctor identifier.</param>
    /// <param name="date">The date.</param>
    /// <param name="excludeAppointmentId">The appointment ID to exclude from the search, if any.</param>
    /// <returns>The available time slots.</returns>
    public List<TimeSpan> GetAvailableTimeSlots(int doctorId, DateTime date, int? excludeAppointmentId = null)
    {
        var availableTimeSlots = new List<TimeSpan>();

        if (date.Date < DateTime.Today)
        {
            return availableTimeSlots;
        }

        var bookedTimes = this.appointmentDal.GetBookedTimes(doctorId, date, excludeAppointmentId);

        for (var time = FirstSlot; time <= LastSlot; time += TimeSpan.FromMinutes(SlotMinutes))
        {
            var isBooked = bookedTimes.Contains(time);
            var hasPassed = date.Date + time <= DateTime.Now;
            if (!isBooked && !hasPassed)
            {
                availableTimeSlots.Add(time);
            }
        }

        return availableTimeSlots;
    }

    /// <summary>
    /// Books the appointment after validating the input.
    /// </summary>
    /// <param name="patient">The patient.</param>
    /// <param name="doctor">The doctor.</param>
    /// <param name="date">The date.</param>
    /// <param name="time">The time.</param>
    /// <param name="reason">The reason.</param>
    /// <returns>The ID of the newly created appointment.</returns>
    /// <exception cref="ArgumentException">
    /// Patient is not active.
    /// or
    /// No doctor selected.
    /// or
    /// No time slot selected.
    /// or
    /// No reason provided.
    /// or
    /// Reason cannot exceed {MaxReasonsLength} characters.
    /// or
    /// The time is not a valid slot.
    /// or
    /// The selected date and time have already passed.
    /// or
    /// The doctor is already booked at the selected date andtime.
    /// </exception>
    public int BookAppointment(Patient patient, Doctor? doctor, DateTime date, TimeSpan? time, string? reason)
    {
        this.validateAppointmentDetails(patient, doctor, date, time, reason, null);

        var appointment = new Appointment
        {
            PatientId = patient.PatientId,
            DoctorId = doctor.DoctorId,
            AppointmentDate = date.Date,
            AppointmentTime = time.Value,
            Reason = reason.Trim()
        };

        return this.appointmentDal.Add(appointment);
    }

    /// <summary>
    /// Gets the appointments for patient which are split into upcoming and past appointments
    /// using the same moment in time so every appointment appears in exactly one of the two lists.
    /// </summary>
    /// <param name="patientId">The patient identifier.</param>
    /// <returns>The upcoming and past appointments.</returns>
    public (List<Appointment> Upcoming, List<Appointment> Past) GetAppointmentsForPatient(int patientId)
    {
        var now = DateTime.Now;

        var upcoming = this.appointmentDal.GetUpcomingAppointments(patientId, now);
        var past = this.appointmentDal.GetPastAppointments(patientId, now);

        return (upcoming, past);   
    }

    /// <summary>
    /// Updates an existing appointment.
    /// </summary>
    /// <param name="patient">The patient.</param>
    /// <param name="original">The original appointment.</param>
    /// <param name="doctor">The doctor.</param>
    /// <param name="date">The date.</param>
    /// <param name="time">The time.</param>
    /// <param name="reason">The reason.</param>
    /// <returns>True if the appointment was updated successfully, false otherwise.</returns>
    public bool UpdateAppointment(Patient patient, Appointment original, Doctor? doctor, DateTime date, TimeSpan? time, string? reason)
    {
        if (original.AppointmentDateTime <= DateTime.Now)
        {
            throw new ArgumentException("Cannot update a past appointment.");
        }
        
        this.validateAppointmentDetails(patient, doctor, date, time, reason, original.AppointmentId);

        var updated = new Appointment()
        {
            AppointmentId = original.AppointmentId,
            PatientId = patient.PatientId,
            DoctorId = doctor!.DoctorId,
            AppointmentDate = date.Date,
            AppointmentTime = time!.Value,
            Reason = reason!.Trim()
        };

        return this.appointmentDal.UpdateAppointment(updated);
    }

    private static bool isValidSlot(TimeSpan time)
    {
        return time >= FirstSlot && time <= LastSlot && time.Minutes % SlotMinutes == 0 && time.Seconds == 0;
    }

    private void validateAppointmentDetails(Patient patient, Doctor? doctor, DateTime date, TimeSpan? time,
        string? reason, int? excludeAppointmentId)
    {
        if (!patient.IsActive)
        {
            throw new ArgumentException("Patient is not active. Make the patient active before making or changing an appointment.");
        }

        if (doctor == null)
        {
            throw new ArgumentException("Please select a doctor.");
        }

        if (time == null)
        {
            throw new ArgumentException("Please select a time slot.");
        }

        if (string.IsNullOrWhiteSpace(reason))
        {
            throw new ArgumentException("Please enter a reason for the appointment.");
        }

        if (reason.Trim().Length > MaxReasonsLength)
        {
            throw new ArgumentException($"Reason cannot exceed {MaxReasonsLength} characters.");
        }

        if (!isValidSlot(time.Value))
        {
            throw new ArgumentException("Please select a valid time slot.");
        }

        if (date.Date + time.Value <= DateTime.Now)
        {
            throw new ArgumentException("Please select a future date and time for the appointment.");
        }

        if (this.appointmentDal.GetBookedTimes(doctor.DoctorId, date, excludeAppointmentId).Contains(time.Value))
        {
            throw new ArgumentException($"Dr. {doctor.FirstName} {doctor.LastName} is not available at the selected time.");
        }
    }

}