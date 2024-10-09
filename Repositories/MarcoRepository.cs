using VidroRoto.Interfaces;
using VidroRoto.Models;
using VidroRoto.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace VidroRoto.Repositories
{

    public class MarcoRepository : IMarcoRepository
    {
        private readonly AppDbContext _context;

        public void Create(Marco marco)
        {
            _context.Marcos.Add(marco);
            _context.SaveChanges();
        }

        public void Delete(int idMarco)
        {
            var client = _context.Marcos.Find(idMarco);
            if (client != null)
            {
                _context.Marcos.Remove(client);
                _context.SaveChanges();
            }
        }

        public Marco GetById(int id)
        {
            return _context.Marcos.Find(id);
        }

        public IEnumerable<Marco> GetMarcos()
        {
            return _context.Marcos.ToList();
        }

        public void Update(Marco marco)
        {
            var existigMarco = _context.Marcos.Find(marco.IdMarco);
            if (existigMarco != null) 
            {
                existigMarco.TipoMarco = marco.TipoMarco;
                existigMarco.Precio = marco.Precio;
                existigMarco.Material = marco.Material;
                existigMarco.Color = marco.Color;
                existigMarco.Dimensiones = marco.Dimensiones;   
                existigMarco.Imagen = marco.Imagen;

                _context.Marcos.Update(existigMarco);
                _context.SaveChanges();
                
            }
        }
    }
}
