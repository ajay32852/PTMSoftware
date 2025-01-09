using PTM.BAL.Utilities.Filters;
using PTM.DAL.Entities;

namespace PTM.DAL.Repositories.IRepositories
{
    public interface ITicketRepository
    {
        Task<List<PtmTicket>> GetAllParkingListByUserId(ParkingTicketFilter filter,int userId);
        Task<PtmTicket> AddNewBookingParking(PtmTicket newTicket);
        Task<PtmTicket> UpdateBookingParking(PtmTicket newTicket);
        
    }
}
