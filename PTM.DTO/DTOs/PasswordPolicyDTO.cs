namespace PTM.DTO.DTOs
{
    public class PasswordPolicyDTO
    {
        public int MinimumLength { get; set; } = 12;
        public int RequiredCharacterGroups { get; set; } = 3;
        public int PasswordHistoryCount { get; set; } = 8;
        public TimeSpan MaximumPasswordAge { get; set; } = TimeSpan.FromDays(365);
    }
}
