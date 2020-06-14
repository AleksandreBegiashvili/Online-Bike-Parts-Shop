using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RabidBike.Data.Abstractions;
using RabidBike.Data.Context;
using RabidBike.Data.Identity;
using RabidBike.Data.Implementations;
using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Data.Extensions
{
    public static class RepositoryConfigExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped(typeof(IItemRepository), typeof(ItemRepository));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IConditionRepository), typeof(ConditionRepository));
            services.AddScoped(typeof(ILocationRepository), typeof(LocationRepository));
            services.AddTransient(typeof(RabidUserManager));

            return services;
        }

        public static IServiceCollection RegisterIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<RabidBikeContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
