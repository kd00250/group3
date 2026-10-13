using MySqlConnector;

namespace HealthcareSystem.Model.DAL;

public class UserAccountDal
{
    public UserAccount? Authenticate(string username, string password)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        const string query = """
                             SELECT ua.account_id, ua.username, ua.account_role, ua.person_id, p.first_name, p.last_name
                             FROM user_account ua
                             INNER JOIN person p 
                                ON ua.person_id = p.person_id
                             WHERE BINARY ua.username = @username
                             AND BINARY ua.password = @password;
                             """;
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@password", password);

        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }

        var roleString = reader.GetString(reader.GetOrdinal("account_role"));

        if (!Enum.TryParse<AccountRole>(roleString, true, out var role))
        {
            return null;
        }

        return new UserAccount
        {
            AccountId = reader.GetInt32(reader.GetOrdinal("account_id")),
            Username = reader.GetString(reader.GetOrdinal("username")),
            AccountRole = role,
            PersonId = reader.GetInt32(reader.GetOrdinal("person_id")),
            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
            LastName = reader.GetString(reader.GetOrdinal("last_name"))
        };
    }

}