using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface ICommentLogic
    {
        Boolean AddComment(string commentcontent, DateTime CreatedDateTime, int ticketid);
    }
}
