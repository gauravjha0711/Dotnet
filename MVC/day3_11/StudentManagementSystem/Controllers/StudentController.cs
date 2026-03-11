using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models.Context;
using System.Runtime.CompilerServices;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private StudentDbContext _context;
        public StudentController(StudentDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var students = _context.Students
                    .Include(s => s.Department)
                    .ToList();
            return View(students);
        }
    }
}
