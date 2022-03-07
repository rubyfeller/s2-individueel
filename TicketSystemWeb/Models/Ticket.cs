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
        [Required(ErrorMessage = "Het invullen van een onderwerp is verplicht")]
        [DisplayName("Onderwerp")]
        public string ticketSubject { get; set; }
        [Required(ErrorMessage = "Het invullen van een probleemomschrijving is verplicht")]
        [DisplayName("Probleemomschrijving")]
        public string ticketContent { get; set; }
        public int displayOrder { get; set; }
        [Required(ErrorMessage = "Het invullen van een categorie is verplicht")]
        public int ticketCategory { get; set; }
        [Required(ErrorMessage = "Het invullen van een prioriteit is verplicht")]
        public int ticketPriority { get; set; }
        [Required(ErrorMessage = "Het invullen van een status is verplicht")]
        public int ticketStatus { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
