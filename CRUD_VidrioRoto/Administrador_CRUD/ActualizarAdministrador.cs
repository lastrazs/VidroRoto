namespace AspireApp1.Web.CRUD_VidrioRoto.Administrador_CRUD
{
    public void ActualizarAdministrador(int id, Administrador administradorActualizado)
    {
        using (var context = new ApplicationDbContext())
        {
            var administrador = context.Administradores.Find(id);
            if (administrador != null)
            {
                administrador.Nombre = administradorActualizado.Nombre;
                administrador.Apellido = administradorActualizado.Apellido;
                administrador.Email = administradorActualizado.Email;
                administrador.Telefono = administradorActualizado.Telefono;

                context.SaveChanges();
            }
        }
    }

}
