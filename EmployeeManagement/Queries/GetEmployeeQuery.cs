using MediatR;

namespace EmployeeManagement.Queries
{
    public record GetEmployeeQuery : IRequest<IEnumerable<EmployeeDto>>;
    public record GetEmployeeByEmpNoQuery(string empno) : IRequest<EmployeeDto>;
}
