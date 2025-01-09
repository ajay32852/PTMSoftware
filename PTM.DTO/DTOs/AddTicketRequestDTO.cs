using System.ComponentModel.DataAnnotations;

namespace PTM.DTO.DTOs
{
    public class AddTicketRequestDTO
    {
        public int? TicketId { get; set; }

        [Required(ErrorMessage = "Parking Lot is required.")]
        public int ParkingLotId { get; set; }

        public int? UserId { get; set; }

        public DateTime? IssueDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "In Time is required.")]
        public DateTime InTime { get; set; } = DateTime.Now;
        public DateTime? OutTime { get; set; }
        public DateTime? ExpirationDate { get; set; } = DateTime.Now.AddDays(7);


        [Required(ErrorMessage = "Fine Amount is required.")]
        public decimal? FineAmount { get; set; }
        public bool? IsPaid { get; set; }
        public string? Remarks { get; set; }
        public decimal? Discount { get; set; }
        public int? TicketNumber { get; set; }
        // Method to generate a random 6-digit ticket number
        public void GenerateTicketNumber()
        {
            Random random = new Random();
            TicketNumber = random.Next(100000, 999999); // Generates a random number between 100000 and 999999
        }

        [Required(ErrorMessage = "License Plate Number  is required.")]
        public string LicensePlate { get; set; }

        [Required(ErrorMessage = "Owner Name Plate Number  is required.")]
        public string OwnerName { get; set; }
        public DateTime? CreatedDate { get; set; }= DateTime.Now;


        [Required(ErrorMessage = "Category Number  is required.")]
        public int? CategoryId { get; set; }

    

    }
}
