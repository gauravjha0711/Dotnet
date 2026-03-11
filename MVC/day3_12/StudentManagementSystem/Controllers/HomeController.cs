using Microsoft.AspNetCore.Mvc;
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
            ViewBag.TotalStudents = _unitOfWork.Students.GetAll().Count();
            ViewBag.TotalDepartments = _unitOfWork.Departments.GetAll().Count();
            ViewBag.TotalCourses = _unitOfWork.Courses.GetAll().Count();

            return View();
        }
    }
}