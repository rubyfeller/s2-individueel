namespace LOGIC.DTO_s
{
    public class DeviceDTO
    {
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
