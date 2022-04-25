using System.ComponentModel.DataAnnotations;

namespace TicketSystemWeb.ViewModels
{
    public class EmployeeAccountViewModel
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
