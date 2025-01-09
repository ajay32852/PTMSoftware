using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PTM.DAL.DataContext;
using PTM.DAL.Entities;
using PTM.DAL.Filters;
using PTM.DAL.Repositories.IRepositories;

namespace PTM.DAL.Repositories
{
    public class ParkingLotsRepository(PTMDBContext ptmDBContext, IHttpContextAccessor httpContextAccessor)
: IParkingLotsRepository
    {

        public async Task<List<PtmParkinglot>> GetAllParkingLotsList(ParkingLotsFilter filter, int userId)
        {
            var query = ptmDBContext.PtmParkinglots
                .Where(x => x.Userid == userId);
         
            
            query = query.OrderByDescending(x => x.Parkinglotid);
            // Apply pagination
            var totalCount = await query.CountAsync();
            var ptmParkinglotlist = await query
                .Skip((filter.PageNumber.Value - 1) * filter.PageSize.Value)
                .Take(filter.PageSize.Value)
                .AsNoTracking()
                .ToListAsync();

            return ptmParkinglotlist;
        }
        public async Task<PtmParkinglot> AddParkingLots(PtmParkinglot newRequestMap)
        {
            await ptmDBContext.PtmParkinglots.AddAsync(newRequestMap);
            await ptmDBContext.SaveChangesAsync();
            return newRequestMap;
        }
        public async Task<PtmParkinglot> UpdateParkingLots(PtmParkinglot newRequestMap)
        {
            var existingParkingLot = await ptmDBContext.PtmParkinglots
                .FirstOrDefaultAsync(x => x.Parkinglotid == newRequestMap.Parkinglotid);
            if (existingParkingLot != null)
            {
                existingParkingLot.Lotname = newRequestMap.Lotname;
                existingParkingLot.Location = newRequestMap.Location;
                existingParkingLot.Totalspaces = newRequestMap.Totalspaces;
                existingParkingLot.Availablespaces = newRequestMap.Availablespaces;
                existingParkingLot.Createddate = newRequestMap.Createddate;
                existingParkingLot.Userid = newRequestMap.Userid;
                await ptmDBContext.SaveChangesAsync();
            }
            return existingParkingLot; // Return the updated parking lot
        }


    }
}
