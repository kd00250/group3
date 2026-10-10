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
            builder.Database = "cs3230f26_g3";        // Database name
            builder.UserID = "kd00250";          // MySQL username
            builder.Password = "917627803";        // MySQL password
            builder.Port = 3307;                    // MySQL port (default: 3306)

            // Get the constructed connection string
            return builder.ToString();

        }
    }
}