using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor
        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==========================
        // VIEW ALL DEPARTMENTS
        // ==========================
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }

        // ==========================
        // CREATE (GET)
        // ==========================
        public IActionResult Create()
        {
            return View();
        }

        // ==========================
        // CREATE (POST)
        // ==========================
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(department);
        }

        // ==========================
        // EDIT (GET)
        // ==========================
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // ==========================
        // EDIT (POST)
        // ==========================
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(department);
        }

        // ==========================
        // DELETE (GET)
        // ==========================
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // ==========================
        // DELETE (POST)
        // ==========================
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _context.Departments.Find(id);

            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}