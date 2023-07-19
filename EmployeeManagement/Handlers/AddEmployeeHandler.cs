using EmployeeManagement.Commands;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, Unit>
    {
        private readonly FakeDataStore _fakeDataStore;
        public AddEmployeeHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<Unit> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddEmployee(request.Employee);
            return Unit.Value;
        }
    }
}
