using MySqlConnector;

namespace HealthcareSystem.Model.DAL;

/// <summary>
/// Data access for the patient table.
/// </summary>
public class PatientDal
{
    /// <summary>
    /// Finds patients by first and last name, date of birth, or both.
    /// A null or blank value for any of the parameters will be ignored in the search.
    /// Filtering happens in the database, not in memory.
    /// </summary>
    /// <param name="firstName">The patients first name.</param>
    /// <param name="lastName">The patients last name.</param>
    /// <param name="dateOfBirth">The patients date of birth.</param>
    /// <returns>The matching patients, sorted by name and date of birth.</returns>
    public List<Patient> Search(string? firstName, string? lastName, DateTime? dateOfBirth)
    {
        var patients = new List<Patient>();

        const string query = """
                             SELECT pa.patient_id, pa.person_id, pa.is_active, pe.first_name, pe.last_name,
                                pe.gender, pe.date_of_birth, pe.street_address, pe.city, pe.state, pe.zip_code, pe.phone_number
                             FROM patient pa
                             JOIN person pe ON pa.person_id = pe.person_id
                             WHERE (@firstName IS NULL OR pe.first_name = @firstName)
                                AND (@lastName IS NULL OR pe.last_name = @lastName)
                                AND (@dateOfBirth IS NULL OR pe.date_of_birth = @dateOfBirth)
                             ORDER BY pe.last_name, pe.first_name, pe.date_of_birth;
                             """;

        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);

        command.Parameters.Add("@firstName", MySqlDbType.VarChar);
        command.Parameters["@firstName"].Value = string.IsNullOrWhiteSpace(firstName) ? DBNull.Value : firstName.Trim();

        command.Parameters.Add("@lastName", MySqlDbType.VarChar);
        command.Parameters["@lastName"].Value = string.IsNullOrWhiteSpace(lastName) ? DBNull.Value : lastName.Trim();

        command.Parameters.Add("@dateOfBirth", MySqlDbType.DateTime);
        command.Parameters["@dateOfBirth"].Value = dateOfBirth.HasValue ? dateOfBirth.Value.Date : DBNull.Value;

        using var reader = command.ExecuteReader();
        
        while (reader.Read())
        {
            patients.Add(ReadPatient(reader));
        }

        return patients;
    }

    /// <summary>
    /// Builds a Patient from ther readers current row.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>The patient for that row.</returns>
    private static Patient ReadPatient(MySqlDataReader reader)
    {
        return new Patient
        {
            PatientId = reader.GetInt32(reader.GetOrdinal("patient_id")),
            PersonId = reader.GetInt32(reader.GetOrdinal("person_id")),
            IsActive = reader.GetBoolean(reader.GetOrdinal("is_active")),
            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
            LastName = reader.GetString(reader.GetOrdinal("last_name")),
            Gender = reader.GetString(reader.GetOrdinal("gender")),
            DateOfBirth = reader.GetDateTime(reader.GetOrdinal("date_of_birth")),
            StreetAddress = reader.GetFieldValueCheckNull<string?>(reader.GetOrdinal("street_address")),
            City = reader.GetFieldValueCheckNull<string?>(reader.GetOrdinal("city")),
            State = reader.GetFieldValueCheckNull<string?>(reader.GetOrdinal("state")),
            ZipCode = reader.GetFieldValueCheckNull<string?>(reader.GetOrdinal("zip_code")),
            PhoneNumber = reader.GetFieldValueCheckNull<string?>(reader.GetOrdinal("phone_number"))
        };
    }

}