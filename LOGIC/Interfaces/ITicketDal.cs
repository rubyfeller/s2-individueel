using LOGIC.DTO_s;
using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface ITicketDal
    {
        Object AddTicket(TicketDTO ticketDto);
        Object UpdateTicket(TicketDTO ticketDto);
        int DeleteTicket(int ticketid);
        List<Ticket> GetTickets();
        List<Ticket> GetTicket(int ticketid);
        List<Ticket> GetTicketAndComments(int ticketid);
    }
}
