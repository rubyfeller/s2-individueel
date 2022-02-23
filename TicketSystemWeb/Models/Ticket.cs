using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystemWeb.Models
{
    public class Ticket
    {
        [Key]
        public int ticketId { get; set; }
        [Required]
        [DisplayName("Onderwerp")]
        public string ticketSubject { get; set; }
        [Required]
        [DisplayName("Probleemomschrijving")]
        public string ticketContent { get; set; }
        public int displayOrder { get; set; }
        public int ticketCategory { get; set; }
        public int ticketPriority { get; set; } 
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
