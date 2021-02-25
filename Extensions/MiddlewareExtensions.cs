using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Edmund.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Edmund Halley API",
                    Version = "v1",
                    Description = "Edmund Halley RESTful API"
                });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new string[] { }}
    });

                // add Basic Authentication
                var basicSecurityScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    Reference = new OpenApiReference { Id = "BasicAuth", Type = ReferenceType.SecurityScheme }
                };
                c.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {basicSecurityScheme, new string[] { }}
    });
                c.EnableAnnotations();
            });
            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api-docs/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api-docs/v1/swagger.json", "Edmund Halley API V1");
                c.RoutePrefix = "api-docs/v1";
            });
            return app;
        }
    }
}
