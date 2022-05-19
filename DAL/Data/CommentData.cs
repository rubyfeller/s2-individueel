using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DAL.Functions
{
    public class CommentData : ICommentDal
    {
        readonly DBCollection dbConnection = new DBCollection();
        int commentResult;
        int deleteCommentResult;

        // Get comments based on ticketid
        public List<CommentDTO> GetComments(int ticketid)
        {
            Comment comment = new Comment();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Comments WHERE ticketId = @TicketId", connection))
                {
                    command.Parameters.AddWithValue("@TicketId", ticketid);
                    List<Comment> specificTicketList = new();
                    List<CommentDTO> specificCommentList = new();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comment.CommentId = Convert.ToInt32(reader.GetInt32("commentId"));
                            comment.CommentContent = reader.GetString("commentContent");
                            comment.CreatedDateTime = reader.GetDateTime("CreatedDateTime");
                            comment.TicketId = Convert.ToInt32(reader.GetInt32(("ticketId")));

                            specificCommentList.Add(new CommentDTO
                            {
                                CommentId = comment.CommentId,
                                CommentContent = comment.CommentContent,
                                CreatedDateTime = comment.CreatedDateTime,
                                TicketId = comment.TicketId,
                            });
                        }
                    }
                    return specificCommentList;
                }
            }
        }

        // Add a new comment
        public int AddComment(CommentDTO comment)
        {
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("INSERT INTO Comments (commentContent, CreatedDateTime, ticketId) VALUES (@CommentContent, @CreatedDateTime, @TicketId)", connection))
                {
                    command.Parameters.AddWithValue("@CommentContent", comment.CommentContent);
                    command.Parameters.AddWithValue("@CreatedDateTime", comment.CreatedDateTime);
                    command.Parameters.AddWithValue("@TicketId", comment.TicketId);
                    connection.Open();
                    commentResult = command.ExecuteNonQuery();
                }
            }
            return commentResult;
        }

        // Delete comment
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
