namespace VidroRoto.Models
{
    public class Marco
    {
        public int IdMarco { get; set; }
        public string TipoMarco { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public string Dimensiones { get; set; }
        public decimal Precio { get; set; }
        public byte[] Imagen { get; set; }

        public List<Cotizacion> Cotizaciones { get; set; }
    }
}
