namespace VidroRoto.Models
{
    public class Cotizacion
    {
        public int IdCotizacion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUser { get; set; }
        public User Usuario { get; set; }

       

        public int IdMarco { get; set; }
        public Marco Marco { get; set; }

        public int IdVidrio { get; set; }
        public Vidrio Vidrio { get; set; }

        public int IdHerraje { get; set; }
        public Herraje Herraje { get; set; }

        public decimal PrecioTotal { get; set; }
    }
}
