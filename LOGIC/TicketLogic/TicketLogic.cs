using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.TicketLogic
{
    public class TicketLogic
    {
        private ITicket _ticket = new DAL.Functions.TicketFunctions();

        public async Task<Boolean> CreateNewTicket(string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus)
        {
            var result = await _ticket.AddTicket(ticketsubject, ticketcontent, createddatetime, ticketcategory, ticketpriority, ticketstatus);
            return result > 0;
        }

        public async Task<Boolean> UpdateTicket(int ticketid, string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus)
        {
            var updateDeviceResult = await _ticket.UpdateTicket(ticketid, ticketsubject, ticketcontent, createddatetime, ticketcategory, ticketpriority, ticketstatus);
            return updateDeviceResult > 0;
        }

        public async Task<Boolean> DeleteTicket(int ticketid)
        {
            var deleteDeviceResult = await _ticket.DeleteTicket(ticketid);
            return deleteDeviceResult > 0;
        }

        public async Task<List<Ticket>> GetTickets()
        {
            List<Ticket> tickets = await _ticket.GetTickets();
            return tickets;
        }

        public async Task<List<Ticket>> GetTicket(int ticketid)
        {
            List<Ticket> specificTicketList = await _ticket.GetTicket(ticketid);
            return specificTicketList;
        }
    }
}
