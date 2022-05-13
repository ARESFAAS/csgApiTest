using csgTest.cgstest;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace csgApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static readonly csgtestContext _dbContext = new csgtestContext();

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var result = _dbContext.Employees.Where(x => x.Id.Equals(id)).FirstOrDefault();
            return JsonSerializer.Serialize(result);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public int Post([FromBody] Employee employee)
        {
            _dbContext.Add(employee);
            var result = _dbContext.SaveChanges();
            return result;
        }

        // PUT api/<EmployeesController>
        [HttpPut]
        public int Put([FromBody] Employee employee)
        {
            var employeeToUpdate = _dbContext.Employees.Where(x => x.Id.Equals(employee.Id)).FirstOrDefault();
            int result = 0;
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Name = employee.Name;
                employeeToUpdate.Salary = employee.Salary;
                employeeToUpdate.DeptoId = employee.DeptoId;
                _dbContext.SaveChanges();
                result = 1;
            }
            return result;
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            var employeeToRemove = _dbContext.Employees.Where(x => x.Id.Equals(id)).FirstOrDefault();
            int result = 0;
            if (employeeToRemove != null)
            {
                _dbContext.Remove(employeeToRemove);
                result = _dbContext.SaveChanges();
            }
            return result;
        }
    }
}
