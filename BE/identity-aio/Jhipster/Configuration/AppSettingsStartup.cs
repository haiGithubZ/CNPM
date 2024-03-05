using Jhipster.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Text;
using System;
using Jhipster.Crosscutting.Constants;

namespace Jhipster.Configuration
{
    public static class AppSettingsConfiguration
    {
        public static IServiceCollection AddAppSettingsModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SecuritySettings>(options => configuration.GetSection("security").Bind(options));

            return services;

        }
    }
}
