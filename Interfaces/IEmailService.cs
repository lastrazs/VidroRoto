using VidroRoto.Models;

namespace VidroRoto.Interfaces
{
    public interface IEmailService
    {
        Task sendEmailAsync(Email email);
    }
}
