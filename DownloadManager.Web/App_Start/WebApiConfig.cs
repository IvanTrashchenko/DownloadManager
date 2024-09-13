using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using DownloadManager.Web.Logging;
using Serilog;

namespace DownloadManager.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            string hostname = Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME");

            if (!string.IsNullOrWhiteSpace(hostname))
            {
                string subdomain = null;

                if (!string.IsNullOrEmpty(hostname))
                {
                    // Split the hostname into parts
                    var parts = hostname.Split('.');

                    // Assuming the format is subdomain.azurewebsites.net, the subdomain is the first part
                    if (parts.Length > 2)
                    {
                        subdomain = parts[0];
                    }
                }

                Log.Information($"Subdomain (WEBSITE_HOSTNAME): {subdomain}");

                var corsAzure = new EnableCorsAttribute($"https://{subdomain}.azurewebsites.net", "*", "*");
                config.EnableCors(corsAzure);
            }

            //var corsDebug = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            //config.EnableCors(corsDebug);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }
    }
}
