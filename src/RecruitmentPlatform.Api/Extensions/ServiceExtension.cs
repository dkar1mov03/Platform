using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RecruitmentPlatform.Data.IRepositories;
using RecruitmentPlatform.Data.Repositories;
using RecruitmentPlatform.Service.Interfaces.IEmployeers;
using RecruitmentPlatform.Service.Interfaces.IJobAplications;
using RecruitmentPlatform.Service.Interfaces.IJobLists;
using RecruitmentPlatform.Service.Interfaces.IJobSeekers;
using RecruitmentPlatform.Service.Mappings;
using RecruitmentPlatform.Service.Services.EmployeerServices;
using RecruitmentPlatform.Service.Services.JobAplicationServices;
using RecruitmentPlatform.Service.Services.JobListServices;
using RecruitmentPlatform.Service.Services.JobSeekerServices;
using System.Reflection;
using System.Text;

namespace RecruitmentPlatform.Api.Extensions;

public static class ServiceExtension
{
    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<IJobAplicationService, JobAplicationService>();
        services.AddScoped<IJobSeekerService, JobSeekerService>();
        services.AddScoped<IJobListService,JobListService>();
        services.AddScoped<IEmployeerService,EmployeerService>();
    }
    public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                ClockSkew = TimeSpan.Zero
            };
        });
    }

    public static void AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "RecruitmentPlatform.Api", Version = "v1" });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[]{ }
            }
        });
        });
    }
}
