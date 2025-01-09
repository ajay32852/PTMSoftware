using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PTM.DAL.DataContext;
using PTM.DAL.Entities;
using PTM.DAL.Repositories.IRepositories;

namespace PTM.DAL.Repositories
{
    public class UserRepository(PTMDBContext ptmDBContext, IHttpContextAccessor httpContextAccessor)
    : IUserRepository
    {
        /// <summary>
        ///     This method will fetch the User by Username (Email address)
        /// </summary>
        /// <returns></returns>
        public async Task<PtmUser> GetUserByUsername(string userName)
        {
            return await ptmDBContext.PtmUsers.Where(x => x.Username.ToLower() == userName.ToLower())
                .FirstOrDefaultAsync();
        }

        public async Task<PtmUser> UpdateLastLogin(PtmUser loginUpdateMap)
        {
            var user = await ptmDBContext.PtmUsers.FirstOrDefaultAsync(x => x.Uid == loginUpdateMap.Uid);
            if (user != null)
            {
                user.Lastlogin = loginUpdateMap.Lastlogin;
                ptmDBContext.PtmUsers.Update(user);
                await ptmDBContext.SaveChangesAsync();
            }
            return user;
        }


    }
}
