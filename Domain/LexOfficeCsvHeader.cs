using System;
namespace Domain
{
	public class LexOfficeCsvHeader
	{
		private readonly char _separator;

		public LexOfficeCsvHeader(char separator = ',')
		{
			_separator = separator;
		}

		public override string ToString() => String.Join(
			_separator,
			new[] {
				"WertStellungsDatum",
				"BuchungsDatum",
				"Auftraggeber",
				"Empfaenger",
				"Verwendungszweck",
				"Betrag",
				"ZusatzInfo"
			}
		);
	}
}
