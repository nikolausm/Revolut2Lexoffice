using System;
using System.Collections.Generic;
using System.Linq;

namespace Revolut2LexOffice
{
	internal class Auftraggeber : ITarget
	{
		public readonly IReadOnlyList<string> FromIdentifier = new List<string> { "From ", "Refund from ", "Payment from ", "Zahlung von ", "Gutschrift von " };

		private IRevolutRecord record;

		public Auftraggeber(IRevolutRecord record)
		{
			this.record = record;
		}

		public IEnumerable<IField> Fields()
		{
			string description = record.Description;

			if (FromIdentifier.Any(identifer => description.StartsWith(identifer)))
			{
				return new List<IField>{
					new Field(
						description.Substring(
							FromIdentifier.First(identifer => description.StartsWith(identifer)).Length
						)
					)
				};
			}

			if (String.IsNullOrWhiteSpace(record.Payer))
			{
				return new List<IField>{
					new Field("Revolut")
				};
			}

			return new List<IField>{
				new Field(record.Payer)
			};
		}
	}
}