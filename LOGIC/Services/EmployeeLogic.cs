using LOGIC.Entities;
using LOGIC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
