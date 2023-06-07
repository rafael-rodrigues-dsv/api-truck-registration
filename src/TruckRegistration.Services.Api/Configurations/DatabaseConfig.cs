using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TruckRegistration.Infra.Data.Context;

namespace TruckRegistration.Services.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<SqlServerDataContext>();
        }

        public static void UseAutoMigration(SqlServerDataContext dataContext, IConfiguration configuration)
        {
            var inMemoryDatabase = bool.Parse(configuration.GetSection("InMemoryDatabase").Value);

            if (!inMemoryDatabase)
            {
                dataContext.Database.Migrate();
            }
        }
    }
}
