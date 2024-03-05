using AutoMapper;
using Jhipster.Configuration.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Jhipster.Configuration
{
    public static class AutoMapperStartup
    {
        public static IServiceCollection AddAutoMapperModule(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            return services;
        }
    }
}
