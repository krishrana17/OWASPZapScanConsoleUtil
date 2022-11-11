using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Serilog;
using CliWrap;
using CliWrap.Buffered;

namespace OWASPZapScanConsoleUtil
{
    public class ZapScanRunner
    {

        private static readonly ILogger _logger = Log.ForContext<ZapScanRunner>();

        public static IConfiguration Configuration { get; set; }

        public static async void StartScan()
        {
            ValidateZapInstallation();

            Console.WriteLine("Site scan started..");
            _logger.Information("Site scan started at - {Now}", DateTime.Now.ToString("f"));

            var commandResult = await Cli.Wrap("powershell.exe")
                .WithWorkingDirectory(Configuration["ZAPScan:ZapInstallPath"])
                .WithArguments(new[]
                    {
                        "java",
                        "-jar",
                        "zap-2.12.0.jar",
                        "-cmd",
                        "-quickurl",
                        Configuration.GetValue<string>("ZAPScan:WebsiteUrlToScan"),
                        "-quickprogress",
                        "-quickout",
                        $"{Path.Combine(Configuration.GetValue<string>("ZAPScan:ReportPath"), $"Report_{DateTime.Now:yyyy_MM_dd_hh_mm}.html")}"
                    }
                )
                .ExecuteBufferedAsync();

            _logger.Information(commandResult.StandardOutput);
        }

        /// <summary>
        /// Get CLI Command of ZAP which we'll run in Powershell CLI
        /// </summary>
        /// <returns></returns>
        //private static string GetZapCommand()
        //{
        //    string resultFile = $"Report_{DateTime.Now:yyyy_MM_dd_hh_mm}.html";

        //    StringBuilder commandBuilder = new();
        //    commandBuilder.Append("java -jar zap-2.12.0.jar -cmd ");
        //    commandBuilder.Append($"-quickurl {Configuration.GetValue<string>("ZAPScan:WebsiteUrlToScan")} ");
        //    commandBuilder.Append("-quickprogress ");
        //    commandBuilder.Append($"-quickout {Path.Combine(Configuration["ZAPScan:ReportPath"], resultFile)}");
        //    return commandBuilder.ToString();
        //}

        //public static void StartScan()
        //{
        //    ValidateZapInstallation();
        //    string scanCommand = GetZapCommand();

        //    Process process = new()
        //    {
        //        StartInfo = new()
        //        {
        //            FileName = "powershell.exe",
        //            CreateNoWindow = false,
        //            UseShellExecute = false,
        //            RedirectStandardInput = true,
        //            RedirectStandardOutput = true,
        //            //Arguments = @"/c cd C:\Program Files\OWASP\Zed Attack Proxy"
        //        }
        //    };

        //    process.Start();
        //    Console.WriteLine("Site scan started..");
        //    _logger.Information("Site scan started at - {Now}", DateTime.Now.ToString("f"));
        //    process.StandardInput.WriteLine($"cd \"{Configuration["ZAPScan:ZapInstallPath"]}\" ");
        //    process.StandardInput.WriteLine(scanCommand);
        //    process.StandardInput.Flush();
        //    process.StandardInput.Close();
        //    _logger.Information(process.StandardOutput.ReadToEnd());
        //    process.WaitForExit();
        //}

        /// <summary>
        /// Throws an exception if ZAP_2_12_0 is not installed on the machine.
        /// </summary>
        private static void ValidateZapInstallation()
        {
            if (!Directory.Exists(Configuration["ZAPScan:ZapInstallPath"]))
            {
                throw new DirectoryNotFoundException("ZAP Tool is not installed!");
            }
        }
    }
}
