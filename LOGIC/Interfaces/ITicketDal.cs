using LOGIC.DTO_s;

namespace LOGIC.Interfaces
{
    public interface ITicketDal
    {
        Object AddTicket(TicketDTO ticketDto);
        Object UpdateTicket(TicketDTO ticketDto);
        int DeleteTicket(int ticketid);
        List<TicketDTO> GetTickets();
        TicketDTO GetTicket(int ticketid);
    }
}
