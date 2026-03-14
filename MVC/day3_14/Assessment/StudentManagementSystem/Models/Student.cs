using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string StudentName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        // Foreign Keys
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        // Navigation Properties
        public Department Department { get; set; }

        public Course Course { get; set; }
    }
}