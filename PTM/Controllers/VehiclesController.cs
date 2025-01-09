using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PTM.BAL.Services;
using PTM.BAL.Services.IServices;
using PTM.BAL.Utilities.Common;
using PTM.BAL.Utilities.Filters;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace PTM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehiclesController(IAuthService authService,
    IStringLocalizer<VehiclesController> localizer) : ControllerBase
    {
        /// <summary>
        /// AUTHOR BY : AJAY KUMAR
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
      /*  [SwaggerOperation(Summary = "Get All Parking List Ticket", Description = "Get all parking list Ticket like in and out parking list")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpGet("getallparking")]
        public async Task<IActionResult> GetAllParkingList([FromQuery] ParkingTicketFilter filter)
        {
            var data = await ticketService.GetAllParkingList(filter);
            return Ok(new ResponseData
            {
                Code = Convert.ToInt16(HttpStatusCode.OK),
                Message = localizer[name: ResponseMessage.Success.ToString()].Value,
                Status = true,
                Data = data
            });

        }*/
    }
}
