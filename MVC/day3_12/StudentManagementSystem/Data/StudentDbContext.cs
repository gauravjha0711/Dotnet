using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
using System;

namespace StudentManagementSystem.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationships (Fluent API)

            // Student -> Department (Many to One)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            // Student -> Course (Many to One)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            // Course -> Department (Many to One)
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            // Seed Data : Departments

            modelBuilder.Entity<Department>().HasData(

                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "Computer Science",
                    Location = "Building A"
                },

                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "Information Technology",
                    Location = "Building B"
                },

                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "Business Administration",
                    Location = "Building C"
                }

            );

            // Seed Data : Courses

            modelBuilder.Entity<Course>().HasData(

                new Course
                {
                    CourseId = 1,
                    CourseName = ".NET Full Stack Development",
                    Duration = 6,
                    DepartmentId = 1
                },

                new Course
                {
                    CourseId = 2,
                    CourseName = "Angular Development",
                    Duration = 4,
                    DepartmentId = 1
                },

                new Course
                {
                    CourseId = 3,
                    CourseName = "Cloud Computing",
                    Duration = 6,
                    DepartmentId = 2
                },

                new Course
                {
                    CourseId = 4,
                    CourseName = "Cyber Security",
                    Duration = 5,
                    DepartmentId = 2
                },

                new Course
                {
                    CourseId = 5,
                    CourseName = "Financial Management",
                    Duration = 3,
                    DepartmentId = 3
                }

            );

            // Seed Data : Students

            modelBuilder.Entity<Student>().HasData(

                new Student
                {
                    StudentId = 1,
                    Name = "Gaurav Jha",
                    Email = "gauravjha@gmail.com",
                    Age = 22,
                    Gender = "Male",
                    AdmissionDate = new DateTime(2024, 1, 10),
                    DepartmentId = 1,
                    CourseId = 1
                },

                new Student
                {
                    StudentId = 2,
                    Name = "Anjali Sharma",
                    Email = "anjali@gmail.com",
                    Age = 23,
                    Gender = "Female",
                    AdmissionDate = new DateTime(2024, 2, 15),
                    DepartmentId = 2,
                    CourseId = 3
                },

                new Student
                {
                    StudentId = 3,
                    Name = "Suresh Reddy",
                    Email = "suresh@gmail.com",
                    Age = 24,
                    Gender = "Male",
                    AdmissionDate = new DateTime(2024, 3, 5),
                    DepartmentId = 1,
                    CourseId = 2
                },

                new Student
                {
                    StudentId = 4,
                    Name = "Priya Nair",
                    Email = "priya@gmail.com",
                    Age = 21,
                    Gender = "Female",
                    AdmissionDate = new DateTime(2024, 4, 20),
                    DepartmentId = 3,
                    CourseId = 5
                }

            );
        }
    }
}