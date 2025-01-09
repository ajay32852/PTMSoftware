using PTM.DAL.Filters;
using PTM.DTO.DTOs;
using PTM.DTO.RequestDTO;

namespace PTM.BAL.Services.IServices
{
    public interface IParkingLotsService
    {
        Task<List<ParkinglotDTO>> GetAllParkingLotsList(ParkingLotsFilter filter);
        Task<ParkinglotDTO> AddParkingLots(AddParkinglotDTO request);
        Task<ParkinglotDTO> UpdateParkingLots(UpdateParkinglotDTO request);
        

    }
}
