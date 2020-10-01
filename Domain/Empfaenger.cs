using System;
using System.Collections.Generic;
using System.Linq;

namespace Revolut2LexOffice
{
	internal class Empfaenger: ITarget
	{
		private readonly ISettings _settings;
		private readonly IRevolutRecord _record;

		public Empfaenger(ISettings settings, IRevolutRecord record)
		{
			_settings = settings ?? throw new ArgumentNullException(nameof(settings));
			_record = record ?? throw new ArgumentNullException(nameof(record));
		}

		public IEnumerable<IField> Fields()
		{
			var fields = new List<Field>();
			if (_record.Description.StartsWith("To ")){
				fields.Add(new Field(_record.Description.Substring("To ".Length)));
			}

			if (_record.Description.StartsWith("Payment from ")){
				fields.Add(new Field(_settings.Owner));
				fields.Add(new Field("IBAN", _settings.IBAN));
				fields.Add(new Field("BIC", _settings.BIC));
			}

			if (_record.Type == "Fee"){
				return new List<IField>
				{
					new Field("Revolut Business")
				};
			}

			if (String.IsNullOrWhiteSpace(_record.BeneficiaryAccountNumber)
				&& String.IsNullOrWhiteSpace(_record.BeneficiaryIban)
				&& String.IsNullOrWhiteSpace(_record.BeneficiaryBic)
				&& !String.IsNullOrWhiteSpace(_record.Description)
				&& !_record.Description?.StartsWith("To ") == true
				&& !_record.Description?.StartsWith("Payment from ") == true
				&& String.IsNullOrWhiteSpace(_record.BeneficiarySortCodeOrRoutingNumber)
			)
			{
				
				fields.Add(new Field(_record.Description));
				return fields;
			}

			return fields.Union(
				new List<Field>
				{
					new Field("Account Number", _record.BeneficiaryAccountNumber),
					new Field("IBAN", _record.BeneficiaryIban),
					new Field("BIC", _record.BeneficiaryBic),
					new Field("Code/Number", _record.BeneficiarySortCodeOrRoutingNumber),
				}
			);
		}
	}
}