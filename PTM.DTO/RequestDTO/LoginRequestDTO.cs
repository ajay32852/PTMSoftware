namespace PTM.DTO.RequestDTO
{
    public class LoginRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? SecretKey { get; set; }
        //public int OTP { get; set; }
    }
}
