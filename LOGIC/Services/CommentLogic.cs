﻿using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;

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

        public int AddComment(CommentDTO commentDto)
        {
            int result = _comment.AddComment(commentDto);

            return result;
        }

        public Boolean DeleteComment(int commentid)
        {
            var deleteCommentResult = _comment.DeleteComment(commentid);
            return deleteCommentResult > 0;
        }
    }
}
