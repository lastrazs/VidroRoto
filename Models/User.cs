namespace VidroRoto.Models
{
    public class User
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public  string Email { get; set; }
        public string Telefono { get; set; }
        public  string Direccion { get; set; }

        public TipoUsuario Rol {  get; set; }
        public List<Cotizacion> Cotizaciones { get; set; }
    }
    public enum TipoUsuario 
    {
        Administrador,
        Cliente
    }
}
