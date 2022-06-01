using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface IEmployeeLogic
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
    }
}
