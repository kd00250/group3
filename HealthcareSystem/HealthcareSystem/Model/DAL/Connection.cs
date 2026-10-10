using MySqlConnector;

namespace HealthcareSystem.Model.DAL
{
    public static class Connection
    {
        public static string ConnectionString()
        {
            var builder = new MySqlConnectionStringBuilder();

            builder.Server = "localhost";    
            builder.Database = "cs3230f26_g3";       
            builder.UserID = "cs3230f26_g3";          
            builder.Password = "dO-@zEm1wAZ,-9sGfRLS";       
            builder.Port = 3307;                    

            return builder.ToString();

        }
    }
}