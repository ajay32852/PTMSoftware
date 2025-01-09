using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PTM.BAL.Services.IServices;
using PTM.BAL.Utilities.Common;
using PTM.BLL.Utilities.CustomExceptions;
using PTM.DTO.RequestDTO;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace PTM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService, IStringLocalizer<AuthController> localizer)
    : ControllerBase
    {

        /// <summary>
        /// 1st step for login
        /// </summary>
        /// <returns>User Data</returns>
        [SwaggerOperation(Summary = "Login Method", Description = "Method to login in the system and shoot an email to the user to receieve OTP")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO userLoginDto)
        {
            if (Request.HttpContext.Connection.RemoteIpAddress == null) return null!;
            var userIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            //Check if user ip is null
            if (string.IsNullOrEmpty(userIp))
            {
                throw new UserIPInvalidException(localizer[name: ResponseMessage.InvalidIP.ToString()]);
            }

            var data = await authService.Login(userLoginDto, userIp);
            return Ok(new ResponseData
            {
                Code = Convert.ToInt16(HttpStatusCode.OK),
                Message = localizer[name: ResponseMessage.Success.ToString()].Value,
                Status = true,
                Data = data
            });

        }







    }

}
