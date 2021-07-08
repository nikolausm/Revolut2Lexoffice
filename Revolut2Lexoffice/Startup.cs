using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;

namespace Revolut2LexOffice
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
		}

		public IConfiguration Configuration { get; }

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddSwaggerGen(
				configuration =>
				{
					var appName = "Revolut2LexOffice";
					configuration.SwaggerDoc(
						"v1",
						new OpenApiInfo
						{
							Version = "v1",
							Title = appName,
							Description = "Converts Revolut CSV files that can be imported by LexOffice.",
							Contact = new OpenApiContact
							{
								Name = "Michael Nikolaus",
								Email = "michael.nikolaus@minicon.eu",
								Url = new Uri("https://www.minicon.eu"),
							}
						}
					);

					configuration.IncludeXmlComments(
						Path.Combine(
							AppContext.BaseDirectory,
							appName + ".xml"
						)
					);
				}
			);

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwagger();

			app.UseSwaggerUI(
				configuration =>
				{
					configuration.SwaggerEndpoint("/swagger/v1/swagger.json", "Converter Api V1");
					configuration.RoutePrefix = String.Empty;
				}
			);

			app.UseRouting();
			
			var client = new SecretClient(
				new Uri("https://revolut2lexoffice.vault.azure.net/"),
				new DefaultAzureCredential(),
				new SecretClientOptions()
				{
					Retry =
					{
						Delay= TimeSpan.FromSeconds(2),
						MaxDelay = TimeSpan.FromSeconds(16),
						MaxRetries = 5,
						Mode = RetryMode.Exponential
					}
				}
			);

			KeyVaultSecret secret = client.GetSecret("PrivateAccountSettings");
			
			
			app.UseEndpoints(
				endpoints =>
				{
					endpoints.MapControllers();
				}
			);

			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(
			endpoints =>
				{
					endpoints.MapControllers();
				}
			);
		}
	}
}
