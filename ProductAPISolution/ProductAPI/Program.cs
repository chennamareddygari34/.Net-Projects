using Microsoft.EntityFrameworkCore;
using ProductAPI.Context;
using ProductAPI.Interfaces;
using ProductAPI.Models;
using ProductAPI.Repositories;
using ProductAPI.Services;

namespace ProductAPI
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



            builder.Services.AddDbContext<ProductContext>(opts =>
            {
                opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("MyCors");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}