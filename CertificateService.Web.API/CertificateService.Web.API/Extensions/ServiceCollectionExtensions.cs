using CertificateService.Web.API.Core.Helpers.Models;
using CertificateService.Web.API.Core.Services;
using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Data.Repositories;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;

namespace CertificateService.Web.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ServiceInjection(this IServiceCollection services)
        {
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentDataRepository, StudentDataRepository>();
            services.AddScoped<IStudentTicketRepository, StudentTicketRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IGroupsService, GroupsService>();
            services.AddScoped<IFacultiesService, FacultiesService>();
            services.AddScoped<IStudentsService, StudentsService>();
            services.AddScoped<ICertificatesService, CertificatesService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtTokenProviderService, JwtTokenProviderService>();
        }

        public static void AddJwtBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection(nameof(AuthorizationModel));
            services.Configure<AuthorizationModel>(appSettingsSection);

            var authModel = appSettingsSection.Get<AuthorizationModel>();
            var key = Encoding.ASCII.GetBytes(authModel.ClientSecret);

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static void AddSwaggerAuthentication(this IServiceCollection services)
        {
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo { Title = string.Empty, Version = "v1" });
                o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. " +
                        "Enter 'Bearer' [space] and then your token in the text input below.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                o.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });            
        }
    }
}
