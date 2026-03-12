using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Interfaces;

namespace StudentManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // List All Departments

        public IActionResult Index()
        {
            var departments = _unitOfWork.Departments.GetAll();
            return View(departments);
        }

        // View Department Details

        public IActionResult Details(int id)
        {
            var department = _unitOfWork.Departments.GetById(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // Create Department

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Departments.Insert(department);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // Edit Department

        public IActionResult Edit(int id)
        {
            var department = _unitOfWork.Departments.GetById(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Departments.Update(department);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }


            return View(department);
        }



        // Delete Department

        public IActionResult Delete(int id)
        {
            var department = _unitOfWork.Departments.GetById(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.Departments.Delete(id);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        // Show Students By Department
        //public IActionResult StudentsByDepartment(int id)
        //{
        //    var department = _unitOfWork.Departments.GetById(id);

        //    if (department == null)
        //        return NotFound();

        //    var students = _unitOfWork.Students
        //        .Find(s => s.DepartmentId == id)
        //        .ToList();

        //    ViewBag.DepartmentName = department.DepartmentName;

        //    return View(students);
        //}
        public IActionResult StudentsByDepartment(int id)
        {
            var department = _unitOfWork.Departments.GetById(id);

            if (department == null)
                return NotFound();

            var students = _unitOfWork.Students
                .GetAll()
                .Where(s => s.DepartmentId == id)
                .ToList();

            // Fetch Courses
            var courses = _unitOfWork.Courses.GetAll();

            // Map course to each student
            foreach (var student in students)
            {
                student.Course = courses
                    .FirstOrDefault(c => c.CourseId == student.CourseId);
            }

            ViewBag.DepartmentName = department.DepartmentName;

            return View(students);
        }


        // Show Courses By Department
        public IActionResult CoursesByDepartment(int id)
        {
            var department = _unitOfWork.Departments.GetById(id);

            if (department == null)
                return NotFound();

            var courses = _unitOfWork.Courses
                .GetAll()
                .Where(c => c.DepartmentId == id)
                .ToList();

            ViewBag.DepartmentName = department.DepartmentName;

            return View(courses);
        }
    }
}