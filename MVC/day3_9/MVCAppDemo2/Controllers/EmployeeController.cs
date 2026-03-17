using CodeFirstDemo.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext _employeeContext;

        // Dependency Injection of EmployeeContext (through constructor)
        public EmployeeController(EmployeeContext _employeeContext)
        {
            this._employeeContext = _employeeContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _employeeContext.Employees != null ?
                        View(await _employeeContext.Employees.ToListAsync()) :
                        Problem("Entity set 'EmployeeContext.Employees'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Position,DepartmentId")] Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeContext.Add(employee);
                await _employeeContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
