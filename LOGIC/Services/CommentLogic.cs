using LOGIC.DTO_s;
using LOGIC.Entities;
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
        private readonly ICommentDal _comment;
        public CommentLogic(ICommentDal comment)
        {
            _comment = comment;
        }

        public List<Comment> GetComments(int ticketid)
        {
            List<CommentDTO> commentsDto = _comment.GetComments(ticketid);
            List<Comment> comments = new();

            foreach (var comment in commentsDto)
            {
                comments.Add(new Comment
                {
                    TicketId = comment.TicketId,
                    CommentId = comment.CommentId,
                    CommentContent = comment.CommentContent,
                    CreatedDateTime = comment.CreatedDateTime,
                });
            }

            return comments;
        }

        public Object AddComment(CommentDTO commentDto)
        {
            Object result = _comment.AddComment(commentDto);

            return result;
        }

        public Boolean DeleteComment(int commentid)
        {
            var deleteCommentResult = _comment.DeleteComment(commentid);
            return deleteCommentResult > 0;
        }
    }
}
