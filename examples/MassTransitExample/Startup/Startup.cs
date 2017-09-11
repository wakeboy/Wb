using System.IO;
using Microsoft.Extensions.Configuration;

namespace Wb.MassTransitExample.Startup
{
    public class Startup
    {
        public static IConfigurationRoot LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
