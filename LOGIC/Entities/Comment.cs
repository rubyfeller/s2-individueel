using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOGIC.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
