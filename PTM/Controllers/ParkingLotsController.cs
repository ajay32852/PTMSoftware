using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PTM.BAL.Services.IServices;
using PTM.BAL.Utilities.Common;
using PTM.DAL.Filters;
using PTM.DTO.DTOs;
using PTM.DTO.RequestDTO;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
namespace PTM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ParkingLotsController(IParkingLotsService parkingLotsService, 
    IStringLocalizer<ParkingLotsController> localizer): ControllerBase
    {
        /// <summary>
        /// AUTHOR BY : AJAY KUMAR
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Get All Parking Lots List", Description = "Get All Parking Lots List")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpGet("getallparkinglots")]
        public async Task<IActionResult> GetAllParkingLotsList([FromQuery] ParkingLotsFilter filter)
        {
            var data = await parkingLotsService.GetAllParkingLotsList(filter);
            return Ok(new ResponseData
            {
                Code = Convert.ToInt16(HttpStatusCode.OK),
                Message = localizer[name: ResponseMessage.Success.ToString()].Value,
                Status = true,
                Data = data
            });

        }

        /// <summary>
        /// AUTHOR BY : AJAY KUMAR
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Add  Parking Lots", Description = "Add  Parking Lots")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpPost("addparkinglots")]
        public async Task<IActionResult> AddParkingLots(AddParkinglotDTO request)
        {
            var data = await parkingLotsService.AddParkingLots(request);
            return Ok(new ResponseData
            {
                Code = Convert.ToInt16(HttpStatusCode.OK),
                Message = localizer[name: ResponseMessage.Success.ToString()].Value,
                Status = true,
                Data = data
            });

        }
        /// <summary>
        /// AUTHOR BY : AJAY KUMAR
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Get All Parking Lots List", Description = "Get All Parking Lots List")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpPut("updateparkinglots")]
        public async Task<IActionResult> UpdateParkingLots(UpdateParkinglotDTO request)
        {
            var data = await parkingLotsService.UpdateParkingLots(request);
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
