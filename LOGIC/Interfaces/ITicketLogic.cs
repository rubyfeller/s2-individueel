using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface ITicketLogic
    {
        Boolean AddTicket(string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus);
        Boolean UpdateTicket(int ticketid, string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus);
        Boolean DeleteTicket(int ticketid);
        List<Ticket> GetTickets();
        List<Ticket> GetTicket(int ticketid);
        List<Ticket> GetTicketAndComments(int ticketid);
    }
}
