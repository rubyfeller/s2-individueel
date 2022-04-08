using LOGIC.Entities;
using LOGIC.Interfaces;

namespace LOGIC.TicketLogic
{
    public class TicketLogic : ITicketLogic
    {
        private ITicket _ticket;

        public TicketLogic(ITicket ticket)
        {
            _ticket = ticket;
        }
        public Boolean AddTicket(string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus)
        {
            var result = _ticket.AddTicket(ticketsubject, ticketcontent, createddatetime, ticketcategory, ticketpriority, ticketstatus);
            return result > 0;
        }

        public Boolean UpdateTicket(int ticketid, string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus)
        {
            var updateDeviceResult = _ticket.UpdateTicket(ticketid, ticketsubject, ticketcontent, createddatetime, ticketcategory, ticketpriority, ticketstatus);
            return updateDeviceResult > 0;
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
