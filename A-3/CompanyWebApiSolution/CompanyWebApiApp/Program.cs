using CompanyApplication.Interfaces.CompanyApplication.Interfaces;
using System.Security.Principal;
using CompanyWebApiApp.Contexts;
using Microsoft.EntityFrameworkCore;
using CompanyApplication.Models;
using CompanyApplication.Repositories;
using CompanyWebApiApp.Interfaces;
using CompanyWebApiApp.Services;

namespace CompanyWebApiApp
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

            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("MyCors", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            builder.Services.AddDbContext<CompanyContext>(opts =>
            {
                opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IRepository<int, Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IRepository<int, Department>, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseCors("MyCors");


            app.MapControllers();

            app.Run();
        }
    }
}
