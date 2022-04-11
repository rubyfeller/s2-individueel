using LOGIC.DTO_s;

namespace LOGIC.Interfaces
{
    public interface ICommentDal
    {
        int DeleteComment(int commentid);
        Object AddComment(CommentDTO commentDto);
    }
}
