using System.ComponentModel.DataAnnotations;

namespace LOGIC.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public int DeviceId { get; set; }
        [Required]
        public string TicketSubject { get; set; }
        [Required]
        public string TicketContent { get; set; }
        [Required]
        public TicketCategories TicketCategory { get; set; }
        [Required]
        public TicketPriorities TicketPriority { get; set; }
        [Required]
        public TicketStatuses TicketStatus { get; set; }
        public TicketLevels TicketLevel { get; set; }
        public int ResponsibleEmployee { get; set; }
        public int ClientId { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public List<Comment>? Comments { get; set; }
        public Device? Device { get; set; }
        public Employee? Employee { get; set; }
        public List<Employee>? Employees { get; set; }
        public Client? Client { get; set; }
        public enum TicketCategories
        {
            Windows,
            macOS,
            Printer,
            InterneSystemen
        }
        public enum TicketPriorities
        {
            Laag,
            Gemiddeld,
            Hoog,
            Kritiek
        }
        public enum TicketStatuses
        {
            Open,
            InBehandeling,
            Gesloten
        }
        public enum TicketLevels
        {
            Moeilijk,
            Gemiddeld,
            Simpel
        }
    }
}
