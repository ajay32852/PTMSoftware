using PTM.DTO.DTOs;

namespace PTM.DTO.RequestDTO
{
    public class AddParkinglotDTO
    {
        public string Lotname { get; set; }
        public string Location { get; set; }
        public int Totalspaces { get; set; }
        public int Availablespaces { get; set; }
        public DateTime? Createddate { get; set; }
        public int? Userid { get; set; }

    }


}
