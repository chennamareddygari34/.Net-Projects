using BankingWebApi.Services;

namespace BankingFilterApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new AuthActionFilter());
                //options.Filters.Add(new ExceptionFilter());
                //options.Filters.Add(new RequestLogFilter());
                //options.Filters.Add(new ResponseLogFilter());
                //options.Filters.Add(new BankingResultFilter());

            });
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<RequestLogFilter>();
            builder.Services.AddScoped<AuthActionFilter>();
            builder.Services.AddScoped<ExceptionFilter>();
            builder.Services.AddScoped<ResponseLogFilter>();
            builder.Services.AddScoped<BankingResultFilter>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}