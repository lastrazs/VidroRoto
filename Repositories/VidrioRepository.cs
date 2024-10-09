using VidroRoto.Interfaces;
using VidroRoto.Models;
using VidroRoto.Data;  
using System.Collections.Generic;
using System.Linq;
using System;

namespace VidroRoto.Repositories
{
    public class VidrioRepository : IVidrioRepository
    {
        private readonly AppDbContext _context;

        public VidrioRepository(AppDbContext context) => _context = context;

        public void Create(Vidrio vidrio)
        {
            _context.Vidrios.Add(vidrio);
            _context.SaveChanges();
        }
        public void Update(Vidrio vidrio)
        {
            var existingVidrio = _context.Vidrios.Find(vidrio.IdVidrio);
            if (existingVidrio != null)
            {
                existingVidrio.TipoVidrio = vidrio.TipoVidrio;
                existingVidrio.Grosor = vidrio.Grosor;
                existingVidrio.Caracteristicas = vidrio.Caracteristicas;

                _context.Vidrios.Update(existingVidrio);
                _context.SaveChanges();

            }
        }
        public void Delete(int id)
        {
            var vidrio = _context.Vidrios.Find(id);
            if (vidrio != null)
            {
                _context.Vidrios.Remove(vidrio);
                _context.SaveChanges();
            }
        }
        public Vidrio GetById(int id) => _context.Vidrios.Find(id);
    
        public IEnumerable<Vidrio> GetVidrios() => _context.Vidrios.ToList();
    }
}
