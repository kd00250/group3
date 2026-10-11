using MySqlConnector;

namespace HealthcareSystem.Model.DAL;

public class NurseDal
{
    public int AddNurse(Nurse nurse)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
        using var transaction = connection.BeginTransaction();

        try
        {
            const string personQuery = """
                                       INSERT INTO person (
                                           first_name,
                                           last_name,
                                           gender,
                                           date_of_birth,
                                           street_address,
                                           city,
                                           state,
                                           zip_code,
                                           phone_number
                                       )
                                       VALUES (
                                           @firstName,
                                           @lastName,
                                           @gender,
                                           @dateOfBirth,
                                           @streetAddress,
                                           @city,
                                           @state,
                                           @zipCode,
                                           @phoneNumber
                                       );
                                       """;
            using var personCommand = new MySqlCommand(personQuery, connection, transaction);
            this.addPersonParameters(personCommand, nurse);
            personCommand.ExecuteNonQuery();

            var personId = checked((int)personCommand.LastInsertedId);

            const string nurseQuery = """
                                      INSERT INTO nurse (person_id)
                                      VALUES (@personId);
                                      """;
            using var nurseCommand = new MySqlCommand(nurseQuery, connection, transaction);
            nurseCommand.Parameters.Add("@personId", MySqlDbType.Int32);
            nurseCommand.Parameters["@personId"].Value = personId;

            nurseCommand.ExecuteNonQuery();
            var nurseId = checked((int)nurseCommand.LastInsertedId);
            transaction.Commit();

            return nurseId;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    /// <summary>
    ///     Gets all nurses.
    /// </summary>
    /// <returns>A list of all the nurses</returns>
    public IList<Nurse> GetAllNurses()
    {
        var nurses = new List<Nurse>();
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        const string query = """
                             SELECT
                                 n.nurse_id,
                                 p.person_id,
                                 p.first_name,
                                 p.last_name,
                                 p.gender,
                                 p.date_of_birth,
                                 p.street_address,
                                 p.city,
                                 p.state,
                                 p.zip_code,
                                 p.phone_number
                             FROM nurse n
                             INNER JOIN person p
                                 ON n.person_id = p.person_id
                             ORDER BY p.last_name, p.first_name;
                             """;
        using var command = new MySqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            nurses.Add(this.readNurse(reader));
        }

        return nurses;
    }

    /// <summary>
    ///     Retrieves a nurse by nurse ID.
    /// </summary>
    public Nurse? GetNurseById(int nurseId)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
        const string query = """
                             SELECT
                                 n.nurse_id,
                                 p.person_id,
                                 p.first_name,
                                 p.last_name,
                                 p.gender,
                                 p.date_of_birth,
                                 p.street_address,
                                 p.city,
                                 p.state,
                                 p.zip_code,
                                 p.phone_number
                             FROM nurse n
                             INNER JOIN person p
                                 ON n.person_id = p.person_id
                             WHERE n.nurse_id = @nurseId;
                             """;

        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@nurseId", nurseId);
        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }

        return this.readNurse(reader);
    }

    /// <summary>
    /// Updates an existing nurse's information.
    /// </summary>
    public bool UpdateNurse(Nurse nurse)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
        const string query = """
                             UPDATE person p
                             INNER JOIN nurse n
                                 ON p.person_id = n.person_id
                             SET
                                 p.first_name = @firstName,
                                 p.last_name = @lastName,
                                 p.gender = @gender,
                                 p.date_of_birth = @dateOfBirth,
                                 p.street_address = @streetAddress,
                                 p.city = @city,
                                 p.state = @state,
                                 p.zip_code = @zipCode,
                                 p.phone_number = @phoneNumber
                             WHERE n.nurse_id = @nurseId;
                             """;

        using var command = new MySqlCommand(query, connection);
        this.addPersonParameters(command, nurse);
        command.Parameters.AddWithValue("@nurseId", nurse.NurseId);

        return command.ExecuteNonQuery() > 0;
    }

    /// <summary>
    ///     Converts a database row into a Nurse object.
    /// </summary>
    private Nurse readNurse(MySqlDataReader reader)
    {
        return new Nurse
        {
            NurseId = reader.GetInt32(reader.GetOrdinal("nurse_id")),
            PersonId = reader.GetInt32(reader.GetOrdinal("person_id")),
            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
            LastName = reader.GetString(reader.GetOrdinal("last_name")),
            Gender = reader.GetString(reader.GetOrdinal("gender")),
            DateOfBirth = reader.GetDateTime(reader.GetOrdinal("date_of_birth")),
            StreetAddress = this.getNullableString(reader, "street_address"),
            City = this.getNullableString(reader, "city"),
            State = this.getNullableString(reader, "state"),
            ZipCode = this.getNullableString(reader, "zip_code"),
            PhoneNumber = this.getNullableString(reader, "phone_number")
        };
    }

    /// <summary>
    ///     Retrieves a nullable string column.
    /// </summary>
    private string? getNullableString(MySqlDataReader reader, string columnName)
    {
        var ordinal = reader.GetOrdinal(columnName);

        return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
    }

    /// <summary>
    ///     Adds shared person parameters to an SQL command.
    /// </summary>
    private void addPersonParameters(MySqlCommand command, Nurse nurse)
    {
        command.Parameters.Add("@firstName", MySqlDbType.VarChar);
        command.Parameters["@firstName"].Value = nurse.FirstName.Trim();

        command.Parameters.Add("@lastName", MySqlDbType.VarChar);
        command.Parameters["@lastName"].Value = nurse.LastName.Trim();

        command.Parameters.Add("@gender", MySqlDbType.VarChar);
        command.Parameters["@gender"].Value = nurse.Gender.Trim();

        command.Parameters.Add("@dateOfBirth", MySqlDbType.Date);
        command.Parameters["@dateOfBirth"].Value = nurse.DateOfBirth.Date;

        command.Parameters.Add("@streetAddress", MySqlDbType.VarChar);
        command.Parameters["@streetAddress"].Value = string.IsNullOrWhiteSpace(nurse.StreetAddress) ? DBNull.Value : nurse.StreetAddress.Trim();

        command.Parameters.Add("@city", MySqlDbType.VarChar);
        command.Parameters["@city"].Value = string.IsNullOrWhiteSpace(nurse.City) ? DBNull.Value : nurse.City.Trim();

        command.Parameters.Add("@state", MySqlDbType.VarChar);
        command.Parameters["@state"].Value = string.IsNullOrWhiteSpace(nurse.State) ? DBNull.Value : nurse.State.Trim();

        command.Parameters.Add("@zipCode", MySqlDbType.VarChar);
        command.Parameters["@zipCode"].Value = string.IsNullOrWhiteSpace(nurse.ZipCode) ? DBNull.Value : nurse.ZipCode.Trim();

        command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar);
        command.Parameters["@phoneNumber"].Value = string.IsNullOrWhiteSpace(nurse.PhoneNumber) ? DBNull.Value : nurse.PhoneNumber.Trim();
    }
}