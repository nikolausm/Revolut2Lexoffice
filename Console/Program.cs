using Console.Extensions;
using Console.Extensions.Configuration;
using CsvHelper;
using CsvHelper.Configuration;
using Domain;
using Domain.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Revolut2LexOffice;
using System;
using System.Globalization;
using System.IO;

namespace Console
{
	class Program
	{
		public static IConfigurationRoot Configuration { get; private set; }

		static void Main(string[] args)
		{

			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
			var config = new CsvConfiguration(CultureInfo.DefaultThreadCurrentCulture)
			{
				Delimiter = ",",
				Encoding = System.Text.Encoding.UTF8,
				HasHeaderRecord = true,
			};

			string fileName = (args.Length < 1)
				? FileFromConsoleInput()
				: args[0];

			string targetFileName = TargetFileName(args, fileName);

			Configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddUserSecrets<Program>()
				.Build();

			var settings = Configuration.GetSection("PrivateAccountSettings").Get<Settings>();

			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(fileName);
			}

			if (File.Exists(targetFileName))
			{
				throw new FileAlreadyExists(targetFileName);
			}

			WriteConvertedFile(config, fileName, settings, targetFileName);
		}

		private static string TargetFileName(string[] args, string sourceFile)
		{
			var index = 1;
			var target = (args.Length > 1)
				? args[1]
				: sourceFile;

			var currentTarget = target;
			while (File.Exists(currentTarget))
			{
				currentTarget = AppendConverted(target, index++);
			}
			return currentTarget;
		}

		private static string AppendConverted(string fileName, int index)
		{
			return fileName.Substring(0, fileName.LastIndexOf('.')).With($".converted{index:D3}.csv");
		}

		private static void WriteConvertedFile(CsvConfiguration config, string fileName, Settings settings, string targetFileName)
		{
			var file = File.OpenRead(fileName);

			config.RegisterClassMap(new RevolutMap());

			if (file.Length > 0)
			{

				using (var targetFile = System.IO.File.Create(targetFileName))
				{

					using (var reader = new StreamReader(file, true))
					using (var csv = new CsvReader(reader, config))
					{
						var result = csv.GetRecords<RevolutRecord>();
						foreach (var record in result)
						{
							targetFile.Write(
								System.Text.Encoding.UTF8.GetBytes(
									new LexOfficeCsvLine(
										new LexOfficeRecordFromRevolutRecord(settings, record)
									).ToString() + "\r\n"
								)
							);
						}
					}
				}
				System.Console.WriteLine($"Wrote to file: {targetFileName}");
			}
		}

		private static string FileFromConsoleInput()
		{
			var files = Directory.GetFiles(Environment.CurrentDirectory, "*.csv");
			if (files.Length == 0)
			{
				throw new Console.MissingFileParameterException("You need to start the application with a file parameter or add some parsable csv files int the directory.");
			}

			int fileNumber = 1;
			var filesInDictionary = new System.Collections.Generic.Dictionary<int, string>();
			foreach (var fileInDirectory in files)
			{
				filesInDictionary.Add(fileNumber, fileInDirectory);
				System.Console.WriteLine($"[{fileNumber++}]: {fileInDirectory}");
			}
			var trycount = 0;
			do
			{
				trycount++;
				System.Console.Write("Choose a file #: ");
				if (Int32.TryParse(System.Console.ReadLine(), out int result) && (filesInDictionary.ContainsKey(result)))
				{
					return filesInDictionary[result];
				}
				else
				{
					System.Console.WriteLine(" -> Wrong input");
				}
			}
			while (trycount <= 5);

			throw new MissingFileParameterException("No matching file found.");
		}
	}
}
