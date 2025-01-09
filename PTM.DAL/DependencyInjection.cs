using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PTM.DAL.DataContext;
using PTM.DAL.Repositories.IRepositories;
using PTM.DAL.Repositories;

namespace PTM.DAL
{
    public static class DependencyInjection
    {
        public static void RegisterDalDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PTMDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IParkingLotsRepository, ParkingLotsRepository>();

            
        }

    }
}
