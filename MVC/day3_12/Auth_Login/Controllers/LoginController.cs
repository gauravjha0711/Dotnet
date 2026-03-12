using Microsoft.AspNetCore.Mvc;
using Auth_Login.AuthenticateLoginRepositories;
namespace Auth_Login.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthenticateLogin _loginUser;
        public LoginController(IAuthenticateLogin loginUser)
        {
            _loginUser = loginUser;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string passcode){
            var issuccess = _loginUser.AuthenticateUser(username, passcode);
            if(issuccess.Result != null)
            {
                ViewBag.username = string.Format("Successfully logged-in", username);

                TempData["username"] = "GAURAV";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed", username);
                return View();
            }
        }
    }
}
