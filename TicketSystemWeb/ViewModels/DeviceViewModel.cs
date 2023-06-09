﻿using LOGIC.Entities;
using System.ComponentModel.DataAnnotations;

namespace TicketSystemWeb.Models
{
    public class DeviceViewModel
    {
        [Key]
        public int DeviceId { get; set; }
        public int? ClientId { get; set; }
        public int? TicketId { get; set; }
        [Required(ErrorMessage = "Het invullen van een apparaatnaam is verplicht")]
        public string DeviceName { get; set; }
        public string? DeviceVersion { get; set; }
        [Required(ErrorMessage = "Het invullen van een merk is verplicht")]
        public string Brand { get; set; }
        public string? OsVersion { get; set; }
        public string? SerialNumber { get; set; }
        public Ticket Ticket { get; set; }
    }
}
