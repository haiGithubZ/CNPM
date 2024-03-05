using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportSvc.Domain.Extensions;
using SportSvc.Infrastructure.Extensions;

namespace SportSvc
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddSportSvcModule(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddBaseCore()
                .AddBaseInfrastructure(configuration);
            return services;
        }
    }
}
