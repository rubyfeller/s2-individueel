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
        public ticketCategories TicketCategory { get; set; }
        [Required]
        public ticketPriorities TicketPriority { get; set; }
        [Required]
        public ticketStatuses TicketStatus { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        //public int? ReplyId { get; set; }

        public enum ticketCategories
        {
            Windows,
            macOS,
            Printer,
            InterneSystemen
        }
        public enum ticketPriorities
        {
            Laag,
            Gemiddeld,
            Hoog,
            Kritiek
        }
        public enum ticketStatuses
        {
            Open,
            InBehandeling,
            Gesloten
        }
    }
}
