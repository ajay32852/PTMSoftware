using PTM.DAL.Entities;

namespace PTM.DAL.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<PtmUser> GetUserByUsername(string userName);
        Task<PtmUser> UpdateLastLogin(PtmUser loginUpdateMap);

    }
}
