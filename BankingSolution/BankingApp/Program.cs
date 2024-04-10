using System.Text;
using BankAcountEstatementApp.Contexts;
using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Repositories;
using BankAcountEstatementApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BankingApp
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

            builder.Services.AddDbContext<BankingContext>(opts =>
            {
                opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            var stringkey = builder.Configuration.GetValue(typeof(string), "TokenKey").ToString();
            var key = Encoding.UTF8.GetBytes(stringkey);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opts =>
                    {
                        opts.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key)
                        };
                    });
           

            builder.Services.AddScoped<IRepository<string, User>, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddScoped<IRepository<int, Account>, AccountRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();

            app.MapControllers();

            app.Run();
        }
    }
}