using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystemWeb.Models
{
    public class Device
    {
        [Key]
        public int deviceId { get; set; }
        public int clientId { get; set; }
        public int ticketId { get; set; }
        [Required(ErrorMessage = "Het invullen van een apparaatnaam is verplicht")]
        public string deviceName { get; set; }
        public string deviceVersion { get; set; }
        [Required(ErrorMessage = "Het invullen van een merk is verplicht")]
        public string brand { get; set; }
        public string osVersion { get; set; }
        public string serialNumber { get; set; }
    }
}
