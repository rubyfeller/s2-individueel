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
        public int AddComment(string commentcontent, int ticketid)
        {
            Comment newComment = new Comment
            {
                CommentContent = commentcontent,
                TicketId = ticketid,
            };
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("INSERT INTO Comments (commentContent, ticketId) VALUES (@CommentContent, @TicketId)", connection))
                {
                    command.Parameters.AddWithValue("@CommentContent", newComment.CommentContent);
                    command.Parameters.AddWithValue("@TicketId", newComment.TicketId);
                    connection.Open();
                    commentResult = command.ExecuteNonQuery();
                }
            }
            return commentResult;
        }
    }
}
