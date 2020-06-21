using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;
using CBA.Training.Talmate.Common;
using CBA.Training.Talmate.Services.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using CBA.Training.Talmate.Repository;
using AutoMapper;
using CBA.Training.Talmate.Services.DemandService;
using System.Collections.Generic;
using CBA.Training.Talmate.Api.Filter;
using CBA.Training.Talmate.Api.ExceptionHandling;
using CBA.Training.Talmate.Services.LoggerService;
using CBA.Training.Talmate.Services.RecommendationService;

namespace CBA.Training.Talmate.Api
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
            services.AddCors();
            services.AddControllers();
            services.AddScoped<TalmateActionFilterAttribute>();
            services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(CustomExceptionHandler));                
            });

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
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

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDemandService, DemandService>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<IRecommendationService, RecommendationService>();


            services.AddSwaggerGen(c => 
            { 
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CBA.Training.Talmate.Api", Version = "v1" });
                c.OperationFilter<AuthorizeCheckOperationFilter>();
                //c.EnableAnnotations();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: 'Bearer 12345abcdef'"
                });
            });

            services.AddDbContext<TalmateDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }
            app.UseSwagger();
            app.UseSwaggerUI(c=>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CBA.Training.Talmate.Api");               
            });
            app.UseHttpsRedirection();

            app.UseRouting();            

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
