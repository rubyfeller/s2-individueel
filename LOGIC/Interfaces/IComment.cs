namespace LOGIC.Interfaces
{
    public interface IComment
    {
        int AddComment(string commentcontent, DateTime CreatedDateTime, int ticketid);
    }
}
