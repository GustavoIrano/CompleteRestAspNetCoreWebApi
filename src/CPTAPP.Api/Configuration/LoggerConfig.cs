using CPTAPP.Api.Extensions;
using Elmah.Io.AspNetCore;
using Elmah.Io.AspNetCore.HealthChecks;
using Elmah.Io.Extensions.Logging;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CPTAPP.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration (this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "eeb1bc1eace74695942cbe3b9d818489";
                o.LogId = new Guid("254c63d2-b3d8-4ab4-9c9b-7f2f9fa854dd");
            });

            services.AddLogging(builder =>
            {
                builder.AddElmahIo(o =>
                {
                    o.ApiKey = "eeb1bc1eace74695942cbe3b9d818489";
                    o.LogId = new Guid("254c63d2-b3d8-4ab4-9c9b-7f2f9fa854dd");
                });

                builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            });

            services.AddHealthChecks()
                .AddElmahIoPublisher("eeb1bc1eace74695942cbe3b9d818489", new Guid("254c63d2-b3d8-4ab4-9c9b-7f2f9fa854dd"), "API Fornecedores")
                .AddCheck("Produtos", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");
            services.AddHealthChecksUI();

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();
            app.UseHealthChecks("/api/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/api/hc-ui";
            });
            return app;
        }
    }
}
