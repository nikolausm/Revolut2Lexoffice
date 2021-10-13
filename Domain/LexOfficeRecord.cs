using System;

public struct LexOfficeRecord : ILexOfficeRecord
{
	public LexOfficeRecord(
		string wertStellungsDatum,
		string buchungsDatum,
		string auftraggeber,
		string empfaenger,
		string? auftraggeberEmpfaenger,
		string verwendungszweck,
		string betrag,
		string? sollBetragAusgabe,
		string? habenBetragEinnahme,
		string zusatzInfo
	)
	{
		WertStellungsDatum = wertStellungsDatum;
		BuchungsDatum = buchungsDatum;
		Auftraggeber = auftraggeber;
		Empfaenger = empfaenger;
		AuftraggeberEmpfaenger = auftraggeberEmpfaenger;
		Verwendungszweck = verwendungszweck;
		Betrag = betrag;
		SollBetragAusgabe = sollBetragAusgabe;
		HabenBetragEinnahme = habenBetragEinnahme;
		ZusatzInfo = zusatzInfo;
	}

	public string WertStellungsDatum { get; }
	public string BuchungsDatum { get; }
	public string Auftraggeber { get; }
	public string Empfaenger { get; }
	public string? AuftraggeberEmpfaenger { get; }
	public string Verwendungszweck { get; }
	public string Betrag { get; }
	public string? SollBetragAusgabe { get; }
	public string? HabenBetragEinnahme { get; }
	public string ZusatzInfo { get; }
}