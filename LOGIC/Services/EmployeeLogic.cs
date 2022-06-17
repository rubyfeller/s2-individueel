using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;

namespace LOGIC.Services
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeDal _employee;

        public EmployeeLogic(IEmployeeDal employee)
        {
            _employee = employee;
        }
        public List<Employee> GetEmployees()
        {
            List<EmployeeDTO> employees = _employee.GetEmployees();

            List<Employee> employeesList = new List<Employee>();

            foreach (var employee in employees)
            {
                employeesList.Add(new Employee
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Password = employee.Password,
                    CompetenceLevel = employee.CompetenceLevel,
                    Role = employee.Role,
                });
            }
            return employeesList;
        }

        public Employee GetEmployee(int employeeId)
        {
            EmployeeDTO employee = _employee.GetEmployee(employeeId);

            Employee specificEmployee = new Employee
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Password = employee.Password,
                Email = employee.Email,
                CompetenceLevel = employee.CompetenceLevel,
                Role = employee.Role,
            };
            return specificEmployee;
        }
    }
}
