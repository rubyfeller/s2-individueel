using LOGIC.DTO_s;
using LOGIC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface IClientDal
    {
        List<ClientDTO> GetClients();
        ClientDTO GetClient(int clientId);
    }
}
