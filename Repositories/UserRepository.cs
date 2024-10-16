using VidroRoto.Interfaces;
using VidroRoto.Models;
using VidroRoto.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VidroRoto.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        // Inyección del DbContext a través del constructor
        public UserRepository(AppDbContext context) => _context = context;

        // Crear un nuevo usuario de forma asíncrona
        public async Task CreateAsync(User user)
        {
            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();  // Guarda los cambios en la base de datos de manera asíncrona
        }

        // Eliminar un usuario por su ID de forma asíncrona
        public async Task DeleteAsync(int idUsuario)
        {
            var user = await _context.Usuarios.FindAsync(idUsuario);  // Busca el usuario por ID
            if (user != null)
            {
                _context.Usuarios.Remove(user);  // Elimina el usuario
                await _context.SaveChangesAsync();
            }
        }

        // Obtener un usuario por su ID de forma asíncrona
        public async Task<User> GetByIdAsync(int idUsuario)
        {
            return await _context.Usuarios.FindAsync(idUsuario);  // Encuentra el usuario por su ID
        }

        // Obtener todos los usuarios de forma asíncrona
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Usuarios.ToListAsync();  // Devuelve una lista de todos los usuarios
        }

        // Actualizar un usuario existente de forma asíncrona
        public async Task UpdateAsync(User user)
        {
            var existingUser = await _context.Usuarios.FindAsync(user.IdUsuario);  // Encuentra el usuario existente
            if (existingUser != null)
            {
                existingUser.Nombre = user.Nombre;  // Actualiza las propiedades necesarias
                existingUser.Apellido = user.Apellido;
                existingUser.Email = user.Email;
                existingUser.Telefono = user.Telefono;
                existingUser.Rol = user.Rol;
                // Agrega más propiedades si es necesario

                _context.Usuarios.Update(existingUser);  // Marca el usuario como modificado
                await _context.SaveChangesAsync();  // Guarda los cambios en la base de datos de manera asíncrona
            }
        }
    }
}
