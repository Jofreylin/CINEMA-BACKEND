﻿using Application.DTO;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Context;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? databaseConnection, IConfigurationSection? jwtConfigurationSection)
        {

            if (jwtConfigurationSection is not null)
            {
                services.Configure<JwtConfiguration>(jwtConfigurationSection);
            }

            services.AddDbContext<CinemaContext>(opt => opt.UseSqlServer(databaseConnection));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();

            return services;
        }
    }
}
