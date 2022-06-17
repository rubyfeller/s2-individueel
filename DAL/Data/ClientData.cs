using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Data
{
    public class ClientData : IClientDal
    {
        private readonly DBCollection dbConnection = new DBCollection();

        // Get all employees
        public List<ClientDTO> GetClients()
        {
            Client client = new Client();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Employees";
                List<ClientDTO> clientList = new();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        client.ClientId = reader.GetInt32("clientId");
                        client.FirstName = reader.GetString("firstName");
                        client.LastName = reader.GetString("lastName");
                        client.Password = reader.GetString("password");
                        clientList.Add(new ClientDTO
                        {
                            ClientId = reader.GetInt32("clientId"),
                            FirstName = reader.GetString("firstName"),
                            LastName = reader.GetString("lastName"),
                            Password = reader.GetString("password"),
                        });
                    }
                }
                return clientList;
            }
        }
        public ClientDTO GetClient(int clientId)
        {
            Client client = new Client();
            var connectionString = dbConnection.GetConnectionString();
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();
            client.ClientId = clientId;
            using SqlCommand command = new SqlCommand("SELECT * FROM Clients WHERE ClientId = @ClientId", connection);
            command.Parameters.AddWithValue("@ClientId", client.ClientId);
            ClientDTO specificClient = new();
            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    client.ClientId = Convert.ToInt32(reader.GetInt32("clientId"));
                    client.FirstName = reader.GetString("firstName");
                    client.LastName = reader.GetString("lastName");
                    client.Password = reader.GetString("password");
                    client.Email = reader.GetString("email");

                    specificClient = new ClientDTO()
                    {
                        ClientId = Convert.ToInt32(reader.GetInt32("clientId")),
                        FirstName = reader.GetString("firstName"),
                        LastName = reader.GetString("lastName"),
                        Password = reader.GetString("password"),
                        Email = reader.GetString("email"),
                    };
                }
                return specificClient;
            }
        }
    }
}
