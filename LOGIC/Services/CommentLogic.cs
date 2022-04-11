using LOGIC.DTO_s;
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
        private ICommentDal _comment;
        public CommentLogic(ICommentDal comment)
        {
            _comment = comment;
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
