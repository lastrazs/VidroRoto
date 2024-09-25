using VidroRoto.Interfaces;
using VidroRoto.Models;
using VidroRoto.Data;  // Asegúrate de importar el DbContext
using System.Collections.Generic;
using System.Linq;
using System;

namespace VidroRoto.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        // Inyección del DbContext a través del constructor
        public ClientRepository(AppDbContext context) => _context = context;

        // Crear un nuevo cliente
        public void Create(Client client)
        {
            _context.Clientes.Add(client);
            _context.SaveChanges();  // Guarda los cambios en la base de datos
        }

        // Eliminar un cliente por su ID
        public void Delete(int IdCliente)
        {
            var client = _context.Clientes.Find(IdCliente);  // Busca el cliente por ID
            if (client != null)
            {
                _context.Clientes.Remove(client);  // Elimina el cliente
                _context.SaveChanges();
            }
        }

        // Obtener un cliente por su ID
        public Client GetById(int id)
        {
            return _context.Clientes.Find(id);  // Encuentra el cliente por su ID
        }

        // Obtener todos los clientes
        public IEnumerable<Client> GetClients()
        {
            return _context.Clientes.ToList();  // Devuelve una lista de todos los clientes
        }

        // Actualizar un cliente existente
        public void Update(Client client)
        {
            var existingClient = _context.Clientes.Find(client.IdCliente);  // Encuentra el cliente existente
            if (existingClient != null)
            {
                existingClient.Nombre = client.Nombre;  // Actualiza las propiedades necesarias
                existingClient.Apellido = client.Apellido;  
                existingClient.Email = client.Email;
                existingClient.Telefono = client.Telefono;
                // Agrega más propiedades si es necesario

                _context.Clientes.Update(existingClient);  // Marca el cliente como modificado
                _context.SaveChanges();  // Guarda los cambios en la base de datos
            }
        }
    }
}
