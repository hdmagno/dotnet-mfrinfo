using System;
using System.Collections.Generic;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.Cep;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Domain.Interfaces.Services.Uf;
using Api.Infra.Contexts;
using Api.Infra.Repository;
using Api.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api.CrossCutting.DependencyInjection
{
    public static class ConfigureDependencyInjection
    {
        public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext
            services.AddDbContext<DataContext>(opt =>
                opt.UseMySql(configuration.GetConnectionString("MySqlString")));
            #endregion

            #region InterfacesRepository
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUfRepository, UfRepository>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped<ICepRepository, CepRepository>();
            #endregion

            #region InterfacesServices
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUfService, UfService>();
            services.AddScoped<IMunicipioService, MunicipioService>();
            services.AddScoped<ICepService, CepService>();
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Curso Api com AspNetCore",
                    Description = "Arquitetura com DDD",
                    TermsOfService = new Uri("http://www.meusite.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Hilton Magno",
                        Email = "hdmagno@gmail.com",
                        Url = new Uri("http://facebook.com/hdmagno")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de licença de uso",
                        Url = new Uri("http://www.meusite.com")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre com o Token JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme,
                            }
                        }, new List<string>()
                    }
                });
            });
            #endregion
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso de AspNetCore 3.1");
                c.RoutePrefix = string.Empty;
            });
            #endregion
        }
    }
}
