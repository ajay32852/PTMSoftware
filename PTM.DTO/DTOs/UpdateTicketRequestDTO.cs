using System.ComponentModel.DataAnnotations;

namespace PTM.DTO.DTOs
{
    public class UpdateTicketRequestDTO
    {
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Parking Lot is required.")]
        public int? ParkingLotId { get; set; }

        public int? UserId { get; set; }

        public DateTime? IssueDate { get; set; }
        public DateTime? OutTime { get; set; }
        public DateTime? ExpirationDate { get; set; }


        [Required(ErrorMessage = "Fine Amount is required.")]
        public decimal? FineAmount { get; set; }
        public bool? IsPaid { get; set; }
        public string? Remarks { get; set; }
        public decimal? Discount { get; set; }

        [Required(ErrorMessage = "License Plate Number  is required.")]
        public string? LicensePlate { get; set; }

        [Required(ErrorMessage = "Owner Name Plate Number  is required.")]
        public string? OwnerName { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "Category Number  is required.")]
        public int? CategoryId { get; set; }
    }
}
