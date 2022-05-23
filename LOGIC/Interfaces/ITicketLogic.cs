using LOGIC.DTO_s;
using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface ITicketLogic
    {
        int AddTicket(TicketDTO ticketDto);
        int UpdateTicket(TicketDTO ticketDto);
        Boolean DeleteTicket(int ticketid);
        List<Ticket> GetTickets(int ticketLevel);
        Ticket GetTicket(int ticketid);
    }
}
