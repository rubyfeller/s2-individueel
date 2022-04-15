using LOGIC.Entities;
using LOGIC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services
{
    public class TicketDeviceCollectionLogic : ITicketDeviceCollectionLogic
    {
        private readonly ITicketDeviceCollectionDal _ticketdevice;
        public TicketDeviceCollectionLogic(ITicketDeviceCollectionDal ticketdevice)
        {
            _ticketdevice = ticketdevice;
        }
        public List<TicketDeviceCollection> GetTicketDevices(int ticketid)
        {
            List<TicketDeviceCollection> deviceList = _ticketdevice.GetTicketDevices(ticketid);
            return deviceList;
        }
    }
}
