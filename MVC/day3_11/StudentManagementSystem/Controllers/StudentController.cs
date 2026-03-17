using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Context;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private StudentDbContext _context;
        public StudentController(StudentDbContext studentDbContext)
        {
            this._context = studentDbContext;
        }
        public IActionResult Index()
        {
            var students = _context.Students
                            .Include(s => s.Department)
                            .ToList();

            return View(students);
        }
        public IActionResult Create()
        {
            ViewBag.Departments = _context.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departments = _context.Departments.ToList();
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.Departments = _context.Departments.ToList();
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _context.Departments.ToList();
            return View(student);
        }

        public IActionResult Details(int id)
        {
            var student = _context.Students
                            .Include(s => s.Department)
                            .FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
