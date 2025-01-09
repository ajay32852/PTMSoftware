namespace PTM.DTO.DTOs
{
    public partial class UserotpDTO
    {
        public int Id { get; set; }

        public int Userid { get; set; }

        public string Otpcode { get; set; }

        public DateTime Expirationtime { get; set; }

        public bool Isused { get; set; }

        public virtual UserDTO User { get; set; }
    }
}
