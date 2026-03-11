using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Interfaces;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // 1. List All Students
        public IActionResult Index(string searchName, int? departmentId, int? courseId)
        {
            var students = _unitOfWork.Students.GetAll();

            if (!string.IsNullOrEmpty(searchName))
            {
                students = students.Where(s => s.Name.Contains(searchName));
            }

            if (departmentId.HasValue)
            {
                students = students.Where(s => s.DepartmentId == departmentId);
            }

            if (courseId.HasValue)
            {
                students = students.Where(s => s.CourseId == courseId);
            }

            ViewBag.Departments = _unitOfWork.Departments.GetAll();
            ViewBag.Courses = _unitOfWork.Courses.GetAll();

            return View(students);
        }

        // 2. View Student Details

        public IActionResult Details(int id)
        {
            var student = _unitOfWork.Students.GetById(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // 3. Create Student

        public IActionResult Create()
        {
            ViewBag.Departments = _unitOfWork.Departments.GetAll();
            ViewBag.Courses = _unitOfWork.Courses.GetAll();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Students.Insert(student);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = _unitOfWork.Departments.GetAll();
            ViewBag.Courses = _unitOfWork.Courses.GetAll();
            return View(student);
        }

        // 4. Edit Student

        public IActionResult Edit(int id)
        {
            var student = _unitOfWork.Students.GetById(id);

            if (student == null)
                return NotFound();

            ViewBag.Departments = _unitOfWork.Departments.GetAll();
            ViewBag.Courses = _unitOfWork.Courses.GetAll();

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Students.Update(student);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            ViewBag.Departments = _unitOfWork.Departments.GetAll();
            ViewBag.Courses = _unitOfWork.Courses.GetAll();

            return View(student);
        }

        // 5. Delete Student
        public IActionResult Delete(int id)
        {
            var student = _unitOfWork.Students.GetById(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.Students.Delete(id);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        // 6. Search Student by Name
        // /Student/Search?name=John

        public IActionResult Search(string name)
        {
            var students = _unitOfWork.Students
                .Find(s => s.Name.Contains(name));

            return View("Index", students);
        }

        // 7. Filter Students by Department
        // /Student/ByDepartment/2

        public IActionResult ByDepartment(int id)
        {
            var students = _unitOfWork.Students
                .Find(s => s.DepartmentId == id);

            return View("Index", students);
        }

        // 8. Filter Students by Course
        // /Student/ByCourse/5

        public IActionResult ByCourse(int id)
        {
            var students = _unitOfWork.Students
                .Find(s => s.CourseId == id);

            return View("Index", students);
        }

        // 9. Students Older Than 25

        public IActionResult OlderThan25()
        {
            var students = _unitOfWork.Students
                .Find(s => s.Age > 25);

            return View("Index", students);
        }

        // 10. Students Admitted After 2024
        public IActionResult RecentAdmissions()
        {
            var students = _unitOfWork.Students
                .Find(s => s.AdmissionDate > DateTime.Now.AddYears(-1));

            return View("Index", students);
        }

        //11. Total Students Per Department
        public IActionResult TotalStudentsPerDepartment()
        {
            var result = _unitOfWork.Students
                .GetAll()
                .GroupBy(s => s.DepartmentId)
                .Select(g => new
                {
                    Department = g.Key,
                    TotalStudents = g.Count()
                })
                .ToList();

            return View(result);
        }

        // 12. Order Students By Name

        public IActionResult OrderByName()
        {
            var students = _unitOfWork.Students
                .GetAll()
                .OrderBy(s => s.Name);

            return View("Index", students);
        }

        // 13. Top 5 Recent Admissions

        public IActionResult Top5Recent()
        {
            var students = _unitOfWork.Students
                .GetAll()
                .OrderByDescending(s => s.AdmissionDate)
                .Take(5);

            return View("Index", students);
        }
    }
}