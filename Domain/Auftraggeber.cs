using System;
using System.Collections.Generic;

namespace Revolut2LexOffice
{
	internal class Auftraggeber : ITarget
	{
		public const string PaymentIdentifier = "Payment from ";
		public const string FromIdentifier = "From ";

		private IRevolutRecord record;

		public Auftraggeber(IRevolutRecord record)
		{
			this.record = record;
		}

		public IEnumerable<IField> Fields()
		{
			string description = record.Description;
			if(description.StartsWith(PaymentIdentifier))
			{
				return new List<IField>{
					new Field(description.Substring(PaymentIdentifier.Length))
				};
			}

			if(description.StartsWith(FromIdentifier))
			{
				return new List<IField>{
					new Field(description.Substring(FromIdentifier.Length))
				};
			}

			if(String.IsNullOrWhiteSpace(record.Payer))
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