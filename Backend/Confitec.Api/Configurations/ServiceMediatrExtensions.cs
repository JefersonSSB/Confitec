
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Api.Configurations
{
    public static class ServiceMediatrExtensions
    {
        public static IServiceCollection UseMediatrHandlers(this IServiceCollection services)
        {
            return services
                .AddMediatR(AppDomain.CurrentDomain.Load("Confitec.Application"));

        }
    }
}
