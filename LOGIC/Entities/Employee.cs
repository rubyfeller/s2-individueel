using System.ComponentModel.DataAnnotations;

namespace LOGIC.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int CompetenceLevel { get; set; }
        public int Role { get; set; }
    }
}
