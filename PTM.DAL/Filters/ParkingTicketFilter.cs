namespace PTM.BAL.Utilities.Filters
{
    public class ParkingTicketFilter
    {
        public int? PageNumber { get; set; } = 1; // Default to the first page
        public int? PageSize { get; set; } = 10; // Default page size

        public bool? IsPaid { get; set; } // get paid and unpaid ticket
        public int?  TicketNumber { get; set; }  // get ticket id wise ticket
        public DateOnly? InTime { get; set; }
        public DateOnly? OutTime { get; set; }

        public string? LicensePlate { get; set; }

        public string? OwnerName { get; set; }

    }
}
