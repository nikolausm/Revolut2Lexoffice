using System;
using System.Collections.Generic;
using System.Text;

namespace Console.Extensions
{
	public static class StringExtensions
	{
		public static string Append(this string self, string value)
		=> self + value;
	}
}
