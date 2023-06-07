using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetDevPack.Messaging;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Infra.Data.Mappings;

namespace TruckRegistration.Infra.Data.Context
{
    public sealed class SqlServerDataContext : DbContext
    {
        public SqlServerDataContext()
        {

        }

        public SqlServerDataContext(DbContextOptions<SqlServerDataContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Truck> Truck { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new TruckMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = GetConfigurationRootDataBase();

                if (IsInMemoryDatabase(configuration))
                {
                    optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");
                }
                else
                {
                    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                }

                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        private IConfigurationRoot GetConfigurationRootDataBase()
        {
            return new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
        }

        private bool IsInMemoryDatabase(IConfigurationRoot configurationRoot)
        {
            return bool.Parse(configurationRoot.GetSection("InMemoryDatabase").Value);
        }

        private bool IsInMemoryMockDatabase(IConfigurationRoot configurationRoot)
        {
            return bool.Parse(configurationRoot.GetSection("InMemoryMockDatabase").Value);
        }
    }
}
