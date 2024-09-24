using VidroRoto.Models;
using System.Collections.Generic;

namespace VidroRoto.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        Client GetById(int id);
        void Create(Client client);
        void Update(Client client);
        void Delete(int IdCliente);
    }
}
