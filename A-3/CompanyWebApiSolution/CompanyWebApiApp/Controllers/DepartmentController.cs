using CompanyApplication.Models;
using CompanyWebApiApp.Interfaces;
using CompanyWebApiApp.Services;
using CompanyWebApiApp.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet("GetDepartmentByDepartmentNumber")]
        public IActionResult GetDepartmentByDepartmentNumber(int DepartmentNumber)
        {
            var department = _departmentService.GetDepartmentByDepartmentNumber(DepartmentNumber);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);

        }
        [HttpGet("GetAllDepartment")]
        public IActionResult GetAllDepartment()
        {
            var departments = _departmentService.GetAllDepartment();
            return Ok(departments);
        }


        [HttpPost("AddNewDepartment")]
        public IActionResult AddNewDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _departmentService.AddNewDepartment(department);
                    return Created("", result);
                }
                catch (InvalidUserEntry e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);

        }
        [HttpDelete("DeleteDepartment")]
        public IActionResult DeleteDepartment(int DepartmentNumber)
        {
            var deletedepartment = _departmentService.DeleteDepartment(DepartmentNumber);
            if (deletedepartment == null)
            {
                return NotFound();
            }
            return Ok(deletedepartment);

        }



        [HttpPut("UpdateDepartment")]
        public IActionResult UpdateDepartment(Department department)
        {
            try
            {
                var result = _departmentService.UpdateDepartment(department);
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
