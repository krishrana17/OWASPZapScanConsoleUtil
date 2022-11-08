using System;
using Serilog;

namespace OWASPZapScanConsoleUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = LogHelper.SetupLogger();

            try
            {
                ZapScanRunner.Configuration = configuration;
                ZapScanRunner.StartScan();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An exception occurred.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
