using BankAcountEstatementApp.Contexts;
using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Repositories;
using BankAcountEstatementApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankAcountEstatementApp
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

            builder.Services.AddDbContext<EStatementContext>(opts =>
            {
                opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            builder.Services.AddScoped<IRepository<string, User>, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddScoped<IRepository<int, Account>, AccountRepository>();
            builder.Services.AddScoped<IRepository<int, Statement>, StatementRepository>();

            builder.Services.AddScoped<IRepository<int, Currency>, CurrencyRepository>();
            builder.Services.AddSingleton<ICurrencyService, CurrencyService>();

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ITransactionService, TransactionService>();


            //builder.Services.AddScoped<ICurrencyService, CurrencyService>();
            builder.Services.AddScoped<IRepository<int, Transaction>, TransactionRepository>();

            builder.Services.AddTransient<IStatementService, StatementService>();
           


            builder.Services.AddMvc();
         
            builder.Services.AddControllers();


            using var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            builder.Services.AddMvc();
            app.MapControllers();
            

            app.Use(async (context, next) =>

            {

                context.Response.Headers.Append("X-Frame-Options", "SAMEORIGIN");

                await next();

            });



            //app.UseMiddleware<HeaderMiddleware>();

            app.Run();
        }
    }
}