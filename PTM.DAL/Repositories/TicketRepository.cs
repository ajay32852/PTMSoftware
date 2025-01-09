using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PTM.BAL.Utilities.Filters;
using PTM.DAL.DataContext;
using PTM.DAL.Entities;
using PTM.DAL.Repositories.IRepositories;

namespace PTM.DAL.Repositories
{

    public class TicketRepository(PTMDBContext ptmDBContext, IHttpContextAccessor httpContextAccessor)
: ITicketRepository
    {
       

        /// <summary>
        ///     This method will fetch the User by 
        /// </summary>
        /// <returns></returns>
        /// 
        public async Task<List<PtmTicket>> GetAllParkingListByUserId(ParkingTicketFilter filter, int userId)
        {
            // Start with the base query
            var query = ptmDBContext.PtmTickets
                .Include(x => x.User)
                .Include(x => x.Vehicle)
                .Include(x => x.Parkinglot)
                .Where(x => x.Userid == userId);
            // Apply filters based on the filter properties
            if (filter.IsPaid.HasValue)
            {
                query = query.Where(x => x.Ispaid == filter.IsPaid.Value);
            }

            if (filter.TicketNumber.HasValue)
            {
                query = query.Where(x => x.Ticketnumber == filter.TicketNumber.Value);
            }

           /* if (filter.InTime.HasValue)
            {
                var inTimeDate = filter.InTime.Value.Date; // Get the date part
                query = query.Where(x => x.Intime >= inTimeDate && x.Intime < inTimeDate.AddDays(1)); // Filter for the entire day
            }

            if (filter.OutTime.HasValue)
            {
                var outTimeDate = filter.OutTime.Value.Date; // Get the date part
                query = query.Where(x => x.Outtime.HasValue && x.Outtime.Value >= outTimeDate && x.Outtime.Value < outTimeDate.AddDays(1)); // Filter for the entire day
            }*/

            if (!string.IsNullOrEmpty(filter.LicensePlate))
            {
                query = query.Where(x => x.Vehicle.Licenseplate.Contains(filter.LicensePlate));
            }

            if (!string.IsNullOrEmpty(filter.OwnerName))
            {
                query = query.Where(x => x.Vehicle.Ownername.Contains(filter.OwnerName));
            }
            query = query.OrderByDescending(x => x.Ticketid);
            // Apply pagination
            var totalCount = await query.CountAsync();
            var tickets = await query
                .Skip((filter.PageNumber.Value - 1) * filter.PageSize.Value)
                .Take(filter.PageSize.Value)
                .AsNoTracking()
                .ToListAsync();

            return tickets;
        }

        public async Task<PtmTicket> AddNewBookingParking(PtmTicket newTicket)
        {
            await ptmDBContext.PtmTickets.AddAsync(newTicket);
            await ptmDBContext.SaveChangesAsync();
            return newTicket;
        }

        public async Task<PtmTicket> UpdateBookingParking(PtmTicket newTicket)
        {
            var existingTicket = await ptmDBContext.PtmTickets
                .Include(x=>x.Vehicle)
                .Where(x => x.Ticketid == newTicket.Ticketid)
                .FirstOrDefaultAsync();
            if (existingTicket != null)
            {
                existingTicket.Parkinglotid = newTicket.Parkinglotid;
                existingTicket.Userid = newTicket.Userid;
                existingTicket.Issuedate = newTicket.Issuedate;
                existingTicket.Outtime = newTicket.Outtime;
                existingTicket.Expirationdate = newTicket.Expirationdate;
                existingTicket.Fineamount = newTicket.Fineamount;
                existingTicket.Ispaid = newTicket.Ispaid;
                existingTicket.Remarks = newTicket.Remarks;
                existingTicket.Discount = newTicket.Discount;
                existingTicket.Vehicle.Licenseplate = newTicket.Vehicle.Licenseplate;
                existingTicket.Vehicle.Ownername = newTicket.Vehicle.Ownername;
                existingTicket.Vehicle.Createddate = DateTime.UtcNow;
                existingTicket.Vehicle.Categoryid = newTicket.Vehicle.Categoryid;
                await ptmDBContext.SaveChangesAsync();
            }

            return existingTicket; 
        }



    }
}
