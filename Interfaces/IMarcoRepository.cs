using VidroRoto.Models;
using System.Collections.Generic;

namespace VidroRoto.Interfaces
{
    public interface IMarcoRepository
    {
        IEnumerable<Marco> GetMarcos();
        Marco GetById(int id);
        void Create(Marco marco);
        void Update(Marco marco);
        void Delete(int IdMarco);
    }
}
