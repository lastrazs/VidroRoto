namespace VidroRoto.Models
{
    public class Email
    {
        // Destinatario del correo
        public string Destinatario { get; set; }

        // Asunto del correo
        public string Asunto { get; set; }

        // Cuerpo del correo
        public string Cuerpo { get; set; }

        // Opcionales: CC y CCO
        public string CC { get; set; }
        public string CCO { get; set; }

        // Opcional: Lista de archivos adjuntos
        public List<string> ArchivosAdjuntos { get; set; }

        // Constructor sin parámetros
        public Email()
        {
            ArchivosAdjuntos = new List<string>();
        }

        // Constructor parametrizado
        public Email(string destinatario, string asunto, string cuerpo, string cc = null, string cco = null)
        {
            Destinatario = destinatario;
            Asunto = asunto;
            Cuerpo = cuerpo;
            CC = cc;
            CCO = cco;
            ArchivosAdjuntos = new List<string>();
        }
    }
}
