namespace AspireApp1.Web.CRUD_VidrioRoto.Desarrollador
{
    public class Programador
    {
        public int IdProgramador { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string LenguajesDominados { get; set; }

        public List<Cotizacion> Cotizaciones { get; set; }
    }


}
