using EmployeeManagement.Commands;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class EditEmployeeHandler : IRequestHandler<EditEmployeeCommand, Unit>
    {
        private readonly FakeDataStore _fakeDataStore;
        public EditEmployeeHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task<Unit> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EditEmployee(request.Employee, request.empno);
            return Unit.Value;
        }
    }
}
