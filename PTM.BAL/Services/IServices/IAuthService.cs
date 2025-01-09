using PTM.DTO.DTOs;
using PTM.DTO.RequestDTO;

namespace PTM.BAL.Services.IServices
{
    public interface IAuthService
    {
        Task<UserLoginDTO?> Login(LoginRequestDTO userLoginRequestDto, string userIp);
    }
}
