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

        public int Duration { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        // Navigation Properties
        public Department Department { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
