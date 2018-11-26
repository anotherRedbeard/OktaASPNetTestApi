using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OktaTestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(
                    c =>
                    {
                        // c.Listen(IPAddress.Any, 5000);
                        // c.Listen(IPAddress.Any, 5001, listenOptions =>
                        // {
                        //     listenOptions.UseHttps("/HTTPS_cert/https.pfx", "****");
                        //     listenOptions.UseHttps(new HttpsConnectionAdapterOptions
                        //     {
                        //         SslProtocols = SslProtocols.Tls12
                        //     });
                        // });
                        c.ConfigureHttpsDefaults(opt =>
                        {
                            opt.SslProtocols = SslProtocols.Tls12;
                        });
                    });
    }
}
