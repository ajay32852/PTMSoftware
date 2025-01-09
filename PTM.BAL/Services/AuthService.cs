using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using PTM.BAL.Services.IServices;
using PTM.BAL.Utilities.Common;
using PTM.BLL.Utilities.CustomExceptions;
using PTM.DTO.DTOs;
using PTM.DTO.RequestDTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text;
using PTM.DAL.Repositories.IRepositories;
using PTM.DAL.Entities;

namespace PTM.BAL.Services
{
    public class AuthService: IAuthService
    {

        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AuthService> _localizer;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        public AuthService(
            IMapper mapper,
            IStringLocalizer<AuthService> localizer,
            IConfiguration configuration,
            IUserRepository userRepository,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _mapper = mapper;
            _localizer = localizer;
            _configuration = configuration;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<UserLoginDTO?> Login(LoginRequestDTO userLoginDto, string userIp)
        {
            // Check if userIp is not null
            if (userIp == null)
            {
                throw new ArgumentNullException(nameof(userIp), "User  IP cannot be null.");
            }

            // Retrieve the user from the repository
            var user = await _userRepository.GetUserByUsername(userLoginDto.UserName);
            var mappedUserData = _mapper.Map<UserDTO>(user);
            if (user == null)
            {
                throw new UserNotFoundException(_localizer[name: ResponseMessage.InvalidUser.ToString()]);
            }
      
            // Validate the password
            if (! Common.IsPasswordValid(userLoginDto.Password, user.Password))
            {
                throw new UserPasswordNotValidatedException(_localizer[name: ResponseMessage.InvalidPassword.ToString()]);
            }
            ///Check if account is blocked.
            if (mappedUserData.Isblocked) throw new UserBlockedException(_localizer[name: ResponseMessage.BlockedUser.ToString()]);

            // Generate JWT token
            var token = GenerateToken(user.Uid, user.Username, user.Usertype, ""); // Pass permissions if needed

            // LAST LOGIN UPDATE 
            mappedUserData.Lastlogin = DateTime.Now;
            var loginUpdateMap=_mapper.Map<PtmUser>(mappedUserData);
            var lastLoginUpdate = await _userRepository.UpdateLastLogin(loginUpdateMap);

            // Create the UserLoginDTO result
            var userLoginDtoResult = new UserLoginDTO
            {
                UserName = mappedUserData.Username,
                Name = mappedUserData.Name,
                SecretKey = token,
                OTP = 0,
                Expired = false,
                FirstTime = false,
                UserData = mappedUserData
            };
            return userLoginDtoResult;
        }
        // GENERATE TOKEN FOR JWT 
        private string GenerateToken(int userId, string username, string userType, string permissions)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, userType ),
            new Claim("Permission", permissions ),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    

    

    }
}
