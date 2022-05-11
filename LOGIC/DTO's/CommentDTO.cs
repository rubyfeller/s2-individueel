namespace LOGIC.DTO_s
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int TicketId { get; set; }
    }
}
