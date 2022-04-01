using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TicketSystemWeb.Models
{
    public class TicketViewModel
    {
        [Key]
        public int TicketId { get; set; }
        [Required(ErrorMessage = "Het invullen van een onderwerp is verplicht")]
        [DisplayName("Onderwerp")]
        public string TicketSubject { get; set; }
        [Required(ErrorMessage = "Het invullen van een probleemomschrijving is verplicht")]
        [DisplayName("Probleemomschrijving")]
        public string TicketContent { get; set; }
        [Required(ErrorMessage = "Het invullen van een categorie is verplicht")]
        public ticketCategories TicketCategory { get; set; }
        [Required(ErrorMessage = "Het invullen van een prioriteit is verplicht")]
        public ticketPriorities TicketPriority { get; set; }
        [Required(ErrorMessage = "Het invullen van een status is verplicht")]
        public ticketStatuses TicketStatus { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        //public int? ReplyId { get; set; }

        public enum ticketCategories
        {
            Windows,
            macOS,
            Printer,
            [Display(Name = "Interne systemen")] InterneSystemen
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
            [Display(Name = "In behandeling")] InBehandeling,
            Gesloten
        }
    }
}
