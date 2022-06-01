using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services
{
    public class ClientLogic : IClientLogic
    {
        private readonly IClientDal _client;

        public ClientLogic(IClientDal client)
        {
            _client = client;
        }
        public List<Client> GetClients()
        {
            List<ClientDTO> clients = _client.GetClients();

            List<Client> clientList = new List<Client>();

            foreach (var client in clients)
            {
                clientList.Add(new Client
                {
                    ClientId = client.ClientId,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Password = client.Password,
                    Email = client.Email
                });
            }
            return clientList;
        }
        public Client GetClient(int clientId)
        {
            ClientDTO client = _client.GetClient(clientId);

            Client specificClient = new Client
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Password = client.Password,
                Email = client.Email,
            };

            return specificClient;
        }
    }
}
