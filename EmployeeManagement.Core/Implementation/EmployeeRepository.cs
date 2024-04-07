
using EmployeeManagement.Core.Services;
using EmployeeManagement.Model.Entities;
using EmployeeManagement.Model;
using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Core.DTOs;




namespace EmployeeManagement.Core.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddEmployee(EmployeeDTO employee)
        {
            var existingUser = _context.Employees.FirstOrDefault(e => e.IdNumber == employee.IdNumber);
            if (existingUser != null)
            {
                return "User Already Exist";
            }

            var newEmployee = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
                IdNumber = employee.IdNumber,
                Department = employee.Department,
            };

            _context.Employees.Add(newEmployee);
            var saveChanges = await _context.SaveChangesAsync();
            if (saveChanges > 0)
            {
                return "User add successfully";
            }

            return "User could not be added successfully";

        }

        public async Task<string> DeleteEmployeeById(int id)
        {
            var employee = await GetEmployeeById(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return "User Deleted Successfully";
            }

            return "User not found";
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<string> UpdateEmployee(Employee employee)
        {
            var existingUser = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
            if (existingUser != null)
            {
                _context.Employees.Update(existingUser);
                return "User Update successfully";
            }

            return "No user found";
        }
    }
}