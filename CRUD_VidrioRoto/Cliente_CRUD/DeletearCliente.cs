namespace AspireApp1.Web.CRUD_VidrioRoto.Cliente_CRUD
{
    public void EliminarCliente(int id)
    {
        using (var context = new ApplicationDbContext())
        {
            var cliente = context.Clientes.Find(id);
            if (cliente != null)
            {
                context.Clientes.Remove(cliente);
                context.SaveChanges();
            }
        }
    }
}
