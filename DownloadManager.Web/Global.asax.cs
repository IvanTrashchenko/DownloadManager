using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DownloadManager.Web.Logging;
using Serilog.Events;
using Serilog;

namespace DownloadManager.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Ensure the logs directory exists
            var logPath = Server.MapPath("~/logs");
            if (!System.IO.Directory.Exists(logPath))
            {
                System.IO.Directory.CreateDirectory(logPath);
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Error)
                .WriteTo.File(
                    path: System.IO.Path.Combine(logPath, "log-.txt"),
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}]\t[{Level:u}]\t{Message:lj}\t{Exception}{NewLine}",
                    rollingInterval: RollingInterval.Day,
                    shared: true
                )
                .CreateLogger();

            Log.Information("Application started.");

            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_End(object sender, EventArgs e)
        {
            Log.Information("Application stopped.");
            Log.CloseAndFlush();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Log.Error(exception, "An unhandled exception occurred.");
        }
    }
}
