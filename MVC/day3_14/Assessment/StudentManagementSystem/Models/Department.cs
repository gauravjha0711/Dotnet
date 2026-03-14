using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        public string Description { get; set; }

        // Navigation Properties
        public ICollection<Course> Courses { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}