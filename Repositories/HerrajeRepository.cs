using VidroRoto.Interfaces;
using VidroRoto.Models;
using VidroRoto.Data;  // Asegúrate de importar el DbContext
using System.Collections.Generic;
using System.Linq;
using System;

namespace VidroRoto.Repositories
{
    public class HerrajeRepository : IHerrajeRepository
    {
        private readonly AppDbContext _context;

        public HerrajeRepository(AppDbContext context) => _context = context;

        public void Create(Herraje herraje) 
        { 
            _context.Herrajes.Add(herraje);
            _context.SaveChanges();
        }
        public IEnumerable<Herraje> GetHerrajes() 
        {
            return _context.Herrajes.ToList();
        }
        public Herraje GetById(int id) => _context.Herrajes.Find(id);
        public void Delete(int idHerraje) 
        { 
            var herraje = _context.Herrajes.Find(idHerraje);
            if (herraje != null) 
            {
                _context.Herrajes.Remove(herraje);
                _context.SaveChanges();
            }
        }
        public void Update(Herraje herraje)
        {
            var existingHerraje = _context.Herrajes.Find(herraje.IdHerraje);
            if (existingHerraje != null) 
            {
                existingHerraje.Descripcion = herraje.Descripcion;
                existingHerraje.TipoHerraje = herraje.TipoHerraje;
                existingHerraje.Precio = herraje.Precio;

                _context.Herrajes.Update(existingHerraje);
                _context.SaveChanges();
            }
        }
    }
}
