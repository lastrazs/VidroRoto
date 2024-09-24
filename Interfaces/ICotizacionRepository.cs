using VidroRoto.Models;
using System.Collections.Generic;

namespace VidroRoto.Interfaces
{
    public interface ICotizacionRepository
    {
        IEnumerable<Cotizacion> GetCotizaciones();
        Cotizacion GetById(int id);
        void Create(Cotizacion cotizacion);
        void Update(Cotizacion cotizacion);
        void Delete(int Id);
    }
}
