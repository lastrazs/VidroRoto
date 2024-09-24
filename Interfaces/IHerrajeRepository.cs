using VidroRoto.Models;
using System.Collections.Generic;

namespace VidroRoto.Interfaces
{
    public interface IHerrajeRepository
    {
        IEnumerable<Herraje> GetHerrajes();
        Herraje GetById(int id);
        void Create(Herraje herraje);
        void Update(Herraje herraje);
        void Delete(int Id);
    }
}
