using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITicket
    {
        Task<Int32> AddTicket(string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus);
        Task<Int32> UpdateTicket(int ticketid, string ticketsubject, string ticketcontent, DateTime createddatetime, int ticketcategory, int ticketpriority, int ticketstatus);
        Task<Int32> DeleteTicket(int ticketid);
        Task<List<Ticket>> GetTickets();
        Task<List<Ticket>> GetTicket(int ticketid);
    }
}
