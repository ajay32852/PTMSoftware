using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PTM.BAL.Services.IServices;
using PTM.BAL.Utilities.Common;
using PTM.BAL.Utilities.Filters;
using PTM.DTO.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace PTM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketsController(ITicketService ticketService,
    IStringLocalizer<TicketsController> localizer) : ControllerBase
    {

         /// <summary>
         /// AUTHOR BY : AJAY KUMAR
         /// </summary>
         /// <param name="filter"></param>
         /// <returns></returns>
        [SwaggerOperation(Summary = "Get All Parking List Ticket", Description = "Get all parking list Ticket like in and out parking list")]
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

        }

       /// <summary>
       /// AUTHOR BY : AJAY KUMAR
       /// ADD NEW TICKET 
       /// </summary>
       /// <param name="filter"></param>
       /// <returns></returns>
        [SwaggerOperation(Summary = "Add new booking ticket for customer ", Description = "Add new booking ticket for customer")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpPost("addnewbookingparking")]
        public async Task<IActionResult> AddNewBookingParking(AddTicketRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new BadResponseData
                {
                    Code = Convert.ToInt16(HttpStatusCode.BadRequest),
                    Message = localizer[name: ResponseMessage.Fail.ToString()].Value,
                    Status = true,
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
                });
            }

            var data = await ticketService.AddNewBookingParking(request);
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
        /// ADD NEW TICKET 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Update Existing booking ticket for customer ", Description = "Update Existing booking ticket for customer")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpPost("updatebookingparking")]
        public async Task<IActionResult> UpdateBookingParking(UpdateTicketRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new BadResponseData
                {
                    Code = Convert.ToInt16(HttpStatusCode.BadRequest),
                    Message = localizer[name: ResponseMessage.Fail.ToString()].Value,
                    Status = true,
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
                });
            }

            var data = await ticketService.UpdateBookingParking(request);
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
