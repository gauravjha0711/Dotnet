using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace CodeFirstDemo.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        [Required]
        [StringLength(100)]
        public string DeptName { get; set; }


        // Navigation property for related Employees
        public ICollection<Employee> Employees { get; set; }
    }
}
