using LOGIC.Entities;
using LOGIC.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class AccountFunctions : IEmployeeDal
    {
        private readonly DBCollection dbConnection = new DBCollection();

        // Get all tickets
        public List<Employee> GetEmployees()
        {
            Employee employee = new Employee();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Employees";
                List<Employee> employeeList = new();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employee.EmployeeId = reader.GetInt32("employeeId");
                        employee.FirstName = reader.GetString("firstName");
                        employee.LastName = reader.GetString("lastName");
                        employee.Password = reader.GetString("password");
                        employee.CompetenceLevel = Convert.ToInt32(reader.GetInt32("competenceLevel"));
                        employee.Role = Convert.ToInt32(reader.GetInt32("role"));
                        employeeList.Add(new Employee
                        {
                            EmployeeId = reader.GetInt32("employeeId"),
                            FirstName = reader.GetString("firstName"),
                            LastName = reader.GetString("lastName"),
                            Password = reader.GetString("password"),
                            CompetenceLevel = Convert.ToInt32(reader.GetInt32("competenceLevel")),
                            Role = Convert.ToInt32(reader.GetInt32("role")),
                        });
                    }
                }
                return employeeList;
            }
        }
    }
}
