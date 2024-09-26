namespace AspireApp1.Web.CRUD_VidrioRoto.Administrador_CRUD
{
    public List<Administrador> LeerAdministradores()
    {
        using (var context = new ApplicationDbContext())
        {
            return context.Administradores.ToList();
        }
    }
}
