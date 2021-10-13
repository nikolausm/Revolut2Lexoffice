using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console.Extensions.Configuration
{
	public static class ConfigurationSectionExtension
	{
		public static T Get<T>(this IConfigurationSection self)
		=> JsonConvert.DeserializeObject<T>(self.Value);
	}
}
