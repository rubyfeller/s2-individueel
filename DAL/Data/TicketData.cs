using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Functions
{
    public class TicketData : ITicketDal
    {
        private readonly DBCollection dbConnection = new DBCollection();
        int ticketResult;
        int updateTicketResult;
        int deleteTicketResult;
        CommentData commentData = new CommentData();
        // Add a new ticket
        public Object AddTicket(TicketDTO ticketDto)
        {
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("INSERT INTO Tickets (ticketSubject, ticketContent, createdDateTime, ticketCategory, ticketPriority, ticketStatus) VALUES (@TicketSubject, @TicketContent, @CreatedDateTime, @TicketCategory, @TicketPriority, @TicketStatus)", connection))
                {
                    command.Parameters.AddWithValue("@TicketSubject", ticketDto.TicketSubject);
                    command.Parameters.AddWithValue("@TicketContent", ticketDto.TicketContent);
                    command.Parameters.AddWithValue("@CreatedDateTime", ticketDto.CreatedDateTime);
                    command.Parameters.AddWithValue("@TicketCategory", (int)ticketDto.TicketCategory);
                    command.Parameters.AddWithValue("@TicketPriority", (int)ticketDto.TicketPriority);
                    command.Parameters.AddWithValue("@TicketStatus", (int)ticketDto.TicketStatus);
                    connection.Open();
                    ticketResult = command.ExecuteNonQuery();
                }
            }
            return ticketResult;
        }

        // Get all tickets
        public List<TicketDTO> GetTickets()
        {
            Ticket ticket = new Ticket();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Tickets ORDER BY ticketPriority DESC, CreatedDateTime";
                List<TicketDTO> ticketList = new();
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
                        ticketList.Add(new TicketDTO
                        {
                            TicketId = Convert.ToInt32(reader.GetInt32("TicketId")),
                            TicketSubject = reader.GetString("ticketSubject"),
                            TicketContent = reader.GetString("ticketContent"),
                            CreatedDateTime = reader.GetDateTime("createdDateTime"),
                            TicketCategory = (TicketDTO.TicketCategories)Convert.ToInt32(reader.GetInt32("ticketCategory")),
                            TicketPriority = (TicketDTO.TicketPriorities)Convert.ToInt32(reader.GetInt32("ticketPriority")),
                            TicketStatus = (TicketDTO.TicketStatuses)Convert.ToInt32(reader.GetInt32("ticketStatus")),
                        });
                    }
                }
                return ticketList;
            }
        }

        // Get specific ticket
        public TicketDTO GetTicket(int ticketid)
        {
            Ticket ticket = new Ticket();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                ticket.TicketId = ticketid;
                using (SqlCommand command = new SqlCommand("SELECT * FROM Tickets WHERE TicketId = @TicketId", connection))
                {
                    command.Parameters.AddWithValue("@TicketId", ticket.TicketId);
                    TicketDTO specificTicket = new();
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
                            //ticket.TicketLevel = (Ticket.TicketLevels)Convert.ToInt32(reader.GetInt32("ticketLevel"));
                            specificTicket = new TicketDTO()
                            {
                                TicketId = Convert.ToInt32(reader.GetInt32("ticketId")),
                                TicketSubject = reader.GetString("ticketSubject"),
                                TicketContent = reader.GetString("ticketContent"),
                                CreatedDateTime = reader.GetDateTime("createdDateTime"),
                                TicketCategory = (TicketDTO.TicketCategories)Convert.ToInt32(reader.GetInt32("ticketCategory")),
                                TicketPriority = (TicketDTO.TicketPriorities)Convert.ToInt32(reader.GetInt32("ticketPriority")),
                                TicketStatus = (TicketDTO.TicketStatuses)Convert.ToInt32(reader.GetInt32("ticketStatus")),
                                //TicketLevel = (Ticket.TicketLevels)Convert.ToInt32(reader.GetInt32("ticketLevel")),
                            };
                        }
                    }
                    return specificTicket;
                }
            }
        }

        // Update ticket
        public Object UpdateTicket(TicketDTO ticketDto)
        {
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("UPDATE Tickets SET ticketSubject = @TicketSubject, ticketContent = @TicketContent, ticketLevel = @TicketLevel, createdDateTime = @CreatedDateTime, ticketCategory = @TicketCategory, ticketPriority = @TicketPriority, ticketStatus = @TicketStatus WHERE ticketId = @TicketId", connection))
                {
                    command.Parameters.AddWithValue("@TicketId", ticketDto.TicketId);
                    command.Parameters.AddWithValue("@TicketSubject", ticketDto.TicketSubject);
                    command.Parameters.AddWithValue("@TicketContent", ticketDto.TicketContent);
                    command.Parameters.AddWithValue("@TicketStatus", ticketDto.TicketStatus);
                    command.Parameters.AddWithValue("@TicketLevel", ticketDto.TicketLevel);
                    command.Parameters.AddWithValue("@CreatedDateTime", ticketDto.CreatedDateTime);
                    command.Parameters.AddWithValue("@TicketCategory", ticketDto.TicketCategory);
                    command.Parameters.AddWithValue("@TicketPriority", ticketDto.TicketPriority);
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
