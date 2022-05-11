using LOGIC.DTO_s;

namespace LOGIC.Interfaces
{
    public interface ICommentDal
    {
        List<CommentDTO> GetComments(int ticketid);
        int DeleteComment(int commentid);
        Object AddComment(CommentDTO commentDto);
    }
}
