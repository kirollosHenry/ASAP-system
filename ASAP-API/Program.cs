
using ASAP_Application.Contract;
using ASAP_Application.Services.APIService;
using ASAP_Application.Services.CientService;
using ASAP_Application.Services.EmailService;
using ASAP_Application.Services.Hangifure;
using ASAP_Application.Services.StockService;
using ASAP_Context;
using ASAP_DTO.StockDTO;
using ASAP_Infrastracture.ClientRepository;
using ASAP_Infrastracture.stock;

using Hangfire;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using System.Configuration;

namespace ASAP_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddHangfire(configuration => configuration
            //                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            //                    .UseSimpleAssemblyNameTypeSerializer()
            //                    .UseRecommendedSerializerSettings()
            //                    .UseSqlServerStorage(builder.Configuration.GetConnectionString("Connstr")));
            //builder.Services.AddHangfireServer();
            //Add Configration for database here using connection string in appsetting 
            builder.Services.AddDbContext<ASAPDBcontext>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("Connstr"));
            });
            builder.Services.AddHttpClient<ApiService>();

            // Register ApiService with the dependency injection container
            builder.Services.AddScoped<ApiService>();
            builder.Services.AddScoped(_ => builder.Configuration["ApiSettings:ApiUrl"]); // Assuming you're using ASP.NET Core configuration
            builder.Services.AddScoped(_ => builder.Configuration["ApiSettings:ApiKey"]);
            // Add configuration for API settings
            builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IClientRepo, ClientRepository>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IEmail, Email>();
            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddScoped<IApiService, ApiService>();
            builder.Services.AddScoped<IStockService, stockService>();
            builder.Services.AddScoped<IStockRepo, StockRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
           
            app.UseAuthorization();
         //   app.UseHangfireDashboard();

            app.MapControllers();

            app.Run();
        }
    }
}
