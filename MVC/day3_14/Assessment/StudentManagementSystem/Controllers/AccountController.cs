using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace StudentManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // REGISTER (GET)
        // =========================
        public IActionResult Register()
        {
            return View();
        }

        // =========================
        // REGISTER (POST)
        // =========================
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if email already exists
                var existingUser = _context.Users
                    .FirstOrDefault(u => u.Email == model.Email);

                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Email already registered");
                    return View(model);
                }

                // Create new user
                User user = new User()
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Password = model.Password,
                    Role = model.Role
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                // Redirect to Login Page
                return RedirectToAction("Login");
            }

            return View(model);
        }

        // =========================
        // LOGIN (GET)
        // =========================
        public IActionResult Login()
        {
            return View();
        }

        // =========================
        // LOGIN (POST)
        // =========================
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users
                    .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    // Store session
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    HttpContext.Session.SetString("UserRole", user.Role);
                    HttpContext.Session.SetString("UserName", user.FullName);

                    // Role based redirect
                    if (user.Role == "Teacher")
                    {
                        return RedirectToAction("Index", "TeacherDashboard");
                    }
                    else
                    {
                        return RedirectToAction("Index", "StudentDashboard");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email or Password");
                }
            }

            return View(model);
        }

        // =========================
        // LOGOUT
        // =========================
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}