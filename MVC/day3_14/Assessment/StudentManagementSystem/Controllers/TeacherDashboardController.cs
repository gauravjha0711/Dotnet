using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
    public class TeacherDashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherDashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==========================
        // TEACHER DASHBOARD
        // ==========================
        public IActionResult Index()
        {
            // Dashboard statistics
            ViewBag.TotalDepartments = _context.Departments.Count();
            ViewBag.TotalCourses = _context.Courses.Count();
            ViewBag.TotalStudents = _context.Students.Count();

            return View();
        }
    }
}