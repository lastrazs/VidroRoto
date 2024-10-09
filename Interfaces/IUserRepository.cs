using VidroRoto.Models;
using System.Collections.Generic;

namespace VidroRoto.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetById(int id);
        void Create(User user);
        void Update(User user);
        void Delete(int IdUser);
    }
}
