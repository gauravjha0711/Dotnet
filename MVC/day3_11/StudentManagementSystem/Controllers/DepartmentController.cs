using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
