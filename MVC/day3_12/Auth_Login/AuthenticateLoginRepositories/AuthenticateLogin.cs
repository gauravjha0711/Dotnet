using System.Linq;
using Microsoft.EntityFrameworkCore;
using Auth_Login.Models;

namespace Auth_Login.AuthenticateLoginRepositories
{
    public class AuthenticateLogin : IAuthenticateLogin
    {
        private readonly LoginDbcontext _context;
        public AuthenticateLogin(LoginDbcontext context)
        {
            _context = context;
        }

        public async Task<UserLogin> AuthenticateUser(string username, string passcode)
        {
            var succeeded = await _context.UserLogins.FirstOrDefaultAsync(u => u.UserName == username && u.passcode == passcode);
            return succeeded;
        }

        public async Task<IEnumerable<UserLogin>> getuser()
        {
            var user = await _context.UserLogins.ToListAsync();
            return user;
        }
    }
}
