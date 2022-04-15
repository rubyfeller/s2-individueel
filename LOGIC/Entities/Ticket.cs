using System.ComponentModel.DataAnnotations;

namespace LOGIC.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
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
        [Required]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public IEnumerable<Comment>? Comments { get; set; }
        public IEnumerable<Device>? Devices { get; set; }
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
    }
}
