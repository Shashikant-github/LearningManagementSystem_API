using AirlineAPI.Services;
using CoursesAPI.Context;
using CoursesAPI.Repository.CommandRepository;
using CoursesAPI.Repository.QueryRepository;
using CoursesAPI.Services.CommandServices;
using CoursesAPI.Services.QueryServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CoursesAPI
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
            //string sqlCoursesDbConnection = Configuration.GetConnectionString("localCoursesSQLConnectionStr");

            string azureSqlCourseDbConnection = Configuration.GetConnectionString("AzureCoursesSQLConnectionStr");

            //services.AddDbContext<CoursesDbContext>(a => a.UseSqlServer(sqlCoursesDbConnection));
            services.AddDbContext<CoursesDbContext>(a => a.UseSqlServer(azureSqlCourseDbConnection));

            services.AddControllers();
            services.AddScoped<ICoursesCommandService, CoursesCommandService>();
            services.AddScoped<ICoursesCommandRepository, CoursesCommandRepository>();
            services.AddScoped<ICoursesQueryService, CoursesQueryService>();
            services.AddScoped<ICoursesQueryRepository, CoursesQueryRepository>();
            TokenValidation(Configuration, services);
            //services.AddAuthentication(a => { a.DefaultAuthenticateScheme = "gg"; a.DefaultChallengeScheme = ""; });

            services.AddMvc();
            services.AddCors(u =>
            {
                u.AddDefaultPolicy(b => b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            });
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AirlineAPI", Version = "v1" });
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoursesAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                         new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}

                    }


                });
            });
        }

        private void TokenValidation(IConfiguration configuration, IServiceCollection services)
        {
            var userAuthTokenDetails = configuration.GetSection("UserAuthTokenDetails");

            var userSecretKey = userAuthTokenDetails["UserSecretKey"];
            var userIssuer = userAuthTokenDetails["UserIssuer"];
            var userAudience = userAuthTokenDetails["UserAudience"];

            var userSecretKeyInBytes = Encoding.ASCII.GetBytes(userSecretKey);
            var userSymmetricSecurityKey = new SymmetricSecurityKey(userSecretKeyInBytes);
            // var userSigningCredentials = new SigningCredentials(userSymmetricSecurityKey,"" );
            var userTokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = userIssuer,

                ValidateAudience = true,
                ValidAudience = userAudience,

                ValidateIssuerSigningKey = true,

                IssuerSigningKey = userSymmetricSecurityKey,

                ValidateLifetime = true,
                ClockSkew = System.TimeSpan.Zero
            };
            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(u => u.TokenValidationParameters = userTokenValidationParameters);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("SeriLogFiles/Log.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //in Dev
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CousesAPI v1"));
            }
            //in Prod Azure
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CousesAPI v1"));

            app.UseCors();
            app.UseHttpsRedirection();

            app.UseRouting();

            //imp
            //app.UseAuthorization();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
