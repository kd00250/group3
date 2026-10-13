using MySql.Data.MySqlClient;

namespace HealthcareSystem.Model.DAL;

/// <summary>
/// Data access layer for the Doctor table.
/// </summary>
public class DoctorDal
{
    /// <summary>
    /// Gets all doctors, sorted by name.
    /// </summary>
    /// <returns>All doctors.</returns>
    public List<Doctor> GetAllDoctors()
    {
        var doctors = new List<Doctor>();

        const string query = """
                             SELECT d.doctor_id, p.first_name, p.last_name
                             FROM doctor d
                             JOIN person p ON d.person_id = p.person_id
                             ORDER BY p.last_name, p.first_name;
                             """;
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            doctors.Add(new Doctor
            {
                DoctorId = reader.GetInt32(reader.GetOrdinal("doctor_id")),
                FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                LastName = reader.GetString(reader.GetOrdinal("last_name"))
            });
        }

        return doctors;
    }
}