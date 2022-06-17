using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface IClientLogic
    {
        List<Client> GetClients();
        Client GetClient(int clientId);
    }
}
