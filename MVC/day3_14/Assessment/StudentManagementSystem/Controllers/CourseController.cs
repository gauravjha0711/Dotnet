using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==========================
        // VIEW ALL COURSES
        // ==========================
        public IActionResult Index()
        {
            var courses = _context.Courses
                          .Include(c => c.Department)
                          .ToList();

            return View(courses);
        }

        // ==========================
        // CREATE (GET)
        // ==========================
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // ==========================
        // CREATE (POST)
        // ==========================
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", course.DepartmentId);
            return View(course);
        }

        // ==========================
        // EDIT (GET)
        // ==========================
        public IActionResult Edit(int id)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
            {
                return NotFound();
            }

            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", course.DepartmentId);

            return View(course);
        }

        // ==========================
        // EDIT (POST)
        // ==========================
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", course.DepartmentId);
            return View(course);
        }

        // ==========================
        // DELETE (GET)
        // ==========================
        public IActionResult Delete(int id)
        {
            var course = _context.Courses
                         .Include(c => c.Department)
                         .FirstOrDefault(c => c.CourseId == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // ==========================
        // DELETE (POST)
        // ==========================
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.Courses.Find(id);

            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}