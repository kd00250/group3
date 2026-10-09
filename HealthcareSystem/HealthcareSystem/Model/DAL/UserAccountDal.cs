using MySql.Data.MySqlClient;

namespace HealthcareSystem.Model.DAL;

public class UserAccountDal
{
    private readonly string connectionString;

    public UserAccountDal(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public UserAccount? Authenticate(string username, string password)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        const string query = """
                             SELECT account_id, username, account_role, person_id
                             FROM user_account
                             WHERE username = @username
                             AND password = @password;
                             """;
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@password", password);

        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }
        
        return new UserAccount
        {
            AccountId = reader.GetInt32(reader.GetOrdinal("account_id")),
            Username = reader.GetString(reader.GetOrdinal("username")),
            AccountRole = reader.GetString(reader.GetOrdinal("account_role")),
            PersonId = reader.GetInt32(reader.GetOrdinal("person_id"))
        };
    }

}