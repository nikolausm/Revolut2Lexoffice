using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Revolut2LexOffice
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		=> Host.CreateDefaultBuilder(args).ConfigureAppConfiguration(
			(hostContext, builder) =>
			{
				if (hostContext.HostingEnvironment.IsDevelopment())
				{
					builder.AddUserSecrets("Revolut2LexOffice");
				}
			}
		).ConfigureWebHostDefaults(
			webBuilder =>
			{
				webBuilder.UseStartup<Startup>();
			}
		);
	}
}

