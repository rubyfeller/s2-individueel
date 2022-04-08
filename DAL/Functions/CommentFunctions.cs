using LOGIC.Entities;
using LOGIC.Interfaces;
using System.Data.SqlClient;

namespace DAL.Functions
{
    public class CommentFunctions : IComment
    {
        readonly DBCollection dbConnection = new DBCollection();
        int commentResult;

        // Add a new device
        public int AddComment(string commentcontent, DateTime CreatedDateTime, int ticketid)
        {
            Comment newComment = new Comment
            {
                CommentContent = commentcontent,
                CreatedDateTime = System.DateTime.Now,
                TicketId = ticketid,
            };
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("INSERT INTO Comments (commentContent, CreatedDateTime, ticketId) VALUES (@CommentContent, @CreatedDateTime, @TicketId)", connection))
                {
                    command.Parameters.AddWithValue("@CommentContent", newComment.CommentContent);
                    command.Parameters.AddWithValue("@CreatedDateTime", newComment.CreatedDateTime);
                    command.Parameters.AddWithValue("@TicketId", newComment.TicketId);
                    connection.Open();
                    commentResult = command.ExecuteNonQuery();
                }
            }
            return commentResult;
        }
    }
}
