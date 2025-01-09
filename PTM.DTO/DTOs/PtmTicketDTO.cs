namespace PTM.DTO.DTOs
{
    public class PtmTicketDTO
    {
        public int? TicketId { get; set; }
        public int VehicleId { get; set; }
        public int ParkingLotId { get; set; }
        public int UserId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal? FineAmount { get; set; }
        public bool? IsPaid { get; set; }
        public string Remarks { get; set; }
        public decimal? Discount { get; set; }
        public int? Ticketnumber { get; set; }

        public virtual ParkinglotDTO? Parkinglot { get; set; }
        public virtual UserDTO? User { get; set; }
        public virtual VehicleDTO? Vehicle { get; set; }
    }
}
