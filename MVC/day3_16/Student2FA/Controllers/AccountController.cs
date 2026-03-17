using Microsoft.AspNetCore.Mvc;
using Student2FA.Data;
using Student2FA.Models;
using Student2FA.Services;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Student2FA.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EmailService _emailService;
        private readonly SmsService _smsService;

        // 🔹 Dependency Injection
        public AccountController(AppDbContext context, EmailService emailService, SmsService smsService)
        {
            _context = context;
            _emailService = emailService;
            _smsService = smsService;
        }

        // ================= REGISTER =================

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                student.OTP = null;

                _context.Students.Add(student);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(student);
        }

        // ================= LOGIN =================

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var student = _context.Students
                .FirstOrDefault(x => x.Username == username && x.Password == password);

            if (student != null)
            {
                HttpContext.Session.SetInt32("UserId", student.Id);
                return RedirectToAction("ChooseOTP");
            }

            ViewBag.Error = "Invalid Username or Password";
            return View();
        }

        // ================= CHOOSE OTP =================

        public IActionResult ChooseOTP()
        {
            int? id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
                return RedirectToAction("Login");

            return View();
        }

        // ================= SEND OTP =================

        [HttpPost]
        public IActionResult SendOTP(string method)
        {
            int? id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
                return RedirectToAction("Login");

            var student = _context.Students.Find(id);

            if (student == null)
                return RedirectToAction("Login");

            string otp = new Random().Next(100000, 999999).ToString();

            student.OTP = otp;
            _context.SaveChanges();

            // 🔹 Use Injected Services
            if (method == "email")
            {
                _emailService.SendEmail(student.Email, otp);
            }
            else if (method == "sms")
            {
                _smsService.SendSMS(student.PhoneNumber, otp);
            }

            return RedirectToAction("VerifyOTP");
        }

        // ================= VERIFY OTP =================

        public IActionResult VerifyOTP()
        {
            int? id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
                return RedirectToAction("Login");

            return View();
        }

        [HttpPost]
        public IActionResult VerifyOTP(string otp)
        {
            int? id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
                return RedirectToAction("Login");

            var student = _context.Students.Find(id);

            if (student != null && student.OTP == otp)
            {
                student.OTP = null;
                _context.SaveChanges();

                HttpContext.Session.SetString("Username", student.Username);

                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid OTP";
            return View();
        }

        // ================= DASHBOARD =================

        public IActionResult Dashboard()
        {
            var username = HttpContext.Session.GetString("Username");

            if (username == null)
                return RedirectToAction("Login");

            // 🔹 Disable browser cache
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            ViewBag.Username = username;

            return View();
        }

        // ================= LOGOUT =================

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // ================= AUTHENTICATOR SETUP =================

        public IActionResult SetupAuthenticator()
        {
            int? id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
                return RedirectToAction("Login");

            AuthenticatorService authService = new AuthenticatorService();

            string key = authService.GenerateSecretKey();

            HttpContext.Session.SetString("AuthKey", key);

            string qrText = authService.GenerateQrCodeUri("Student2FA", key);
            string qrImage = authService.GenerateQrCodeImage(qrText);

            ViewBag.QrCodeImage = qrImage;
            ViewBag.ManualKey = key;

            return View();
        }

        [HttpPost]
        public IActionResult VerifyAuthenticator(string code)
        {
            string key = HttpContext.Session.GetString("AuthKey");

            if (key == null)
                return RedirectToAction("Login");

            AuthenticatorService authService = new AuthenticatorService();

            bool isValid = authService.ValidateOtp(key, code);

            if (isValid)
            {
                HttpContext.Session.SetString("Username", "AuthenticatedUser");
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid Code";
            return View("SetupAuthenticator");
        }
    }
}