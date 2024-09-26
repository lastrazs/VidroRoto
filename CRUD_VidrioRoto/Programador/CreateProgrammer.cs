namespace AspireApp1.Web.CRUD_VidrioRoto.Programador
{
    public void CrearProgramador(Programador programador)
    {
        using (var context = new ApplicationDbContext())
        {
            context.Programadores.Add(programador);
            context.SaveChanges();
        }
    }
}
