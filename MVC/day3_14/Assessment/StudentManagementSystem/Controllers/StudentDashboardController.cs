using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
    public class StudentDashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentDashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==========================
        // STUDENT DASHBOARD
        // ==========================
        public IActionResult Index()
        {
            return View();
        }

        // ==========================
        // VIEW PROFILE
        // ==========================
        public IActionResult Profile()
        {
            // Example: fetch first student (in real case we use logged in user email)
            var student = _context.Students
                .Include(s => s.Department)
                .Include(s => s.Course)
                .FirstOrDefault();

            if (student == null)
            {
                return NotFound();
            }

            var profile = new StudentProfileViewModel
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Address = student.Address,
                DepartmentName = student.Department.DepartmentName,
                CourseName = student.Course.CourseName,
                Duration = student.Course.Duration,
                Fees = student.Course.Fees
            };

            return View(profile);
        }

        // ==========================
        // UPDATE PROFILE
        // ==========================
        [HttpPost]
        public IActionResult UpdateProfile(StudentProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = _context.Students.Find(model.StudentId);

                if (student == null)
                {
                    return NotFound();
                }

                // Only update allowed fields
                student.PhoneNumber = model.PhoneNumber;
                student.Address = model.Address;

                _context.SaveChanges();

                return RedirectToAction("Profile");
            }

            return View("Profile", model);
        }
    }
}