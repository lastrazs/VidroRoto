namespace AspireApp1.Web.CRUD_VidrioRoto.Programador
{
    public List<Programador> LeerProgramadores()
    {
        using (var context = new ApplicationDbContext())
        {
            return context.Programadores.ToList();
        }
    }
}
