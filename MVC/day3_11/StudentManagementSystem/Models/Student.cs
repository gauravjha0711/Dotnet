using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace StudentManagementSystem.Models
{
    public class Student
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public int StudentId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(18,60)]
        public int Age { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(50)]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }

}
