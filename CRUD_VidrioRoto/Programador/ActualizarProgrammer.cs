namespace AspireApp1.Web.CRUD_VidrioRoto.Programador
{
    public void ActualizarProgramador(int id, Programador programadorActualizado)
    {
        using (var context = new ApplicationDbContext())
        {
            var programador = context.Programadores.Find(id);
            if (programador != null)
            {
                programador.Nombre = programadorActualizado.Nombre;
                programador.Apellido = programadorActualizado.Apellido;
                programador.Email = programadorActualizado.Email;
                programador.Telefono = programadorActualizado.Telefono;
                programador.LenguajesDominados = programadorActualizado.LenguajesDominados;

                context.SaveChanges();
            }
        }
    }
}
