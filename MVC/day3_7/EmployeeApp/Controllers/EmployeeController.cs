using Microsoft.AspNetCore.Mvc;
using EmployeeApp.Models;
using EmployeeApp.Repositries;


namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            EmployeeRepository.Create(employee);
            return View("Thanks", employee);
        }
    }
}
