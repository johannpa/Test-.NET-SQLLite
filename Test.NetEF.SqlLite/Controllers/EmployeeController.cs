using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.NetEF.SqlLite.Data;
using Test.NetEF.SqlLite.Models;

namespace Test.NetEF.SqlLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var employees = await _appDbContext.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee newEmployee)
        {
            if (newEmployee != null)
            {
                _appDbContext.Employees.Add(newEmployee);
                await _appDbContext.SaveChangesAsync();
                return await _appDbContext.Employees.ToListAsync();
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var employee = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee != null)
            {
                _appDbContext.Employees.Remove(employee);
                await _appDbContext.SaveChangesAsync();
                return await _appDbContext.Employees.ToListAsync();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee updatedEmployee)
        {
            if(updatedEmployee != null)
            {
                var employee = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == updatedEmployee.Id);
                if (employee != null)
                {
                    employee.Name = updatedEmployee.Name;
                    employee.Age = updatedEmployee.Age;
                    await _appDbContext.SaveChangesAsync();

                    var employees = await _appDbContext.Employees.ToListAsync();
                    return Ok(employees);
                }
                return NotFound();
            }
            return BadRequest();
        }
    }
}
