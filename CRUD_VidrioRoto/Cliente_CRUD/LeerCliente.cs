namespace AspireApp1.Web.CRUD_VidrioRoto.Cliente_CRUD
{
    public List<Cliente> LeerClientes()
    {
        using (var context = new ApplicationDbContext())
        {
            return context.Clientes.ToList();
        }
    }
}
