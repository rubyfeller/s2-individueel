using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Functions
{
    public class EmployeeData : IEmployeeDal
    {
        private readonly DBCollection dbConnection = new DBCollection();

        // Get all employees
        public List<EmployeeDTO> GetEmployees()
        {
            Employee employee = new Employee();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Employees";
                List<EmployeeDTO> employeeList = new();
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
                        employeeList.Add(new EmployeeDTO
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

        public EmployeeDTO GetEmployee(int employeeId)
        {
            Employee employee = new Employee();
            var connectionString = dbConnection.GetConnectionString();
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();
            employee.EmployeeId = employeeId;
            using SqlCommand command = new SqlCommand("SELECT * FROM Employees WHERE employeeId = @EmployeeId", connection);
            command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            EmployeeDTO specificEmployee = new();
            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(reader.GetInt32("employeeId"));
                    employee.FirstName = reader.GetString("firstName");
                    employee.LastName = reader.GetString("lastName");
                    employee.Password = reader.GetString("password");
                    employee.Email = reader.GetString("email");
                    employee.CompetenceLevel = Convert.ToInt32(reader.GetInt32("competenceLevel"));
                    employee.Role = Convert.ToInt32(reader.GetInt32("role"));

                    specificEmployee = new EmployeeDTO()
                    {
                        EmployeeId = Convert.ToInt32(reader.GetInt32("employeeId")),
                        FirstName = reader.GetString("firstName"),
                        LastName = reader.GetString("lastName"),
                        Password = reader.GetString("password"),
                        Email = reader.GetString("email"),
                        CompetenceLevel = Convert.ToInt32(reader.GetInt32("competenceLevel")),
                        Role = Convert.ToInt32(reader.GetInt32("role")),
                    };
                }
                return specificEmployee;
            }
        }
    }
}