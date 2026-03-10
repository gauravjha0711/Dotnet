using CodeFirstDemo.Context;
using CodeFirstDemo.EmployeeRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDemo.Controllers
{
    public class EmployeeController : Controller
    {
        //private EmployeeContext _employeeContext;
        //public EmployeeController(EmployeeContext _employeecontext)
        //{
        //    this._employeeContext = _employeecontext;//Constructor Injection
        //}
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    return _employeeContext.Employees != null ?
        //                View(await _employeeContext.Employees.ToListAsync()) :
        //                Problem("Entity set 'EmployeeContext.Employees'  is null.");
        //}


 
        private IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository _employeeRepository)
        {
            this._employeeRepository = _employeeRepository;//Constructor Injection
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _employeeRepository.GetAllEmployee());
        }
    }
}
