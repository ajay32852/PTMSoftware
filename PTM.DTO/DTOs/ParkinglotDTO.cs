namespace PTM.DTO.DTOs
{
    public class ParkinglotDTO
    {
        public int Parkinglotid { get; set; }

        public string Lotname { get; set; }

        public string Location { get; set; }

        public int Totalspaces { get; set; }

        public int Availablespaces { get; set; }

        public DateTime? Createddate { get; set; }

        public int? Userid { get; set; }

        public virtual ICollection<PtmTicketDTO> PtmTickets { get; set; } = new List<PtmTicketDTO>();

        public virtual UserDTO User { get; set; }
    }
}
