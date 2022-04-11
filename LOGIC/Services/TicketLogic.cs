using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;

namespace LOGIC.TicketLogic
{
    public class TicketLogic : ITicketLogic
    {
        private ITicketDal _ticket;

        public TicketLogic(ITicketDal ticket)
        {
            _ticket = ticket;
        }
        public Object AddTicket(TicketDTO ticketDto)
        {
            var result = _ticket.AddTicket(ticketDto);

            return result;
        }

        public Object UpdateTicket(TicketDTO ticketDto)
        {
            var updateDeviceResult = _ticket.UpdateTicket(ticketDto);

            return updateDeviceResult;
        }

        public Boolean DeleteTicket(int ticketid)
        {
            var deleteDeviceResult = _ticket.DeleteTicket(ticketid);
            return deleteDeviceResult > 0;
        }

        public List<Ticket> GetTickets()
        {
            List<Ticket> tickets = _ticket.GetTickets();
            return tickets;
        }

        public List<Ticket> GetTicket(int ticketid)
        {
            List<Ticket> specificTicketList = _ticket.GetTicket(ticketid);
            return specificTicketList;
        }
        public List<Ticket> GetTicketAndComments(int ticketid)
        {
            List<Ticket> ticketAndCommentsList = _ticket.GetTicketAndComments(ticketid);
            return ticketAndCommentsList;
        }
    }
}
