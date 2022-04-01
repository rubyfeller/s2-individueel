using LOGIC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface ITicketLogic
    {
        Boolean AddTicket(string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus);
        Boolean UpdateTicket(int ticketid, string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus);
        Boolean DeleteTicket(int ticketid);
        List<Ticket> GetTickets();
        List<Ticket> GetTicket(int ticketid);

    }
}
