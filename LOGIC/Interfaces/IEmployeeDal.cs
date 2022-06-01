using LOGIC.DTO_s;

namespace LOGIC.Interfaces
{
    public interface IEmployeeDal
    {
        List<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployee(int employeeId);
    }
}
