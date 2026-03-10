using CodeFirstDemo.Context;
using CodeFirstDemo.EmployeeRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeFirstDemo.Models;
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

        public async Task<IActionResult> Details(int? id)
        {
            Employee employee = await _employeeRepository.GetEmployeeById(id);
            return View(employee);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,EmpName,Address,Salary,Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,EmpName,Address,Salary,Email")] Employee employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeRepository.Update(id, employee);
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return Problem("Entity set 'EmployeeContext.Employees'  is null.");

            }
            await _employeeRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
