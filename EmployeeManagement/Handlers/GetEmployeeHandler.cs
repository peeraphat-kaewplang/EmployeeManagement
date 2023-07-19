using EmployeeManagement.Queries;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeQuery, IEnumerable<EmployeeDto>>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetEmployeeHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken) 
            => await _fakeDataStore.GetAllEmployee();

    }
}
