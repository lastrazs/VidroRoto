using VidroRoto.Interfaces;
using VidroRoto.Models;

namespace VidroRoto.Services
{
    public class CotizacionService : ICotizacionService
    {
        private readonly ICotizacionRepository _cotizacionRepository;
        private readonly IEmailService _emailService;
        public CotizacionService(ICotizacionRepository cotizacionRepository, IEmailService emailRepository)
        {
            _cotizacionRepository = cotizacionRepository;
            _emailService = emailRepository;

        }
        // Método para calcular el precio total
        public async Task<decimal> CalcularPrecioTotalAsync(Cotizacion cotizacion)
        {
            decimal precioTotal = 0;
            precioTotal += cotizacion.Marco.Precio;
            precioTotal += cotizacion.Herraje.Precio;
        
            return precioTotal;
        }
        public async Task CreateCotizacionAsync(Cotizacion cotizacion)
        {
            cotizacion.PrecioTotal = await CalcularPrecioTotalAsync(cotizacion);
            await _cotizacionRepository.CreateAsync(cotizacion);
        }

        // Método para enviar la cotización por correo electrónico
        public async Task SendCotizacionPorCorreoAsync(Cotizacion cotizacion)
        {
            string asunto = "Cotización de Vidriería y Marquetería 'El Vidrio Roto'";
            string cuerpo = $"Estimado {cotizacion.Usuario.Nombre}, su cotización es de: {cotizacion.PrecioTotal:C}.";

            // Crear instancia de Email
            var email = new Email
            {
                Destinatario = cotizacion.Usuario.Email,
                Asunto = asunto,
                Cuerpo = cuerpo
            };

            await _emailService.sendEmailAsync(email);
        }
    }
}
