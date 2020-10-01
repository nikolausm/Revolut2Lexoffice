using CsvHelper.Configuration;

public class RevolutMap : ClassMap<RevolutRecord>
{
	public RevolutMap()
	{
		Map(m => m.Account).Name("Account");
		Map(m => m.Amount).Name("Amount");
		Map(m => m.Balance).Name("Balance");
		Map(m => m.BeneficiaryAccountNumber).Name("Beneficiary account number");
		Map(m => m.BeneficiaryBic).Name("Beneficiary BIC");
		Map(m => m.BeneficiaryIban).Name("Beneficiary IBAN");
		Map(m => m.BeneficiarySortCodeOrRoutingNumber).Name("Beneficiary sort code or routing number");
		Map(m => m.CardName).Name("Card name");
		Map(m => m.CardNumber).Name("Card number");
		Map(m => m.DateCompletedUtc).Name("Date completed (UTC)");
		Map(m => m.DateStartedUtc).Name("Date started (UTC)");
		Map(m => m.Description).Name("Description");
		Map(m => m.Fee).Name("Fee");
		Map(m => m.OrigAmount).Name("Orig amount");
		Map(m => m.OrigCurrency).Name("Orig currency");
		Map(m => m.Payer).Name("Payer");
		Map(m => m.PaymentCurrency).Name("Payment currency");
		Map(m => m.Reference).Name("Reference");
		Map(m => m.State).Name("State");
		Map(m => m.TimeCompletedUtc).Name("Time completed (UTC)");
		Map(m => m.TimeStartedUtc).Name("Time started (UTC)");
		Map(m => m.Type).Name("Type");
	}
}