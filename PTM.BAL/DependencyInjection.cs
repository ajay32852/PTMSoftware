using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PTM.BAL.Services;
using PTM.BAL.Services.IServices;
using PTM.BAL.Utilities.AutoMapperProfiles;
using PTM.BAL.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace PTM.BAL
{
    public static class DependencyInjection
    {
        public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            //services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<UserToLoginDTOValidator>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IParkingLotsService, ParkingLotsService>();
            

        }

    }
}
