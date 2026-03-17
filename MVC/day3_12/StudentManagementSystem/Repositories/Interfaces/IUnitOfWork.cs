using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Student> Students { get; }

        IGenericRepository<Department> Departments { get; }

        IGenericRepository<Course> Courses { get; }

        void Save();
    }
}