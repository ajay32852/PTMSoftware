namespace PTM.DTO.DTOs
{
    public class VehicleDTO
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public string OwnerName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CategoryId { get; set; }

        // Related entities
        public CategoryDTO Category { get; set; } // Assuming you have a PtmCategoryDTO
        public ICollection<PtmTicketDTO> PtmTickets { get; set; } = new List<PtmTicketDTO>(); // Assuming you have a PtmTicketDTO
    }
}
