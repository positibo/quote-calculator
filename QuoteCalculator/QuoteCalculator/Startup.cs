using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using QuoteCalculator.Entities;
using QuoteCalculator.Source.Domain.Helpers;

namespace QuoteCalculator
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
            var appSettingSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingSection.Get<AppSettings>();
            services.Configure<AppSettings>(appSettingSection);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Quote Calculator Web API", Version = "v1" });
            });

            services.AddDbContextPool<DataContext>(context => context
              .UseLazyLoadingProxies()
              .UseSqlServer(appSettings.ConnectionString)
              );

            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerProvider loggerProvider)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quote Calculator Web API"));

            app.ConfigureExceptionHandler(loggerProvider.CreateLogger("default"));
            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
