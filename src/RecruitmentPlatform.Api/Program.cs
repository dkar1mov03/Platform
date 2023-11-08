using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Api.Extensions;
using RecruitmentPlatform.Api.Middlewares;
using RecruitmentPlatform.Data.DbContexts;

namespace RecruitmentPlatform.Api
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

            //JWT
            builder.Services.AddJwtService(builder.Configuration);

            //Swagger
            builder.Services.AddSwaggerService();
            //Database Configuration
            builder.Services.AddDbContext<AppDbContext>(option
                => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
                );
            builder.Services.AddCustomService();

            

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //middlewares

            app.UseMiddleware<ExceptionHandlermiddleWares>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}