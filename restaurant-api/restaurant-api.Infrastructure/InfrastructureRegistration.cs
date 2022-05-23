using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using restaurant_api.Domain.DTOs.User;
using restaurant_api.Infrastructure.Context;
using restaurant_api.Infrastructure.Validators.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_api.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();

            return services;
        }
    }
}
