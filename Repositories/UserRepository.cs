using VidroRoto.Interfaces;
using VidroRoto.Models;
using VidroRoto.Data;  // Asegúrate de importar el DbContext
using System.Collections.Generic;
using System.Linq;
using System;

namespace VidroRoto.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        // Inyección del DbContext a través del constructor
        public UserRepository(AppDbContext context) => _context = context;

        // Crear un nuevo cliente
        public void Create(User client)
        {
            _context.Usuarios.Add(client);
            _context.SaveChanges();  // Guarda los cambios en la base de datos
        }

        // Eliminar un cliente por su ID
        public void Delete(int IdCliente)
        {
            var client = _context.Usuarios.Find(IdCliente);  // Busca el cliente por ID
            if (client != null)
            {
                _context.Usuarios.Remove(client);  // Elimina el cliente
                _context.SaveChanges();
            }
        }

        // Obtener un cliente por su ID
        public User GetById(int id) => _context.Usuarios.Find(id);  // Encuentra el cliente por su ID

        // Obtener todos los clientes
        public IEnumerable<User> GetUsers()
        {
            return _context.Usuarios.ToList();  // Devuelve una lista de todos los clientes
        }

        // Actualizar un cliente existente
        public void Update(User client)
        {
            var existingClient = _context.Usuarios.Find(client.IdUsuario);  // Encuentra el cliente existente
            if (existingClient != null)
            {
                existingClient.Nombre = client.Nombre;  // Actualiza las propiedades necesarias
                existingClient.Apellido = client.Apellido;  
                existingClient.Email = client.Email;
                existingClient.Telefono = client.Telefono;
                existingClient.Rol = client.Rol;
                // Agrega más propiedades si es necesario

                _context.Usuarios.Update(existingClient);  // Marca el cliente como modificado
                _context.SaveChanges();  // Guarda los cambios en la base de datos
            }
        }
    }
}
