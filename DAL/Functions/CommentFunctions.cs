using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using System.Data.SqlClient;

namespace DAL.Functions
{
    public class CommentFunctions : ICommentDal
    {
        readonly DBCollection dbConnection = new DBCollection();
        Object commentResult;
        int deleteCommentResult;

        // Add a new device
        public Object AddComment(CommentDTO comment)
        {
            Comment newComment = new Comment
            {
                CommentContent = comment.CommentContent,
                CreatedDateTime = System.DateTime.Now,
                TicketId = comment.TicketId,
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

        // Delete ticket
        public Int32 DeleteComment(int commentid)
        {
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("DELETE FROM Comments WHERE commentId = @CommentId", connection))
                {
                    command.Parameters.AddWithValue("@CommentId", commentid);
                    connection.Open();
                    deleteCommentResult = command.ExecuteNonQuery();
                }
            }
            return deleteCommentResult;
        }
    }
}
