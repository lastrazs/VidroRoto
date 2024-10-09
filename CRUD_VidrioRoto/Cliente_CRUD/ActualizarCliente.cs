namespace AspireApp1.Web.CRUD_VidrioRoto.Cliente_CRUD
{
    public void ActualizarCliente(int id, Cliente clienteActualizado)
    {
        using (var context = new ApplicationDbContext())
        {
            var cliente = context.Clientes.Find(id);
            if (cliente != null)
            {
                cliente.Nombre = clienteActualizado.Nombre;
                cliente.Apellido = clienteActualizado.Apellido;
                cliente.Email = clienteActualizado.Email;
                cliente.Telefono = clienteActualizado.Telefono;
                cliente.Direccion = clienteActualizado.Direccion;

                context.SaveChanges();
            }
        }
    }
}
