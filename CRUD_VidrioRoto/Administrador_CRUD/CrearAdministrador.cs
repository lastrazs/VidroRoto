namespace AspireApp1.Web.CRUD_VidrioRoto.Administrador_CRUD
{

    public void CrearAdministrador(Administrador administrador)
    {
        using (var context = new ApplicationDbContext())
        {
            context.Administradores.Add(administrador);
            context.SaveChanges();
        }
    }

}
