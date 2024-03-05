using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportSvc.Application.Configurations.Mapper;
using SportSvc.Application.Contracts;
using SportSvc.Domain.Abstractions;
using SportSvc.Infrastructure.Persistences.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Jhipster.Infrastructure.Shared;
using MediatR;
using SportSvc.Application.Commands.ShoppingCartss;

namespace SportSvc.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBaseInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDatabaseContext<SportSvcDbContext>(config)
                .AddScoped<ISportSvcDbContext>(provider => provider.GetService<SportSvcDbContext>());
            // Đăng kí mediatR
            services.AddMediatR(typeof(AddProductToShoppingCartCommand).GetTypeInfo().Assembly);
            services.AddAutoMapper(typeof(AutoMapperProfile));
            //// Đăng kí repository
            services.AddScoped(typeof(ISportSvcRepository), typeof(SportSvcRepository));
            services.AddScoped(typeof(IPromotionRepository), typeof(PromotionRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IStadiumRepository), typeof(StadiumRepository));

            return services;
        }
    }
}
