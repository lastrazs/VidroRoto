namespace AspireApp1.Web.CRUD_VidrioRoto.Administrador_CRUD
{
    public class Administrador
    {
        public int IdAdministrador { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public List<Cotizacion> Cotizaciones { get; set; }
    }
}
