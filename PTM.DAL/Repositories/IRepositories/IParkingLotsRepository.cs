using PTM.DAL.Entities;
using PTM.DAL.Filters;

namespace PTM.DAL.Repositories.IRepositories
{
    public interface IParkingLotsRepository
    {
        Task<List<PtmParkinglot>> GetAllParkingLotsList(ParkingLotsFilter filter,int userId);
        Task<PtmParkinglot> AddParkingLots(PtmParkinglot newRequestMap);
        Task<PtmParkinglot> UpdateParkingLots(PtmParkinglot newRequestMap);
    }
}
