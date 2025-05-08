using Application.Service;
using Application.Service.Interface;
using Core.Repository.Interface;
using Infraestructure.Configuration;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace webApi.Extensions
{
    public static class WebApiConfigurationExtension
    {
        public static void ConfigureControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddMemoryCache();

            builder.Services
                .AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                })
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
                });
        }

        public static void ConfigureDbContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IDirectDistanceDialingService, DirectDistanceDialingService>();

            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IDirectDistanceDialingRepository, DirectDistanceDialingRepository>();
        }

        public static void ConfigureSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "APIStorageContato",
                    Version = "v1",
                    Description = "Esta API realiza operações diretas no banco de dados para gerenciamento de contatos por DDD.",
                });
            });
        }
    }
}
