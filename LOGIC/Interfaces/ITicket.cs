using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface ITicket
    {
        int AddTicket(string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus);
        int UpdateTicket(int ticketid, string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus);
        int DeleteTicket(int ticketid);
        List<Ticket> GetTickets();
        List<Ticket> GetTicket(int ticketid);
        List<Ticket> GetTicketAndComments(int ticketid);
    }
}
