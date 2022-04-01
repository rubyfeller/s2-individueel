using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class DBCollection
    {
        public void OpenSqlConnection()
        {
            connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                Console.WriteLine("State: {0}", connection.State);
            }
        }
        public string connectionString { get; set; }

        public string GetConnectionString()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");
            string sqlConnectionString = appSetting.Value;
            return sqlConnectionString;
        }
    }
}
