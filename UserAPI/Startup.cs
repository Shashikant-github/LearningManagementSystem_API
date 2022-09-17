using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using UserAPI.Context;
using UserAPI.Repository;
using UserAPI.Services;
using UserAPI.UserAPILogFiles;

namespace UserAPI
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
            //string localConnectionStr = "Server=JRDOTNETFSE;User Id=sa;Password=;Database=FlightBooking";

            //string localConnectionStr = "Server=JRDOTNETFSE;Integrated Security = True; Database=FlightBooking";

            //string localConnectionStr = Configuration.GetConnectionString("LocalSQLServerSetting");
            string azureConnectionStr = Configuration.GetConnectionString("AzureSQLServerSetting");
            
            services.AddControllers();
            //Used for List
            //services.AddSingleton<IUserRepository, UserRepository>();
            //services.AddSingleton<IUserService, UserService>();

            //Used for Database
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
            services.AddSingleton<LoggingLogic>();

            //services.AddDbContext<UserDbContext>(u => u.UseSqlServer(localConnectionStr));
            services.AddDbContext<UserDbContext>(u => u.UseSqlServer(azureConnectionStr));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserAPI", Version = "v1" });
            });
            services.AddCors(u =>
            {
                u.AddDefaultPolicy(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("LogFiles/UserSerlog.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //Dev 
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserAPI v1"));
            }
            //in PROD azure
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserAPI v1"));
            app.UseCors();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
