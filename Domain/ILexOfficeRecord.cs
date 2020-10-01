public interface ILexOfficeRecord
{
	string WertStellungsDatum { get; }
	string BuchungsDatum { get; }
	string Auftraggeber { get; }
	string Empfaenger { get; }
	string AuftraggeberEmpfaenger { get; }
	string Verwendungszweck { get; }
	string Betrag { get; }
	string SollBetragAusgabe { get; }
	string HabenBetragEinnahme { get; }
	string ZusatzInfo { get; }
}
