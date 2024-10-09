using VidroRoto.Interfaces;
using VidroRoto.Models;
using VidroRoto.Data;  // Asegúrate de importar el DbContext
using System.Collections.Generic;
using System.Linq;
using System;

namespace VidroRoto.Repositories
{
    public class CotizacionRepository : ICotizacionRepository
    {
        private readonly AppDbContext _context;

        public CotizacionRepository(AppDbContext context) => _context = context;

        public void Create(Cotizacion c) 
        { 
            _context.Cotizaciones.Add(c);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var cotizacion = _context.Cotizaciones.Find(id);
            if (cotizacion != null) 
            {
                _context.Cotizaciones.Remove(cotizacion);
                _context.SaveChanges();
            }
        }

        public Cotizacion GetById(int id) => _context.Cotizaciones.Find(id);

        public IEnumerable<Cotizacion> GetCotizaciones() 
        {
            return _context.Cotizaciones.ToList();
        }

        public void Update(Cotizacion c)
        {
            var existingCotizacion = _context.Cotizaciones.Find(c.IdCotizacion);
            if (existingCotizacion != null)
            {
                existingCotizacion.Marco = c.Marco;
                existingCotizacion.Herraje = c.Herraje;
                existingCotizacion.Vidrio = c.Vidrio;

                _context.Cotizaciones.Update(existingCotizacion);
                _context.SaveChanges();
            }
        }
   
    }
}
