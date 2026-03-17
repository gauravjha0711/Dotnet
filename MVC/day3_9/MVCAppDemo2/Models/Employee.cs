using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstDemo.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Employee Name cannot exceed 100 characters")]
        
        public string? EmpName { get; set; }

        [Required(ErrorMessage = "Employee Address is required")]
        [StringLength(300)]

        public string Address { get; set; }

        [Required(ErrorMessage = "Employee Salary is required")]
        [Range(3000, 1000000, ErrorMessage = "Salary must be between 3000 and 1000000")]

        public double Salary { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email Address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please Enter a Valid Email Address")]
        public string Email { get; set; }

    }
}
