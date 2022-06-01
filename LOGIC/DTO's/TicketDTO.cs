namespace LOGIC.DTO_s
{
    public class TicketDTO
    {
        public int TicketId { get; set; }
        public int DeviceId { get; set; }
        public string TicketSubject { get; set; }
        public string TicketContent { get; set; }
        public TicketCategories TicketCategory { get; set; }
        public TicketPriorities TicketPriority { get; set; }
        public TicketStatuses TicketStatus { get; set; }
        public TicketLevels TicketLevel { get; set; }
        public int ResponsibleEmployee { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public enum TicketCategories
        {
            Windows,
            macOS,
            Printer,
            InterneSystemen
        }
        public enum TicketPriorities
        {
            Laag,
            Gemiddeld,
            Hoog,
            Kritiek
        }
        public enum TicketStatuses
        {
            Open,
            InBehandeling,
            Gesloten
        }
        public enum TicketLevels
        {
            Moeilijk,
            Gemiddeld,
            Simpel
        }
    }
}
