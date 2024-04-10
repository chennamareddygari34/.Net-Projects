using CompanyApplication.Models;
using CompanyWebApiApp.Models.DTOs;
using CompanyWebApiApp.Services.Interfaces;
using CompanyWebApiApp.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetEmployeeByEmployeeId")]
        public IActionResult GetEmployeeByEmployeeId(int EmployeeId)
        {
            var employee = _employeeService.GetEmployeeByEmployeeId(EmployeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }
        [HttpGet("GetAllEmployee")]
        public IActionResult GetAllEmployee()
        {
            var employees = _employeeService.GetAllEmployee();
            return Ok(employees);
        }

        

        [HttpPost("AddNewEmployee")]
        public IActionResult AddNewEmployee(CreateEmployeeDto employeeDto) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _employeeService.AddNewEmployee(employeeDto);
                    return Created("", result);
                }
                catch (InvalidUserEntry e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);

        }


        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var deleteemployee = _employeeService.DeleteEmployee(id);
            if (deleteemployee == null)
            {
                return NotFound();
            }
            return Ok(deleteemployee);

        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                var result = _employeeService.UpdateEmployee(employee);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
