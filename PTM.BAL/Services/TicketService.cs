using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using PTM.BAL.Services.IServices;
using PTM.BAL.Utilities.Common;
using PTM.BAL.Utilities.Filters;
using PTM.BLL.Utilities.CustomExceptions;
using PTM.DAL.Entities;
using PTM.DAL.Repositories.IRepositories;
using PTM.DTO.DTOs;
using System.Security.Claims;

namespace PTM.BAL.Services
{
    public class TicketService: ITicketService
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<TicketService> _localizer;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITicketRepository _ticketRepository;
        public TicketService(
            IMapper mapper,
            IStringLocalizer<TicketService> localizer,
            IConfiguration configuration,
            ITicketRepository ticketRepository,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _mapper = mapper;
            _localizer = localizer;
            _configuration = configuration;
            _ticketRepository = ticketRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<PtmTicketDTO>> GetAllParkingList(ParkingTicketFilter filter)
        {
            // Get current user id from claims and convert to int
            string userIdClaim = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                throw new InvalidOperationException(_localizer[name: ResponseMessage.UserNotFound.ToString()]);
            }

            // Retrieve all tickets for the user
            var getallTicketslistResult = await _ticketRepository.GetAllParkingListByUserId(filter, userId);

            // Map the result to DTO
            var getallTicketslist = _mapper.Map<List<PtmTicketDTO>>(getallTicketslistResult);

            if (getallTicketslist == null || !getallTicketslist.Any())
            {
                throw new NoDataException(_localizer[name: ResponseMessage.DataNotFound.ToString()]);
            }

            return getallTicketslist;
        }

        public async Task<PtmTicketDTO> AddNewBookingParking(AddTicketRequestDTO request)
        {
            string userIdClaim = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                throw new InvalidOperationException(_localizer[name: ResponseMessage.UserNotFound.ToString()]);
            }
            request.GenerateTicketNumber();
            request.UserId = userId;
            var newTicket = _mapper.Map<PtmTicket>(request);
            var addticketResponse=await _ticketRepository.AddNewBookingParking(newTicket);
            var ticketResponse = _mapper.Map<PtmTicketDTO>(addticketResponse);
            return ticketResponse;
        }
       

        public async Task<PtmTicketDTO> UpdateBookingParking(UpdateTicketRequestDTO request)
        {
            string userIdClaim = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                throw new InvalidOperationException(_localizer[name: ResponseMessage.UserNotFound.ToString()]);
            }
            request.UserId = userId;
            if(request.IsPaid==true)
            {
                request.OutTime = DateTime.Now; 
            }
            if (request.Discount > 0)
            {
                request.FineAmount = request.FineAmount - request.Discount;
            }
            var newTicket = _mapper.Map<PtmTicket>(request);
            var addticketResponse = await _ticketRepository.UpdateBookingParking(newTicket);
            var ticketResponse = _mapper.Map<PtmTicketDTO>(addticketResponse);
            return ticketResponse;
        }

    }
}
