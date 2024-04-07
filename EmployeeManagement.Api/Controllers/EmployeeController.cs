using EmployeeManagement.Core.Services;
using EmployeeManagement.Model.Entities;
using EmployeeManagement.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeMgtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("add-employee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO employee)
        {
            var result = await _employeeRepository.AddEmployee(employee);
            return Ok(result);
        }

        [HttpGet("get-all-employees")]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            List<Employee> employees = await _employeeRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet("get-employee-by-id")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost("update-employee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            var updatedEmployee = await _employeeRepository.UpdateEmployee(employee);
            return Ok(updatedEmployee);
        }
    }
}