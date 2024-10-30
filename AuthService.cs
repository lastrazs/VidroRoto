// Services/AuthService.cs
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Login.Services
{
    public class AuthService
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthService(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
