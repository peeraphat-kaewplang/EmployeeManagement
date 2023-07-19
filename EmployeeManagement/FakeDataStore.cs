namespace EmployeeManagement
{
    public class FakeDataStore
    {
        private static List<Employee> _employees = new();
        public FakeDataStore()
        {
            _employees = new List<Employee>
            {
                new Employee { EMPNO = "1001" , FIRST_NAME = "STEFAN" , LAST_NAME ="SALVATORE" , DESIGNATION ="BUSSINESS ANALYST" , HIREDATE = DateTime.Now ,SALARY=50000 , COMM = "" , DEPTNO=40},
                new Employee { EMPNO = "1002" , FIRST_NAME = "DIANA" , LAST_NAME ="LORRENCE" , DESIGNATION ="TECHNIAL ARCHITECT" , HIREDATE = DateTime.Now ,SALARY=70000 , COMM = "" , DEPTNO=10},
            };
        }

        public async Task AddEmployee(EmployeeDto employee)
        {
            _employees.Add(new Employee
            {
                EMPNO = employee.EMPNO,
                SALARY = employee.SALARY,
                FIRST_NAME = employee.FIRST_NAME,
                LAST_NAME = employee.LAST_NAME,
                COMM = employee.COMM,
                DEPTNO = employee.DEPTNO,
                DESIGNATION = employee.DESIGNATION,
                HIREDATE = DateTime.Parse(employee.HIREDATE)
            });
            await Task.CompletedTask;
        }
        public async Task EditEmployee(EmployeeDto employee , string empno)
        {
            var emp = _employees.Single(e => e.EMPNO == empno);
            if(emp != null)
            {
                _employees.Remove(emp);
                await AddEmployee(employee);
                await Task.CompletedTask;
            }
        }
        public async Task DeleteEmployee(string empno)
        {
            var emp = _employees.Single(e => e.EMPNO == empno);
            if (emp != null)
            {
                _employees.Remove(emp);
                await Task.CompletedTask;
            }
        }
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployee() => await Task.FromResult(_employees.Select(e => new EmployeeDto
        {
            EMPNO = e.EMPNO,
            FIRST_NAME = e.FIRST_NAME,
            LAST_NAME = e.LAST_NAME,
            DESIGNATION = e.DESIGNATION,
            HIREDATE = e.HIREDATE.ToString("dd-MMMM-y"),
            COMM = string.IsNullOrEmpty(e.COMM) ? "-" : e.COMM,
            DEPTNO = e.DEPTNO,
            SALARY = e.SALARY,
        }));

        public async Task<EmployeeDto> GetEmployeeByEmpNo(string empno) => await Task.FromResult(_employees.Select(e => new EmployeeDto
        {
            EMPNO = e.EMPNO,
            FIRST_NAME = e.FIRST_NAME,
            LAST_NAME = e.LAST_NAME,
            DESIGNATION = e.DESIGNATION,
            HIREDATE = e.HIREDATE.ToString("dd-MMMM-y"),
            COMM = string.IsNullOrEmpty(e.COMM) ? "-" : e.COMM,
            DEPTNO = e.DEPTNO,
            SALARY = e.SALARY,
        }).Single(p => p.EMPNO == empno));
    }
}
