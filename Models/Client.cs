namespace VidroRoto.Models
{
    public class Client
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public List<Cotizacion> Cotizaciones { get; set; }
    }
}
