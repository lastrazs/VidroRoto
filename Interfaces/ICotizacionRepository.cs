using VidroRoto.Models;
using System.Collections.Generic;

namespace VidroRoto.Interfaces
{
    public interface ICotizacionRepository
    {
        Task<IEnumerable<Cotizacion>> GetCotizacionesAsync();
        Task<Cotizacion> GetByIdAsync(int id);
        Task CreateAsync(Cotizacion cotizacion);
        Task UpdateAsync(Cotizacion cotizacion);
        Task DeleteAsync(int Id);
    }
}
