using CompanyApplication.Models;
using CompanyWebApiApp.Interfaces;
using CompanyWebApiApp.Utilities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApiApp.Controllers
{
    [EnableCors("MyCors")]
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
        public IActionResult AddNewEmployee(Employee employee) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _employeeService.AddNewEmployee(employee);
                    return Created("", result);
                }
                catch (InvalidUserEntry e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);

        }


        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int EmployeeId)
        {
            var deleteemployee = _employeeService.DeleteEmployee(EmployeeId);
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
