using PTM.BAL.Utilities.Filters;
using PTM.DTO.DTOs;

namespace PTM.BAL.Services.IServices
{
    public interface ITicketService
    {
        Task<List<PtmTicketDTO>> GetAllParkingList(ParkingTicketFilter filter);
        Task<PtmTicketDTO> AddNewBookingParking(AddTicketRequestDTO request);
        Task<PtmTicketDTO> UpdateBookingParking(UpdateTicketRequestDTO request);
        


    }
}
