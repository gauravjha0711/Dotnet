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

        public string Location { get; set; }

        //navigation property
        public ICollection<Student> Students { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
