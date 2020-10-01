public class RevolutRecord : IRevolutRecord
{
	public string DateStartedUtc { get; set; }
	public string TimeStartedUtc { get; set; }
	public string DateCompletedUtc { get; set; }
	public string TimeCompletedUtc { get; set; }
	public string State { get; set; }
	public string Type { get; set; }
	public string Description { get; set; }
	public string Reference { get; set; }
	public string Payer { get; set; }
	public string CardName { get; set; }
	public string CardNumber { get; set; }
	public string OrigCurrency { get; set; }
	public string OrigAmount { get; set; }
	public string PaymentCurrency { get; set; }
	public string Amount { get; set; }
	public string Fee { get; set; }
	public string Balance { get; set; }
	public string Account { get; set; }
	public string BeneficiaryAccountNumber { get; set; }
	public string BeneficiarySortCodeOrRoutingNumber { get; set; }
	public string BeneficiaryIban { get; set; }
	public string BeneficiaryBic { get; set; }
}