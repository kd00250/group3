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
}
