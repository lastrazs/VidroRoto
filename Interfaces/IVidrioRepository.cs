using VidroRoto.Models;
using System.Collections.Generic;

namespace VidroRoto.Interfaces
{
    public interface IVidrioRepository
    {
        IEnumerable<Vidrio> GetVidrios();
        Vidrio GetById (int idVidrio);
        void Create(Vidrio vidrio);
        void Update(Vidrio vidrio);
        void Delete(int idVidrio);
    }
}
