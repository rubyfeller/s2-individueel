using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOGIC.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        [ForeignKey("FK_Comments_Tickets")]
        public int TicketId { get; set; }
    }
}
