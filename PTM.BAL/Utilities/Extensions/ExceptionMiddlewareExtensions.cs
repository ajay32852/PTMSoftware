using Microsoft.AspNetCore.Builder;
using PTM.BAL.Utilities.CustomExceptionMiddleware;
namespace PTM.BAL.Utilities.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {

        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
