using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Revolut2LexOffice
{
	internal class Empfaenger : ITarget
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
			switch (_record.Type.ToUpper())
			{
				case "CARD_REFUND":
				case "TOPUP":
					{
						yield return new Field(_settings.Owner);
						yield return new Field("IBAN", _settings.IBAN);
						yield return new Field("BIC", _settings.BIC);
					}
					break;

				case "TRANSFER":
					yield return new Field(
						_record.Description.Substring("An ".Length)
					);
					break;
				case "FEE":
					{
						yield return new Field("Revolut Business");
					}
					break;
				case "CARD_PAYMENT":
				default:
					{
						yield return new Field(_record.Description);
					}
					break;
			}

			yield return new Field("Account Number", _record.BeneficiaryAccountNumber);
			yield return new Field("IBAN", _record.BeneficiaryIban);
			yield return new Field("BIC", _record.BeneficiaryBic);
			yield return new Field("Code/Number", _record.BeneficiarySortCodeOrRoutingNumber);
		}
	}
}