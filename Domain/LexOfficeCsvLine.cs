using System;
using System.Linq;

namespace Domain
{
	public class LexOfficeCsvLine
	{
		private readonly ILexOfficeRecord _lexOfficeRecord;
		private readonly char separator;
		private readonly string quotationMark;

		public LexOfficeCsvLine(ILexOfficeRecord lexOfficeRecord, char separator = ',', string quotations = "\"")
		{
			_lexOfficeRecord = lexOfficeRecord;
			this.separator = separator;
			this.quotationMark = quotations;
		}

		public override string ToString()
		{
			return String.Join(
				separator,
				new[]
				{
					_lexOfficeRecord.WertStellungsDatum,
					_lexOfficeRecord.BuchungsDatum,
					_lexOfficeRecord.Auftraggeber,
					_lexOfficeRecord.Empfaenger,
					_lexOfficeRecord.Verwendungszweck,
					_lexOfficeRecord.Betrag,
					_lexOfficeRecord.ZusatzInfo
				}.ToList()
					.Select(e => e.Replace(quotationMark, quotationMark + quotationMark))
					.Select(e => quotationMark + e + quotationMark)
			);
		}
	}
}
