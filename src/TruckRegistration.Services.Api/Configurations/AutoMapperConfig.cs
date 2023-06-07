using Microsoft.Extensions.DependencyInjection;
using System;
using TruckRegistration.Application.AutoMapper;

namespace TruckRegistration.Services.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(AutoMapperMappingProfile));
        }
    }
}
