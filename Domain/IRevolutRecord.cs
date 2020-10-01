public interface IRevolutRecord
{
	string DateStartedUtc { get; set; }
	string TimeStartedUtc { get; set; }
	string DateCompletedUtc { get; set; }
	string TimeCompletedUtc { get; set; }
	string State { get; set; }
	string Type { get; set; }
	string Description { get; set; }
	string Reference { get; set; }
	string Payer { get; set; }
	string CardName { get; set; }
	string CardNumber { get; set; }
	string OrigCurrency { get; set; }
	string OrigAmount { get; set; }
	string PaymentCurrency { get; set; }
	string Amount { get; set; }
	string Fee { get; set; }
	string Balance { get; set; }
	string Account { get; set; }
	string BeneficiaryAccountNumber { get; set; }
	string BeneficiarySortCodeOrRoutingNumber { get; set; }
	string BeneficiaryIban { get; set; }
	string BeneficiaryBic { get; set; }
}
