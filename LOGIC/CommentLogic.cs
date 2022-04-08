using LOGIC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class CommentLogic : ICommentLogic
    {
        private IComment _comment;
        public CommentLogic(IComment comment)
        {
            _comment = comment;
        }
        public Boolean AddComment(string commentContent, DateTime CreatedDateTime, int ticketid)
        {
            var result = _comment.AddComment(commentContent, CreatedDateTime, ticketid);
            return result > 0;
        }
    }
}
