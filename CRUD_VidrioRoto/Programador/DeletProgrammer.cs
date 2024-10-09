namespace AspireApp1.Web.CRUD_VidrioRoto.Programador
{

    public void EliminarProgramador(int id)
    {
        using (var context = new ApplicationDbContext())
        {
            var programador = context.Programadores.Find(id);
            if (programador != null)
            {
                context.Programadores.Remove(programador);
                context.SaveChanges();
            }
        }
    }
}
