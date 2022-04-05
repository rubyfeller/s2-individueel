using System.ComponentModel.DataAnnotations;

namespace TicketSystemWeb.ViewModels
{
    public class CommentViewModel
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public int TicketId { get; set; }
    }
}
