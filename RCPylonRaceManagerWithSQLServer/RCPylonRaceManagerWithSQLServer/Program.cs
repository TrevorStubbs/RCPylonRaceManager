using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RCPylonRaceManagerWithSQLServer.Data;
using RCPylonRaceManagerWithSQLServer.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCPylonRaceManagerWithSQLServer
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = CreateHostBuilder(args);
            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<EntryForm>>();
                var entryForm = services.GetRequiredService<EntryForm>();

                try
                {                    
                    //var context = services.GetRequiredService<PylonDbContext>();
                    Application.Run(entryForm);

                    logger.LogInformation("Application has STARTED");

                }
                catch (Exception ex)
                {
                    logger.LogWarning("Application did not start");
                    throw;
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var startup = new Startup();

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    startup.ConfigureServcies(services);
                });

            return host;
        }
    }
}
