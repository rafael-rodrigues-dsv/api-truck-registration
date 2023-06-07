using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using TruckRegistration.Infra.Data.Context;
using TruckRegistration.Services.Api.Configurations;

namespace TruckRegistration.Services.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Setting DBContexts
            services.AddDatabaseConfiguration(this.Configuration);

            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfiguration();

            // AutoMapper Settings
            services.AddAutoMapperConfiguration();

            // Api Version Config
            services.AddVersioningConfiguration();

            // Swagger Config
            services.AddSwaggerConfiguration();

            // Routing Lowercase Config
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SqlServerDataContext dataContext)
        {
            // Use AutoMigration Configuration from Database
            DatabaseConfig.UseAutoMigration(dataContext, this.Configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerSetup();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
