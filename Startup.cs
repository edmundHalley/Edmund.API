using AutoMapper;
using Edmund.API.Domain.Persistence.Contexts;
using Edmund.API.Domain.Repositories;
using Edmund.API.Domain.Services;
using Edmund.API.Domain.Services.Communications;
using Edmund.API.Extensions;
using Edmund.API.Persistence.Repositories;
using Edmund.API.Services;
using Edmund.API.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edmund.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("edmund-api-in-memory");
            });

            //AppSettings Section Reference
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // Json Web Tpken Authentication Configuration
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //Authentication Service Configuration
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            



            services.AddScoped<IEducationalStageRepository, EducationalStageRepository>();
            services.AddScoped<IEducationalStageSubjectRepository, EducationalStageSubjectRepository>();
            services.AddScoped<IMarkRepository, MarkRepository>();
            services.AddScoped<IMarksRecordRepository, MarksRecordRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserSubjectRepository, UserSubjectRepository>();
            services.AddScoped<IClassroomRepository, ClassroomRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEducationalStageService, EducationalStageService>();
            services.AddScoped<IEducationalStageSubjectService, EducationalStageSubjectService>();
            services.AddScoped<IMarkService, MarkService>();
            services.AddScoped<IMarksRecordService, MarksRecordService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserSubjectService, UserSubjectService>();
            services.AddScoped<IClassroomService, ClassroomService>();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddAutoMapper(typeof(Startup));
            services.AddCustomSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options =>
            {
                options.WithOrigins("*");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("https://localhost:44346/api-docs/v1/swagger.json", "My API V1");

            });
            app.UseCustomSwagger();
        }
    }
}
