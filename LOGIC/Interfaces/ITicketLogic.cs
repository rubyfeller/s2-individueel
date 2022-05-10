using LOGIC.DTO_s;
using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface ITicketLogic
    {
        Object AddTicket(TicketDTO ticketDto);
        Object UpdateTicket(TicketDTO ticketDto);
        Boolean DeleteTicket(int ticketid);
        List<Ticket> GetTickets();
        Ticket GetTicket(int ticketid);
    }
}
