namespace AspireApp1.Web.CRUD_VidrioRoto.Cliente_CRUD
{
    public void CrearCliente(Cliente cliente)
    {
        using (var context = new ApplicationDbContext())
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
        }
    }
}
