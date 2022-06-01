using LOGIC.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TicketSystemWeb.Models
{
    public class TicketViewModel
    {
        [Key]
        public int TicketId { get; set; }
        public int DeviceId { get; set; }
        [Required(ErrorMessage = "Het invullen van een onderwerp is verplicht")]
        [DisplayName("Onderwerp")]
        public string TicketSubject { get; set; }
        [Required(ErrorMessage = "Het invullen van een probleemomschrijving is verplicht")]
        [DisplayName("Probleemomschrijving")]
        public string TicketContent { get; set; }
        [Required(ErrorMessage = "Het invullen van een categorie is verplicht")]
        public TicketCategories TicketCategory { get; set; }
        [Required(ErrorMessage = "Het invullen van een prioriteit is verplicht")]
        public TicketPriorities TicketPriority { get; set; }
        [Required(ErrorMessage = "Het invullen van een status is verplicht")]
        public TicketStatuses TicketStatus { get; set; }
        public TicketLevels TicketLevel { get; set; }
        public int ResponsibleEmployee { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public List<Comment>? Comments { get; set; }
        public string CommentContent { get; set; }
        public Device? Device { get; set; }
        public Employee? Employee { get; set; }
        public List<Employee>? Employees { get; set; }
        public Client? Client { get; set; }
        public enum TicketCategories
        {
            Windows,
            macOS,
            Printer,
            [Display(Name = "Interne systemen")] InterneSystemen
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
            [Display(Name = "In behandeling")] InBehandeling,
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
