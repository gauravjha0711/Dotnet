using Auth_Login.Models;
namespace Auth_Login.AuthenticateLoginRepositories
{
    public interface IAuthenticateLogin
    {
        Task<IEnumerable<UserLogin>> getuser();
        Task<UserLogin> AuthenticateUser(string username, string passcode);
    }
}
