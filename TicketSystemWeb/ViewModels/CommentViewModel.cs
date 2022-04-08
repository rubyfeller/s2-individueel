using LOGIC.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace TicketSystemWeb.ViewModels
{
    public class CommentViewModel
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
