using Psigest.Domain.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Psigest.Application.Interface;
using Psigest.Application.Mappings;
using Psigest.Application.Services;
using Psigest.Domain.Interfaces;
using Psigest.Infrastructure.Data.Context;
using Psigest.Infrastructure.Data.Identity;
using Psigest.Infrastructure.Data.Repositories;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Psigest.Infrastructure.CrossCutting.Ioc;
public static class DependencyInjection
{

    // <summary>
    ///  Configura e adiciona as infraestruturas necessárias para a aplicação.
    /// </summary>
    /// <param name="services">Coleção de serviços</param>
    /// <param name="configuration">Configurações da aplicação</param>
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddMappers(services);
        AddDbContext(services, configuration);
        ConfigureIoC(services);
        AddIdentity(services);
        AddInfrastructureJWT(services, configuration);
        AddSwagger(services);
    }

    /// <summary>
    /// Configura a inversão de dependências
    /// </summary>
    /// <param name="services">Coleção de serviços</param>
    private static void ConfigureIoC(IServiceCollection services)
    {
        services.AddScoped<IClinicRepository, ClinicRepository>();
        services.AddScoped<IHealthInsuranceRepository, HealthInsuranceRepository>();
        services.AddScoped<IClinicService, ClinicService>();
        services.AddScoped<IHealthInsuranceService, HealthInsuranceService>();
        services.AddScoped<IAuthenticate, AuthenticateService>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
    }
    /// <summary>
    /// Configura a conexão com o banco de dados
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });
    }

    private static void AddIdentity(IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
    }

    private static void AddInfrastructureJWT(this IServiceCollection services,
            IConfiguration configuration)
    {
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                     Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                ClockSkew = TimeSpan.Zero
            };
        });
    }

    private static void AddMappers(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
    }

    private static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            
            var xmlFileService = $"{Assembly.Load("Psigest").GetName().Name}.xml";
            var xmlPathService = Path.Combine(AppContext.BaseDirectory, xmlFileService);
            options.IncludeXmlComments(xmlPathService);

            var xmlFileApplication = $"{Assembly.Load("Psigest.Application").GetName().Name}.xml";
            var xmlPathApplication = Path.Combine(AppContext.BaseDirectory, xmlFileApplication);
            options.IncludeXmlComments(xmlPathApplication);


            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Psigest Api",
                Description = "Api para agendamento de pacientes",
                Contact = new OpenApiContact
                {
                    Name = "Email",
                    Email = "victor.hugo.antunes.n@gmail.com"
                }
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] " +
                    "and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                            Array.Empty<string>()
                    }
                });
        });
    }
}
