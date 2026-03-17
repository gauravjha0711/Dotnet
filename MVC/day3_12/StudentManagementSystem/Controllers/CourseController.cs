using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace StudentManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // List All Courses
        public IActionResult Index()
        {
            var courses = _unitOfWork.Courses.GetAll().ToList();
            var departments = _unitOfWork.Departments.GetAll().ToList();

            // Map Department to Course
            foreach (var course in courses)
            {
                course.Department = departments
                    .FirstOrDefault(d => d.DepartmentId == course.DepartmentId);
            }
            return View(courses);
        }

        // View Course Details

        public IActionResult Details(int id)
        {
            var course = _unitOfWork.Courses.GetById(id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        // Create Course

        public IActionResult Create()
        {
            ViewBag.Departments = _unitOfWork.Departments.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Courses.Insert(course);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = _unitOfWork.Departments.GetAll();
            return View(course);
        }

        // Edit Course

        public IActionResult Edit(int id)
        {
            var course = _unitOfWork.Courses.GetById(id);

            if (course == null)
                return NotFound();

            ViewBag.Departments = _unitOfWork.Departments.GetAll();

            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Courses.Update(course);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = _unitOfWork.Departments.GetAll();
            return View(course);
        }

        // Delete Course

        public IActionResult Delete(int id)
        {
            var course = _unitOfWork.Courses.GetById(id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.Courses.Delete(id);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        // Filter Students by Course
        public IActionResult StudentsByCourse(int id)
        {
            var course = _unitOfWork.Courses.GetById(id);

            if (course == null)
                return NotFound();

            var students = _unitOfWork.Students
                .GetAll()
                .Where(s => s.CourseId == id)
                .ToList();

            var departments = _unitOfWork.Departments.GetAll().ToList();

            // Map Department to each Student
            foreach (var student in students)
            {
                student.Department = departments
                    .FirstOrDefault(d => d.DepartmentId == student.DepartmentId);
            }

            ViewBag.CourseName = course.CourseName;

            return View(students);
        }
    }
}