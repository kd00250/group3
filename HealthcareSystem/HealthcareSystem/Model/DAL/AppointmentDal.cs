using MySqlConnector;

namespace HealthcareSystem.Model.DAL;

/// <summary>
/// Data access layer for the Appointment table.
/// </summary>
public class AppointmentDal
{
    /// <summary>
    /// Gets the times a doctor is already booked on a given date.
    /// </summary>
    /// <param name="doctorId">The doctor identifier.</param>
    /// <param name="date">The date to check.</param>
    /// <param name="excludeAppointmentId">The appointment ID to exclude from the results so
    /// it is not considered as a booked time when editing an appointment.</param>
    /// <returns>The booked times</returns>
    public List<TimeSpan> GetBookedTimes(int doctorId, DateTime date, int? excludeAppointmentId = null)
    {
        var bookedTimes = new List<TimeSpan>();
        const string query = """
                             SELECT appointment_time
                             FROM appointment
                             WHERE doctor_id = @doctorId 
                             AND appointment_date = @appointmentDate
                             AND (@excludeAppointmentId IS NULL OR appointment_id != @excludeAppointmentId);
                             """;
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);

        command.Parameters.Add("@doctorId", MySqlDbType.Int32);
        command.Parameters["@doctorId"].Value = doctorId;

        command.Parameters.Add("@appointmentDate", MySqlDbType.Date);
        command.Parameters["@appointmentDate"].Value = date.Date;

        command.Parameters.Add("@excludeAppointmentId", MySqlDbType.Int32);
        command.Parameters["@excludeAppointmentId"].Value = excludeAppointmentId.HasValue ? excludeAppointmentId.Value : DBNull.Value;

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            bookedTimes.Add(reader.GetTimeSpan(reader.GetOrdinal("appointment_time")));
        }

        return bookedTimes;
    }

    /// <summary>
    /// Adds the specified appointment.
    /// </summary>
    /// <param name="appointment">The appointment.</param>
    /// <returns>The new appointments identifier.</returns>
    public int Add(Appointment appointment)
    {
        const string query = """
                             INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
                             VALUES (@appointmentDate, @appointmentTime, @reason, @patientId, @doctorId);
                             """;
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);

        command.Parameters.Add("@appointmentDate", MySqlDbType.Date);
        command.Parameters["@appointmentDate"].Value = appointment.AppointmentDate.Date;

        command.Parameters.Add("@appointmentTime", MySqlDbType.Time);
        command.Parameters["@appointmentTime"].Value = appointment.AppointmentTime;

        command.Parameters.Add("@reason", MySqlDbType.VarChar);
        command.Parameters["@reason"].Value = string.IsNullOrWhiteSpace(appointment.Reason) ? DBNull.Value : appointment.Reason.Trim();

        command.Parameters.Add("@patientId", MySqlDbType.Int32);
        command.Parameters["@patientId"].Value = appointment.PatientId;

        command.Parameters.Add("@doctorId", MySqlDbType.Int32);
        command.Parameters["@doctorId"].Value = appointment.DoctorId;

        command.ExecuteNonQuery();

        return (int)command.LastInsertedId;
    }

    /// <summary>
    /// Updates an appointment's doctor, date, time, and reason.
    /// </summary>
    /// <param name="appointment">The appointment.</param>
    /// <returns>True if the appointment was updated successfully, false otherwise.</returns>
    public bool UpdateAppointment(Appointment appointment)
    {
        const string query = """
                             UPDATE appointment
                             SET appointment_date = @appointmentDate,
                                 appointment_time = @appointmentTime,
                                 reason = @reason,
                                 doctor_id = @doctorId
                             WHERE appointment_id = @appointmentId;
                             """;
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);

        command.Parameters.Add("@appointmentId", MySqlDbType.Int32);
        command.Parameters["@appointmentId"].Value = appointment.AppointmentId;

        command.Parameters.Add("@appointmentDate", MySqlDbType.Date);
        command.Parameters["@appointmentDate"].Value = appointment.AppointmentDate.Date;

        command.Parameters.Add("@appointmentTime", MySqlDbType.Time);
        command.Parameters["@appointmentTime"].Value = appointment.AppointmentTime;

        command.Parameters.Add("@reason", MySqlDbType.VarChar);
        command.Parameters["@reason"].Value = string.IsNullOrWhiteSpace(appointment.Reason) ? DBNull.Value : appointment.Reason.Trim();

        command.Parameters.Add("@doctorId", MySqlDbType.Int32);
        command.Parameters["@doctorId"].Value = appointment.DoctorId;

        return command.ExecuteNonQuery() > 0;
    }

    /// <summary>
    /// Gets the upcoming appointments for a patient, soonest first.
    /// </summary>
    /// <param name="patientId">The patient identifier.</param>
    /// <param name="now">The current date and time.</param>
    /// <returns>The upcoming appointments with doctor names.</returns>
    public List<Appointment> GetUpcomingAppointments(int patientId, DateTime now)
    {
        const string query = """
                             SELECT a.appointment_id, a.appointment_date, a.appointment_time, a.reason,
                                    a.patient_id, a.doctor_id,
                                    dp.first_name AS doctor_first_name, dp.last_name AS doctor_last_name
                             FROM appointment a
                             JOIN doctor d ON a.doctor_id = d.doctor_id
                             JOIN person dp ON d.person_id = dp.person_id
                             WHERE a.patient_id = @patientId 
                                AND TIMESTAMP(a.appointment_date, a.appointment_time) >= @now
                                AND NOT EXISTS (
                                 SELECT 1
                                 FROM visit v
                                 WHERE v.appointment_id = a.appointment_id)
                             ORDER BY a.appointment_date, a.appointment_time;
                             """;

        return getAppointments(query, patientId, now);
    }

    /// <summary>
    /// Gets the past appointments for a patient, most recent first.
    /// </summary>
    /// <param name="patientId">The patient identifier.</param>
    /// <param name="now">The current date and time.</param>
    /// <returns>The past appointments with doctor names.</returns>
    public List<Appointment> GetPastAppointments(int patientId, DateTime now)
    {
        const string query = """
                             SELECT a.appointment_id, a.appointment_date, a.appointment_time, a.reason,
                                    a.patient_id, a.doctor_id,
                                    dp.first_name AS doctor_first_name, dp.last_name AS doctor_last_name
                             FROM appointment a
                             JOIN doctor d ON a.doctor_id = d.doctor_id
                             JOIN person dp ON d.person_id = dp.person_id
                             WHERE a.patient_id = @patientId 
                                AND (TIMESTAMP(a.appointment_date, a.appointment_time) <= @now
                                OR EXISTS (
                                 SELECT 1
                                 FROM visit v
                                 WHERE v.appointment_id = a.appointment_id))
                             ORDER BY a.appointment_date DESC, a.appointment_time DESC;
                             """;
        return getAppointments(query, patientId, now);
    }

    private List<Appointment> getAppointments(string query, int patientId, DateTime now)
    {
        var appointments = new List<Appointment>();
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);

        command.Parameters.Add("@patientId", MySqlDbType.Int32);
        command.Parameters["@patientId"].Value = patientId;

        command.Parameters.Add("@now", MySqlDbType.DateTime);
        command.Parameters["@now"].Value = now;

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            appointments.Add(readAppointment(reader));
        }

        return appointments;
    }

    private static Appointment readAppointment(MySqlDataReader reader)
    {
        return new Appointment
        {
            AppointmentId = reader.GetInt32(reader.GetOrdinal("appointment_id")),
            AppointmentDate = reader.GetDateTime(reader.GetOrdinal("appointment_date")),
            AppointmentTime = reader.GetTimeSpan(reader.GetOrdinal("appointment_time")),
            Reason = reader.GetFieldValueCheckNull<string?>(reader.GetOrdinal("reason")),
            PatientId = reader.GetInt32(reader.GetOrdinal("patient_id")),
            DoctorId = reader.GetInt32(reader.GetOrdinal("doctor_id")),
            DoctorFirstName = reader.GetString(reader.GetOrdinal("doctor_first_name")),
            DoctorLastName = reader.GetString(reader.GetOrdinal("doctor_last_name"))
        };
    }

}