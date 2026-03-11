using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Models.Context
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }


        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(s => s.Department)
                    .WithMany(d => d.Students)
                    .HasForeignKey(s => s.DepartmentId);
            });

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Computer Science", Location = "A-Block" },
                new Department { DepartmentId = 2, DepartmentName = "Mechanical Engineering", Location = "B-Block" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseName = "Asp.Net Core MVC", Duration = 6 },
                new Course { CourseId = 2, CourseName = "Entity Framework Core", Duration = 4 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "Alice Johnson", Age = 20, Email = "alice@example.com", DepartmentId = 1, Gender = "Female" },
                new Student { StudentId = 2, Name = "Bob Smith", Age = 22, Email = "bob@example.com", DepartmentId = 2, Gender = "Male" }
            );
        }

    }
}
