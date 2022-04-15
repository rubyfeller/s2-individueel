using LOGIC.Entities;

namespace TicketSystemWeb.ViewModels
{
    public class TicketDeviceCollectionViewModel
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public string DeviceName { get; set; }
        public string DeviceVersion { get; set; }
        public string Brand { get; set; }
        public string OsVersion { get; set; }
        public string SerialNumber { get; set; }
    }
}
