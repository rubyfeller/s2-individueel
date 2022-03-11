using System.ComponentModel.DataAnnotations;

namespace TicketSystemWeb.Models
{
    public class Device
    {
        [Key]
        public int deviceId { get; set; }
        public int clientId { get; set; }
        public int ticketId { get; set; }
        [Required]
        public string deviceName { get; set; }
        public string deviceVersion { get; set; }
        [Required]
        public string brand { get; set; }
        public string osVersion { get; set; }
        public string serialNumber { get; set; }
    }
}
