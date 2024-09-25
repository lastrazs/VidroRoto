namespace VidroRoto.Models
{
    public class Client
    {
        public int IdCliente { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public required string Telefono { get; set; }
        public required string Direccion { get; set; }

        public List<Cotizacion> Cotizaciones { get; set; }
    }
}
