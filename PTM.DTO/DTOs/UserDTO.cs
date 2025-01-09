namespace PTM.DTO.DTOs
{
    public partial class UserDTO
    {
        public int Uid { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime Signupdate { get; set; }

        public DateTime? Lastlogin { get; set; }

        public bool? Isactive { get; set; }

        public string Usertype { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public Guid Apikey { get; set; }

        public bool Isremindernotification { get; set; }

        public string Extension { get; set; }

        public DateTime? Passwordupdatedon { get; set; }

        public bool Isblocked { get; set; }

        public int Loginattempt { get; set; }

        public int Usertypeid { get; set; }

        public DateTime? Lastotplogin { get; set; }

        public virtual ICollection<UserotpDTO> PtmUserotps { get; set; } = new List<UserotpDTO>();
    }
}
