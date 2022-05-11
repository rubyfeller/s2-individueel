using LOGIC.DTO_s;

namespace LOGIC.Interfaces
{
    public interface ICommentLogic
    {
        Object AddComment(CommentDTO commentDto);
        Boolean DeleteComment(int commentid);
    }
}
