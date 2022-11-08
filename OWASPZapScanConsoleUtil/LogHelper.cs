using Microsoft.Extensions.Configuration;
using Serilog;

namespace OWASPZapScanConsoleUtil
{
    public class LogHelper
    {
        /// <summary>
        /// Configure Serilog for logging
        /// </summary>
        public static IConfiguration SetupLogger()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            return configuration;
        }
    }
}
