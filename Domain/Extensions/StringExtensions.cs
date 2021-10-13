using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Extensions
{
	public static class StringExtensions
	{
		public static string With(this string self, string value)
		=> self + value;

		public static string RemovePrefix(
			this string self, 
			IEnumerable<string> prefixes
		)
		=> self.Substring(
			prefixes.Where(
				prefix => self.StartsWith(prefix)
			).FirstOrDefault()?.Length ?? 0
		);
	}
}
