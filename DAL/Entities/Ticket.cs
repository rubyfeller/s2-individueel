using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
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
