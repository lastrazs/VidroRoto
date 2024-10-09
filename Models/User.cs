namespace VidroRoto.Models
{
    public class User
    {
        public int IdUsuario { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public required string Telefono { get; set; }
        public required string Direccion { get; set; }

        public required TipoUsuario Rol {  get; set; }
        public List<Cotizacion> Cotizaciones { get; set; }
    }
    public enum TipoUsuario 
    {
        Administrador,
        Cliente
    }
}
