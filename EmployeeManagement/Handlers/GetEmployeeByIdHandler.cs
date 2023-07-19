using EmployeeManagement.Queries;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByEmpNoQuery, EmployeeDto>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetEmployeeByIdHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task<EmployeeDto> Handle(GetEmployeeByEmpNoQuery request, CancellationToken cancellationToken) => await _fakeDataStore.GetEmployeeByEmpNo(request.empno);
    }
}
