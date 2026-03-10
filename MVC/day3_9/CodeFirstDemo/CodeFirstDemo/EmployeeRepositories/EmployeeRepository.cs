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

        public async Task<Employee> GetEmployeeById(int? id)
        {
            try
            {
                Employee employee = await _employeeContext.Employees.FindAsync(id);
                if(employee == null)
                {
                    return null;
                }
                return employee;
            }
            catch
            {
                throw;
            }
        }

        public async Task Add(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            try
            {
                _employeeContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(int id, Employee employee)
        {
            try
            {
                Employee Emp = await _employeeContext.Employees.FindAsync(id);
                if (Emp != null)
                {
                    Emp.EmpName = employee.EmpName;
                    Emp.Address = employee.Address;
                    Emp.Salary = employee.Salary;
                    Emp.Email = employee.Email;

                    _employeeContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}
