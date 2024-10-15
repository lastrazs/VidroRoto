using System.Net.Mail;
using VidroRoto.Models;
using System.Threading.Tasks;
using VidroRoto.Interfaces;

namespace VidroRoto.Services
{
    public class EmailServices : IEmailService
    {
        public async Task sendEmailAsync(Email email)
        {
            using (var client = new SmtpClient("smtp.servidor.com"))
            {
                var mailMessage = new MailMessage()
                {
                    From = new MailAddress("vidrio@vidrieria.com"),
                    Subject = email.Asunto,
                    Body = email.Cuerpo
                };
                mailMessage.To.Add(email.Destinatario);

                if (!string.IsNullOrEmpty(email.CC))
                {
                    mailMessage.CC.Add(email.CC);
                }

                if (!string.IsNullOrEmpty(email.CCO))
                {
                    mailMessage.Bcc.Add(email.CCO);
                }

                // Añadir archivos adjuntos, si existen
                foreach (var filePath in email.ArchivosAdjuntos)
                {
                    mailMessage.Attachments.Add(new Attachment(filePath));
                }

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
