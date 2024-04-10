using LoanApp.Contexts;
using LoanApp.Interfaces;
using LoanApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using ServiceStack;

namespace LoanApp
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
            builder.Services.AddDbContext<LoanContext>(opts =>
            {
                opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IBikeLoanService, BikeLoanService>();
            builder.Services.AddScoped<ICarLoanService, CarLoanService>();
            builder.Services.AddScoped<IBusLoanService, BusLoanService>();

            builder.Services.AddMvc();
            builder.Services.AddControllers();

            builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new HeaderApiVersionReader("options-api-version");


            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseRouting();


            app.MapControllers();
            app.Use(async (context, next) =>

            {

                context.Response.Headers.Append("X-Frame-Options", "SAMEORIGIN");

                await next();

            });


            app.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}