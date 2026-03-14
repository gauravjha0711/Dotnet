using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public decimal Fees { get; set; }

        // Foreign Key
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        // Navigation Property
        public Department Department { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}