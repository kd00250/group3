using MySqlConnector;

namespace HealthcareSystem.Model.DAL
{
    public static class Connection
    {
        public static string ConnectionString()
        {
            var builder = new MySqlConnectionStringBuilder();

            // Set the connection string properties
            builder.Server = "localhost";    // MySQL server address
            builder.Database = "company";        // Database name
            builder.UserID = "root";          // MySQL username
            builder.Password = "gowest";        // MySQL password
            builder.Port = 3306;                    // MySQL port (default: 3306)

            // Get the constructed connection string
            return builder.ToString();

        }
    }
}