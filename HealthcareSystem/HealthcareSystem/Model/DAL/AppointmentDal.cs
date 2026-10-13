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
    /// <returns>The booked times</returns>
    public List<TimeSpan> GetBookedTimes(int doctorId, DateTime date)
    {
        var bookedTimes = new List<TimeSpan>();
        const string query = """
                             SELECT appointment_time
                             FROM appointment
                             WHERE doctor_id = @doctorId 
                             AND appointment_date = @appointmentDate;
                             """;
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);

        command.Parameters.Add("@doctorId", MySqlDbType.Int32);
        command.Parameters["@doctorId"].Value = doctorId;

        command.Parameters.Add("@appointmentDate", MySqlDbType.Date);
        command.Parameters["@appointmentDate"].Value = date.Date;

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

}