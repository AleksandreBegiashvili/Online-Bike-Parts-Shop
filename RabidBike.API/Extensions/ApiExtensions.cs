using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RabidBike.API.ActionFilters;
using RabidBike.API.Helpers.Mapper;
using RabidBike.Domain.Entities;
using RabidBike.Services.Helpers.Mapper;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.API.Extensions
{
    public static class ApiExtensions
    {
        public static IServiceCollection RegisterCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });

            return services;
        }

        public static IServiceCollection RegisterMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfiles(new List<Profile>() { new ApiToServiceMappingProfile(), new ServiceToRepositoryMappingProfile() });
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static IServiceCollection AddPolicyAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireUser", policy =>
                {
                    policy.RequireRole("User", "Admin")
                    .RequireAuthenticatedUser();
                });
                options.AddPolicy("RequireAdmin", policy =>
                {
                    policy.RequireRole("Admin")
                    .RequireAuthenticatedUser();
                });
            });

            return services;
        }

        public static IServiceCollection AddActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ValidateEntityExistsAttribute<Item>>();
            return services;
        }
    }
}
