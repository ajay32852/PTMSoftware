namespace PTM.DTO.DTOs
{
    public class UserLoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SecretKey { get; set; }
        public int OTP { get; set; }
        public bool Expired { get; set; }
        public bool FirstTime { get; set; }
        public UserDTO UserData { get; set; }
    }
}
