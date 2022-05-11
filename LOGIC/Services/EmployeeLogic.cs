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
            List<Employee> employees = _employee.GetEmployees();
            return employees;
        }
    }
}
