using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOGIC.Entities
{
    public class Device
    {
        [Key]
        public int DeviceId { get; set; }
        public int? ClientId { get; set; }
        public int? TicketId { get; set; }
        public string DeviceName { get; set; }
        public string? DeviceVersion { get; set; }
        public string Brand { get; set; }
        public string? OsVersion { get; set; }
        public string? SerialNumber { get; set; }
    }
}
