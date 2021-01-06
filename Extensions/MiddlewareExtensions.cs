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
