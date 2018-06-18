namespace SWAG
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Serilog;
    using Serilog.Sinks.MSSqlServer;
    using SWAG.Controllers;
    using System;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                 .UseContentRoot(Directory.GetCurrentDirectory())
                 .ConfigureLogging(ConfigureLogging)
                 .UseStartup<Startup>()
                 .Build();
            return host;
        }

        private static void ConfigureLogging(WebHostBuilderContext context, ILoggingBuilder loggingBuilder)
        {
            var env = context.HostingEnvironment;
            var config = context.Configuration;

            loggingBuilder.AddDebug();
            loggingBuilder.AddConsole();
            var connString = context.Configuration.GetConnectionString("LogConnection");
            AddLoggingProvider(loggingBuilder, connString);
            if (!env.IsDevelopment())
            {

            }
            else
            {
                Serilog.Debugging.SelfLog.Out = Console.Out; // output logging error ot console from Serilog
            }
        }
        private static void AddLoggingProvider(ILoggingBuilder loggingBuilder, string connectionString)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var tableName = "Log";
            var columnOptions = new ColumnOptions();

            var fileLogger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .MinimumLevel.Information()
                .WriteTo.File(path: "C:\\Logs\\SWAG\\log.txt",
                                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u8}] [{SourceContext}] {Message}{NewLine}{Exception}",
                                fileSizeLimitBytes: 1024 * 1024 * 10,
                                rollingInterval: RollingInterval.Day,
                                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
                .CreateLogger()
                .ForContext<ValuesController>();

           
            var dbLogger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(connectionString,
                                    tableName: tableName,
                                    columnOptions: columnOptions,
                                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)
                .CreateLogger()
                .ForContext<ValuesController>();

            loggingBuilder.AddSerilog(fileLogger);
            loggingBuilder.AddSerilog(dbLogger);
        }
    }
}
