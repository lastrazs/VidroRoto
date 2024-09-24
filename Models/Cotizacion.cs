namespace VidroRoto.Models
{
    public class Cotizacion
    {
        public int IdCotizacion { get; set; }
        public int IdCliente { get; set; }
        public Client Cliente { get; set; }

        public DateTime Fecha { get; set; }

        public int IdMarco { get; set; }
        public Marco Marco { get; set; }

        public int IdVidrio { get; set; }
        public Vidrio Vidrio { get; set; }

        public int IdHerraje { get; set; }
        public Herraje Herraje { get; set; }

        public decimal PrecioTotal { get; set; }
    }
}
