using System;
using System.Linq;

namespace Domain
{
	public class LexOfficeCsvLine
	{
		private readonly ILexOfficeRecord _lexOfficeRecord;
		private readonly char _separator;
		private readonly string _quotationMark;

		public LexOfficeCsvLine(ILexOfficeRecord lexOfficeRecord, char separator = ',', string quotations = "\"")
		{
			_lexOfficeRecord = lexOfficeRecord;
			_separator = separator;
			_quotationMark = quotations;
		}

		public override string ToString()
		{
			return String.Join(
				_separator,
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
					.Select(e => e.Replace(_quotationMark, _quotationMark + _quotationMark))
					.Select(e => _quotationMark + e + _quotationMark)
			);
		}
	}
}
