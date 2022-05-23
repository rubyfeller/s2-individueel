using LOGIC.DTO_s;

namespace LOGIC.Interfaces
{
    public interface ITicketDal
    {
        int AddTicket(TicketDTO ticketDto);
        int UpdateTicket(TicketDTO ticketDto);
        int DeleteTicket(int ticketid);
        List<TicketDTO> GetTickets(int ticketLevel);
        TicketDTO GetTicket(int ticketid);
    }
}
