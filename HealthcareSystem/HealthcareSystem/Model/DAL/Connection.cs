using System.Configuration;

namespace HealthcareSystem.Model.DAL
{
    /// <summary>
    ///     The connection class where we get our connection string from to connect to the database.
    /// </summary>
    public static class Connection
    {
        /// <summary>
        ///     Gets the connections the string from the configuration file.
        /// </summary>
        /// <returns>the connection string to be used to connect to the database.</returns>
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["HealthcareDatabase"]!.ConnectionString;

        }
    }
}