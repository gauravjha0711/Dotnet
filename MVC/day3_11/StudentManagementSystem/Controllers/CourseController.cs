using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Context;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly StudentDbContext _context;

        public CourseController(StudentDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }
    }
}
