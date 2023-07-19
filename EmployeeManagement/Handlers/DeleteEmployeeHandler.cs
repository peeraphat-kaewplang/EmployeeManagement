using EmployeeManagement.Commands;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly FakeDataStore _fakeDataStore;
        public DeleteEmployeeHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.DeleteEmployee(request.empno);
            return Unit.Value;
        }
    }
}
