using CleanArch.Application;
using CleanArch.Application.Middleware;
using CleanArch.Infrastructure;
using CleanArch.Persistence;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Serilog;

namespace CleanArch.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;

        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddApplicationServices();

            services.AddInfrastructureServices(Configuration);

            services.AddPersistenceServices(Configuration);

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services.AddFeatureManagement();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //log.AddSerilog();

            //app.UseAuthentication();

            //app.UseAuthorization();

            //app.UseSwagger();

            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArch.Api v1"));

            //app.UseHealthChecks("/healthz", new HealthCheckOptions
            //{
            //    Predicate = _ => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            //    ResultStatusCodes =
            //    {
            //        [HealthStatus.Healthy] = StatusCodes.Status200OK,
            //        [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
            //        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
            //    },
            //}).UseHealthChecksUI(setup =>
            //{
            //    setup.ApiPath = "/healthcheck";
            //    setup.UIPath = "/healthcheck-ui";
            //});

            //app.UseCustomExceptionHandler();

            //app.UseCors("Open");

            app.UseCors("AllowAnyOrigin");

            app.UseEndpoints(endpoints =>
            {
                var x = env.EnvironmentName;
                endpoints.MapControllers();
            });

        }

    }
}
