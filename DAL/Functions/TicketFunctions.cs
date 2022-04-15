using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Functions
{
    public class TicketFunctions : ITicketDal
    {
        private readonly DBCollection dbConnection = new DBCollection();
        int ticketResult;
        int updateTicketResult;
        int deleteTicketResult;

        // Add a new ticket
        public Object AddTicket(TicketDTO ticketDto)
        {
            Ticket newTicket = new Ticket
            {
                TicketSubject = ticketDto.TicketSubject,
                TicketContent = ticketDto.TicketContent,
                CreatedDateTime = ticketDto.CreatedDateTime,
                TicketCategory = (Ticket.TicketCategories)ticketDto.TicketCategory,
                TicketPriority = (Ticket.TicketPriorities)ticketDto.TicketPriority,
                TicketStatus = (Ticket.TicketStatuses)ticketDto.TicketStatus,
            };
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("INSERT INTO Tickets (ticketSubject, ticketContent, createdDateTime, ticketCategory, ticketPriority, ticketStatus) VALUES (@TicketSubject, @TicketContent, @CreatedDateTime, @TicketCategory, @TicketPriority, @TicketStatus)", connection))
                {
                    command.Parameters.AddWithValue("@TicketSubject", newTicket.TicketSubject);
                    command.Parameters.AddWithValue("@TicketContent", newTicket.TicketContent);
                    command.Parameters.AddWithValue("@CreatedDateTime", newTicket.CreatedDateTime);
                    command.Parameters.AddWithValue("@TicketCategory", newTicket.TicketCategory);
                    command.Parameters.AddWithValue("@TicketPriority", newTicket.TicketPriority);
                    command.Parameters.AddWithValue("@TicketStatus", newTicket.TicketStatus);
                    connection.Open();
                    ticketResult = command.ExecuteNonQuery();
                }
            }
            return ticketResult;
        }

        // Get all tickets
        public List<Ticket> GetTickets()
        {
            Ticket ticket = new Ticket();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Tickets ORDER BY ticketPriority DESC, CreatedDateTime";
                List<Ticket> ticketList = new();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ticket.TicketId = reader.GetInt32("ticketId");
                        ticket.TicketSubject = reader.GetString("ticketSubject");
                        ticket.TicketContent = reader.GetString("ticketContent");
                        ticket.CreatedDateTime = reader.GetDateTime("createdDateTime");
                        ticket.TicketCategory = (Ticket.TicketCategories)Convert.ToInt32(reader.GetInt32("ticketCategory"));
                        ticket.TicketPriority = (Ticket.TicketPriorities)Convert.ToInt32(reader.GetInt32("ticketPriority"));
                        ticket.TicketStatus = (Ticket.TicketStatuses)Convert.ToInt32(reader.GetInt32("ticketStatus"));
                        ticketList.Add(new Ticket
                        {
                            TicketId = Convert.ToInt32(reader.GetInt32("TicketId")),
                            TicketSubject = reader.GetString("ticketSubject"),
                            TicketContent = reader.GetString("ticketContent"),
                            CreatedDateTime = reader.GetDateTime("createdDateTime"),
                            TicketCategory = (Ticket.TicketCategories)Convert.ToInt32(reader.GetInt32("ticketCategory")),
                            TicketPriority = (Ticket.TicketPriorities)Convert.ToInt32(reader.GetInt32("ticketPriority")),
                            TicketStatus = (Ticket.TicketStatuses)Convert.ToInt32(reader.GetInt32("ticketStatus")),
                        });
                    }
                }
                return ticketList;
            }
        }

        // Get specific ticket
        public List<Ticket> GetTicket(int ticketid)
        {
            Ticket ticket = new Ticket();
            Comment comment = new Comment();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                // DbCommand command = connection.CreateCommand();
                ticket.TicketId = ticketid;
                using (SqlCommand command = new SqlCommand("SELECT * FROM Tickets WHERE TicketId = @TicketId", connection))
                {
                    command.Parameters.AddWithValue("@TicketId", ticket.TicketId);
                    List<Ticket> specificTicketList = new();
                    List<Comment> specificCommentList = new();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ticket.TicketId = Convert.ToInt32(reader.GetInt32("ticketId"));
                            ticket.TicketSubject = reader.GetString("ticketSubject");
                            ticket.TicketContent = reader.GetString("ticketContent");
                            ticket.CreatedDateTime = reader.GetDateTime("createdDateTime");
                            ticket.TicketCategory = (Ticket.TicketCategories)Convert.ToInt32(reader.GetInt32("ticketCategory"));
                            ticket.TicketPriority = (Ticket.TicketPriorities)Convert.ToInt32(reader.GetInt32("ticketPriority"));
                            ticket.TicketStatus = (Ticket.TicketStatuses)Convert.ToInt32(reader.GetInt32("ticketStatus"));
                            specificTicketList.Add(new Ticket
                            {
                                TicketId = Convert.ToInt32(reader.GetInt32("ticketId")),
                                TicketSubject = reader.GetString("ticketSubject"),
                                TicketContent = reader.GetString("ticketContent"),
                                CreatedDateTime = reader.GetDateTime("createdDateTime"),
                                TicketCategory = (Ticket.TicketCategories)Convert.ToInt32(reader.GetInt32("ticketCategory")),
                                TicketPriority = (Ticket.TicketPriorities)Convert.ToInt32(reader.GetInt32("ticketPriority")),
                                TicketStatus = (Ticket.TicketStatuses)Convert.ToInt32(reader.GetInt32("ticketStatus")),
                                Comments = GetComments(ticketid),
                            });

                            GetComments(ticketid);
                        }
                    }
                    return specificTicketList;
                }
            }
        }

        // Get comments based on ticketid
        public List<Comment> GetComments(int ticketid)
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
                    List<Comment> specificCommentList = new();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comment.CommentId = Convert.ToInt32(reader.GetInt32("commentId"));
                            comment.CommentContent = reader.GetString("commentContent");
                            comment.CreatedDateTime = reader.GetDateTime("CreatedDateTime");
                            comment.TicketId = Convert.ToInt32(reader.GetInt32(("ticketId")));

                            specificCommentList.Add(new Comment
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

        // Update ticket
        public Object UpdateTicket(TicketDTO ticketDto)
        {
            Ticket newTicket = new Ticket
            {
                TicketId = ticketDto.TicketId,
                TicketSubject = ticketDto.TicketSubject,
                TicketContent = ticketDto.TicketContent,
                CreatedDateTime = ticketDto.CreatedDateTime,
                TicketCategory = (Ticket.TicketCategories)ticketDto.TicketCategory,
                TicketPriority = (Ticket.TicketPriorities)ticketDto.TicketPriority,
                TicketStatus = (Ticket.TicketStatuses)ticketDto.TicketStatus,
            };
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("UPDATE Tickets SET ticketSubject = @TicketSubject, ticketContent = @TicketContent, createdDateTime = @CreatedDateTime, ticketCategory = @TicketCategory, ticketPriority = @TicketPriority, ticketStatus = @TicketStatus WHERE ticketId = @TicketId", connection))
                {
                    command.Parameters.AddWithValue("@TicketId", newTicket.TicketId);
                    command.Parameters.AddWithValue("@TicketSubject", newTicket.TicketSubject);
                    command.Parameters.AddWithValue("@TicketContent", newTicket.TicketContent);
                    command.Parameters.AddWithValue("@CreatedDateTime", newTicket.CreatedDateTime);
                    command.Parameters.AddWithValue("@TicketCategory", newTicket.TicketCategory);
                    command.Parameters.AddWithValue("@TicketPriority", newTicket.TicketPriority);
                    command.Parameters.AddWithValue("@TicketStatus", newTicket.TicketStatus);
                    connection.Open();
                    updateTicketResult = command.ExecuteNonQuery();
                }
            }
            return updateTicketResult;
        }

        // Delete ticket
        public int DeleteTicket(int ticketid)
        {
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("DELETE FROM Tickets WHERE ticketId = @TicketId", connection))
                {
                    command.Parameters.AddWithValue("@TicketId", ticketid);
                    connection.Open();
                    deleteTicketResult = command.ExecuteNonQuery();
                }
            }
            return deleteTicketResult;
        }
    }
}
