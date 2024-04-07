using EmployeeManagement.Core.DTOs;
using EmployeeManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Services
{
    public interface IEmployeeRepository
    {
        Task<string> AddEmployee(EmployeeDTO employee);
        Task<List<Employee>> GetAll();
        Task<Employee> GetEmployeeById(int id);
        Task<string> UpdateEmployee(Employee employee);
        Task<string> DeleteEmployeeById(int id);
    }
}
