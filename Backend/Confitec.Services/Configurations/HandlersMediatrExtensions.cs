using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Services.Configurations
{
    public static class HandlersMediatrExtensions
    {
        public static IServiceCollection UseServicesHandlers(this IServiceCollection services)
        {
            return services.AddMediatR(typeof(HandlersMediatrExtensions).Assembly);
        }
    }
}
