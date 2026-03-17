using Microsoft.AspNetCore.Mvc;
using firstMVCDemo.Models;

namespace firstMVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()

        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee{Id=1,Name="Kundan",Department="HR"},
                new Employee{Id=2,Name="Gaurav",Department="IT"},

            };
            ViewBag.Company = "BlueOceanWhale";
            ViewData["Location"] = "Hyderabad";
            TempData["Message"] = "Welcome to Employee Dashbaord";

            ViewData["Message"] = "welcome To employeeDashboard";
            ViewData["Today"] = DateTime.Now.ToShortDateString();

            ViewBag.Name = "Kn";
            ViewBag.Department = "IT";
            ViewBag.Salary = 500000;



            return View(employees);
        }
        public IActionResult Create()
        {
            TempData["Success"] = "Profile Created Sucessfully";
            return RedirectToAction("Index");
        }
        public IActionResult ListCourses()
        {
            ViewBag.Message = "This is ListCourse Example";
            List<string> courses = new List<string>();
            courses.Add("C# .Net");
            courses.Add("ASP.Net");
            courses.Add("SharePoint 2010");
            courses.Add("ASP.NET MVC");
            ViewBag.Courses = courses;
            return View();
        }
    }
}