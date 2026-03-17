using System.ComponentModel.DataAnnotations;

namespace Student2FA.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? OTP { get; set; }
    }
}