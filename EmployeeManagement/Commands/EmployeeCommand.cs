using MediatR;

namespace EmployeeManagement.Commands
{
    public record AddEmployeeCommand(EmployeeDto Employee) : IRequest;
    public record EditEmployeeCommand(EmployeeDto Employee , string empno) : IRequest;
    public record DeleteEmployeeCommand(string empno) : IRequest;
}
