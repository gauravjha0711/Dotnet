using Microsoft.EntityFrameworkCore;

namespace EmployeeManagmentApiServices.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee>? Employees { get; set; }
    }
}