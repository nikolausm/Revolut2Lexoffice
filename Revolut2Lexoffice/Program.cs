using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;


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
				
				if (hostContext.HostingEnvironment.IsProduction())
				{
					builder.AddAzureKeyVault(
						new Uri($"https://revolut2lexoffice.vault.azure.net/"),
						new EnvironmentCredential(),
						new KeyVaultSecretManager()
					);
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

