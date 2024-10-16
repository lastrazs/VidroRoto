using VidroRoto.Interfaces;
using VidroRoto.Models;
using VidroRoto.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidroRoto.Repositories
{
    public class CotizacionRepository : ICotizacionRepository
    {
        private readonly AppDbContext _context;

        public CotizacionRepository(AppDbContext context) => _context = context;

        // Crear una nueva cotización de forma asíncrona
        public async Task CreateAsync(Cotizacion cotizacion)
        {
            try
            {
                _context.Cotizaciones.Add(cotizacion);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error o lanzar una excepción personalizada)
                throw new Exception("Ocurrió un error al crear la cotización", ex);
            }
        }

        // Eliminar una cotización por su ID de forma asíncrona
        public async Task DeleteAsync(int id)
        {
            var cotizacion = await _context.Cotizaciones.FindAsync(id);
            if (cotizacion != null)
            {
                _context.Cotizaciones.Remove(cotizacion);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("La cotización no existe.");
            }
        }

        // Obtener una cotización por su ID de forma asíncrona
        public async Task<Cotizacion> GetByIdAsync(int id)
        {
            var cotizacion = await _context.Cotizaciones
                                           .Include(c => c.Marco)
                                           .Include(c => c.Vidrio)
                                           .Include(c => c.Herraje)
                                           .FirstOrDefaultAsync(c => c.IdCotizacion == id);
            if (cotizacion == null)
                throw new KeyNotFoundException("La cotización no fue encontrada.");

            return cotizacion;
        }

        // Obtener todas las cotizaciones de forma asíncrona
        public async Task<IEnumerable<Cotizacion>> GetCotizacionesAsync()
        {
            return await _context.Cotizaciones
                                 .Include(c => c.Marco)
                                 .Include(c => c.Vidrio)
                                 .Include(c => c.Herraje)
                                 .ToListAsync();
        }

        // Actualizar una cotización existente de forma asíncrona
        public async Task UpdateAsync(Cotizacion cotizacion)
        {
            var existingCotizacion = await _context.Cotizaciones.FindAsync(cotizacion.IdCotizacion);
            if (existingCotizacion == null)
                throw new KeyNotFoundException("La cotización no existe.");

            // Actualiza solo las propiedades relevantes
            existingCotizacion.Marco = cotizacion.Marco;
            existingCotizacion.Herraje = cotizacion.Herraje;
            existingCotizacion.Vidrio = cotizacion.Vidrio;
            existingCotizacion.PrecioTotal = cotizacion.PrecioTotal;

            try
            {
                _context.Cotizaciones.Update(existingCotizacion);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Ocurrió un error al actualizar la cotización", ex);
            }
        }
    }
}
