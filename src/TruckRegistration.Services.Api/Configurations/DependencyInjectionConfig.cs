using Microsoft.Extensions.DependencyInjection;
using System;
using TruckRegistration.Infra.CrossCutting.IoC;

namespace TruckRegistration.Services.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
