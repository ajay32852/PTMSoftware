using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using PTM.BAL.Services.IServices;
using PTM.BAL.Utilities.Common;
using PTM.BLL.Utilities.CustomExceptions;
using PTM.DAL.Entities;
using PTM.DAL.Filters;
using PTM.DAL.Repositories.IRepositories;
using PTM.DTO.DTOs;
using PTM.DTO.RequestDTO;
using System.Security.Claims;

namespace PTM.BAL.Services
{
    public class ParkingLotsService: IParkingLotsService
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<ParkingLotsService> _localizer;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITicketRepository _ticketRepository;
        private readonly IParkingLotsRepository _parkingLotsRepository;
        public ParkingLotsService(
            IMapper mapper,
            IStringLocalizer<ParkingLotsService> localizer,
            IConfiguration configuration,
            ITicketRepository ticketRepository,
            IHttpContextAccessor httpContextAccessor,
            IParkingLotsRepository parkingLotsRepository
            )
        {
            _mapper = mapper;
            _localizer = localizer;
            _configuration = configuration;
            _ticketRepository = ticketRepository;
            _httpContextAccessor = httpContextAccessor;
            _parkingLotsRepository = parkingLotsRepository;
        }

        public async Task<List<ParkinglotDTO>> GetAllParkingLotsList(ParkingLotsFilter filter)
        {
            string userIdClaim = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                throw new InvalidOperationException(_localizer[name: ResponseMessage.UserNotFound.ToString()]);
            }
            var getalllistResult = await _parkingLotsRepository.GetAllParkingLotsList(filter, userId);
            var getallParkingslist = _mapper.Map<List<ParkinglotDTO>>(getalllistResult);

            if (getallParkingslist == null || !getallParkingslist.Any())
            {
                throw new NoDataException(_localizer[name: ResponseMessage.DataNotFound.ToString()]);
            }
            return getallParkingslist;
        }

        public async Task<ParkinglotDTO> AddParkingLots(AddParkinglotDTO request)
        {
            string userIdClaim = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                throw new InvalidOperationException(_localizer[name: ResponseMessage.UserNotFound.ToString()]);
            }
            request.Userid = userId;
            var newRequestMap = _mapper.Map<PtmParkinglot>(request);
            var addParkingLots = await _parkingLotsRepository.AddParkingLots(newRequestMap);
            var addParkingLotsResponseMap = _mapper.Map<ParkinglotDTO>(addParkingLots);
            return addParkingLotsResponseMap;

        }
        public async Task<ParkinglotDTO> UpdateParkingLots(UpdateParkinglotDTO request)
        {
            string userIdClaim = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                throw new InvalidOperationException(_localizer[name: ResponseMessage.UserNotFound.ToString()]);
            }
            request.Userid = userId;
            var updateRequestMap = _mapper.Map<PtmParkinglot>(request);
            var updateParkingLots = await _parkingLotsRepository.UpdateParkingLots(updateRequestMap);
            var updateParkingLotsResponseMap = _mapper.Map<ParkinglotDTO>(updateParkingLots);
            return updateParkingLotsResponseMap;
        }





    }
}
