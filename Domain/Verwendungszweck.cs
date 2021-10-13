using System;
using System.Collections.Generic;

namespace Revolut2LexOffice
{
	internal sealed class Verwendungszweck : ITarget
	{
		private readonly IRevolutRecord record;

		public Verwendungszweck(IRevolutRecord record)
		{
			this.record = record;
		}

		public IEnumerable<IField> Fields()
		{

			switch (record.Type.ToUpper())
			{
				case "FEE":
					yield return new Field(
						record.Description
					);
					break;
				default:
					yield return new Field(
						String.IsNullOrWhiteSpace(record.Reference)
							? "n/a"
							: record.Reference
					);
					break;
			}
		}
	}
}