using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==========================
        // VIEW ALL STUDENTS
        // ==========================
        public IActionResult Index()
        {
            var students = _context.Students
                .Include(s => s.Department)
                .Include(s => s.Course)
                .ToList();

            return View(students);
        }

        // ==========================
        // CREATE (GET)
        // ==========================
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName");

            return View();
        }

        // ==========================
        // CREATE (POST)
        // ==========================
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName", student.CourseId);

            return View(student);
        }

        // ==========================
        // EDIT (GET)
        // ==========================
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName", student.CourseId);

            return View(student);
        }

        // ==========================
        // EDIT (POST)
        // ==========================
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName", student.CourseId);

            return View(student);
        }

        // ==========================
        // DELETE (GET)
        // ==========================
        public IActionResult Delete(int id)
        {
            var student = _context.Students
                .Include(s => s.Department)
                .Include(s => s.Course)
                .FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // ==========================
        // DELETE (POST)
        // ==========================
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}