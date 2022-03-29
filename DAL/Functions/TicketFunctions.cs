using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class TicketFunctions : ITicket
    {
        DBCollection dbConnection = new DBCollection();
        int ticketResult;
        int updateTicketResult;
        int deleteTicketResult;

        // Add a new device
        public async Task<Int32> AddTicket(string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus)
        {
            Ticket newTicket = new Ticket
            {
                TicketSubject = ticketsubject,
                TicketContent = ticketcontent,
                CreatedDateTime = createddatetime,
                TicketCategory = ticketcategory,
                TicketPriority = ticketpriority,
                TicketStatus = ticketstatus,
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
                    ticketResult = await command.ExecuteNonQueryAsync();
                }
            }
            return ticketResult;
        }

        // Get all tickets
        public async Task<List<Ticket>> GetTickets()
        {
            Ticket ticket = new Ticket();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                await connection.OpenAsync();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Tickets";
                List<Ticket> ticketList = new();
                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        ticket.TicketId = reader.GetInt32("ticketId");
                        ticket.TicketSubject = reader.GetString("ticketSubject");
                        ticket.TicketContent = reader.GetString("ticketContent");
                        ticket.CreatedDateTime = reader.GetDateTime("createdDateTime");
                        ticket.TicketCategory = Convert.ToInt32(reader.GetInt32("ticketCategory"));
                        ticket.TicketPriority = Convert.ToInt32(reader.GetInt32("ticketPriority"));
                        ticket.TicketStatus = Convert.ToInt32(reader.GetInt32("ticketStatus"));
                        ticketList.Add(new Ticket
                        {
                            TicketId = Convert.ToInt32(reader.GetInt32("TicketId")),
                            TicketSubject = reader.GetString("ticketSubject"),
                            TicketContent = reader.GetString("ticketContent"),
                            CreatedDateTime = reader.GetDateTime("createdDateTime"),
                            TicketCategory = Convert.ToInt32(reader.GetInt32("ticketCategory")),
                            TicketPriority = Convert.ToInt32(reader.GetInt32("ticketPriority")),
                            TicketStatus = Convert.ToInt32(reader.GetInt32("ticketStatus")),
                        });
                    }
                }
                return ticketList;
            }
        }

        // Get specific ticket
        public async Task<List<Ticket>> GetTicket(int ticketid)
        {
            Ticket ticket = new Ticket();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                await connection.OpenAsync();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Tickets WHERE ticketId = " + ticketid;
                List<Ticket> specificTicketList = new();
                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        ticket.TicketId = Convert.ToInt32(reader.GetInt32("ticketId"));
                        ticket.TicketSubject = reader.GetString("ticketSubject");
                        ticket.TicketContent = reader.GetString("ticketContent");
                        ticket.CreatedDateTime = reader.GetDateTime("createdDateTime");
                        ticket.TicketCategory = Convert.ToInt32(reader.GetInt32("ticketCategory"));
                        ticket.TicketPriority = Convert.ToInt32(reader.GetInt32("ticketPriority"));
                        ticket.TicketStatus = Convert.ToInt32(reader.GetInt32("ticketStatus"));
                        specificTicketList.Add(new Ticket
                        {
                            TicketId = Convert.ToInt32(reader.GetInt32("ticketId")),
                            TicketSubject = reader.GetString("ticketSubject"),
                            TicketContent = reader.GetString("ticketContent"),
                            CreatedDateTime = reader.GetDateTime("createdDateTime"),
                            TicketCategory = Convert.ToInt32(reader.GetInt32("ticketCategory")),
                            TicketPriority = Convert.ToInt32(reader.GetInt32("ticketPriority")),
                            TicketStatus = Convert.ToInt32(reader.GetInt32("ticketStatus")),
                        });
                    }
                }
                return specificTicketList;
            }
        }

        // Update ticket
        public async Task<Int32> UpdateTicket(int ticketid, string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus)
        {
            Ticket newTicket = new Ticket
            {
                TicketId = ticketid,
                TicketSubject = ticketsubject,
                TicketContent = ticketcontent,
                CreatedDateTime = createddatetime,
                TicketCategory = ticketcategory,
                TicketPriority = ticketpriority,
                TicketStatus = ticketstatus,
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
                    updateTicketResult = await command.ExecuteNonQueryAsync();
                }
            }
            return updateTicketResult;
        }

        public async Task<Int32> DeleteTicket(int ticketid)
        {
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("DELETE FROM Tickets WHERE ticketId = @TicketId", connection))
                {
                    command.Parameters.AddWithValue("@TicketId", ticketid);
                    connection.Open();
                    deleteTicketResult = await command.ExecuteNonQueryAsync();
                }
            }
            return deleteTicketResult;
        }
    }
}