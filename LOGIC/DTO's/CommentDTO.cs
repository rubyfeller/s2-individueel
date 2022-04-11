using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.DTO_s
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int TicketId { get; set; }
    }
}
