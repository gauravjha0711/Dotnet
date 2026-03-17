using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Interfaces;

namespace StudentManagementSystem.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentDbContext _context;

        public IGenericRepository<Student> Students { get; private set; }

        public IGenericRepository<Department> Departments { get; private set; }

        public IGenericRepository<Course> Courses { get; private set; }

        public UnitOfWork(StudentDbContext context)
        {
            _context = context;

            Students = new GenericRepository<Student>(_context);
            Departments = new GenericRepository<Department>(_context);
            Courses = new GenericRepository<Course>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}