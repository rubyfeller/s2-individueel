using LOGIC.DTO_s;

namespace LOGIC.Interfaces
{
    public interface ICommentLogic
    {
        int AddComment(CommentDTO commentDto);
        Boolean DeleteComment(int commentid);
    }
}
