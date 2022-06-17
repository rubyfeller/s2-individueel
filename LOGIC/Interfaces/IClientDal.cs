using LOGIC.DTO_s;

namespace LOGIC.Interfaces
{
    public interface IClientDal
    {
        List<ClientDTO> GetClients();
        ClientDTO GetClient(int clientId);
    }
}
