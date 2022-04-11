using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Entities
{
    public class TicketDeviceCollection
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
