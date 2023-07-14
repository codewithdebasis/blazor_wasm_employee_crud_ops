using employee_crud_ops.Shared.DataContexts;
using employee_crud_ops.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace employee_crud_ops.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly SQLDBContext _dbContext;

        public EmployeeController(SQLDBContext context)
        {
            _dbContext = context;
        }

        [Route("GetEmployees")]
        [HttpGet]
        public async Task<IList<Employee>> GetEmployees()
        {
            try
            {
                var _data = await _dbContext.Employees.ToListAsync();
                return _data;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [Route("GetEmployee/{id}")]
        [HttpGet]
        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
                var _data = await _dbContext.Employees.FindAsync(id);
                return _data;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [Route("SaveEmployee")]
        [HttpPost]
        public async Task<IActionResult> SaveEmployee(Employee employee)
        {
            try
            {
                if (_dbContext.Employees == null)
                {
                    return Problem("Entity set 'AppDbContext.Employee'  is null.");
                }

                if (employee != null)
                {
                    _dbContext.Add(employee);
                    await _dbContext.SaveChangesAsync();

                    return Ok("Save Successfully!!");
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return NoContent();
        }

        [Route("UpdateEmployee")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            _dbContext.Entry(employee).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
                return Ok("Update Successfully!!");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_dbContext.Employees == null)
            {
                return NotFound();
            }
            var product = await _dbContext.Employees.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _dbContext.Employees.Remove(product);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_dbContext.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
