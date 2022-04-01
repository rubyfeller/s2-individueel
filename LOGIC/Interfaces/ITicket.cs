using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface ITicket
    {
        Int32 AddTicket(string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus);
        Int32 UpdateTicket(int ticketid, string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus);
        Int32 DeleteTicket(int ticketid);
        List<Ticket> GetTickets();
        List<Ticket> GetTicket(int ticketid);
    }
}
