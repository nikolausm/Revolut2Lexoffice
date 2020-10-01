using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace revolutToLexOffice
{
	class Program
	{
		static void Main(string[] args)
		{
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

			if (args.Length < 1)
			{
				throw new Exception("Not csv file provided");
			}

			var file = args[0];

			if (!System.IO.File.Exists(file))
			{
				throw new Exception($"FileNotFound: {file}");
			}

			var settings = new Settings(
				"Michael Nikolaus (Minicon, IT Consulting)",
				"GB81 REVO 0099 6911 5564 43",
				"REVOGB21"
			);

			var config = new CsvConfiguration(CultureInfo.DefaultThreadCurrentCulture)
			{
				Delimiter = ",",
				Encoding = System.Text.Encoding.UTF8,
				HasHeaderRecord = true,
				CultureInfo = CultureInfo.DefaultThreadCurrentCulture
			};

			var recordsForWriter = new List<ILexOfficeRecord>();
			config.RegisterClassMap(new RevolutMap());

			int counter = 0;
			using (var reader = new StreamReader(file))
			using (var csv = new CsvReader(reader, config))
			{

				var result = csv.GetRecords<RevolutRecord>();
				System.Console.WriteLine("Converting records");
				foreach (var record in result)
				{
					counter++;
					if (counter % 10 == 0)
					{
						System.Console.Write(".");
					}

					recordsForWriter.Add(
						new LexOfficeRecordFromRevolutRecord(settings, record)
					);


				}
				System.Console.WriteLine($"Done converting.");
			} 

			var writerConfiguration = new CsvConfiguration(new CultureInfo("de-DE"));
			writerConfiguration.Delimiter = ",";
			var targetFile = file.Replace(".csv", "_lexOffice.csv");

			Console.WriteLine("Writing: " + targetFile);
			using (var writer = new StreamWriter(targetFile))
			using (var csv = new CsvWriter(writer, writerConfiguration))
			{
				System.Console.WriteLine($"Writing Records {recordsForWriter.Count}");

				csv.WriteRecords(recordsForWriter);
				writer.Flush();
			}

			System.Console.WriteLine($"Done writing {targetFile}");


		}
	}
}
