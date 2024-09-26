namespace AspireApp1.Web.CRUD_VidrioRoto.Administrador_CRUD
{
    public void EliminarAdministrador(int id)
    {
        using (var context = new ApplicationDbContext())
        {
            var administrador = context.Administradores.Find(id);
            if (administrador != null)
            {
                context.Administradores.Remove(administrador);
                context.SaveChanges();
            }
        }
    }
}
