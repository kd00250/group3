using MySqlConnector;

namespace HealthcareSystem.Model.DAL;

/// <summary>
/// Data access layer for the Visit table.
/// </summary>
public class VisitDal
{
    /// <summary>
    /// Gets all visits for a patient, newest first.
    /// </summary>
    /// <param name="patientId">The patient identifier.</param>
    /// <returns>The patient's visits.</returns>
    public List<Visit> GetVisitsForPatient(int patientId)
    {
        var visits = new List<Visit>();

        const string query = """
                             SELECT v.visit_id, v.visit_datetime, v.appointment_id, a.patient_id, a.reason,
                                    dp.first_name AS doctor_first_name, dp.last_name AS doctor_last_name,
                                    v.height, v.weight, v.systolic, v.diastolic, v.body_temperature, v.pulse,
                                    v.symptoms, v.check_datetime, v.initial_diagnosis, v.final_diagnosis,
                                    v.nurse_id, np.first_name AS nurse_first_name, np.last_name AS nurse_last_name,
                                    v.is_finalized
                             FROM visit v
                             JOIN appointment a ON v.appointment_id = a.appointment_id
                             JOIN doctor d ON a.doctor_id = d.doctor_id
                             JOIN person dp ON d.person_id = dp.person_id
                             LEFT JOIN nurse n ON v.nurse_id = n.nurse_id
                             LEFT JOIN person np ON n.person_id = np.person_id
                             WHERE a.patient_id = @patientId
                             ORDER BY v.visit_datetime DESC;
                             """;
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);
        command.Parameters.Add("@patientId", MySqlDbType.Int32);
        command.Parameters["@patientId"].Value = patientId;

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            visits.Add(this.readVisit(reader));
        }

        return visits;
    }

    /// <summary>
    /// Updates the checkup vitals, symptoms and recording nurse of a visit that is not yet finalized.
    /// </summary>
    /// <param name="visit">The visit.</param>
    /// <returns><c>true</c> if the visit was updated; <c>false</c> if it was not found or is already finalized.</returns>
    public bool Update(Visit visit)
    {
        const string query = """
                             UPDATE visit
                             SET height = @height,
                                 weight = @weight,
                                 systolic = @systolic,
                                 diastolic = @diastolic,
                                 body_temperature = @bodyTemperature,
                                 pulse = @pulse,
                                 symptoms = @symptoms,
                                 check_datetime = @checkDateTime,
                                 nurse_id = @nurseId
                             WHERE visit_id = @visitId
                             AND is_finalized = FALSE;
                             """;
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);

        command.Parameters.Add("@height", MySqlDbType.Decimal);
        command.Parameters["@height"].Value = (object?)visit.Height ?? DBNull.Value;

        command.Parameters.Add("@weight", MySqlDbType.Decimal);
        command.Parameters["@weight"].Value = (object?)visit.Weight ?? DBNull.Value;

        command.Parameters.Add("@systolic", MySqlDbType.Int32);
        command.Parameters["@systolic"].Value = (object?)visit.Systolic ?? DBNull.Value;

        command.Parameters.Add("@diastolic", MySqlDbType.Int32);
        command.Parameters["@diastolic"].Value = (object?)visit.Diastolic ?? DBNull.Value;

        command.Parameters.Add("@bodyTemperature", MySqlDbType.Decimal);
        command.Parameters["@bodyTemperature"].Value = (object?)visit.BodyTemperature ?? DBNull.Value;

        command.Parameters.Add("@pulse", MySqlDbType.Int32);
        command.Parameters["@pulse"].Value = (object?)visit.Pulse ?? DBNull.Value;

        command.Parameters.Add("@symptoms", MySqlDbType.Text);
        command.Parameters["@symptoms"].Value = string.IsNullOrWhiteSpace(visit.Symptoms) ? DBNull.Value : visit.Symptoms.Trim();

        command.Parameters.Add("@checkDateTime", MySqlDbType.DateTime);
        command.Parameters["@checkDateTime"].Value = (object?)visit.CheckDateTime ?? DBNull.Value;

        command.Parameters.Add("@nurseId", MySqlDbType.Int32);
        command.Parameters["@nurseId"].Value = (object?)visit.NurseId ?? DBNull.Value;

        command.Parameters.Add("@visitId", MySqlDbType.Int32);
        command.Parameters["@visitId"].Value = visit.VisitId;

        return command.ExecuteNonQuery() > 0;
    }

    /// <summary>
    /// Gets the nurse identifier and name for a person, if that person is a nurse.
    /// </summary>
    /// <param name="personId">The person identifier.</param>
    /// <returns>The nurse identifier, or <c>null</c> if the person is not a nurse.</returns>
    public int? GetNurseIdByPersonId(int personId)
    {
        const string query = "SELECT nurse_id FROM nurse WHERE person_id = @personId;";
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);
        command.Parameters.Add("@personId", MySqlDbType.Int32);
        command.Parameters["@personId"].Value = personId;

        var result = command.ExecuteScalar();

        return result == null || result == DBNull.Value ? null : Convert.ToInt32(result);
    }

    private Visit readVisit(MySqlDataReader reader)
    {
        var nurseFirstName = this.getNullableString(reader, "nurse_first_name");
        var nurseLastName = this.getNullableString(reader, "nurse_last_name");

        return new Visit
        {
            VisitId = reader.GetInt32(reader.GetOrdinal("visit_id")),
            VisitDateTime = reader.GetDateTime(reader.GetOrdinal("visit_datetime")),
            AppointmentId = reader.GetInt32(reader.GetOrdinal("appointment_id")),
            PatientId = reader.GetInt32(reader.GetOrdinal("patient_id")),
            Reason = this.getNullableString(reader, "reason"),
            DoctorName = $"{reader.GetString(reader.GetOrdinal("doctor_first_name"))} {reader.GetString(reader.GetOrdinal("doctor_last_name"))}",
            Height = this.getNullable<decimal>(reader, "height"),
            Weight = this.getNullable<decimal>(reader, "weight"),
            Systolic = this.getNullable<int>(reader, "systolic"),
            Diastolic = this.getNullable<int>(reader, "diastolic"),
            BodyTemperature = this.getNullable<decimal>(reader, "body_temperature"),
            Pulse = this.getNullable<int>(reader, "pulse"),
            Symptoms = this.getNullableString(reader, "symptoms"),
            CheckDateTime = this.getNullable<DateTime>(reader, "check_datetime"),
            InitialDiagnosis = this.getNullableString(reader, "initial_diagnosis"),
            FinalDiagnosis = this.getNullableString(reader, "final_diagnosis"),
            NurseId = this.getNullable<int>(reader, "nurse_id"),
            NurseName = nurseFirstName == null ? null : $"{nurseFirstName} {nurseLastName}",
            IsFinalized = reader.GetBoolean(reader.GetOrdinal("is_finalized"))
        };
    }

    private string? getNullableString(MySqlDataReader reader, string columnName)
    {
        var ordinal = reader.GetOrdinal(columnName);

        return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
    }

    private T? getNullable<T>(MySqlDataReader reader, string columnName) where T : struct
    {
        var ordinal = reader.GetOrdinal(columnName);

        return reader.IsDBNull(ordinal) ? null : reader.GetFieldValue<T>(ordinal);
    }

    /// <summary>
    ///     Gets upcoming appointments for a patient that do not have visits.
    /// </summary>
    /// <param name="patientId">The patient identifier.</param>
    /// <returns>The available appointments.</returns>
    public List<Appointment> GetAvailableAppointments(int patientId)
    {
        var appointments = new List<Appointment>();

        const string query = """
                         SELECT a.appointment_id, a.patient_id, a.doctor_id,
                                a.appointment_date, a.appointment_time, a.reason
                         FROM appointment a
                         WHERE a.patient_id = @patientId
                         AND TIMESTAMP(a.appointment_date, a.appointment_time) >= NOW()
                         AND NOT EXISTS (
                             SELECT 1
                             FROM visit v
                             WHERE v.appointment_id = a.appointment_id
                         )
                         ORDER BY a.appointment_date ASC, a.appointment_time ASC;
                         """;

        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);
        command.Parameters.Add("@patientId", MySqlDbType.Int32);
        command.Parameters["@patientId"].Value = patientId;

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            appointments.Add(new Appointment
            {
                AppointmentId = reader.GetInt32(reader.GetOrdinal("appointment_id")),
                PatientId = reader.GetInt32(reader.GetOrdinal("patient_id")),
                DoctorId = reader.GetInt32(reader.GetOrdinal("doctor_id")),
                AppointmentDate = reader.GetDateTime(reader.GetOrdinal("appointment_date")),
                AppointmentTime = reader.GetTimeSpan(reader.GetOrdinal("appointment_time")),
                Reason = this.getNullableString(reader, "reason")
            });
        }

        return appointments;
    }

    /// <summary>
    ///     Creates a visit for an available appointment.
    /// </summary>
    /// <param name="patientId">The patient identifier.</param>
    /// <param name="appointmentId">The appointment identifier.</param>
    /// <returns>The newly created visit identifier.</returns>
    public Visit CreateVisit(int patientId, int appointmentId)
    {
        const string query = """
                             INSERT INTO visit
                                 (appointment_id, visit_datetime, is_finalized)
                             SELECT a.appointment_id, NOW(), FALSE
                             FROM appointment a
                             WHERE a.appointment_id = @appointmentId
                             AND a.patient_id = @patientId
                             AND TIMESTAMP(a.appointment_date, a.appointment_time) >= NOW()
                             AND NOT EXISTS (
                                 SELECT 1
                                 FROM visit v
                                 WHERE v.appointment_id = a.appointment_id
                             );
                             """;

        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);

        command.Parameters.Add("@patientId", MySqlDbType.Int32);
        command.Parameters["@patientId"].Value = patientId;

        command.Parameters.Add("@appointmentId", MySqlDbType.Int32);
        command.Parameters["@appointmentId"].Value = appointmentId;

        var rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected == 0)
        {
            throw new ArgumentException(
                "The appointment is no longer available for starting a visit.");
        }
        var visitId = Convert.ToInt32(command.LastInsertedId);

        return new Visit
        {
            VisitId = visitId,
            AppointmentId = appointmentId,
            PatientId = patientId,
            VisitDateTime = DateTime.Now,
            IsFinalized = false
        };
    }
}
