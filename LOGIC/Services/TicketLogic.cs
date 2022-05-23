using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;

namespace LOGIC.TicketLogic
{
    public class TicketLogic : ITicketLogic
    {
        private readonly ITicketDal _ticket;
        private readonly ICommentDal _comment;

        public TicketLogic(ITicketDal ticket, ICommentDal comment)
        {
            _ticket = ticket;
            _comment = comment;
        }

        public int AddTicket(TicketDTO ticketDto)
        {
            var result = _ticket.AddTicket(ticketDto);

            return result;
        }

        public int UpdateTicket(TicketDTO ticketDto)
        {
            var updateDeviceResult = _ticket.UpdateTicket(ticketDto);

            return updateDeviceResult;
        }

        public Boolean DeleteTicket(int ticketid)
        {
            var deleteDeviceResult = _ticket.DeleteTicket(ticketid);
            return deleteDeviceResult > 0;
        }

        public List<Ticket> GetTickets(int ticketLevel)
        {
            List<TicketDTO> ticketsDto = _ticket.GetTickets(ticketLevel);
            List<Ticket> tickets = new();

            foreach (var ticket in ticketsDto)
            {
                tickets.Add(new Ticket
                {
                    TicketId = ticket.TicketId,
                    TicketSubject = ticket.TicketSubject,
                    TicketContent = ticket.TicketContent,
                    TicketCategory = (Ticket.TicketCategories)ticket.TicketCategory,
                    TicketPriority = (Ticket.TicketPriorities)ticket.TicketPriority,
                    TicketStatus = (Ticket.TicketStatuses)ticket.TicketStatus,
                    CreatedDateTime = ticket.CreatedDateTime,
                    //Comments = commentLogic.GetComments(ticket.TicketId),
                });
            }

            return tickets;
        }

        public List<Comment> TransferCommentDTO(int ticketId)
        {
            List<CommentDTO> comments = _comment.GetComments(ticketId);
            List<Comment> transferedComments = new();

            foreach (var comment in comments)
            {
                transferedComments.Add(new Comment
                {
                    CommentId = comment.CommentId,
                    CommentContent = comment.CommentContent,
                });
            }
            return transferedComments;
        }
        public Ticket GetTicket(int ticketid)
        {
            TicketDTO specificTicket = _ticket.GetTicket(ticketid);
            Ticket ticket = new Ticket()
            {
                TicketId = specificTicket.TicketId,
                TicketSubject = specificTicket.TicketSubject,
                TicketContent = specificTicket.TicketContent,
                TicketCategory = (Ticket.TicketCategories)specificTicket.TicketCategory,
                TicketPriority = (Ticket.TicketPriorities)specificTicket.TicketPriority,
                TicketStatus = (Ticket.TicketStatuses)specificTicket.TicketStatus,
                CreatedDateTime = specificTicket.CreatedDateTime,
                Comments = TransferCommentDTO(specificTicket.TicketId),
            };

            return ticket;
        }
    }
}
