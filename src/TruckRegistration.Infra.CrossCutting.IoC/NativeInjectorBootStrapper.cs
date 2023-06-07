using Microsoft.Extensions.DependencyInjection;
using TruckRegistration.Application.Contracts;
using TruckRegistration.Application.Services;
using TruckRegistration.Domain.Commands;
using TruckRegistration.Domain.Contracts.Commands;
using TruckRegistration.Domain.Contracts.Repositories;
using TruckRegistration.Infra.Data.Respositories;

namespace TruckRegistration.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ITruckAppService, TruckAppService>();

            // Domain
            services.AddScoped<ITruckCommandHandler, TruckCommandHandler>();

            // Infra - Data
            services.AddScoped<ITruckRepository, TruckRepository>();
        }
    }
}
