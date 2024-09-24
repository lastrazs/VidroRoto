namespace VidroRoto.Models
{
    public class Vidrio
    {
        public int IdVidrio { get; set; }
        public string TipoVidrio { get; set; }
        public decimal Grosor { get; set; }
        public string Caracteristicas { get; set; }

        public List<Cotizacion> Cotizaciones { get; set; }
    }
}
