using EmployeeManagement.Commands;
using EmployeeManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ISender _sender;
        public EmployeeController(ISender sender) => _sender = sender;
        [HttpGet]
        public async Task<ActionResult> GetEmployee()
        {
            var employee = await _sender.Send(new GetEmployeeQuery());
            return Ok(employee);
        }
        [HttpGet("{empno}", Name = "GetEmployeeByEmpNo")]
        public async Task<ActionResult> GetEmployeeByEmpNo(string empno)
        {
            var employee = await _sender.Send(new GetEmployeeByEmpNoQuery(empno.ToString()));
            return Ok(employee);
        }
        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeDto employee)
        {
            await _sender.Send(new AddEmployeeCommand(employee));
            return StatusCode(201);
        }
        [HttpPut("{empno}", Name = "EditEmployee")]
        public async Task<ActionResult> EditEmployee([FromBody] EmployeeDto employee, string empno)
        {
            await _sender.Send(new EditEmployeeCommand(employee, empno));
            return StatusCode(201);
        }
        [HttpDelete("{empno}")] 
        public async Task<ActionResult> DeleteEmployee(string empno)
        {
            await _sender.Send(new DeleteEmployeeCommand(empno));
            return StatusCode(201);
        }
    }
}
