using VidroRoto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VidroRoto.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetByIdAsync(int id);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int idUser);
    }
}
