using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Caching.Memory;

using Microsoft.Extensions.Caching.Memory;

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
            option.Expires = DateTime.Now.AddMinutes(10);
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

        //hidden field
        public IActionResult SaveData(){
            return View();
        }

        [HttpPost]
        public IActionResult SaveData(int UserId)
        {
            return Content($"UserId is: {UserId}");
        }

        public IActionResult Index2()
        {
            return RedirectToAction($"Details", new { id = 10 });
        } 

        public IActionResult Details(int id)
        {
            return Content($"Details of id: {id}");
        }

        public IActionResult SetSession(){
            HttpContext.Session.SetString("UserName", "Gaurav Jha");
            return Content("Session has been set");
        }

        public IActionResult GetSession()
        {
            string username = HttpContext.Session.GetString("UserName");
            return Content($"Session Value: {username}");
        }

        private readonly IMemoryCache _cache;
        public StateManagementController(IMemoryCache cache)
        {
            _cache = cache;
        }
        public IActionResult CacheDemo()
        {
            _cache.Set("User", "Gaurav Jha");
            string user = _cache.Get<string>("User");
            return Content(user);
        }
    }
}
