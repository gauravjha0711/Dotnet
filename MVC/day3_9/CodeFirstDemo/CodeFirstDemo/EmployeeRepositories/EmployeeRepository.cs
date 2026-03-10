using CodeFirstDemo.Context;
using CodeFirstDemo.EmployeeRepositories;
using CodeFirstDemo.Models;
using Microsoft.EntityFrameworkCore;
namespace CodeFirstDemo.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext? _employeeContext;
        public EmployeeRepository(EmployeeContext _employeeContext)
        {
            this._employeeContext = _employeeContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            try
            {
                var employee = await _employeeContext.Employees.ToListAsync();
                return employee;
            }
            catch
            {
                throw;
            }
        }

        public Task<Employee> GetEmployeeById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Task Update(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
