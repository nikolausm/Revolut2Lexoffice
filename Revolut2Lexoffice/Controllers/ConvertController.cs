using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Revolut2LexOffice.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ConvertController : ControllerBase
	{
		private readonly ILogger<ConvertController> _logger;
		private readonly ISettings _configuration;

		public ConvertController(ILogger<ConvertController> logger, ISettings configuration)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		}
		[HttpGet]
		public string Get()
		{
			return "Works";
		}

		/// <summary>
		/// Upload a RevolutCsv file to convert it to a a LexOffice csv file.
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		[Consumes("multipart/form-data")]
		[Produces("text/csv")]
		[HttpPost]
		public FileResult PostAsync(IFormFile file)
		=> File(
			new System.Text.ASCIIEncoding().GetBytes(
				String.Join(
					"\r\n",
					LexOfficeRecords(
						file,
						_configuration
					).Select(row => new LexOfficeCsvLine(row).ToString())
				)
			),
			"text/csv"
		);

		
		private IEnumerable<ILexOfficeRecord> LexOfficeRecords(IFormFile file, ISettings settings)
		{

			var config = new CsvConfiguration(CultureInfo.DefaultThreadCurrentCulture)
			{
				Delimiter = ",",
				Encoding = System.Text.Encoding.UTF8,
				HasHeaderRecord = true
			};

			config.RegisterClassMap(new RevolutMap());

			if (file.Length > 0)
			{
				var filePath = Path.GetTempFileName();

				using (var stream = System.IO.File.Create(filePath))
				{

					using (var reader = new StreamReader(file.OpenReadStream()))
					using (var csv = new CsvReader(reader, config))
					{
						var result = csv.GetRecords<RevolutRecord>();
						foreach (var record in result)
						{
							yield return new LexOfficeRecordFromRevolutRecord(settings, record);
						}
					}
				}
			}

		}
	}
}
