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
        public int ticketId { get; set; }
        [Required]
        public string ticketSubject { get; set; }
        [Required]
        public string ticketContent { get; set; }
        [Required]
        public int ticketCategory { get; set; }
        [Required]
        public int ticketPriority { get; set; }
        [Required]
        public ticketStatuses ticketStatus { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int? replyId { get; set; }

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
