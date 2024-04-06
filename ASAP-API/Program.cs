
using ASAP_Application.Contract;
using ASAP_Application.Services.CientService;
using ASAP_Context;
using ASAP_Infrastracture.ClientRepository;
using Microsoft.EntityFrameworkCore;
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
            //Add Configration for database here using connection string in appsetting 
            builder.Services.AddDbContext<ASAPDBcontext>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("Connstr"));
            });
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IClientRepo, ClientRepository>();
            builder.Services.AddScoped<IClientService, ClientService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
