namespace VidroRoto.Models
{
    public class Herraje
    {
        public int IdHerraje { get; set; }
        public string TipoHerraje { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public List<Cotizacion> Cotizaciones { get; set; }
    }
}
