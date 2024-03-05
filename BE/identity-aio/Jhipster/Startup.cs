using System;
using Jhipster.Infrastructure.Data;
using Jhipster.Configuration;
using Jhipster.Infrastructure.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Jhipster.Infrastructure.Shared;
using MediatR;
using System.Reflection;
using Serilog;
using SportSvc;

[assembly: ApiController]

namespace Jhipster
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        private IConfiguration Configuration { get; }

        public IHostEnvironment Environment { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAppSettingsModule(Configuration);

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            AddDatabase(services);

            AddModule(services);

            services
                .AddSecurityModule()
                .AddProblemDetailsModule(Environment)
                .AddAutoMapperModule()
                .AddSwaggerModule()
                .AddWebModule()
                .AddRepositoryModule()
                .AddServiceModule();

            services
                .AddMailModule(Configuration);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostEnvironment env, IServiceProvider serviceProvider,
            ApplicationDatabaseContext context, IOptions<SecuritySettings> securitySettingsOptions)
        {
            var securitySettings = securitySettingsOptions.Value;
            app.UseSerilogRequestLogging();
            app
                .UseApplicationSecurity(securitySettings)
                .UseApplicationProblemDetails()
                .UseApplicationSwagger()
                .UseApplicationWeb(env)
                .UseApplicationDatabase(serviceProvider, env)
                .UseApplicationIdentity(serviceProvider);
        }

        protected virtual void AddDatabase(IServiceCollection services)
        {
            services.AddDatabaseModule(Configuration);
        }

        protected virtual void AddModule(IServiceCollection services)
        {
            // General Infras
            services.AddSharedInfrastructure(Configuration);
            services.AddSportSvcModule(Configuration);
        }

    }
}
