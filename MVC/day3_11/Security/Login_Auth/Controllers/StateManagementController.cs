using Microsoft.AspNetCore.Mvc;

namespace Login_Auth.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetCookie()
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMintues(10);
            Response.Cookies.Append("UserName", "Gaurav Jha", option);
            return Content("Cookie has been set");
        }
        public IActionResult GetCookie()
        {
            string username = Request.Cookies["UserName"];
            return Content($"Cookie Value: {username}");
        }
        public IActionResult DeleteCookie()
        {
            Response.Cookies.Delete("UserName");
            return Content("Cookie has been deleted");
        }
    }
}
