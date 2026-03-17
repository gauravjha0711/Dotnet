
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_Assignment_BoilerPlateCode.Repos;
using LINQ_Assignment_BoilerPlateCode.DTOs;
using LINQ_Assignment_BoilerPlateCode.Models;
using System.Security.AccessControl;

namespace LINQ_Assignment_BoilerPlateCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // =======================
            // SAMPLE DATA
            // =======================
            var employees = EmployeeRepo.SeedEmployees();
            
            var projects = ProjectRepo. SeedProjects();
            List<Employee> employees1 = Program.GetHighEarningEmployees(employees);
            Console.WriteLine("High Earning Employees:");
            foreach(var emp in employees1)
            {
                Console.WriteLine($"- {emp.Name}, Salary: {emp.Salary}");
            }


            Console.WriteLine("LINQ Scenario Boilerplate Loaded");
            Console.ReadLine();
        }

        // =====================================================
        // 🟢 SECTION 1 – HR ANALYTICS
        // =====================================================

        // TODO 1.1: Get employees earning more than 60,000
        static List<Employee> GetHighEarningEmployees(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            List<Employee> result = (from emp in employees
                                     where emp.Salary > 60000
                                     select emp).ToList();
            return result;
            throw new NotImplementedException();
        }

        // TODO 1.2: Get list of employee names only
        static List<string> GetEmployeeNames(List<Employee> employees)
        {
            // TODO: Write LINQ query here for employee names only
            List<string> result = (from emp in employees
                                   where emp.Name != null
                                   select emp.Name).ToList();
            return result;
            throw new NotImplementedException();
        }

        // TODO 1.3: Check if any employee belongs to HR department
        static bool HasHREmployees(List<Employee> employees)
        {
            bool result = (from emp in employees
                           where emp.Department == "HR"
                           select emp).Any();
            return result;
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // =====================================================
        // 🟡 SECTION 2 – MANAGEMENT INSIGHTS
        // =====================================================

        // TODO 2.1: Get department-wise employee count
        static List<DepartmentCount> GetDepartmentWiseCount(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            List<DepartmentCount> result = (from emp in employees
                                            group emp by emp.Department into deptGroup
                                            select new DepartmentCount
                                            {
                                                Department = deptGroup.Key,
                                                Count = deptGroup.Count()
                                            }).ToList();
            return result;
            throw new NotImplementedException();
        }

        // TODO 2.2: Find the highest paid employee
        static Employee GetHighestPaidEmployee(List<Employee> employees)
        {
            Employee result = (from emp in employees
                               orderby emp.Salary descending
                               select emp).FirstOrDefault();
            return result;
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // TODO 2.3: Sort employees by Salary (DESC), then Name (ASC)
        static List<Employee> SortEmployeesBySalaryAndName(List<Employee> employees)
        {
            List<Employee> result = (from emp in employees
                                     orderby emp.Salary descending, emp.Name ascending
                                     select emp).ToList();
            return result;
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // =====================================================
        // 🔵 SECTION 3 – PROJECT & SKILL INTELLIGENCE
        // =====================================================

        // TODO 3.1: Join employees with projects
        static List<EmployeeProject> GetEmployeeProjectMappings(
            List<Employee> employees,
            List<Project> projects)
        {
            List<EmployeeProject> result = (from emp in employees
                                             join proj in projects
                                             on emp.Id equals proj.EmployeeId
                                             select new EmployeeProject
                                             {
                                                 EmployeeName = emp.Name,
                                                 ProjectName = proj.ProjectName
                                             }).ToList();
            return result;
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // TODO 3.2: Find employees who are NOT assigned to any project
        static List<Employee> GetUnassignedEmployees(
            List<Employee> employees,
            List<Project> projects)
        {
            List<Employee> result = (from emp in employees
                                     join proj in projects
                                     on emp.Id equals proj.EmployeeId into empProjGroup
                                     from ep in empProjGroup.DefaultIfEmpty()
                                     where ep == null
                                     select emp).ToList();
            return result;
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // TODO 3.3: Get all unique skills across the organization
        static List<string> GetAllUniqueSkills(List<Employee> employees)
        {
            List<string> result = (from emp in employees
                                   from skill in emp.Skills
                                   select skill).Distinct().ToList();
            return result;
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // =====================================================
        // 🔴 SECTION 4 – ADVANCED WORKFORCE ANALYTICS
        // =====================================================

        // TODO 4.1: Get top 3 highest-paid employees per department
        static List<DepartmentTopEmployees> GetTopEarnersByDepartment(
            List<Employee> employees)
        {
            List<DepartmentTopEmployees> result = (from emp in employees
                                                   group emp by emp.Department into deptGroup
                                                   select new DepartmentTopEmployees
                                                   {
                                                       Department = deptGroup.Key,
                                                       TopEmployees = (from e in deptGroup
                                                                       orderby e.Salary descending
                                                                       select e).Take(3).ToList()
                                                   }).ToList();
            return result;
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // TODO 4.2: Remove duplicate employees based on Id
        static List<Employee> RemoveDuplicateEmployees(List<Employee> employees)
        {
            List<Employee> result = (from emp in employees
                                     group emp by emp.Id into empGroup
                                     select empGroup.First()).ToList();
            return result;
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // TODO 4.3: Implement pagination
        static List<Employee> GetEmployeesByPage(
            List<Employee> employees,
            int pageNumber,
            int pageSize = 5)
        {
            List<Employee> result = (from emp in employees
                                     select emp)
                                     .Skip((pageNumber - 1) * pageSize)
                                     .Take(pageSize)
                                     .ToList();
            return result;
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }


    }
}
