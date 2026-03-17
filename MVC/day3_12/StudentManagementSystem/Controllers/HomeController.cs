using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using StudentManagementSystem.Repositories.Interfaces;

namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var students = _unitOfWork.Students.GetAll().ToList();
            var departments = _unitOfWork.Departments.GetAll().ToList();
            var courses = _unitOfWork.Courses.GetAll().ToList();

            ViewBag.TotalStudents = students.Count;
            ViewBag.TotalDepartments = departments.Count;
            ViewBag.TotalCourses = courses.Count;

            var deptData = students
                .GroupBy(s => s.Department.DepartmentName)
                .Select(g => new
                {
                    Department = g.Key,
                    Count = g.Count()
                }).ToList();

            ViewBag.DepartmentNames =
                JsonSerializer.Serialize(deptData.Select(x => x.Department));

            ViewBag.DepartmentCounts =
                JsonSerializer.Serialize(deptData.Select(x => x.Count));

            return View();
        }
    }
}