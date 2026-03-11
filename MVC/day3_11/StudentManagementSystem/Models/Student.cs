using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace StudentManagementSystem.Models

{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]

        public string Name { get; set; }

        [Range(18, 60)]
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string? Gender { get; set; }
        public Department? Department { get; set; }
    }
}
